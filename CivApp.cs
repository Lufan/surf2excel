/*
 * Created by SharpDevelop.
 * User: Луферов Александр Николаевич
 * 
 * 
 * 
 * Лицензия GPL v2.0: http://www.gnu.org/licenses/gpl-2.0.html.
 */
namespace Surf2Excel
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Autodesk.AutoCAD.Runtime;
	using Autodesk.AutoCAD.EditorInput;
	using Autodesk.AutoCAD.ApplicationServices;
	using Autodesk.Civil.Land.DatabaseServices;
	using Autodesk.Civil;
	using Autodesk.AutoCAD.DatabaseServices;
	
	
	/// <summary>
	/// Implement interractions with Autodesk Civil3d application
	/// </summary>
	public sealed class CivApp
	{
		public static Autodesk.AutoCAD.EditorInput.Editor CivEd {
			get {
				return Application.DocumentManager.MdiActiveDocument.Editor;
			}
		}
		
		public static Autodesk.AutoCAD.DatabaseServices.Database CivDb {
			get {
				return HostApplicationServices.WorkingDatabase;
			}
		}
		
		public static Autodesk.Civil.ApplicationServices.CivilDocument CivDoc {
			get {
				return Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
			}
		}
		
		public static String PromptSelectAlignment(String message, String rejectMessage)
		{
			String algnName = "";
			try{
				using (var tr = StartTransaction()){
					var opt = new PromptEntityOptions(message);
					opt.SetRejectMessage(rejectMessage);
					opt.AddAllowedClass(typeof(Alignment), false);
					var ent = CivEd.GetEntity(opt);
					if (ent.Status == PromptStatus.OK){
						var alignId = ent.ObjectId;
						if (alignId == ObjectId.Null) {
							return "";
						}
						var curAlgn = tr.GetObject(alignId, OpenMode.ForRead) as Alignment;
						algnName = curAlgn.Name;
						return algnName; // All OK. Return alignment name
					} // If PromptStatus.OK
				}
			}catch(Autodesk.AutoCAD.Runtime.Exception ex){
				CivEd.WriteMessage("ERROR: ACivilApplication.PromptSelectAlignment()\n" + ex + "\n");
			}
			return ""; //There have been some errors
		}
		
		public static String PromptSelectTINSurface(String message, String rejectMessage)
		{
			String surfName = "";
			try{
				using (var tr = StartTransaction()){
					var opt = new PromptEntityOptions("\nВыберите поверхность TIN: ");
					opt.SetRejectMessage("\nОбъект должен быть поверхностью TIN.\n");
					opt.AddAllowedClass(typeof(TinSurface), false);
					opt.SetMessageAndKeywords("\nВыберите поверхность TIN [Список]: ", "Cc");
					var ent = CivEd.GetEntity(opt);
					if (ent.Status == PromptStatus.Keyword && (ent.StringResult == "с" || ent.StringResult == "С")){
						SelectForm fm = new SelectForm(SelectForm.SelectType.TinSurface);
						fm.Visible = true;
						surfName = fm.GetResult();
					}
					if (ent.Status == PromptStatus.OK){
						var tinsurfId = ent.ObjectId;
						if (tinsurfId == ObjectId.Null){
							return "";
						}
						var tinsurf = tinsurfId.GetObject(OpenMode.ForRead) as TinSurface;
						surfName = tinsurf.Name;
						return surfName; // All OK. Return surface name
					} // If PromptStatus.OK
				} // using
			}catch(Autodesk.AutoCAD.Runtime.Exception ex){
				CivEd.WriteMessage("ERROR: ACivilApplication.PromptSelectTINSurface()\n" + ex + "\n");
			}
			return ""; //There have been some errors
		}
		
		public static Double PromptEnterDouble(String message, Double defaultValue = 0.0d)
		{
			Double result = -1.0d;
			try{
				using (var tr = StartTransaction()){
					var optDist = new PromptDoubleOptions(message);
					optDist.UseDefaultValue = true;
					optDist.DefaultValue = defaultValue;
					optDist.AllowNone = false;
					optDist.AllowNegative = false;
					var valDist = CivEd.GetDouble(optDist);
					if (valDist.Status == PromptStatus.OK){
						result = valDist.Value;
						return result;
					}
				} // using
			}catch(Autodesk.AutoCAD.Runtime.Exception ex){
				CivEd.WriteMessage("ERROR: ACivilApplication.PromptEnterDouble()\n" + ex + "\n");
			}
			return -1.0d; //There have been some errors
		}


		/// <summary>
		/// Get list of alignments names from drawing
		/// </summary>
		/// <returns>Collection of the alignments names</returns>
		public static List<String> GetAlignmentList()
		{
			var algnList = new List<String>();
			using(var tr = StartTransaction()){
				try {
					var alignments = CivDoc.GetAlignmentIds();
					foreach (ObjectId aid in alignments) {
						var curAlgn = tr.GetObject(aid, OpenMode.ForRead) as Autodesk.Civil.Land.DatabaseServices.Alignment;
						algnList.Add(curAlgn.Name);
					}
				} catch (System.Exception ex) {
					CivEd.WriteMessage("ERROR: ACivilApplication.GetAlignmentList()\n" + ex + "\n");
				}
			}
			return algnList;
		}

		/// <summary>
		/// Get list of surfaces (only TIN) names from drawing
		/// </summary>
		/// <returns>Collection of the surfaces names</returns>
		public static List<string> GetSurfaceList()
		{
			var surfList = new List<string>();
			using(var tr = StartTransaction()){
				try {
					var surfaces = CivDoc.GetSurfaceIds();
					foreach (ObjectId sid in surfaces) {
						var curSurf = tr.GetObject(sid, OpenMode.ForRead) as Autodesk.Civil.Land.DatabaseServices.Surface;
						if (curSurf.GetType() == typeof(TinSurface)) {
							surfList.Add(curSurf.Name);
						}
					}
				} catch (System.Exception ex) {
					CivEd.WriteMessage("ERROR: ACivilApplication.GetSurfaceList()\n" + ex + "\n");
				}
			}// using
			return surfList;
		}

		/// <summary>
		/// Get elevation from %surfaceName% along %alignmentName% at pk and offset 
		/// </summary>
		/// <param name="alignmentName">Name of the alignment</param>
		/// <param name="surfaceName">Name of the surface</param>
		/// <param name="pk">PK position along alignment</param>
		/// <param name="offset">Offset distance from alignment</param>
		/// <param name="elevation">out parametr - elevation at this point</param>
		/// <returns>True if point onto surface, otherwise false</returns>
		public static Boolean GetElevationAtPK(Alignment align, TinSurface surf, Double pk, 
		                                Double offset, out Double elevation)
		{
			elevation = 0.0d;
			try {
				var east = 0.0d;
				var north = 0.0d;
				align.PointLocation(pk, offset, ref east, ref north);
				// Get elevation from surface at point
				elevation = surf.FindElevationAtXY(east, north);
			} catch (Autodesk.Civil.PointNotOnEntityException) {
				return false;
			}
			return true;
		}
		
		/// <summary>
		/// Method used to store into the variable curAlignment
		/// current alignment object
		/// </summary>
		/// <param name="name">Alignment name</param>
		public static void SetCurAlignment(String name)
		{
			curAlignment = GetAlignmentByName(name);
		}
		/// <summary>
		/// Method used to store into the variable curSurface
		/// current TinSurface object
		/// </summary>
		/// <param name="name"></param>
		public static void SetCurSurfaceEx(String name)
		{
			curSurface = GetTinSurfaceByName(name);
		}
		/// <summary>
		/// Method used to get from the variable curAlignment
		/// current alignment object
		/// </summary>
		/// <returns>Alignment object</returns>
		public static Alignment GetCurAlignment()
		{
			return curAlignment;
		}
		/// <summary>
		/// Method used to get from the variable curSurface
		/// current TinSurface object
		/// </summary>
		/// <returns>TinSurface object</returns>
		public static TinSurface GetCurSurfaceEx()
		{
			return curSurface;
		}
		
		/// <summary>
		/// Get alignment data 
		/// </summary>
		/// <param name="alignment">Name of the alignment</param>
		/// <param name="startPK">out parametr - starting station</param>
		/// <param name="endPK">out parametr - ending station</param>
		/// <param name="length">out parametr - length of the alignment</param>
		/// <returns>True if no errors, otherwise false</returns>
		public static Boolean GetAlignmentData(String alignment, out Double startPK, out Double endPK, 
		                                out Double length)
		{
			startPK = -1.0d;
			endPK = -1.0d;
			length = -1.0d;
			try {
				Alignment algn = GetAlignmentByName(alignment);
				startPK = algn.StartingStation;
				endPK = algn.EndingStation;
				length = algn.Length;
			} catch (System.Exception ex) {
				CivEd.WriteMessage("ERROR: ACivilApplication.GetAlignmentData()\n" + ex + "\n");
				return false;
			}
			return true;
		}
		
		/// <summary>
		/// Get name of the current drawing
		/// </summary>
		/// <returns>Current drawing's name</returns>
		public static String GetFileName()
		{
			var mdidoc = Application.DocumentManager.MdiActiveDocument;
			var hs = HostApplicationServices.Current;
			return hs.FindFile(mdidoc.Name,mdidoc.Database,FindFileHint.Default);
		}
		
		/// <summary>
		/// Get alignment from drawing by the given name
		/// </summary>
		/// <param name="name">Name of the alignment</param>
		/// <returns>Alignment</returns>
		private static Alignment GetAlignmentByName(String name)
		{
			Alignment curAlgn;
			using(var tr = StartTransaction()){
				try	{
					var alignments = CivDoc.GetAlignmentIds();
					foreach (ObjectId aid in alignments) {
						curAlgn = tr.GetObject(aid, OpenMode.ForRead) as Alignment;
						if (curAlgn.Name == name) {
							return curAlgn;
						}
					}
				} catch (System.Exception ex) {
					CivEd.WriteMessage("ERROR: ACivilApplication.GetAlignmentByName()\n" + ex + "\n");
				}
			}// using
			return null;
		}
		
		/// <summary>
		/// Get TinSurface from drawing by the given name
		/// </summary>
		/// <param name="name">Name of the surface</param>
		/// <returns>TinSurface</returns>
		private static TinSurface GetTinSurfaceByName(String name)
		{
			Autodesk.Civil.Land.DatabaseServices.Surface curSurf;
			using(var tr = StartTransaction()){
				try	{
					var surfaces = CivDoc.GetSurfaceIds();
					foreach (ObjectId sid in surfaces) {
						curSurf = tr.GetObject(sid, OpenMode.ForRead) as Autodesk.Civil.Land.
							                                             DatabaseServices.Surface;
						if (curSurf.GetType() == typeof(TinSurface) && curSurf.Name == name) {
							return curSurf as TinSurface;
						}
					}
				} catch (System.Exception ex) {
					CivEd.WriteMessage("ERROR: ACivilApplication.GetTinSurfaceByName()\n" + ex + "\n");
				}
			}// using
			return null;
		}
		
		/// <summary>
		/// Get transaction object
		/// </summary>
		/// <returns>Transaction object</returns>
		private static Autodesk.AutoCAD.DatabaseServices.Transaction StartTransaction()
		{
			return Application.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction();
		}
		
		private CivApp()
		{
		}
		
		/// <summary>
		/// To set and get this variable use method SetCurAlignment 
		/// and GetCurAlignment
		/// </summary>
		private static Alignment curAlignment;
		/// <summary>
		/// To set and get this variable use method SetCurSurfaceEx 
		/// and GetCurSurfaceEx
		/// </summary>
		private static TinSurface curSurface;
	}
}
