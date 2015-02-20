/*
 * Created by SharpDevelop.
 * User: bad-1
 * Date: 26.03.2012
 * Time: 10:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Surf2Excel
{
	/// <summary>
	/// Description of CExcelApplication.
	/// </summary>
	public sealed class ExcApp
	{
		/// <summary>
		/// Write array to the worksheet Excel
		/// </summary>
		/// <param name="rows">The required amount of row into the worksheet </param>
		/// <param name="columns">The required amount of columns into the worksheet </param>
		/// <param name="worksheet">The worksheet in which data will be written </param>
		/// <param name="data"> The data to be written on the worksheet </param>
		private static void WriteArray(int rows, int columns, Microsoft.Office.Interop.Excel.Worksheet worksheet, object[,] data)
		{ 
			var startCell = worksheet.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range; 
			var endCell = worksheet.Cells[rows*2, columns] as Microsoft.Office.Interop.Excel.Range; 
			var writeRange = worksheet.get_Range(startCell, endCell);
			writeRange.Value2 = data;
		}


		/// <summary>
		/// Create rectangular array of objects from ResultData collection
		/// </summary>
		/// <param name="res">Collection of the ResultData to convert </param>
		/// <returns> Return rectangular array of objects </returns>
		private static object[,] ResultToExcel(List<Surf2Excel.ResultData> res)
		{
			var data = new object[(res.Count+1)*2, 4+1];
			var count = 0;
			foreach (Surf2Excel.ResultData r in res){
				data[count,0] = r.PK;
				data[count,1] = r.LeftPt.Value;
				data[count,2] = r.CentrPt.Value;
				data[count,3] = r.RightPt.Value;
				data[count+1,0] = null;
				data[count+1,1] = r.LeftPt.Key;
				data[count+1,2] = r.CentrPt.Key;
				data[count+1,3] = r.RightPt.Key;
				count += 2;
			}
			return data;
		}
		
		/// <summary>
		/// Create instance of the Excel application and into write data 
		/// </summary>
		/// <param name="data">Collection of the ResultData to write </param>
		/// <returns> Return filename of the created file or the string with error description</returns>
		public static String WriteDataToExcel(List<Surf2Excel.ResultData> data, String fileName)
		{
			try{
				var xlApp = new Microsoft.Office.Interop.Excel.Application();
				xlApp.DisplayAlerts = false;

				var wbTemp = xlApp.Workbooks.Add(System.Reflection.Missing.Value); 
				var wsTemp = wbTemp.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet; 
				wsTemp.Name = "Surf2ExcelResult";

				WriteArray(data.Count, 4, wsTemp, ResultToExcel(data));

				xlApp.Visible = true;

				wbTemp.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet,
				              System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 
				              System.Reflection.Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
				              System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, 
				              System.Reflection.Missing.Value, System.Reflection.Missing.Value);

				return fileName;
			}catch (System.Exception ex){
				return ("ERROR: WriteResultToExcel -> " + ex.ToString());
			}
		}
		
		private ExcApp()
		{
		}
	}
}
