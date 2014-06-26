/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP_02
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.lblTitle = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblBarcodeHelp = new System.Windows.Forms.Label();
			this.btnBarcodeSearch = new System.Windows.Forms.Button();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.btnEnter = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblSubCategory = new System.Windows.Forms.Label();
			this.lblCategory = new System.Windows.Forms.Label();
			this.cbxSubCategory = new System.Windows.Forms.ComboBox();
			this.cbxCategory = new System.Windows.Forms.ComboBox();
			this.dstSubCategory = new System.Data.DataSet();
			this.dstCategory = new System.Data.DataSet();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.listViewProductDetails = new System.Windows.Forms.ListView();
			this.colProduct = new System.Windows.Forms.ColumnHeader();
			this.colBarcode = new System.Windows.Forms.ColumnHeader();
			this.colPrice = new System.Windows.Forms.ColumnHeader();
			this.colQuantity = new System.Windows.Forms.ColumnHeader();
			this.colShelf = new System.Windows.Forms.ColumnHeader();
			this.colDiscount = new System.Windows.Forms.ColumnHeader();
			this.colDescription = new System.Windows.Forms.ColumnHeader();
			this.btnZHHK = new System.Windows.Forms.Button();
			this.btnZHCN = new System.Windows.Forms.Button();
			this.btnEN = new System.Windows.Forms.Button();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.lblPercentText = new System.Windows.Forms.ToolStripStatusLabel();
			this.pgbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.bgwSqlQuery = new System.ComponentModel.BackgroundWorker();
			this.db_conn = new System.Data.OleDb.OleDbConnection();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dstSubCategory)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dstCategory)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			resources.ApplyResources(this.lblTitle, "lblTitle");
			this.lblTitle.Name = "lblTitle";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblBarcodeHelp);
			this.groupBox1.Controls.Add(this.btnBarcodeSearch);
			this.groupBox1.Controls.Add(this.txtBarcode);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// lblBarcodeHelp
			// 
			resources.ApplyResources(this.lblBarcodeHelp, "lblBarcodeHelp");
			this.lblBarcodeHelp.BackColor = System.Drawing.SystemColors.Window;
			this.lblBarcodeHelp.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.lblBarcodeHelp.Name = "lblBarcodeHelp";
			// 
			// btnBarcodeSearch
			// 
			resources.ApplyResources(this.btnBarcodeSearch, "btnBarcodeSearch");
			this.btnBarcodeSearch.BackColor = System.Drawing.Color.Gainsboro;
			this.btnBarcodeSearch.Name = "btnBarcodeSearch";
			this.btnBarcodeSearch.UseVisualStyleBackColor = false;
			this.btnBarcodeSearch.Click += new System.EventHandler(this.BtnBarcodeSearch_Click);
			// 
			// txtBarcode
			// 
			resources.ApplyResources(this.txtBarcode, "txtBarcode");
			this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.TextChanged += new System.EventHandler(this.TxtBarcode_TextChanged);
			this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcodeKeyDown);
			// 
			// btnEnter
			// 
			resources.ApplyResources(this.btnEnter, "btnEnter");
			this.btnEnter.Name = "btnEnter";
			this.btnEnter.UseVisualStyleBackColor = true;
			this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblSubCategory);
			this.groupBox2.Controls.Add(this.btnEnter);
			this.groupBox2.Controls.Add(this.lblCategory);
			this.groupBox2.Controls.Add(this.cbxSubCategory);
			this.groupBox2.Controls.Add(this.cbxCategory);
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// lblSubCategory
			// 
			resources.ApplyResources(this.lblSubCategory, "lblSubCategory");
			this.lblSubCategory.Name = "lblSubCategory";
			// 
			// lblCategory
			// 
			resources.ApplyResources(this.lblCategory, "lblCategory");
			this.lblCategory.Name = "lblCategory";
			// 
			// cbxSubCategory
			// 
			resources.ApplyResources(this.cbxSubCategory, "cbxSubCategory");
			this.cbxSubCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbxSubCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxSubCategory.FormattingEnabled = true;
			this.cbxSubCategory.Name = "cbxSubCategory";
			this.cbxSubCategory.Enter += new System.EventHandler(this.typableFieldFocusEnter);
			// 
			// cbxCategory
			// 
			resources.ApplyResources(this.cbxCategory, "cbxCategory");
			this.cbxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbxCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxCategory.FormattingEnabled = true;
			this.cbxCategory.Name = "cbxCategory";
			this.cbxCategory.Enter += new System.EventHandler(this.typableFieldFocusEnter);
			// 
			// dstSubCategory
			// 
			this.dstSubCategory.DataSetName = "NewDataSet";
			// 
			// dstCategory
			// 
			this.dstCategory.DataSetName = "NewDataSet";
			this.dstCategory.Locale = new System.Globalization.CultureInfo("en-GB");
			// 
			// groupBox3
			// 
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.Controls.Add(this.listViewProductDetails);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			// 
			// listViewProductDetails
			// 
			this.listViewProductDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colProduct,
									this.colBarcode,
									this.colPrice,
									this.colQuantity,
									this.colShelf,
									this.colDiscount,
									this.colDescription});
			resources.ApplyResources(this.listViewProductDetails, "listViewProductDetails");
			this.listViewProductDetails.FullRowSelect = true;
			this.listViewProductDetails.GridLines = true;
			this.listViewProductDetails.Name = "listViewProductDetails";
			this.listViewProductDetails.UseCompatibleStateImageBehavior = false;
			this.listViewProductDetails.View = System.Windows.Forms.View.Details;
			// 
			// colProduct
			// 
			resources.ApplyResources(this.colProduct, "colProduct");
			// 
			// colBarcode
			// 
			resources.ApplyResources(this.colBarcode, "colBarcode");
			// 
			// colPrice
			// 
			resources.ApplyResources(this.colPrice, "colPrice");
			// 
			// colQuantity
			// 
			resources.ApplyResources(this.colQuantity, "colQuantity");
			// 
			// colShelf
			// 
			resources.ApplyResources(this.colShelf, "colShelf");
			// 
			// colDiscount
			// 
			resources.ApplyResources(this.colDiscount, "colDiscount");
			// 
			// colDescription
			// 
			resources.ApplyResources(this.colDescription, "colDescription");
			// 
			// btnZHHK
			// 
			resources.ApplyResources(this.btnZHHK, "btnZHHK");
			this.btnZHHK.Name = "btnZHHK";
			this.btnZHHK.UseVisualStyleBackColor = true;
			this.btnZHHK.Click += new System.EventHandler(this.langChgBtnClick);
			// 
			// btnZHCN
			// 
			resources.ApplyResources(this.btnZHCN, "btnZHCN");
			this.btnZHCN.Name = "btnZHCN";
			this.btnZHCN.UseVisualStyleBackColor = true;
			this.btnZHCN.Click += new System.EventHandler(this.langChgBtnClick);
			// 
			// btnEN
			// 
			resources.ApplyResources(this.btnEN, "btnEN");
			this.btnEN.Name = "btnEN";
			this.btnEN.UseVisualStyleBackColor = true;
			this.btnEN.Click += new System.EventHandler(this.langChgBtnClick);
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.lblStatusText,
									this.lblPercentText,
									this.pgbProgressBar});
			resources.ApplyResources(this.statusStripMain, "statusStripMain");
			this.statusStripMain.Name = "statusStripMain";
			// 
			// lblPercentText
			// 
			this.lblPercentText.Name = "lblPercentText";
			resources.ApplyResources(this.lblPercentText, "lblPercentText");
			// 
			// pgbProgressBar
			// 
			this.pgbProgressBar.Name = "pgbProgressBar";
			resources.ApplyResources(this.pgbProgressBar, "pgbProgressBar");
			this.pgbProgressBar.Value = 100;
			// 
			// bgwSqlQuery
			// 
			this.bgwSqlQuery.WorkerReportsProgress = true;
			this.bgwSqlQuery.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwSqlQueryDoWork);
			this.bgwSqlQuery.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DatabaseBackgroundWorkers_ProgressChanged);
			this.bgwSqlQuery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DatabaseBackgroundWorkers_Completed);
			// 
			// db_conn
			// 
			this.db_conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=database.accdb";
			// 
			// splitContainer1
			// 
			resources.ApplyResources(this.splitContainer1, "splitContainer1");
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			// 
			// lblStatusText
			// 
			this.lblStatusText.Name = "lblStatusText";
			resources.ApplyResources(this.lblStatusText, "lblStatusText");
			this.lblStatusText.Spring = true;
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.btnEN);
			this.Controls.Add(this.btnZHCN);
			this.Controls.Add(this.btnZHHK);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.lblTitle);
			this.DoubleBuffered = true;
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dstSubCategory)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dstCategory)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnBarcodeSearch;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label lblSubCategory;
		private System.Data.OleDb.OleDbConnection db_conn;
		private System.Data.DataSet dstSubCategory;
		private System.Data.DataSet dstCategory;
		private System.Windows.Forms.Label lblBarcodeHelp;
		private System.ComponentModel.BackgroundWorker bgwSqlQuery;
		private System.Windows.Forms.ToolStripProgressBar pgbProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel lblPercentText;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.Button btnEN;
		private System.Windows.Forms.Button btnZHCN;
		private System.Windows.Forms.Button btnZHHK;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.ColumnHeader colDescription;
		private System.Windows.Forms.ColumnHeader colDiscount;
		private System.Windows.Forms.ColumnHeader colShelf;
		private System.Windows.Forms.ColumnHeader colQuantity;
		private System.Windows.Forms.ColumnHeader colPrice;
		private System.Windows.Forms.ColumnHeader colBarcode;
		private System.Windows.Forms.ColumnHeader colProduct;
		private System.Windows.Forms.ListView listViewProductDetails;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cbxCategory;
		private System.Windows.Forms.ComboBox cbxSubCategory;
		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnEnter;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblTitle;
	}
}
