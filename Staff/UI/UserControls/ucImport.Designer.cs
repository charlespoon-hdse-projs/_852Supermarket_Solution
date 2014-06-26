/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 8:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP1_01
{
	partial class ucImport
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lsvPreview = new System.Windows.Forms.ListView();
			this.colBarcode = new System.Windows.Forms.ColumnHeader();
			this.colSubCategory = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.colQuantity = new System.Windows.Forms.ColumnHeader();
			this.colUnit = new System.Windows.Forms.ColumnHeader();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.lbltxt = new System.Windows.Forms.Label();
			this.btnImport = new System.Windows.Forms.Button();
			this.ofdCSVImport = new System.Windows.Forms.OpenFileDialog();
			this.bgwReadFile = new System.ComponentModel.BackgroundWorker();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lsvPreview);
			this.groupBox1.Location = new System.Drawing.Point(3, 33);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(740, 378);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Preview";
			// 
			// lsvPreview
			// 
			this.lsvPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colBarcode,
									this.colSubCategory,
									this.colDescription,
									this.colQuantity,
									this.colUnit});
			this.lsvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsvPreview.Location = new System.Drawing.Point(3, 16);
			this.lsvPreview.Name = "lsvPreview";
			this.lsvPreview.Size = new System.Drawing.Size(734, 359);
			this.lsvPreview.TabIndex = 1;
			this.lsvPreview.UseCompatibleStateImageBehavior = false;
			this.lsvPreview.View = System.Windows.Forms.View.Details;
			// 
			// colBarcode
			// 
			this.colBarcode.Text = "Barcode";
			this.colBarcode.Width = 84;
			// 
			// colSubCategory
			// 
			this.colSubCategory.Text = "Sub-Category";
			this.colSubCategory.Width = 116;
			// 
			// colDescription
			// 
			this.colDescription.Text = "Description";
			this.colDescription.Width = 383;
			// 
			// colQuantity
			// 
			this.colQuantity.Text = "Quantity";
			this.colQuantity.Width = 52;
			// 
			// colUnit
			// 
			this.colUnit.Text = "Unit";
			this.colUnit.Width = 58;
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(100, 7);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(558, 20);
			this.txtPath.TabIndex = 1;
			this.txtPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPathKeyUp);
			this.txtPath.Leave += new System.EventHandler(this.TxtPathLeave);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(664, 7);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(79, 20);
			this.btnBrowse.TabIndex = 2;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
			// 
			// lbltxt
			// 
			this.lbltxt.Location = new System.Drawing.Point(3, 9);
			this.lbltxt.Name = "lbltxt";
			this.lbltxt.Size = new System.Drawing.Size(91, 18);
			this.lbltxt.TabIndex = 3;
			this.lbltxt.Text = "Select a CSV file";
			this.lbltxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnImport
			// 
			this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImport.Location = new System.Drawing.Point(661, 417);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(82, 32);
			this.btnImport.TabIndex = 4;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Click += new System.EventHandler(this.BtnImportClick);
			// 
			// ofdCSVImport
			// 
			this.ofdCSVImport.Filter = "Comma-Seperated Values|*.csv";
			this.ofdCSVImport.ReadOnlyChecked = true;
			// 
			// bgwReadFile
			// 
			this.bgwReadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwReadFileDoWork);
			// 
			// ucImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.lbltxt);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.groupBox1);
			this.Name = "ucImport";
			this.Size = new System.Drawing.Size(746, 456);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.ComponentModel.BackgroundWorker bgwReadFile;
		private System.Windows.Forms.ColumnHeader colUnit;
		private System.Windows.Forms.ColumnHeader colQuantity;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader colSubCategory;
		private System.Windows.Forms.ColumnHeader colBarcode;
		private System.Windows.Forms.ListView lsvPreview;
		private System.Windows.Forms.OpenFileDialog ofdCSVImport;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Label lbltxt;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
