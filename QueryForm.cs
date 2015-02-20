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
	using System.Drawing;
	using System.Windows.Forms;
	using System.Collections.Generic;
	using System.Text;
	using System.Runtime.InteropServices;
	
	/// <summary>
	/// Description of QueryForm.
	/// </summary>
	public partial class QueryForm : Form
	{
		public QueryForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		/// <summary>
		/// Update data onto the comboBox controls cbSelAlgn, cbSelExSurf and cbSelPrSurf
		/// </summary>
		public void UpdateData()
		{
			// Get list of alignments in drawing
			cbSelAlgn.Items.AddRange(CivApp.GetAlignmentList().ToArray() as Object[]);
			cbSelExSurf.Items.AddRange(CivApp.GetSurfaceList().ToArray() as Object[]);
			cbSelPrSurf.Items.AddRange(CivApp.GetSurfaceList().ToArray() as Object[]);
			if (cbSelAlgn.Items.Count == 0
			   || cbSelExSurf.Items.Count == 0
			   || cbSelPrSurf.Items.Count == 0) {
				cbSelAlgn.Enabled = false;
				cbSelExSurf.Enabled = false;
				cbSelPrSurf.Enabled = false;
				btSolut.Enabled = false;
				btSelAlgn.Enabled = false;
				btSelExSurf.Enabled = false;
				btSelPrSurf.Enabled = false;
			} else {
				cbSelAlgn.Text = (string)cbSelAlgn.Items[0];
				cbSelExSurf.Text = (string)cbSelExSurf.Items[0];
				cbSelPrSurf.Text = (string)cbSelPrSurf.Items[0];
			}
		}

		/// <summary>
		/// Check state of controll: cbSelExSurf, cbSelPrSurf, cbSelAlgn,
		/// tbStartPKUse, tbEndPKUse, tbMinWidth, tbMaxWidth, tbStep, tbHeightVyr
		/// </summary>
		/// <returns>if all their data valid return true, else return false</returns>
		private Boolean CheckInputDataState()
		{
			var IsDataValid = true;
			//Check cbSelExSurf, cbSelPrSurf, cbSelAlgn
			//they can contain only "" or valid data
			if (cbSelAlgn.Text == "" || cbSelPrSurf.Text == "" || cbSelAlgn.Text == "") {
				IsDataValid = false;
			}
			//Check tbStartPKUse, tbEndPKUse
			//they can contain "", valid date, and invalid data
			if (tbStartPKUse.Text == "" || tbEndPKUse.Text == "") {
				IsDataValid = false;
			} else {
				var start = 0.0d;
				var end = 0.0d;
				var parseResult1 = Double.TryParse(tbStartPKUse.Text, out start);
				var parseResult2 = Double.TryParse(tbEndPKUse.Text, out end);
				if (!parseResult1 || !parseResult2) {
					IsDataValid = false;
				} else {
					var startAl = Double.Parse(tbStartPKUse.Text);
					var endAl = Double.Parse(tbEndPKUse.Text);
					if (start < startAl || start >= end || end > endAl) {
						IsDataValid = false;
					}
				}
			}
			return IsDataValid;
		}

		/// <summary>
		/// Filtrate any non digit and decimal point characters
		/// </summary>
		/// <param name="sender">Controll which send events</param>
		/// <param name="e">Event arguments</param>
		/// <returns>True if pressed digital character or decimal point character 
		/// (not first character), otherwise false </returns>
		private Boolean FiltrateNonDoublePositiveNumbers(object sender, KeyPressEventArgs e)
		{
			//Filtr any non digit and decimal point characters 
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') {
				return true;
			}
			//Only allow one decimal point and not first character
			if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1
				                 && (sender as TextBox).Text.IndexOf('.') != 0) {
				return true;
			}
			return false;
		}


		void CbSelAlgnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbSelAlgn.SelectedItem != null) {
				//If into the drawing exists alignment enable controlls
				gbAlgn.Enabled = true;
				gbSect.Enabled = true;
				gbRaschUch.Enabled = true;
				var alignName = cbSelAlgn.SelectedItem as string;
				var startPK = 0.0d;
				var endPK = 0.0d;
				var length = 0.0d;
				CivApp.GetAlignmentData(alignName, out startPK, out endPK, out length);
				tbStartPK.Text = startPK.ToString();
				tbEndPK.Text = endPK.ToString();
				lbAlgnName.Text = alignName;
				lbAlgnLength.Text = length.ToString();
			}else {
				gbAlgn.Enabled = false;
				gbSect.Enabled = false;
			}
		}

		void TbMinWidthKeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = FiltrateNonDoublePositiveNumbers(sender, e);
		}

		void TbMaxWidthKeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = FiltrateNonDoublePositiveNumbers(sender, e);
		}

		void TbStepKeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = FiltrateNonDoublePositiveNumbers(sender, e);
		}

		void TbHeightVyrKeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = FiltrateNonDoublePositiveNumbers(sender, e);
		}

		void TbStartPKUseKeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = FiltrateNonDoublePositiveNumbers(sender, e);
		}

		void TbEndPKUseKeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = FiltrateNonDoublePositiveNumbers(sender, e);
		}

		void BtSolutClick(object sender, EventArgs e)
		{
			//Validating data onto controlls
			if (!CheckInputDataState()) {
				MessageBox.Show("Проверьте правильность введенных данных");
				return;
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
