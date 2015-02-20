/*
 * Created by SharpDevelop.
 * User: bad-1
 * Date: 22.03.2012
 * Time: 15:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Surf2Excel
{
	partial class QueryForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbSelExSurf = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btSelExSurf = new System.Windows.Forms.Button();
			this.btSelPrSurf = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cbSelPrSurf = new System.Windows.Forms.ComboBox();
			this.btSelAlgn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbSelAlgn = new System.Windows.Forms.ComboBox();
			this.btSolut = new System.Windows.Forms.Button();
			this.gbAlgn = new System.Windows.Forms.GroupBox();
			this.lbAlgnName = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbEndPK = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbStartPK = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.lbAlgnLength = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gbSect = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbStep = new System.Windows.Forms.TextBox();
			this.tbHeightVyr = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbMaxWidth = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbMinWidth = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.gbRaschUch = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.tbEndPKUse = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.tbStartPKUse = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.pgFlow = new System.Windows.Forms.ProgressBar();
			this.gbAlgn.SuspendLayout();
			this.gbSect.SuspendLayout();
			this.gbRaschUch.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbSelExSurf
			// 
			this.cbSelExSurf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSelExSurf.FormattingEnabled = true;
			this.cbSelExSurf.Location = new System.Drawing.Point(230, 12);
			this.cbSelExSurf.Name = "cbSelExSurf";
			this.cbSelExSurf.Size = new System.Drawing.Size(204, 21);
			this.cbSelExSurf.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(212, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Существующая поверхность:";
			// 
			// btSelExSurf
			// 
			this.btSelExSurf.Location = new System.Drawing.Point(440, 10);
			this.btSelExSurf.Name = "btSelExSurf";
			this.btSelExSurf.Size = new System.Drawing.Size(65, 23);
			this.btSelExSurf.TabIndex = 2;
			this.btSelExSurf.Text = "указать";
			this.btSelExSurf.UseVisualStyleBackColor = true;
			// 
			// btSelPrSurf
			// 
			this.btSelPrSurf.Location = new System.Drawing.Point(440, 37);
			this.btSelPrSurf.Name = "btSelPrSurf";
			this.btSelPrSurf.Size = new System.Drawing.Size(65, 23);
			this.btSelPrSurf.TabIndex = 5;
			this.btSelPrSurf.Text = "указать";
			this.btSelPrSurf.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(212, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Проектная поверхность:";
			// 
			// cbSelPrSurf
			// 
			this.cbSelPrSurf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSelPrSurf.FormattingEnabled = true;
			this.cbSelPrSurf.Location = new System.Drawing.Point(230, 39);
			this.cbSelPrSurf.Name = "cbSelPrSurf";
			this.cbSelPrSurf.Size = new System.Drawing.Size(204, 21);
			this.cbSelPrSurf.TabIndex = 4;
			// 
			// btSelAlgn
			// 
			this.btSelAlgn.Location = new System.Drawing.Point(440, 64);
			this.btSelAlgn.Name = "btSelAlgn";
			this.btSelAlgn.Size = new System.Drawing.Size(65, 23);
			this.btSelAlgn.TabIndex = 8;
			this.btSelAlgn.Text = "указать";
			this.btSelAlgn.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(212, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Ось трассы:";
			// 
			// cbSelAlgn
			// 
			this.cbSelAlgn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSelAlgn.FormattingEnabled = true;
			this.cbSelAlgn.Location = new System.Drawing.Point(230, 66);
			this.cbSelAlgn.Name = "cbSelAlgn";
			this.cbSelAlgn.Size = new System.Drawing.Size(204, 21);
			this.cbSelAlgn.TabIndex = 7;
			this.cbSelAlgn.SelectedIndexChanged += new System.EventHandler(this.CbSelAlgnSelectedIndexChanged);
			// 
			// btSolut
			// 
			this.btSolut.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btSolut.Location = new System.Drawing.Point(263, 266);
			this.btSolut.Name = "btSolut";
			this.btSolut.Size = new System.Drawing.Size(146, 32);
			this.btSolut.TabIndex = 12;
			this.btSolut.Text = "Вычислить";
			this.btSolut.UseVisualStyleBackColor = true;
			this.btSolut.Click += new System.EventHandler(this.BtSolutClick);
			// 
			// gbAlgn
			// 
			this.gbAlgn.Controls.Add(this.lbAlgnName);
			this.gbAlgn.Controls.Add(this.label14);
			this.gbAlgn.Controls.Add(this.label9);
			this.gbAlgn.Controls.Add(this.label10);
			this.gbAlgn.Controls.Add(this.tbEndPK);
			this.gbAlgn.Controls.Add(this.label6);
			this.gbAlgn.Controls.Add(this.tbStartPK);
			this.gbAlgn.Controls.Add(this.label5);
			this.gbAlgn.Controls.Add(this.lbAlgnLength);
			this.gbAlgn.Controls.Add(this.label4);
			this.gbAlgn.Enabled = false;
			this.gbAlgn.Location = new System.Drawing.Point(12, 93);
			this.gbAlgn.Name = "gbAlgn";
			this.gbAlgn.Size = new System.Drawing.Size(245, 123);
			this.gbAlgn.TabIndex = 9;
			this.gbAlgn.TabStop = false;
			this.gbAlgn.Text = "Данные по трассе";
			// 
			// lbAlgnName
			// 
			this.lbAlgnName.Location = new System.Drawing.Point(112, 16);
			this.lbAlgnName.Name = "lbAlgnName";
			this.lbAlgnName.Size = new System.Drawing.Size(121, 23);
			this.lbAlgnName.TabIndex = 1;
			this.lbAlgnName.Text = "не выбрана трасса";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(6, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 23);
			this.label14.TabIndex = 0;
			this.label14.Text = "Наименование: ";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(218, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(25, 23);
			this.label9.TabIndex = 9;
			this.label9.Text = "м";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(218, 69);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(25, 23);
			this.label10.TabIndex = 8;
			this.label10.Text = "м";
			// 
			// tbEndPK
			// 
			this.tbEndPK.Location = new System.Drawing.Point(112, 93);
			this.tbEndPK.MaxLength = 12;
			this.tbEndPK.Name = "tbEndPK";
			this.tbEndPK.ReadOnly = true;
			this.tbEndPK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbEndPK.Size = new System.Drawing.Size(100, 20);
			this.tbEndPK.TabIndex = 7;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 6;
			this.label6.Text = "Конечный пикет:";
			// 
			// tbStartPK
			// 
			this.tbStartPK.Location = new System.Drawing.Point(112, 66);
			this.tbStartPK.MaxLength = 12;
			this.tbStartPK.Name = "tbStartPK";
			this.tbStartPK.ReadOnly = true;
			this.tbStartPK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbStartPK.Size = new System.Drawing.Size(100, 20);
			this.tbStartPK.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Начальный пикет:";
			// 
			// lbAlgnLength
			// 
			this.lbAlgnLength.Location = new System.Drawing.Point(112, 39);
			this.lbAlgnLength.Name = "lbAlgnLength";
			this.lbAlgnLength.Size = new System.Drawing.Size(121, 23);
			this.lbAlgnLength.TabIndex = 3;
			this.lbAlgnLength.Text = "не выбрана трасса";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "Протяженность: ";
			// 
			// gbSect
			// 
			this.gbSect.Controls.Add(this.label11);
			this.gbSect.Controls.Add(this.label8);
			this.gbSect.Controls.Add(this.tbStep);
			this.gbSect.Controls.Add(this.tbHeightVyr);
			this.gbSect.Controls.Add(this.label7);
			this.gbSect.Controls.Add(this.label12);
			this.gbSect.Controls.Add(this.label17);
			this.gbSect.Controls.Add(this.label13);
			this.gbSect.Controls.Add(this.tbMaxWidth);
			this.gbSect.Controls.Add(this.label15);
			this.gbSect.Controls.Add(this.tbMinWidth);
			this.gbSect.Controls.Add(this.label16);
			this.gbSect.Enabled = false;
			this.gbSect.Location = new System.Drawing.Point(263, 93);
			this.gbSect.Name = "gbSect";
			this.gbSect.Size = new System.Drawing.Size(245, 123);
			this.gbSect.TabIndex = 10;
			this.gbSect.TabStop = false;
			this.gbSect.Text = "Данные по поперечнику";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(217, 96);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(25, 23);
			this.label11.TabIndex = 11;
			this.label11.Text = "м";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(217, 69);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(25, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "м";
			// 
			// tbStep
			// 
			this.tbStep.Location = new System.Drawing.Point(152, 66);
			this.tbStep.MaxLength = 8;
			this.tbStep.Name = "tbStep";
			this.tbStep.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbStep.Size = new System.Drawing.Size(59, 20);
			this.tbStep.TabIndex = 5;
			this.tbStep.Text = "10.0";
			this.tbStep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbStepKeyPress);
			// 
			// tbHeightVyr
			// 
			this.tbHeightVyr.Location = new System.Drawing.Point(152, 93);
			this.tbHeightVyr.MaxLength = 8;
			this.tbHeightVyr.Name = "tbHeightVyr";
			this.tbHeightVyr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbHeightVyr.Size = new System.Drawing.Size(59, 20);
			this.tbHeightVyr.TabIndex = 7;
			this.tbHeightVyr.Text = "0.05";
			this.tbHeightVyr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbHeightVyrKeyPress);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(5, 69);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(141, 23);
			this.label7.TabIndex = 4;
			this.label7.Text = "Шаг поперечников:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(217, 42);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(25, 23);
			this.label12.TabIndex = 7;
			this.label12.Text = "м";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(5, 96);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(141, 23);
			this.label17.TabIndex = 6;
			this.label17.Text = "Толщина выравнивания:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(217, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(25, 23);
			this.label13.TabIndex = 6;
			this.label13.Text = "м";
			// 
			// tbMaxWidth
			// 
			this.tbMaxWidth.Location = new System.Drawing.Point(152, 39);
			this.tbMaxWidth.MaxLength = 8;
			this.tbMaxWidth.Name = "tbMaxWidth";
			this.tbMaxWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbMaxWidth.Size = new System.Drawing.Size(59, 20);
			this.tbMaxWidth.TabIndex = 3;
			this.tbMaxWidth.Text = "10.0";
			this.tbMaxWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbMaxWidthKeyPress);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(5, 42);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(141, 20);
			this.label15.TabIndex = 2;
			this.label15.Text = "Макс ширина не более:";
			// 
			// tbMinWidth
			// 
			this.tbMinWidth.Location = new System.Drawing.Point(152, 13);
			this.tbMinWidth.MaxLength = 8;
			this.tbMinWidth.Name = "tbMinWidth";
			this.tbMinWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbMinWidth.Size = new System.Drawing.Size(59, 20);
			this.tbMinWidth.TabIndex = 1;
			this.tbMinWidth.Text = "2.0";
			this.tbMinWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbMinWidthKeyPress);
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(5, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(141, 23);
			this.label16.TabIndex = 0;
			this.label16.Text = "Мин ширина не менее:";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(415, 266);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 32);
			this.button1.TabIndex = 13;
			this.button1.Text = "Отмена";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// gbRaschUch
			// 
			this.gbRaschUch.Controls.Add(this.label18);
			this.gbRaschUch.Controls.Add(this.label19);
			this.gbRaschUch.Controls.Add(this.tbEndPKUse);
			this.gbRaschUch.Controls.Add(this.label20);
			this.gbRaschUch.Controls.Add(this.tbStartPKUse);
			this.gbRaschUch.Controls.Add(this.label21);
			this.gbRaschUch.Enabled = false;
			this.gbRaschUch.Location = new System.Drawing.Point(12, 226);
			this.gbRaschUch.Name = "gbRaschUch";
			this.gbRaschUch.Size = new System.Drawing.Size(245, 72);
			this.gbRaschUch.TabIndex = 11;
			this.gbRaschUch.TabStop = false;
			this.gbRaschUch.Text = "Расчетный участок";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(218, 48);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(25, 23);
			this.label18.TabIndex = 5;
			this.label18.Text = "м";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(218, 22);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(25, 23);
			this.label19.TabIndex = 4;
			this.label19.Text = "м";
			// 
			// tbEndPKUse
			// 
			this.tbEndPKUse.Location = new System.Drawing.Point(112, 45);
			this.tbEndPKUse.MaxLength = 12;
			this.tbEndPKUse.Name = "tbEndPKUse";
			this.tbEndPKUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbEndPKUse.Size = new System.Drawing.Size(100, 20);
			this.tbEndPKUse.TabIndex = 3;
			this.tbEndPKUse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbEndPKUseKeyPress);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(6, 48);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 23);
			this.label20.TabIndex = 2;
			this.label20.Text = "Конечный пикет:";
			// 
			// tbStartPKUse
			// 
			this.tbStartPKUse.Location = new System.Drawing.Point(112, 19);
			this.tbStartPKUse.MaxLength = 12;
			this.tbStartPKUse.Name = "tbStartPKUse";
			this.tbStartPKUse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbStartPKUse.Size = new System.Drawing.Size(100, 20);
			this.tbStartPKUse.TabIndex = 1;
			this.tbStartPKUse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbStartPKUseKeyPress);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(6, 22);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 23);
			this.label21.TabIndex = 0;
			this.label21.Text = "Начальный пикет:";
			// 
			// pgFlow
			// 
			this.pgFlow.Enabled = false;
			this.pgFlow.Location = new System.Drawing.Point(263, 237);
			this.pgFlow.Name = "pgFlow";
			this.pgFlow.Size = new System.Drawing.Size(245, 23);
			this.pgFlow.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pgFlow.TabIndex = 14;
			// 
			// QueryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 310);
			this.Controls.Add(this.pgFlow);
			this.Controls.Add(this.gbRaschUch);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.gbSect);
			this.Controls.Add(this.gbAlgn);
			this.Controls.Add(this.btSolut);
			this.Controls.Add(this.btSelAlgn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbSelAlgn);
			this.Controls.Add(this.btSelPrSurf);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbSelPrSurf);
			this.Controls.Add(this.btSelExSurf);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbSelExSurf);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QueryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Surf2Excel. Расчет выравнивающего слоя";
			this.TopMost = true;
			this.gbAlgn.ResumeLayout(false);
			this.gbAlgn.PerformLayout();
			this.gbSect.ResumeLayout(false);
			this.gbSect.PerformLayout();
			this.gbRaschUch.ResumeLayout(false);
			this.gbRaschUch.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ProgressBar pgFlow;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbHeightVyr;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbStartPKUse;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbEndPKUse;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox gbRaschUch;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label lbAlgnName;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbMinWidth;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbMaxWidth;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox gbSect;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbStep;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbAlgnLength;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbStartPK;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbEndPK;
		private System.Windows.Forms.GroupBox gbAlgn;
		private System.Windows.Forms.Button btSolut;
		private System.Windows.Forms.ComboBox cbSelAlgn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btSelAlgn;
		private System.Windows.Forms.ComboBox cbSelPrSurf;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btSelPrSurf;
		private System.Windows.Forms.Button btSelExSurf;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbSelExSurf;
	}
}
