/*
 * Created by SharpDevelop.
 * User: Луферов Александр Николаевич
 * 
 * 
 * 
 * Лицензия GPL v2.0: http://www.gnu.org/licenses/gpl-2.0.html.
 */
using System;
using System.Collections.Generic;

namespace Surf2Excel
{
	/// <summary>
	/// Description of Surf2Excel.
	/// </summary>
	public sealed class Surf2Excel
	{
		private Surf2Excel()
		{

		}
		/// <summary>
		/// Precision is the step to calculate elevations from the sections
		/// </summary>
		private const Double PRECISION = 0.01d;

		
		/// <summary>
		/// Calculate points onto the given surface along given alignment
		/// </summary>
		/// <param name="algnName">Alignment name along which will process calculation</param>
		/// <param name="surfName">Surface name from which will get elevation and offset</param>
		/// <param name="startPK">A start station of the calculation along the alignment</param>
		/// <param name="endPK">An end station of the calculation along the alignment</param>
		/// <param name="stepPK">A step which used  to calculate data along alignment </param>
		/// <param name="minW">A distance less than distance from the central line of section to the border of surface</param>
		/// <param name="maxW">A distance more than distance from the central line of section to the border of surface</param>
		/// <returns> Return collection of the calculated data </returns>
		public static List<Surf2Excel.ResultData> CalculateSectionElevation(String algnName, String surfName,
		                                                   Double startPK, Double endPK, Double stepPK,
		                                                   Double minW, Double maxW)
		{
			var result = new List<ResultData>((int)((endPK-startPK)/stepPK) + 1);
			CivApp.SetCurAlignment(algnName);
			CivApp.SetCurSurfaceEx(surfName);
			for (Double curPK = startPK; curPK <= endPK; curPK += stepPK)
			{
				var elevatCentr = 0.0d;
				var elevatLeft = 0.0d;
				var elevatRight = 0.0d;
				var elevat_pr = 0.0d;

				var offsetLeft = 0.0d;
				var offsetRight = 0.0d;
				var offset_pr = 0.0d;
				
				// Get elevation at alignment -> offset = 0.0;
				// If point outside from the surface -> skip section;
				if (!CivApp.GetElevationAtPK(CivApp.GetCurAlignment(), CivApp.GetCurSurfaceEx(), curPK, 0.0d, out elevatCentr)){
					CivApp.CivEd.WriteMessage("\nERROR. ПК: "+ curPK + ". Не найдена поверхность. Пропуск поперечника.\n"); 
					elevatCentr = 0.0d;
					continue;
				}
				
				// Get elevation at left offset;
				// If point outside from the surface elevation set to 0.0d;
				for (Double offset = -minW; offset > -maxW; offset += -PRECISION) {
					if (CivApp.GetElevationAtPK(CivApp.GetCurAlignment(), CivApp.GetCurSurfaceEx(), curPK, offset, out elevatLeft)){
						elevat_pr = elevatLeft;
						offset_pr = offset;
					} else {
						// Return to previous step
						//When point is out of surface
						offsetLeft = offset_pr;
						elevatLeft = elevat_pr;
						break;
					}
				}// for left side
				// Reset to zero temp variables for the event when at the rigth
				// side point 
				elevat_pr = 0.0d;
				offset_pr = 0.0d;
				
				// Get elevation at right offset;
				// If point outside from the surface elevation set to 0.0d;
				for (Double offset = minW; offset < maxW; offset += PRECISION) {
					if (CivApp.GetElevationAtPK(CivApp.GetCurAlignment(), CivApp.GetCurSurfaceEx(), curPK, offset, out elevatRight)){
						elevat_pr = elevatRight;
						offset_pr = offset;
					} else {
						// Return to previous step
						// When point is out of surface
						offsetRight = offset_pr; 
						elevatRight = elevat_pr;
						break;
					}
				}// for rigth side
				
				result.Add(new ResultData(curPK, elevatCentr, offsetLeft, elevatLeft, 
					                          offsetRight, elevatRight));
			}// End for through the alignment
			return result;
		}
		
		
		/// <summary>
		/// Class for store result data to the method C
		/// alculateSectionElevation and CalculateSectionWorkElev
		/// </summary>
		public class ResultData
		{
			public ResultData(Double pk, Double centerElev, Double leftOffset, Double leftElev, 
			                  Double rightOffset, Double rightElev)
			{
				_PK = pk;
				_centrPt = new KeyValuePair<Double, Double>(0.0d, centerElev);
				_leftPt = new KeyValuePair<Double, Double>(leftOffset, leftElev);
				_rigthPt = new KeyValuePair<Double, Double>(rightOffset, rightElev);
			}

			public Double PK {
				get {
					return _PK;
				}
			}

			public KeyValuePair<Double,Double> LeftPt {
				get {
					return _leftPt;
				}
			}

			public KeyValuePair<Double,Double> RightPt {
				get {
					return _rigthPt;
				}
			}

			public KeyValuePair<Double,Double> CentrPt {
				get {
					return _centrPt;
				}
			}

			private Double _PK;
			private KeyValuePair<Double,Double> _leftPt;
			private KeyValuePair<Double,Double> _rigthPt;
			private KeyValuePair<Double,Double> _centrPt;
		}

	}
}
