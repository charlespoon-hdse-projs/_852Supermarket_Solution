/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 4:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP1_01
{
	partial class UcSearchView
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
			this.cbxSearchColumn = new System.Windows.Forms.ComboBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtSearchValue = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.spcMain = new System.Windows.Forms.SplitContainer();
			this.lsvSearchResult = new System.Windows.Forms.ListView();
			this.colProductID = new System.Windows.Forms.ColumnHeader();
			this.colBarcode = new System.Windows.Forms.ColumnHeader();
			this.colName = new System.Windows.Forms.ColumnHeader();
			this.colQuantity = new System.Windows.Forms.ColumnHeader();
			this.colPrice = new System.Windows.Forms.ColumnHeader();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.txtProductID = new System.Windows.Forms.TextBox();
			this.txtLinkedDiscount = new System.Windows.Forms.TextBox();
			this.txtShelfUsing = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.txtInShopWarehouseUsing = new System.Windows.Forms.TextBox();
			this.lblProductID = new System.Windows.Forms.Label();
			this.lblPrice = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblBarcode = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.txtPackagingInfo = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtDescriptionZHCN = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtDescriptionZHHK = new System.Windows.Forms.TextBox();
			this.pnlProductImage = new System.Windows.Forms.Panel();
			this.lblImage = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnViewDetails = new System.Windows.Forms.Button();
			this.lblProductSummary = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
			this.spcMain.Panel1.SuspendLayout();
			this.spcMain.Panel2.SuspendLayout();
			this.spcMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.pnlProductImage.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbxSearchColumn
			// 
			this.cbxSearchColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSearchColumn.FormattingEnabled = true;
			this.cbxSearchColumn.Items.AddRange(new object[] {
									"Category ID",
									"Category Name",
									"Sub-Category ID",
									"Sub-Category Name",
									"Product ID",
									"Product Barcode",
									"Product Name",
									"Product Price",
									"Linked to Discount ID",
									"Linked to Shelf Location ID",
									"Linked to In-shop Warehouse ID"});
			this.cbxSearchColumn.Location = new System.Drawing.Point(56, 4);
			this.cbxSearchColumn.Name = "cbxSearchColumn";
			this.cbxSearchColumn.Size = new System.Drawing.Size(180, 21);
			this.cbxSearchColumn.TabIndex = 0;
			// 
			// lblSearch
			// 
			this.lblSearch.Location = new System.Drawing.Point(0, 2);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.lblSearch.Size = new System.Drawing.Size(53, 23);
			this.lblSearch.TabIndex = 1;
			this.lblSearch.Text = "Search:";
			this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSearchValue
			// 
			this.txtSearchValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchValue.Location = new System.Drawing.Point(242, 4);
			this.txtSearchValue.Name = "txtSearchValue";
			this.txtSearchValue.Size = new System.Drawing.Size(420, 20);
			this.txtSearchValue.TabIndex = 2;
			this.txtSearchValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearchValue_KeyUp);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Location = new System.Drawing.Point(668, 3);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 20);
			this.btnSearch.TabIndex = 3;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// spcMain
			// 
			this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.spcMain.Location = new System.Drawing.Point(0, 0);
			this.spcMain.Name = "spcMain";
			this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// spcMain.Panel1
			// 
			this.spcMain.Panel1.Controls.Add(this.lsvSearchResult);
			this.spcMain.Panel1.Controls.Add(this.txtSearchValue);
			this.spcMain.Panel1.Controls.Add(this.btnSearch);
			this.spcMain.Panel1.Controls.Add(this.cbxSearchColumn);
			this.spcMain.Panel1.Controls.Add(this.lblSearch);
			// 
			// spcMain.Panel2
			// 
			this.spcMain.Panel2.AutoScroll = true;
			this.spcMain.Panel2.Controls.Add(this.splitContainer1);
			this.spcMain.Panel2.Controls.Add(this.label1);
			this.spcMain.Panel2.Controls.Add(this.btnViewDetails);
			this.spcMain.Panel2.Controls.Add(this.lblProductSummary);
			this.spcMain.Panel2.Margin = new System.Windows.Forms.Padding(6);
			this.spcMain.Size = new System.Drawing.Size(746, 456);
			this.spcMain.SplitterDistance = 252;
			this.spcMain.TabIndex = 5;
			// 
			// lsvSearchResult
			// 
			this.lsvSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lsvSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colProductID,
									this.colBarcode,
									this.colName,
									this.colQuantity,
									this.colPrice});
			this.lsvSearchResult.FullRowSelect = true;
			this.lsvSearchResult.GridLines = true;
			this.lsvSearchResult.Location = new System.Drawing.Point(3, 28);
			this.lsvSearchResult.MultiSelect = false;
			this.lsvSearchResult.Name = "lsvSearchResult";
			this.lsvSearchResult.Size = new System.Drawing.Size(740, 221);
			this.lsvSearchResult.TabIndex = 4;
			this.lsvSearchResult.UseCompatibleStateImageBehavior = false;
			this.lsvSearchResult.View = System.Windows.Forms.View.Details;
			this.lsvSearchResult.SelectedIndexChanged += new System.EventHandler(this.LsvSearchResult_SelectedIndexChanged);
			this.lsvSearchResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LsvSearchResultMouseDoubleClick);
			// 
			// colProductID
			// 
			this.colProductID.Text = "Product ID";
			this.colProductID.Width = 64;
			// 
			// colBarcode
			// 
			this.colBarcode.Text = "Barcode";
			this.colBarcode.Width = 93;
			// 
			// colName
			// 
			this.colName.Text = "Name";
			this.colName.Width = 196;
			// 
			// colQuantity
			// 
			this.colQuantity.Text = "Qty";
			this.colQuantity.Width = 80;
			// 
			// colPrice
			// 
			this.colPrice.Text = "HK$";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 32);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnlProductImage);
			this.splitContainer1.Size = new System.Drawing.Size(740, 154);
			this.splitContainer1.SplitterDistance = 516;
			this.splitContainer1.TabIndex = 75;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.txtProductID);
			this.splitContainer2.Panel1.Controls.Add(this.txtLinkedDiscount);
			this.splitContainer2.Panel1.Controls.Add(this.txtShelfUsing);
			this.splitContainer2.Panel1.Controls.Add(this.txtPrice);
			this.splitContainer2.Panel1.Controls.Add(this.txtBarcode);
			this.splitContainer2.Panel1.Controls.Add(this.txtInShopWarehouseUsing);
			this.splitContainer2.Panel1.Controls.Add(this.lblProductID);
			this.splitContainer2.Panel1.Controls.Add(this.lblPrice);
			this.splitContainer2.Panel1.Controls.Add(this.label6);
			this.splitContainer2.Panel1.Controls.Add(this.label8);
			this.splitContainer2.Panel1.Controls.Add(this.label7);
			this.splitContainer2.Panel1.Controls.Add(this.lblBarcode);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.label4);
			this.splitContainer2.Panel2.Controls.Add(this.label2);
			this.splitContainer2.Panel2.Controls.Add(this.label3);
			this.splitContainer2.Panel2.Controls.Add(this.label5);
			this.splitContainer2.Panel2.Controls.Add(this.txtProductName);
			this.splitContainer2.Panel2.Controls.Add(this.txtPackagingInfo);
			this.splitContainer2.Panel2.Controls.Add(this.txtQuantity);
			this.splitContainer2.Panel2.Controls.Add(this.txtDescriptionZHCN);
			this.splitContainer2.Panel2.Controls.Add(this.txtDescription);
			this.splitContainer2.Panel2.Controls.Add(this.txtDescriptionZHHK);
			this.splitContainer2.Size = new System.Drawing.Size(516, 154);
			this.splitContainer2.SplitterDistance = 150;
			this.splitContainer2.TabIndex = 83;
			// 
			// txtProductID
			// 
			this.txtProductID.Location = new System.Drawing.Point(91, 0);
			this.txtProductID.MaxLength = 15;
			this.txtProductID.Name = "txtProductID";
			this.txtProductID.ReadOnly = true;
			this.txtProductID.Size = new System.Drawing.Size(59, 20);
			this.txtProductID.TabIndex = 82;
			this.txtProductID.TabStop = false;
			// 
			// txtLinkedDiscount
			// 
			this.txtLinkedDiscount.Location = new System.Drawing.Point(91, 78);
			this.txtLinkedDiscount.MaxLength = 15;
			this.txtLinkedDiscount.Name = "txtLinkedDiscount";
			this.txtLinkedDiscount.ReadOnly = true;
			this.txtLinkedDiscount.Size = new System.Drawing.Size(59, 20);
			this.txtLinkedDiscount.TabIndex = 81;
			this.txtLinkedDiscount.TabStop = false;
			// 
			// txtShelfUsing
			// 
			this.txtShelfUsing.Location = new System.Drawing.Point(91, 104);
			this.txtShelfUsing.MaxLength = 13;
			this.txtShelfUsing.Name = "txtShelfUsing";
			this.txtShelfUsing.ReadOnly = true;
			this.txtShelfUsing.Size = new System.Drawing.Size(59, 20);
			this.txtShelfUsing.TabIndex = 85;
			this.txtShelfUsing.TabStop = false;
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(91, 52);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.ReadOnly = true;
			this.txtPrice.Size = new System.Drawing.Size(59, 20);
			this.txtPrice.TabIndex = 83;
			this.txtPrice.TabStop = false;
			// 
			// txtBarcode
			// 
			this.txtBarcode.Location = new System.Drawing.Point(91, 26);
			this.txtBarcode.MaxLength = 13;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.ReadOnly = true;
			this.txtBarcode.Size = new System.Drawing.Size(59, 20);
			this.txtBarcode.TabIndex = 86;
			this.txtBarcode.TabStop = false;
			// 
			// txtInShopWarehouseUsing
			// 
			this.txtInShopWarehouseUsing.Location = new System.Drawing.Point(91, 130);
			this.txtInShopWarehouseUsing.Name = "txtInShopWarehouseUsing";
			this.txtInShopWarehouseUsing.ReadOnly = true;
			this.txtInShopWarehouseUsing.Size = new System.Drawing.Size(59, 20);
			this.txtInShopWarehouseUsing.TabIndex = 84;
			this.txtInShopWarehouseUsing.TabStop = false;
			// 
			// lblProductID
			// 
			this.lblProductID.Location = new System.Drawing.Point(1, 3);
			this.lblProductID.Name = "lblProductID";
			this.lblProductID.Size = new System.Drawing.Size(84, 13);
			this.lblProductID.TabIndex = 76;
			this.lblProductID.Text = "Product ID";
			this.lblProductID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblPrice
			// 
			this.lblPrice.Location = new System.Drawing.Point(1, 55);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(84, 13);
			this.lblPrice.TabIndex = 80;
			this.lblPrice.Text = "Price";
			this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(1, 107);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(84, 13);
			this.label6.TabIndex = 80;
			this.label6.Text = "Shelf Using";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(1, 81);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(84, 13);
			this.label8.TabIndex = 80;
			this.label8.Text = "Linked Discount";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(1, 133);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(84, 13);
			this.label7.TabIndex = 80;
			this.label7.Text = "ISWh Using";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblBarcode
			// 
			this.lblBarcode.Location = new System.Drawing.Point(1, 29);
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Size = new System.Drawing.Size(84, 13);
			this.lblBarcode.TabIndex = 75;
			this.lblBarcode.Text = "Barcode";
			this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(2, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 13);
			this.label4.TabIndex = 84;
			this.label4.Text = "Quantity";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(2, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 13);
			this.label2.TabIndex = 82;
			this.label2.Text = "Product Name";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(2, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 13);
			this.label3.TabIndex = 83;
			this.label3.Text = "Per-item Packaging Info";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(2, 81);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(122, 13);
			this.label5.TabIndex = 91;
			this.label5.Text = "Description";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProductName
			// 
			this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProductName.Location = new System.Drawing.Point(130, 0);
			this.txtProductName.MaxLength = 15;
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.ReadOnly = true;
			this.txtProductName.Size = new System.Drawing.Size(219, 20);
			this.txtProductName.TabIndex = 85;
			this.txtProductName.TabStop = false;
			// 
			// txtPackagingInfo
			// 
			this.txtPackagingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPackagingInfo.Location = new System.Drawing.Point(130, 26);
			this.txtPackagingInfo.MaxLength = 13;
			this.txtPackagingInfo.Name = "txtPackagingInfo";
			this.txtPackagingInfo.ReadOnly = true;
			this.txtPackagingInfo.Size = new System.Drawing.Size(219, 20);
			this.txtPackagingInfo.TabIndex = 90;
			this.txtPackagingInfo.TabStop = false;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtQuantity.Location = new System.Drawing.Point(130, 52);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.ReadOnly = true;
			this.txtQuantity.Size = new System.Drawing.Size(219, 20);
			this.txtQuantity.TabIndex = 87;
			this.txtQuantity.TabStop = false;
			// 
			// txtDescriptionZHCN
			// 
			this.txtDescriptionZHCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescriptionZHCN.Location = new System.Drawing.Point(130, 130);
			this.txtDescriptionZHCN.Name = "txtDescriptionZHCN";
			this.txtDescriptionZHCN.ReadOnly = true;
			this.txtDescriptionZHCN.Size = new System.Drawing.Size(219, 20);
			this.txtDescriptionZHCN.TabIndex = 88;
			this.txtDescriptionZHCN.TabStop = false;
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(130, 78);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.Size = new System.Drawing.Size(219, 20);
			this.txtDescription.TabIndex = 86;
			this.txtDescription.TabStop = false;
			// 
			// txtDescriptionZHHK
			// 
			this.txtDescriptionZHHK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescriptionZHHK.Location = new System.Drawing.Point(130, 104);
			this.txtDescriptionZHHK.Name = "txtDescriptionZHHK";
			this.txtDescriptionZHHK.ReadOnly = true;
			this.txtDescriptionZHHK.Size = new System.Drawing.Size(219, 20);
			this.txtDescriptionZHHK.TabIndex = 89;
			this.txtDescriptionZHHK.TabStop = false;
			// 
			// pnlProductImage
			// 
			this.pnlProductImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pnlProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlProductImage.Controls.Add(this.lblImage);
			this.pnlProductImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlProductImage.Location = new System.Drawing.Point(0, 0);
			this.pnlProductImage.Name = "pnlProductImage";
			this.pnlProductImage.Size = new System.Drawing.Size(220, 154);
			this.pnlProductImage.TabIndex = 75;
			// 
			// lblImage
			// 
			this.lblImage.AutoSize = true;
			this.lblImage.Location = new System.Drawing.Point(6, 6);
			this.lblImage.Margin = new System.Windows.Forms.Padding(6);
			this.lblImage.Name = "lblImage";
			this.lblImage.Size = new System.Drawing.Size(88, 13);
			this.lblImage.TabIndex = 1;
			this.lblImage.Text = "Image of Product";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(459, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(203, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "View more, edit or delete with click button";
			// 
			// btnViewDetails
			// 
			this.btnViewDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnViewDetails.Enabled = false;
			this.btnViewDetails.Location = new System.Drawing.Point(668, 3);
			this.btnViewDetails.Name = "btnViewDetails";
			this.btnViewDetails.Size = new System.Drawing.Size(75, 24);
			this.btnViewDetails.TabIndex = 1;
			this.btnViewDetails.Text = "View &Details";
			this.btnViewDetails.UseVisualStyleBackColor = true;
			this.btnViewDetails.Click += new System.EventHandler(this.BtnViewDetails_Click);
			// 
			// lblProductSummary
			// 
			this.lblProductSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lblProductSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lblProductSummary.Location = new System.Drawing.Point(3, 4);
			this.lblProductSummary.Name = "lblProductSummary";
			this.lblProductSummary.Size = new System.Drawing.Size(450, 23);
			this.lblProductSummary.TabIndex = 0;
			this.lblProductSummary.Text = "Summary of product";
			// 
			// UcSearchView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.spcMain);
			this.Name = "UcSearchView";
			this.Size = new System.Drawing.Size(746, 456);
			this.spcMain.Panel1.ResumeLayout(false);
			this.spcMain.Panel1.PerformLayout();
			this.spcMain.Panel2.ResumeLayout(false);
			this.spcMain.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
			this.spcMain.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.pnlProductImage.ResumeLayout(false);
			this.pnlProductImage.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox txtDescriptionZHHK;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtDescriptionZHCN;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtPackagingInfo;
		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TextBox txtLinkedDiscount;
		private System.Windows.Forms.TextBox txtInShopWarehouseUsing;
		private System.Windows.Forms.TextBox txtShelfUsing;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblImage;
		private System.Windows.Forms.Panel pnlProductImage;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.TextBox txtProductID;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Label lblBarcode;
		private System.Windows.Forms.Label lblProductID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnViewDetails;
		private System.Windows.Forms.Label lblProductSummary;
		private System.Windows.Forms.ColumnHeader colPrice;
		private System.Windows.Forms.ColumnHeader colQuantity;
		private System.Windows.Forms.ColumnHeader colName;
		private System.Windows.Forms.ColumnHeader colBarcode;
		private System.Windows.Forms.ColumnHeader colProductID;
		private System.Windows.Forms.ListView lsvSearchResult;
		private System.Windows.Forms.SplitContainer spcMain;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox txtSearchValue;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.ComboBox cbxSearchColumn;
	}
}
