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
	using System.Text;
	using System.Runtime.InteropServices;
	
	using Autodesk.AutoCAD.Runtime;
	using Autodesk.AutoCAD.EditorInput;
	using Autodesk.AutoCAD.ApplicationServices;
	using Autodesk.Civil.Land.DatabaseServices;
	using Autodesk.Civil;
	using Autodesk.AutoCAD.DatabaseServices;

	/// <summary>
	/// Class contains command metod to invoke in autocad..
	/// </summary>
	public sealed class Commands : IExtensionApplication
	{
		#region IExtensionApplication Members
		public void Initialize()
		{
			CivApp.CivEd.WriteMessage("\nSurf2Excel успешно загружен.\nЗапуск командой Surf2ExcelCMD и Surf2ExcelGUI.\n");
		}
		public void Terminate()
		{
			CivApp.CivEd.WriteMessage("\nSurf2Excel terminated succesfuly.\n");
		}
		#endregion


		#region Commands to invoke in autocad
		/// <summary>
		/// Calculate points along the alignment onto the central line and
		/// borders of the surface
		/// </summary>
		[CommandMethod("SURF2EXCELCMD")]
		public void Surf2ExcelCMD()
		{
			//Ask user to select alignment from drawing
			String algnName;
			algnName = CivApp.PromptSelectAlignment("\nВыберите трассу: ", "\nОбъект должен быть трассой.\n");
			if (algnName == ""){
				return; //If nothing selected - exit without prompt
			}
			var stPK = 0.0d;
			var edPK = 0.0d;
			var leng = 0.0d;
			CivApp.GetAlignmentData(algnName, out stPK, out edPK, out leng);
			CivApp.CivEd.WriteMessage("Имя выбранной трассы: " + algnName + "\n");
			CivApp.CivEd.WriteMessage("Пикет начала трассы: " + stPK + " м\n");
			CivApp.CivEd.WriteMessage("Пикет  конца трассы: " + edPK + " м\n");
			CivApp.CivEd.WriteMessage("Общая  длина трассы: " + leng + " м\n");
			//Ask user to select TINSurface from drawing
			String surfName;
			surfName = CivApp.PromptSelectTINSurface("\nВыберите поверхность TIN: ", "\nОбъект должен быть поверхностью TIN.\n");
			if (surfName == ""){
				return; //If nothing selected - exit without prompt
			}
			CivApp.CivEd.WriteMessage("Имя выбранной поверхности: " + algnName + "\n");
			// Ask user to input a start station
			var startPK = CivApp.PromptEnterDouble("\nВведите начальный пикет [м]: ", stPK);
			if (startPK == -1.0d){
				return; //If nothing entered - exit without prompt
			}
			// Ask user to input a end station 
			var endPK = CivApp.PromptEnterDouble("\nВведите конечный пикет [м]: ", edPK);
			if (endPK == -1.0d){
				return; //If nothing entered - exit without prompt
			}
			// Ask user to input step of the computation. Default is 10.0 
			var stepPK = CivApp.PromptEnterDouble("\nВведите шаг вычислений [м]: ", 10.0d);
			if (stepPK == -1.0d){
				return; //If nothing entered - exit without prompt
			}
			// Ask user to input minimum width of the surface at sections. Default 0.0
			var minW = CivApp.PromptEnterDouble("\nВведите минимальную ширину поперечника [м]: ", 0.0d);
			if (minW == -1.0d){
				return; //If nothing entered - exit without prompt
			}
				// Ask user to input maximum width of the surface at sections. Default 10.0 
			var maxW = CivApp.PromptEnterDouble("\nВведите максимальную ширину поперечника [м]: ", 10.0d);
			if (maxW == -1.0d){
				return; //If nothing entered - exit without prompt
			}
			//Start calculiation. Store result onto variable result
			List<Surf2Excel.ResultData> result;
			result = Surf2Excel.CalculateSectionElevation(algnName, surfName, startPK, endPK, stepPK, minW, maxW);

			CivApp.CivEd.WriteMessage("\nОбработано поперечников: " + result.Count + "\n");
			CivApp.CivEd.WriteMessage("\nПередача данных в Excel:\n");
			
			//Create filename for the Creating excel file
			var fileName = CivApp.GetFileName() + ".xls";
			
			//Write data to the excel application
			var file = ExcApp.WriteDataToExcel(result, fileName);
			CivApp.CivEd.WriteMessage("\nСоздан файл: " + file + "\n");                        
		}


		/// <summary>
		/// Calculate volume of the filling layer and the cutting layer
		/// </summary>
		[CommandMethod("SURF2EXCELGUI")]
		public void Surf2ExcelGUI()
		{
			var fm1 = new QueryForm();
			fm1.UpdateData();
			fm1.Visible = true;
		}
		#endregion












	}
}