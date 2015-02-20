/*
 * Created by SharpDevelop.
 * User: bad-1
 * Date: 27.03.2012
 * Time: 12:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Surf2Excel
{
	partial class SelectForm
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
			this.cbItem = new System.Windows.Forms.ComboBox();
			this.btOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbItem
			// 
			this.cbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbItem.FormattingEnabled = true;
			this.cbItem.Location = new System.Drawing.Point(12, 12);
			this.cbItem.Name = "cbItem";
			this.cbItem.Size = new System.Drawing.Size(194, 21);
			this.cbItem.TabIndex = 0;
			// 
			// btOK
			// 
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btOK.Location = new System.Drawing.Point(212, 10);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(98, 23);
			this.btOK.TabIndex = 1;
			this.btOK.Text = "ОК";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.BtOKClick);
			// 
			// SelectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 44);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.cbItem);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Выбор";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.ComboBox cbItem;
	}
}
