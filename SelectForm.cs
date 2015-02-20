/*
 * Created by SharpDevelop.
 * User: bad-1
 * Date: 27.03.2012
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Surf2Excel
{
	/// <summary>
	/// Description of SelectForm.
	/// </summary>
	public partial class SelectForm : Form
	{
		public enum SelectType {Alignment = 1, TinSurface = 2};
		public SelectForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public SelectForm(SelectType type) : this()
		{
			if (type.Equals(SelectType.TinSurface)){
				this.Text = "Выбор поверхности TIN: ";
			} else if (type.Equals(SelectType.Alignment)){
				this.Text = "Выбор трассы: ";
			}
		}
		
		public void AppendData(List<String> data)
		{
			if (data.Count > 0){
				cbItem.Items.AddRange(data.ToArray());
				cbItem.SelectedItem[0];
			} else {
				
			}
		}
		
		public String GetResult()
		{
			return cbItem.SelectedItem as String; 
		}
		
		void BtOKClick(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
