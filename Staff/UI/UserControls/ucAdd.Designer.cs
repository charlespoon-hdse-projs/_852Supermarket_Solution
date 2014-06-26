/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP1_01
{
	partial class ucAdd
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
			this.lblCal = new System.Windows.Forms.Label();
			this.lblDetailTitle = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.bgwLoadListsOnStart = new System.ComponentModel.BackgroundWorker();
			this.gbxDiscount = new System.Windows.Forms.GroupBox();
			this.lsvDiscounts = new System.Windows.Forms.ListView();
			this.colDiscountOperation = new System.Windows.Forms.ColumnHeader();
			this.colExisting = new System.Windows.Forms.ColumnHeader();
			this.colMinQuantities = new System.Windows.Forms.ColumnHeader();
			this.colMinByPrice = new System.Windows.Forms.ColumnHeader();
			this.btnDiscountsDelete = new System.Windows.Forms.Button();
			this.btnDiscountsAdd = new System.Windows.Forms.Button();
			this.gbxShelfUsage = new System.Windows.Forms.GroupBox();
			this.lsvShelfUsage = new System.Windows.Forms.ListView();
			this.colOnShelf = new System.Windows.Forms.ColumnHeader();
			this.colWkPlcName = new System.Windows.Forms.ColumnHeader();
			this.btnShelfUsageDelete = new System.Windows.Forms.Button();
			this.btnShelfUsageAddEdit = new System.Windows.Forms.Button();
			this.gbxInShopWarehouse = new System.Windows.Forms.GroupBox();
			this.lsvInShopWarehouseUsage = new System.Windows.Forms.ListView();
			this.colInShopWarehouse = new System.Windows.Forms.ColumnHeader();
			this.colWorkplace = new System.Windows.Forms.ColumnHeader();
			this.btnInShopWarehouseUsageDelete = new System.Windows.Forms.Button();
			this.btnInShopWarehouseUsageAddEdit = new System.Windows.Forms.Button();
			this.pnlProductImage = new System.Windows.Forms.Panel();
			this.lblImage = new System.Windows.Forms.Label();
			this.btnImageClear = new System.Windows.Forms.Button();
			this.btnImageChange = new System.Windows.Forms.Button();
			this.sptDiscountAndUsages = new System.Windows.Forms.SplitContainer();
			this.sptShelfUsageAndInShopWarehouseUsage = new System.Windows.Forms.SplitContainer();
			this.sptProductInfosAndPackagingQuantity = new System.Windows.Forms.SplitContainer();
			this.sptProductInfoAndDescription = new System.Windows.Forms.SplitContainer();
			this.sptProductBasicInfoAndProductName = new System.Windows.Forms.SplitContainer();
			this.lblProductID = new System.Windows.Forms.Label();
			this.lblBarcode = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtProductID = new System.Windows.Forms.TextBox();
			this.btnAutoProductID = new System.Windows.Forms.Button();
			this.lblPrice = new System.Windows.Forms.Label();
			this.gbxProductName = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.txtProductNameZHHK = new System.Windows.Forms.TextBox();
			this.txtProductNameZHCN = new System.Windows.Forms.TextBox();
			this.gbxDescription = new System.Windows.Forms.GroupBox();
			this.lblZHCN = new System.Windows.Forms.Label();
			this.lblDescZHHK = new System.Windows.Forms.Label();
			this.lblDescEN = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtDescriptionZHHK = new System.Windows.Forms.TextBox();
			this.txtDescriptionZHCN = new System.Windows.Forms.TextBox();
			this.sptPackagingInfoAndQuantity = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPackagingInfo = new System.Windows.Forms.TextBox();
			this.txtPackagingInfoZHHK = new System.Windows.Forms.TextBox();
			this.txtPackagingInfoZHCN = new System.Windows.Forms.TextBox();
			this.gbxQuantityUnit = new System.Windows.Forms.GroupBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.txtUnitZHHK = new System.Windows.Forms.TextBox();
			this.txtUnitZHCN = new System.Windows.Forms.TextBox();
			this.ofdProductImage = new System.Windows.Forms.OpenFileDialog();
			this.cbxCategory = new System.Windows.Forms.ComboBox();
			this.cbxSubCategory = new System.Windows.Forms.ComboBox();
			this.btnManageCategory = new System.Windows.Forms.Button();
			this.btnManageSubCategory = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.gbxDiscount.SuspendLayout();
			this.gbxShelfUsage.SuspendLayout();
			this.gbxInShopWarehouse.SuspendLayout();
			this.pnlProductImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sptDiscountAndUsages)).BeginInit();
			this.sptDiscountAndUsages.Panel1.SuspendLayout();
			this.sptDiscountAndUsages.Panel2.SuspendLayout();
			this.sptDiscountAndUsages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sptShelfUsageAndInShopWarehouseUsage)).BeginInit();
			this.sptShelfUsageAndInShopWarehouseUsage.Panel1.SuspendLayout();
			this.sptShelfUsageAndInShopWarehouseUsage.Panel2.SuspendLayout();
			this.sptShelfUsageAndInShopWarehouseUsage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sptProductInfosAndPackagingQuantity)).BeginInit();
			this.sptProductInfosAndPackagingQuantity.Panel1.SuspendLayout();
			this.sptProductInfosAndPackagingQuantity.Panel2.SuspendLayout();
			this.sptProductInfosAndPackagingQuantity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sptProductInfoAndDescription)).BeginInit();
			this.sptProductInfoAndDescription.Panel1.SuspendLayout();
			this.sptProductInfoAndDescription.Panel2.SuspendLayout();
			this.sptProductInfoAndDescription.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sptProductBasicInfoAndProductName)).BeginInit();
			this.sptProductBasicInfoAndProductName.Panel1.SuspendLayout();
			this.sptProductBasicInfoAndProductName.Panel2.SuspendLayout();
			this.sptProductBasicInfoAndProductName.SuspendLayout();
			this.gbxProductName.SuspendLayout();
			this.gbxDescription.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sptPackagingInfoAndQuantity)).BeginInit();
			this.sptPackagingInfoAndQuantity.Panel1.SuspendLayout();
			this.sptPackagingInfoAndQuantity.Panel2.SuspendLayout();
			this.sptPackagingInfoAndQuantity.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbxQuantityUnit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCal
			// 
			this.lblCal.AutoSize = true;
			this.lblCal.Location = new System.Drawing.Point(13, 49);
			this.lblCal.Name = "lblCal";
			this.lblCal.Size = new System.Drawing.Size(89, 13);
			this.lblCal.TabIndex = 0;
			this.lblCal.Text = "Select categories";
			this.lblCal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDetailTitle
			// 
			this.lblDetailTitle.AutoSize = true;
			this.lblDetailTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDetailTitle.Location = new System.Drawing.Point(13, 12);
			this.lblDetailTitle.Name = "lblDetailTitle";
			this.lblDetailTitle.Size = new System.Drawing.Size(242, 25);
			this.lblDetailTitle.TabIndex = 20;
			this.lblDetailTitle.Text = "Add new product details";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(577, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 29);
			this.btnAdd.TabIndex = 39;
			this.btnAdd.Text = "&Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(658, 13);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 29);
			this.btnClear.TabIndex = 40;
			this.btnClear.Text = "&Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// bgwLoadListsOnStart
			// 
			this.bgwLoadListsOnStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwLoadListsOnStart_DoWork);
			// 
			// gbxDiscount
			// 
			this.gbxDiscount.Controls.Add(this.lsvDiscounts);
			this.gbxDiscount.Controls.Add(this.btnDiscountsDelete);
			this.gbxDiscount.Controls.Add(this.btnDiscountsAdd);
			this.gbxDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxDiscount.Location = new System.Drawing.Point(0, 0);
			this.gbxDiscount.Name = "gbxDiscount";
			this.gbxDiscount.Size = new System.Drawing.Size(240, 158);
			this.gbxDiscount.TabIndex = 54;
			this.gbxDiscount.TabStop = false;
			this.gbxDiscount.Text = "Discounts";
			// 
			// lsvDiscounts
			// 
			this.lsvDiscounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lsvDiscounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colDiscountOperation,
									this.colExisting,
									this.colMinQuantities,
									this.colMinByPrice});
			this.lsvDiscounts.FullRowSelect = true;
			this.lsvDiscounts.Location = new System.Drawing.Point(6, 19);
			this.lsvDiscounts.Name = "lsvDiscounts";
			this.lsvDiscounts.Size = new System.Drawing.Size(224, 101);
			this.lsvDiscounts.TabIndex = 1;
			this.lsvDiscounts.UseCompatibleStateImageBehavior = false;
			this.lsvDiscounts.View = System.Windows.Forms.View.Details;
			// 
			// colDiscountOperation
			// 
			this.colDiscountOperation.Text = "Dc. OpID";
			// 
			// colExisting
			// 
			this.colExisting.Text = "Exist";
			this.colExisting.Width = 35;
			// 
			// colMinQuantities
			// 
			this.colMinQuantities.Text = "Min. Qty";
			this.colMinQuantities.Width = 55;
			// 
			// colMinByPrice
			// 
			this.colMinByPrice.Text = "Min. $";
			this.colMinByPrice.Width = 50;
			// 
			// btnDiscountsDelete
			// 
			this.btnDiscountsDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDiscountsDelete.Location = new System.Drawing.Point(121, 126);
			this.btnDiscountsDelete.Name = "btnDiscountsDelete";
			this.btnDiscountsDelete.Size = new System.Drawing.Size(109, 23);
			this.btnDiscountsDelete.TabIndex = 0;
			this.btnDiscountsDelete.Text = "Delete";
			this.btnDiscountsDelete.UseVisualStyleBackColor = true;
			this.btnDiscountsDelete.Click += new System.EventHandler(this.BtnDiscountsDelete_Click);
			// 
			// btnDiscountsAdd
			// 
			this.btnDiscountsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDiscountsAdd.Location = new System.Drawing.Point(6, 126);
			this.btnDiscountsAdd.Name = "btnDiscountsAdd";
			this.btnDiscountsAdd.Size = new System.Drawing.Size(109, 23);
			this.btnDiscountsAdd.TabIndex = 0;
			this.btnDiscountsAdd.Text = "Add";
			this.btnDiscountsAdd.UseVisualStyleBackColor = true;
			this.btnDiscountsAdd.Click += new System.EventHandler(this.BtnDiscountsAddEdit_Click);
			// 
			// gbxShelfUsage
			// 
			this.gbxShelfUsage.Controls.Add(this.lsvShelfUsage);
			this.gbxShelfUsage.Controls.Add(this.btnShelfUsageDelete);
			this.gbxShelfUsage.Controls.Add(this.btnShelfUsageAddEdit);
			this.gbxShelfUsage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxShelfUsage.Location = new System.Drawing.Point(0, 0);
			this.gbxShelfUsage.Name = "gbxShelfUsage";
			this.gbxShelfUsage.Size = new System.Drawing.Size(238, 158);
			this.gbxShelfUsage.TabIndex = 54;
			this.gbxShelfUsage.TabStop = false;
			this.gbxShelfUsage.Text = "Shelf Usage";
			// 
			// lsvShelfUsage
			// 
			this.lsvShelfUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lsvShelfUsage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colOnShelf,
									this.colWkPlcName});
			this.lsvShelfUsage.FullRowSelect = true;
			this.lsvShelfUsage.Location = new System.Drawing.Point(6, 19);
			this.lsvShelfUsage.Name = "lsvShelfUsage";
			this.lsvShelfUsage.Size = new System.Drawing.Size(224, 101);
			this.lsvShelfUsage.TabIndex = 1;
			this.lsvShelfUsage.UseCompatibleStateImageBehavior = false;
			this.lsvShelfUsage.View = System.Windows.Forms.View.Details;
			// 
			// colOnShelf
			// 
			this.colOnShelf.Text = "On Shelf";
			// 
			// colWkPlcName
			// 
			this.colWkPlcName.Text = "...of Location";
			this.colWkPlcName.Width = 120;
			// 
			// btnShelfUsageDelete
			// 
			this.btnShelfUsageDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShelfUsageDelete.Location = new System.Drawing.Point(121, 126);
			this.btnShelfUsageDelete.Name = "btnShelfUsageDelete";
			this.btnShelfUsageDelete.Size = new System.Drawing.Size(109, 23);
			this.btnShelfUsageDelete.TabIndex = 0;
			this.btnShelfUsageDelete.Text = "Delete";
			this.btnShelfUsageDelete.UseVisualStyleBackColor = true;
			this.btnShelfUsageDelete.Click += new System.EventHandler(this.BtnShelfUsageDelete_Click);
			// 
			// btnShelfUsageAddEdit
			// 
			this.btnShelfUsageAddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnShelfUsageAddEdit.Location = new System.Drawing.Point(6, 126);
			this.btnShelfUsageAddEdit.Name = "btnShelfUsageAddEdit";
			this.btnShelfUsageAddEdit.Size = new System.Drawing.Size(109, 23);
			this.btnShelfUsageAddEdit.TabIndex = 0;
			this.btnShelfUsageAddEdit.Text = "Add / Edit";
			this.btnShelfUsageAddEdit.UseVisualStyleBackColor = true;
			this.btnShelfUsageAddEdit.Click += new System.EventHandler(this.BtnShelfUsageAddEdit_Click);
			// 
			// gbxInShopWarehouse
			// 
			this.gbxInShopWarehouse.Controls.Add(this.lsvInShopWarehouseUsage);
			this.gbxInShopWarehouse.Controls.Add(this.btnInShopWarehouseUsageDelete);
			this.gbxInShopWarehouse.Controls.Add(this.btnInShopWarehouseUsageAddEdit);
			this.gbxInShopWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxInShopWarehouse.Location = new System.Drawing.Point(0, 0);
			this.gbxInShopWarehouse.Name = "gbxInShopWarehouse";
			this.gbxInShopWarehouse.Size = new System.Drawing.Size(230, 158);
			this.gbxInShopWarehouse.TabIndex = 54;
			this.gbxInShopWarehouse.TabStop = false;
			this.gbxInShopWarehouse.Text = "In-shop Warehouse Usage";
			// 
			// lsvInShopWarehouseUsage
			// 
			this.lsvInShopWarehouseUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.lsvInShopWarehouseUsage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.colInShopWarehouse,
									this.colWorkplace});
			this.lsvInShopWarehouseUsage.FullRowSelect = true;
			this.lsvInShopWarehouseUsage.Location = new System.Drawing.Point(6, 19);
			this.lsvInShopWarehouseUsage.Name = "lsvInShopWarehouseUsage";
			this.lsvInShopWarehouseUsage.Size = new System.Drawing.Size(218, 101);
			this.lsvInShopWarehouseUsage.TabIndex = 1;
			this.lsvInShopWarehouseUsage.UseCompatibleStateImageBehavior = false;
			this.lsvInShopWarehouseUsage.View = System.Windows.Forms.View.Details;
			// 
			// colInShopWarehouse
			// 
			this.colInShopWarehouse.Text = "In-Shop Wh.";
			this.colInShopWarehouse.Width = 80;
			// 
			// colWorkplace
			// 
			this.colWorkplace.Text = "...of Location";
			this.colWorkplace.Width = 120;
			// 
			// btnInShopWarehouseUsageDelete
			// 
			this.btnInShopWarehouseUsageDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInShopWarehouseUsageDelete.Location = new System.Drawing.Point(121, 126);
			this.btnInShopWarehouseUsageDelete.Name = "btnInShopWarehouseUsageDelete";
			this.btnInShopWarehouseUsageDelete.Size = new System.Drawing.Size(103, 23);
			this.btnInShopWarehouseUsageDelete.TabIndex = 0;
			this.btnInShopWarehouseUsageDelete.Text = "Delete";
			this.btnInShopWarehouseUsageDelete.UseVisualStyleBackColor = true;
			this.btnInShopWarehouseUsageDelete.Click += new System.EventHandler(this.BtnInShopWarehouseUsageDelete_Click);
			// 
			// btnInShopWarehouseUsageAddEdit
			// 
			this.btnInShopWarehouseUsageAddEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnInShopWarehouseUsageAddEdit.Location = new System.Drawing.Point(6, 126);
			this.btnInShopWarehouseUsageAddEdit.Name = "btnInShopWarehouseUsageAddEdit";
			this.btnInShopWarehouseUsageAddEdit.Size = new System.Drawing.Size(109, 23);
			this.btnInShopWarehouseUsageAddEdit.TabIndex = 0;
			this.btnInShopWarehouseUsageAddEdit.Text = "Add / Edit";
			this.btnInShopWarehouseUsageAddEdit.UseVisualStyleBackColor = true;
			this.btnInShopWarehouseUsageAddEdit.Click += new System.EventHandler(this.BtnInShopWarehouseUsageAddEdit_Click);
			// 
			// pnlProductImage
			// 
			this.pnlProductImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlProductImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pnlProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlProductImage.Controls.Add(this.lblImage);
			this.pnlProductImage.Controls.Add(this.btnImageClear);
			this.pnlProductImage.Controls.Add(this.btnImageChange);
			this.pnlProductImage.Location = new System.Drawing.Point(533, 82);
			this.pnlProductImage.Name = "pnlProductImage";
			this.pnlProductImage.Size = new System.Drawing.Size(200, 200);
			this.pnlProductImage.TabIndex = 55;
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
			// btnImageClear
			// 
			this.btnImageClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImageClear.Location = new System.Drawing.Point(6, 169);
			this.btnImageClear.Name = "btnImageClear";
			this.btnImageClear.Size = new System.Drawing.Size(75, 23);
			this.btnImageClear.TabIndex = 0;
			this.btnImageClear.Text = "Clear";
			this.btnImageClear.UseVisualStyleBackColor = true;
			this.btnImageClear.Click += new System.EventHandler(this.BtnImageClear_Click);
			// 
			// btnImageChange
			// 
			this.btnImageChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnImageChange.Location = new System.Drawing.Point(118, 169);
			this.btnImageChange.Name = "btnImageChange";
			this.btnImageChange.Size = new System.Drawing.Size(75, 23);
			this.btnImageChange.TabIndex = 0;
			this.btnImageChange.Text = "Change...";
			this.btnImageChange.UseVisualStyleBackColor = true;
			this.btnImageChange.Click += new System.EventHandler(this.BtnImageChange_Click);
			// 
			// sptDiscountAndUsages
			// 
			this.sptDiscountAndUsages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.sptDiscountAndUsages.IsSplitterFixed = true;
			this.sptDiscountAndUsages.Location = new System.Drawing.Point(13, 288);
			this.sptDiscountAndUsages.Margin = new System.Windows.Forms.Padding(0);
			this.sptDiscountAndUsages.Name = "sptDiscountAndUsages";
			// 
			// sptDiscountAndUsages.Panel1
			// 
			this.sptDiscountAndUsages.Panel1.Controls.Add(this.gbxDiscount);
			// 
			// sptDiscountAndUsages.Panel2
			// 
			this.sptDiscountAndUsages.Panel2.Controls.Add(this.sptShelfUsageAndInShopWarehouseUsage);
			this.sptDiscountAndUsages.Size = new System.Drawing.Size(720, 158);
			this.sptDiscountAndUsages.SplitterDistance = 240;
			this.sptDiscountAndUsages.SplitterWidth = 6;
			this.sptDiscountAndUsages.TabIndex = 56;
			// 
			// sptShelfUsageAndInShopWarehouseUsage
			// 
			this.sptShelfUsageAndInShopWarehouseUsage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sptShelfUsageAndInShopWarehouseUsage.IsSplitterFixed = true;
			this.sptShelfUsageAndInShopWarehouseUsage.Location = new System.Drawing.Point(0, 0);
			this.sptShelfUsageAndInShopWarehouseUsage.Margin = new System.Windows.Forms.Padding(0);
			this.sptShelfUsageAndInShopWarehouseUsage.Name = "sptShelfUsageAndInShopWarehouseUsage";
			// 
			// sptShelfUsageAndInShopWarehouseUsage.Panel1
			// 
			this.sptShelfUsageAndInShopWarehouseUsage.Panel1.Controls.Add(this.gbxShelfUsage);
			// 
			// sptShelfUsageAndInShopWarehouseUsage.Panel2
			// 
			this.sptShelfUsageAndInShopWarehouseUsage.Panel2.Controls.Add(this.gbxInShopWarehouse);
			this.sptShelfUsageAndInShopWarehouseUsage.Size = new System.Drawing.Size(474, 158);
			this.sptShelfUsageAndInShopWarehouseUsage.SplitterDistance = 238;
			this.sptShelfUsageAndInShopWarehouseUsage.SplitterWidth = 6;
			this.sptShelfUsageAndInShopWarehouseUsage.TabIndex = 0;
			// 
			// sptProductInfosAndPackagingQuantity
			// 
			this.sptProductInfosAndPackagingQuantity.IsSplitterFixed = true;
			this.sptProductInfosAndPackagingQuantity.Location = new System.Drawing.Point(13, 75);
			this.sptProductInfosAndPackagingQuantity.Name = "sptProductInfosAndPackagingQuantity";
			// 
			// sptProductInfosAndPackagingQuantity.Panel1
			// 
			this.sptProductInfosAndPackagingQuantity.Panel1.Controls.Add(this.sptProductInfoAndDescription);
			// 
			// sptProductInfosAndPackagingQuantity.Panel2
			// 
			this.sptProductInfosAndPackagingQuantity.Panel2.Controls.Add(this.sptPackagingInfoAndQuantity);
			this.sptProductInfosAndPackagingQuantity.Size = new System.Drawing.Size(514, 207);
			this.sptProductInfosAndPackagingQuantity.SplitterDistance = 336;
			this.sptProductInfosAndPackagingQuantity.SplitterWidth = 6;
			this.sptProductInfosAndPackagingQuantity.TabIndex = 57;
			// 
			// sptProductInfoAndDescription
			// 
			this.sptProductInfoAndDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sptProductInfoAndDescription.IsSplitterFixed = true;
			this.sptProductInfoAndDescription.Location = new System.Drawing.Point(0, 0);
			this.sptProductInfoAndDescription.Margin = new System.Windows.Forms.Padding(0);
			this.sptProductInfoAndDescription.Name = "sptProductInfoAndDescription";
			this.sptProductInfoAndDescription.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sptProductInfoAndDescription.Panel1
			// 
			this.sptProductInfoAndDescription.Panel1.Controls.Add(this.sptProductBasicInfoAndProductName);
			// 
			// sptProductInfoAndDescription.Panel2
			// 
			this.sptProductInfoAndDescription.Panel2.Controls.Add(this.gbxDescription);
			this.sptProductInfoAndDescription.Size = new System.Drawing.Size(336, 207);
			this.sptProductInfoAndDescription.SplitterDistance = 106;
			this.sptProductInfoAndDescription.TabIndex = 58;
			// 
			// sptProductBasicInfoAndProductName
			// 
			this.sptProductBasicInfoAndProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sptProductBasicInfoAndProductName.IsSplitterFixed = true;
			this.sptProductBasicInfoAndProductName.Location = new System.Drawing.Point(0, 0);
			this.sptProductBasicInfoAndProductName.Margin = new System.Windows.Forms.Padding(0);
			this.sptProductBasicInfoAndProductName.Name = "sptProductBasicInfoAndProductName";
			// 
			// sptProductBasicInfoAndProductName.Panel1
			// 
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.lblProductID);
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.lblBarcode);
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.txtBarcode);
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.txtPrice);
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.txtProductID);
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.btnAutoProductID);
			this.sptProductBasicInfoAndProductName.Panel1.Controls.Add(this.lblPrice);
			// 
			// sptProductBasicInfoAndProductName.Panel2
			// 
			this.sptProductBasicInfoAndProductName.Panel2.Controls.Add(this.gbxProductName);
			this.sptProductBasicInfoAndProductName.Size = new System.Drawing.Size(336, 106);
			this.sptProductBasicInfoAndProductName.SplitterDistance = 156;
			this.sptProductBasicInfoAndProductName.TabIndex = 58;
			// 
			// lblProductID
			// 
			this.lblProductID.Location = new System.Drawing.Point(0, 6);
			this.lblProductID.Name = "lblProductID";
			this.lblProductID.Size = new System.Drawing.Size(62, 13);
			this.lblProductID.TabIndex = 62;
			this.lblProductID.Text = "Product ID";
			this.lblProductID.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblBarcode
			// 
			this.lblBarcode.Location = new System.Drawing.Point(0, 57);
			this.lblBarcode.Name = "lblBarcode";
			this.lblBarcode.Size = new System.Drawing.Size(62, 13);
			this.lblBarcode.TabIndex = 61;
			this.lblBarcode.Text = "Barcode";
			this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBarcode
			// 
			this.txtBarcode.Location = new System.Drawing.Point(66, 54);
			this.txtBarcode.MaxLength = 13;
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(85, 20);
			this.txtBarcode.TabIndex = 63;
			this.txtBarcode.TextChanged += new System.EventHandler(this.ULongFields_TextChanged);
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(66, 80);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(85, 20);
			this.txtPrice.TabIndex = 63;
			this.txtPrice.TextChanged += new System.EventHandler(this.UnsignedDoubleFields_TextChanged);
			// 
			// txtProductID
			// 
			this.txtProductID.Location = new System.Drawing.Point(66, 3);
			this.txtProductID.MaxLength = 15;
			this.txtProductID.Name = "txtProductID";
			this.txtProductID.Size = new System.Drawing.Size(85, 20);
			this.txtProductID.TabIndex = 63;
			// 
			// btnAutoProductID
			// 
			this.btnAutoProductID.Location = new System.Drawing.Point(106, 29);
			this.btnAutoProductID.Name = "btnAutoProductID";
			this.btnAutoProductID.Size = new System.Drawing.Size(45, 19);
			this.btnAutoProductID.TabIndex = 65;
			this.btnAutoProductID.TabStop = false;
			this.btnAutoProductID.Text = "Auto?";
			this.btnAutoProductID.UseVisualStyleBackColor = true;
			this.btnAutoProductID.Click += new System.EventHandler(this.BtnAutoProductID_Click);
			// 
			// lblPrice
			// 
			this.lblPrice.Location = new System.Drawing.Point(0, 83);
			this.lblPrice.Name = "lblPrice";
			this.lblPrice.Size = new System.Drawing.Size(60, 13);
			this.lblPrice.TabIndex = 64;
			this.lblPrice.Text = "Price";
			this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbxProductName
			// 
			this.gbxProductName.Controls.Add(this.label1);
			this.gbxProductName.Controls.Add(this.label2);
			this.gbxProductName.Controls.Add(this.label3);
			this.gbxProductName.Controls.Add(this.txtProductName);
			this.gbxProductName.Controls.Add(this.txtProductNameZHHK);
			this.gbxProductName.Controls.Add(this.txtProductNameZHCN);
			this.gbxProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxProductName.Location = new System.Drawing.Point(0, 0);
			this.gbxProductName.Margin = new System.Windows.Forms.Padding(0);
			this.gbxProductName.Name = "gbxProductName";
			this.gbxProductName.Size = new System.Drawing.Size(176, 106);
			this.gbxProductName.TabIndex = 66;
			this.gbxProductName.TabStop = false;
			this.gbxProductName.Text = "Product Name";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Pink;
			this.label1.Location = new System.Drawing.Point(6, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 33;
			this.label1.Text = "中国中文";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.LightGreen;
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 17);
			this.label2.TabIndex = 33;
			this.label2.Text = "香港中文";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.LightBlue;
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 17);
			this.label3.TabIndex = 33;
			this.label3.Text = "English";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtProductName
			// 
			this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProductName.Location = new System.Drawing.Point(72, 19);
			this.txtProductName.MaxLength = 100;
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(92, 20);
			this.txtProductName.TabIndex = 34;
			// 
			// txtProductNameZHHK
			// 
			this.txtProductNameZHHK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProductNameZHHK.Location = new System.Drawing.Point(72, 45);
			this.txtProductNameZHHK.MaxLength = 100;
			this.txtProductNameZHHK.Name = "txtProductNameZHHK";
			this.txtProductNameZHHK.Size = new System.Drawing.Size(92, 20);
			this.txtProductNameZHHK.TabIndex = 35;
			// 
			// txtProductNameZHCN
			// 
			this.txtProductNameZHCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProductNameZHCN.Location = new System.Drawing.Point(72, 71);
			this.txtProductNameZHCN.MaxLength = 100;
			this.txtProductNameZHCN.Name = "txtProductNameZHCN";
			this.txtProductNameZHCN.Size = new System.Drawing.Size(92, 20);
			this.txtProductNameZHCN.TabIndex = 36;
			// 
			// gbxDescription
			// 
			this.gbxDescription.Controls.Add(this.lblZHCN);
			this.gbxDescription.Controls.Add(this.lblDescZHHK);
			this.gbxDescription.Controls.Add(this.lblDescEN);
			this.gbxDescription.Controls.Add(this.txtDescription);
			this.gbxDescription.Controls.Add(this.txtDescriptionZHHK);
			this.gbxDescription.Controls.Add(this.txtDescriptionZHCN);
			this.gbxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxDescription.Location = new System.Drawing.Point(0, 0);
			this.gbxDescription.Name = "gbxDescription";
			this.gbxDescription.Size = new System.Drawing.Size(336, 97);
			this.gbxDescription.TabIndex = 52;
			this.gbxDescription.TabStop = false;
			this.gbxDescription.Text = "Description";
			// 
			// lblZHCN
			// 
			this.lblZHCN.BackColor = System.Drawing.Color.Pink;
			this.lblZHCN.Location = new System.Drawing.Point(6, 74);
			this.lblZHCN.Name = "lblZHCN";
			this.lblZHCN.Size = new System.Drawing.Size(60, 17);
			this.lblZHCN.TabIndex = 33;
			this.lblZHCN.Text = "中国中文";
			this.lblZHCN.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblDescZHHK
			// 
			this.lblDescZHHK.BackColor = System.Drawing.Color.LightGreen;
			this.lblDescZHHK.Location = new System.Drawing.Point(6, 48);
			this.lblDescZHHK.Name = "lblDescZHHK";
			this.lblDescZHHK.Size = new System.Drawing.Size(60, 17);
			this.lblDescZHHK.TabIndex = 33;
			this.lblDescZHHK.Text = "香港中文";
			this.lblDescZHHK.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblDescEN
			// 
			this.lblDescEN.BackColor = System.Drawing.Color.LightBlue;
			this.lblDescEN.Location = new System.Drawing.Point(6, 22);
			this.lblDescEN.Name = "lblDescEN";
			this.lblDescEN.Size = new System.Drawing.Size(60, 17);
			this.lblDescEN.TabIndex = 33;
			this.lblDescEN.Text = "English";
			this.lblDescEN.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(72, 19);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(258, 20);
			this.txtDescription.TabIndex = 34;
			// 
			// txtDescriptionZHHK
			// 
			this.txtDescriptionZHHK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescriptionZHHK.Location = new System.Drawing.Point(72, 45);
			this.txtDescriptionZHHK.Name = "txtDescriptionZHHK";
			this.txtDescriptionZHHK.Size = new System.Drawing.Size(258, 20);
			this.txtDescriptionZHHK.TabIndex = 35;
			// 
			// txtDescriptionZHCN
			// 
			this.txtDescriptionZHCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescriptionZHCN.Location = new System.Drawing.Point(72, 71);
			this.txtDescriptionZHCN.Name = "txtDescriptionZHCN";
			this.txtDescriptionZHCN.Size = new System.Drawing.Size(258, 20);
			this.txtDescriptionZHCN.TabIndex = 36;
			// 
			// sptPackagingInfoAndQuantity
			// 
			this.sptPackagingInfoAndQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sptPackagingInfoAndQuantity.IsSplitterFixed = true;
			this.sptPackagingInfoAndQuantity.Location = new System.Drawing.Point(0, 0);
			this.sptPackagingInfoAndQuantity.Name = "sptPackagingInfoAndQuantity";
			this.sptPackagingInfoAndQuantity.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// sptPackagingInfoAndQuantity.Panel1
			// 
			this.sptPackagingInfoAndQuantity.Panel1.Controls.Add(this.groupBox1);
			// 
			// sptPackagingInfoAndQuantity.Panel2
			// 
			this.sptPackagingInfoAndQuantity.Panel2.Controls.Add(this.gbxQuantityUnit);
			this.sptPackagingInfoAndQuantity.Size = new System.Drawing.Size(172, 207);
			this.sptPackagingInfoAndQuantity.SplitterDistance = 106;
			this.sptPackagingInfoAndQuantity.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtPackagingInfo);
			this.groupBox1.Controls.Add(this.txtPackagingInfoZHHK);
			this.groupBox1.Controls.Add(this.txtPackagingInfoZHCN);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(172, 106);
			this.groupBox1.TabIndex = 51;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Per-item packaging info";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Pink;
			this.label4.Location = new System.Drawing.Point(6, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 17);
			this.label4.TabIndex = 33;
			this.label4.Text = "中国中文";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.LightGreen;
			this.label5.Location = new System.Drawing.Point(6, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 17);
			this.label5.TabIndex = 33;
			this.label5.Text = "香港中文";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.LightBlue;
			this.label6.Location = new System.Drawing.Point(6, 22);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 17);
			this.label6.TabIndex = 33;
			this.label6.Text = "English";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtPackagingInfo
			// 
			this.txtPackagingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPackagingInfo.Location = new System.Drawing.Point(72, 19);
			this.txtPackagingInfo.Name = "txtPackagingInfo";
			this.txtPackagingInfo.Size = new System.Drawing.Size(77, 20);
			this.txtPackagingInfo.TabIndex = 34;
			// 
			// txtPackagingInfoZHHK
			// 
			this.txtPackagingInfoZHHK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPackagingInfoZHHK.Location = new System.Drawing.Point(72, 45);
			this.txtPackagingInfoZHHK.Name = "txtPackagingInfoZHHK";
			this.txtPackagingInfoZHHK.Size = new System.Drawing.Size(77, 20);
			this.txtPackagingInfoZHHK.TabIndex = 35;
			// 
			// txtPackagingInfoZHCN
			// 
			this.txtPackagingInfoZHCN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPackagingInfoZHCN.Location = new System.Drawing.Point(72, 71);
			this.txtPackagingInfoZHCN.Name = "txtPackagingInfoZHCN";
			this.txtPackagingInfoZHCN.Size = new System.Drawing.Size(77, 20);
			this.txtPackagingInfoZHCN.TabIndex = 36;
			// 
			// gbxQuantityUnit
			// 
			this.gbxQuantityUnit.Controls.Add(this.txtQuantity);
			this.gbxQuantityUnit.Controls.Add(this.label7);
			this.gbxQuantityUnit.Controls.Add(this.label10);
			this.gbxQuantityUnit.Controls.Add(this.label8);
			this.gbxQuantityUnit.Controls.Add(this.label9);
			this.gbxQuantityUnit.Controls.Add(this.txtUnit);
			this.gbxQuantityUnit.Controls.Add(this.txtUnitZHHK);
			this.gbxQuantityUnit.Controls.Add(this.txtUnitZHCN);
			this.gbxQuantityUnit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbxQuantityUnit.Location = new System.Drawing.Point(0, 0);
			this.gbxQuantityUnit.Name = "gbxQuantityUnit";
			this.gbxQuantityUnit.Size = new System.Drawing.Size(172, 97);
			this.gbxQuantityUnit.TabIndex = 51;
			this.gbxQuantityUnit.TabStop = false;
			this.gbxQuantityUnit.Text = "Quantity";
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(6, 49);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(50, 20);
			this.txtQuantity.TabIndex = 37;
			this.txtQuantity.TextChanged += new System.EventHandler(this.UInt32Fields_TextChanged);
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Pink;
			this.label7.Location = new System.Drawing.Point(62, 75);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 13);
			this.label7.TabIndex = 33;
			this.label7.Text = "单位:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 33);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(37, 13);
			this.label10.TabIndex = 33;
			this.label10.Text = "Value:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.LightGreen;
			this.label8.Location = new System.Drawing.Point(62, 49);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 13);
			this.label8.TabIndex = 33;
			this.label8.Text = "單位:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.LightBlue;
			this.label9.Location = new System.Drawing.Point(62, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(34, 13);
			this.label9.TabIndex = 33;
			this.label9.Text = "Unit:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtUnit
			// 
			this.txtUnit.Location = new System.Drawing.Point(102, 20);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(54, 20);
			this.txtUnit.TabIndex = 34;
			// 
			// txtUnitZHHK
			// 
			this.txtUnitZHHK.Location = new System.Drawing.Point(102, 46);
			this.txtUnitZHHK.Name = "txtUnitZHHK";
			this.txtUnitZHHK.Size = new System.Drawing.Size(54, 20);
			this.txtUnitZHHK.TabIndex = 35;
			// 
			// txtUnitZHCN
			// 
			this.txtUnitZHCN.Location = new System.Drawing.Point(102, 72);
			this.txtUnitZHCN.Name = "txtUnitZHCN";
			this.txtUnitZHCN.Size = new System.Drawing.Size(54, 20);
			this.txtUnitZHCN.TabIndex = 36;
			// 
			// ofdProductImage
			// 
			this.ofdProductImage.FileName = "Load a image of product";
			this.ofdProductImage.Filter = "Supported Image Formats (*.bmp;*.gif;*.jpg;*.png;*.jpeg;*.tif;*.tiff;)|*.bmp;*.gi" +
			"f;*.jpg;*.png;*.jpeg;*.tif;*.tiff;|All files (*.*)|*.*";
			// 
			// cbxCategory
			// 
			this.cbxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.cbxCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbxCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxCategory.FormattingEnabled = true;
			this.cbxCategory.Location = new System.Drawing.Point(0, 0);
			this.cbxCategory.Name = "cbxCategory";
			this.cbxCategory.Size = new System.Drawing.Size(273, 21);
			this.cbxCategory.TabIndex = 1;
			this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.CbxCategory_SelectedIndexChanged);
			// 
			// cbxSubCategory
			// 
			this.cbxSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.cbxSubCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbxSubCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbxSubCategory.FormattingEnabled = true;
			this.cbxSubCategory.Location = new System.Drawing.Point(0, 0);
			this.cbxSubCategory.Name = "cbxSubCategory";
			this.cbxSubCategory.Size = new System.Drawing.Size(274, 21);
			this.cbxSubCategory.TabIndex = 1;
			// 
			// btnManageCategory
			// 
			this.btnManageCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnManageCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnManageCategory.Location = new System.Drawing.Point(279, -1);
			this.btnManageCategory.Name = "btnManageCategory";
			this.btnManageCategory.Size = new System.Drawing.Size(30, 21);
			this.btnManageCategory.TabIndex = 49;
			this.btnManageCategory.Text = ",,,";
			this.btnManageCategory.UseVisualStyleBackColor = true;
			// 
			// btnManageSubCategory
			// 
			this.btnManageSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnManageSubCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.btnManageSubCategory.Location = new System.Drawing.Point(282, -1);
			this.btnManageSubCategory.Name = "btnManageSubCategory";
			this.btnManageSubCategory.Size = new System.Drawing.Size(30, 21);
			this.btnManageSubCategory.TabIndex = 49;
			this.btnManageSubCategory.Text = ",,,";
			this.btnManageSubCategory.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(108, 46);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.cbxCategory);
			this.splitContainer1.Panel1.Controls.Add(this.btnManageCategory);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.cbxSubCategory);
			this.splitContainer1.Panel2.Controls.Add(this.btnManageSubCategory);
			this.splitContainer1.Size = new System.Drawing.Size(625, 23);
			this.splitContainer1.SplitterDistance = 309;
			this.splitContainer1.TabIndex = 37;
			// 
			// ucAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.sptProductInfosAndPackagingQuantity);
			this.Controls.Add(this.sptDiscountAndUsages);
			this.Controls.Add(this.pnlProductImage);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lblCal);
			this.Controls.Add(this.lblDetailTitle);
			this.DoubleBuffered = true;
			this.Name = "ucAdd";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(746, 456);
			this.Load += new System.EventHandler(this.UcAdd_Load);
			this.gbxDiscount.ResumeLayout(false);
			this.gbxShelfUsage.ResumeLayout(false);
			this.gbxInShopWarehouse.ResumeLayout(false);
			this.pnlProductImage.ResumeLayout(false);
			this.pnlProductImage.PerformLayout();
			this.sptDiscountAndUsages.Panel1.ResumeLayout(false);
			this.sptDiscountAndUsages.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sptDiscountAndUsages)).EndInit();
			this.sptDiscountAndUsages.ResumeLayout(false);
			this.sptShelfUsageAndInShopWarehouseUsage.Panel1.ResumeLayout(false);
			this.sptShelfUsageAndInShopWarehouseUsage.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sptShelfUsageAndInShopWarehouseUsage)).EndInit();
			this.sptShelfUsageAndInShopWarehouseUsage.ResumeLayout(false);
			this.sptProductInfosAndPackagingQuantity.Panel1.ResumeLayout(false);
			this.sptProductInfosAndPackagingQuantity.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sptProductInfosAndPackagingQuantity)).EndInit();
			this.sptProductInfosAndPackagingQuantity.ResumeLayout(false);
			this.sptProductInfoAndDescription.Panel1.ResumeLayout(false);
			this.sptProductInfoAndDescription.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sptProductInfoAndDescription)).EndInit();
			this.sptProductInfoAndDescription.ResumeLayout(false);
			this.sptProductBasicInfoAndProductName.Panel1.ResumeLayout(false);
			this.sptProductBasicInfoAndProductName.Panel1.PerformLayout();
			this.sptProductBasicInfoAndProductName.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sptProductBasicInfoAndProductName)).EndInit();
			this.sptProductBasicInfoAndProductName.ResumeLayout(false);
			this.gbxProductName.ResumeLayout(false);
			this.gbxProductName.PerformLayout();
			this.gbxDescription.ResumeLayout(false);
			this.gbxDescription.PerformLayout();
			this.sptPackagingInfoAndQuantity.Panel1.ResumeLayout(false);
			this.sptPackagingInfoAndQuantity.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sptPackagingInfoAndQuantity)).EndInit();
			this.sptPackagingInfoAndQuantity.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbxQuantityUnit.ResumeLayout(false);
			this.gbxQuantityUnit.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnImageClear;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.OpenFileDialog ofdProductImage;
		private System.Windows.Forms.ColumnHeader colMinByPrice;
		private System.Windows.Forms.ColumnHeader colMinQuantities;
		private System.Windows.Forms.ColumnHeader colExisting;
		private System.Windows.Forms.ColumnHeader colDiscountOperation;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.SplitContainer sptPackagingInfoAndQuantity;
		private System.Windows.Forms.SplitContainer sptProductInfosAndPackagingQuantity;
		private System.Windows.Forms.SplitContainer sptProductInfoAndDescription;
		private System.Windows.Forms.SplitContainer sptProductBasicInfoAndProductName;
		private System.Windows.Forms.SplitContainer sptShelfUsageAndInShopWarehouseUsage;
		private System.Windows.Forms.SplitContainer sptDiscountAndUsages;
		private System.Windows.Forms.Label lblImage;
		private System.Windows.Forms.Button btnImageChange;
		private System.Windows.Forms.Panel pnlProductImage;
		private System.Windows.Forms.ColumnHeader colWorkplace;
		private System.Windows.Forms.ColumnHeader colInShopWarehouse;
		private System.Windows.Forms.ColumnHeader colWkPlcName;
		private System.Windows.Forms.ColumnHeader colOnShelf;
		private System.Windows.Forms.Button btnInShopWarehouseUsageAddEdit;
		private System.Windows.Forms.Button btnInShopWarehouseUsageDelete;
		private System.Windows.Forms.ListView lsvInShopWarehouseUsage;
		private System.Windows.Forms.Button btnShelfUsageAddEdit;
		private System.Windows.Forms.Button btnShelfUsageDelete;
		private System.Windows.Forms.ListView lsvShelfUsage;
		private System.Windows.Forms.Button btnDiscountsAdd;
		private System.Windows.Forms.Button btnDiscountsDelete;
		private System.Windows.Forms.ListView lsvDiscounts;
		private System.Windows.Forms.GroupBox gbxInShopWarehouse;
		private System.Windows.Forms.GroupBox gbxShelfUsage;
		private System.Windows.Forms.GroupBox gbxDiscount;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtUnitZHCN;
		private System.Windows.Forms.TextBox txtUnitZHHK;
		private System.Windows.Forms.TextBox txtUnit;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox gbxQuantityUnit;
		private System.Windows.Forms.TextBox txtPackagingInfoZHCN;
		private System.Windows.Forms.TextBox txtPackagingInfoZHHK;
		private System.Windows.Forms.TextBox txtPackagingInfo;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtProductNameZHCN;
		private System.Windows.Forms.TextBox txtProductNameZHHK;
		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gbxProductName;
		private System.Windows.Forms.Label lblZHCN;
		private System.Windows.Forms.Label lblDescZHHK;
		private System.Windows.Forms.GroupBox gbxDescription;
		private System.Windows.Forms.Button btnAutoProductID;
		private System.Windows.Forms.ComboBox cbxSubCategory;
		private System.Windows.Forms.Button btnManageSubCategory;
		private System.Windows.Forms.Button btnManageCategory;
		private System.ComponentModel.BackgroundWorker bgwLoadListsOnStart;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label lblDetailTitle;
		private System.Windows.Forms.Label lblProductID;
		private System.Windows.Forms.Label lblBarcode;
		private System.Windows.Forms.TextBox txtProductID;
		private System.Windows.Forms.Label lblPrice;
		private System.Windows.Forms.Label lblDescEN;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtDescriptionZHHK;
		private System.Windows.Forms.TextBox txtDescriptionZHCN;
		private System.Windows.Forms.ComboBox cbxCategory;
		private System.Windows.Forms.Label lblCal;
	}
}
