/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 7:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	/// <summary>
	/// Description of ucAdd.
	/// </summary>
	public partial class ucAdd : UserControl
	{
		// local variable
		private Thread thrLoadCategory;
		private Thread thrLoadSubCategory;
		private DiscountCollection addDiscountCollection = new DiscountCollection();
		private Dictionary<string, string> _old_values = new Dictionary<string, string>();
		
		// delegate
		private delegate void RunOnUIThreadDelegate();
		
		// ctor
		public ucAdd()
		{
			InitializeComponent();
		}
		
		// method
		// event handler
		#region on form load
		private void UcAdd_Load(object sender, EventArgs e)
		{
			this.bgwLoadListsOnStart.RunWorkerAsync();
			#if DEBUG
//			this.txtBarcode.Text = "5410228141327";
//			this.txtPrice.Text = "16.5";
//			this.txtProductName.Text = "Stella Artois";
//			this.txtProductNameZHHK.Text = "時代啤酒";
//			this.txtProductNameZHCN.Text = "时代啤酒";
//			this.txtDescription.Text = "Belgium Stella Artois Beer (Standard Version)";
//			this.txtDescriptionZHHK.Text = "比利時時代啤酒啤酒（標準版）";
//			this.txtDescriptionZHCN.Text = "比利时时代啤酒啤酒（标准版）";
//			this.txtPackagingInfo.Text = "60 cl";
//			this.txtPackagingInfoZHHK.Text = "60 厘升";
//			this.txtPackagingInfoZHCN.Text = "60 厘升";
//			this.txtQuantity.Text = "50";
//			this.txtUnit.Text = "box";
//			this.txtUnitZHHK.Text = "箱";
//			this.txtUnitZHCN.Text = "箱";
			#endif
		}
		
		private void BgwLoadListsOnStart_DoWork(object sender, DoWorkEventArgs e)
		{
			// category
			thrLoadCategory = new Thread(new ThreadStart(LoadCategoriesToUI));
			thrLoadCategory.Start();
			thrLoadCategory.Join();
			
			// sub-category
		}
		#endregion
		
		#region methods to load category lists
		private void LoadCategoriesToUI()
		{
			bool originalEnabled = false;
			
			this.Invoke(new RunOnUIThreadDelegate(delegate {
			                                      	originalEnabled = this.cbxCategory.Enabled;
			                                      	this.cbxCategory.Enabled = false;
			                                      	this.cbxCategory.Text = "(Loading...)";
			                                      }));
			
			DataTable dtbCategory = null;
			try {
				OleDbCommand cmdSelectCategory = new OleDbCommand("SELECT categoryID, name & ' ' & name_ZHHK & ' ' & name_ZHCN AS names_concat FROM Category");
				dtbCategory = DatabaseCommunicator.SelectFromTable(cmdSelectCategory);
			} catch (Exception) {
			}
			
			this.Invoke(new RunOnUIThreadDelegate(delegate {
			                                      	this.cbxCategory.Text = "";
			                                      	this.cbxCategory.Enabled = originalEnabled;
									            	if (dtbCategory != null) {
														this.cbxCategory.DataSource = dtbCategory;
														this.cbxCategory.DisplayMember = "names_concat";
														this.cbxCategory.ValueMember = "categoryID";
													} else {
														this.cbxCategory.Text = "Error loading Category list from databse";
														this.cbxCategory.BackColor = Color.Red;
														this.cbxCategory.ForeColor = Color.White;
													}
			                                      }));
		}
		
		private void LoadSubCategoriesToUI()
		{
			bool originalEnabled = false;
			
			this.Invoke(new RunOnUIThreadDelegate(delegate {
			                                      	originalEnabled = this.cbxCategory.Enabled;
			                                      	this.cbxSubCategory.Enabled = false;
			                                      	this.cbxSubCategory.Text = "(Loading...)";
			                                      }));
			
			string selectedSubCategory = "";
			this.Invoke(new RunOnUIThreadDelegate(delegate { selectedSubCategory = (string)this.cbxCategory.SelectedValue; }));
			
			DataTable dtbSubCategory = null;
			try {
				OleDbCommand cmdSelectSubCategory = new OleDbCommand("SELECT subCategoryID, name & ' ' & name_ZHHK & ' ' & name_ZHCN AS names_concat FROM SubCategory WHERE categoryID = @categoryID");
				cmdSelectSubCategory.Parameters.AddWithValue("@categoryID", selectedSubCategory);
				dtbSubCategory = DatabaseCommunicator.SelectFromTable(cmdSelectSubCategory);
				
			} catch (Exception) {
			}
			
			this.Invoke(new RunOnUIThreadDelegate(delegate {
			                                      	this.cbxSubCategory.Text = "";
			                                      	this.cbxSubCategory.Enabled = originalEnabled;
									            	if (dtbSubCategory != null) {
														this.cbxSubCategory.DataSource = dtbSubCategory;
														this.cbxSubCategory.DisplayMember = "names_concat";
														this.cbxSubCategory.ValueMember = "subCategoryID";
													} else {
														this.cbxSubCategory.Text = "Error loading Sub-Category list from databse";
														this.cbxSubCategory.BackColor = Color.Red;
														this.cbxSubCategory.ForeColor = Color.White;
													}
			                                      }));
		}
		#endregion
		
		#region field Save or Clear eventhandlers and related methods
		private void BtnAddClick(object sender, EventArgs e)
		{
			DlgConfirm dlgConfirm = new DlgConfirm();
			if (dlgConfirm.ShowDialog(this.ParentForm) == DialogResult.OK) {
				// hahahahahahahaha (24567111
				int steps = 2 + this.lsvDiscounts.Items.Count + this.lsvShelfUsage.Items.Count + this.lsvInShopWarehouseUsage.Items.Count + (this.pnlProductImage.BackgroundImage != null ? 1 : 0);
				Dictionary<string, string> sqlRevertDictionary = new Dictionary<string, string>();
				FrmLoading frmLoading = new FrmLoading("Validating completeness of fields", ProgressBarStyle.Continuous, true, false);
				this.BeginInvoke(new FrmLoading.RunWithNotBlockingThisThreadDelegate(delegate { frmLoading.ShowDialog(this.ParentForm); }));
				
				SetFieldsEnabled(false);
				#region validate field completeness
				{
					List<string> err = new List<string>();
					
					// cbxCategory
					if (this.cbxCategory.SelectedIndex == -1) err.Add("No category is selected.");
					
					// cbxSubCategory
					if (this.cbxSubCategory.SelectedIndex == -1) err.Add("No sub-category is selected.");
					
					// txtProductID
					if (this.txtProductID.Text.Length == 0) err.Add("ProductID is blank.");
					
					// txmBarcode
					if (this.txtBarcode.Text.Length == 0) err.Add("Barcode is blank.");
					
					// txtPrice
					if (this.txtPrice.Text.Length == 0) err.Add("Price is blank.");
					
					// txtProductName
					if (this.txtProductName.Text.Length == 0) err.Add("Product name (English) is blank.");
					
					// txtProductNameZHHK
//					if (this.txtProductNameZHHK.Text.Length == 0) err.Add("Product name (香港中文) is blank.");
					
					// txtProductNameZHCN
//					if (this.txtProductNameZHCN.Text.Length == 0) err.Add("Product name (中国中文) is blank.");
					
					// txtDescription
					if (this.txtDescription.Text.Length == 0) err.Add("Description (English) is blank.");
					
					// txtDescriptionZHHK
//					if (this.txtDescriptionZHHK.Text.Length == 0) err.Add("Description (香港中文) is blank.");
					
					// txtDescriptionZHCN
//					if (this.txtDescriptionZHCN.Text.Length == 0) err.Add("Description (中国中文) is blank.");
					
					// txtPackagingInfo
					if (this.txtPackagingInfo.Text.Length == 0) err.Add("Packaging info (English) is blank.");
					
					// txtPackagingInfoZHHK
//					if (this.txtPackagingInfoZHHK.Text.Length == 0) err.Add("Packaging info (香港中文) is blank.");
					
					// txtPackagingInfoZHCN
//					if (this.txtPackagingInfoZHCN.Text.Length == 0) err.Add("Packaging info (中国中文) is blank.");
					
					// txtQuantity
					if (this.txtQuantity.Text.Length == 0) err.Add("Quantity is blank.");
					
					// txtUnit
					if (this.txtUnit.Text.Length == 0) err.Add("Unit (English) is blank.");
					
					// txtUnitZHHK
//					if (this.txtUnitZHHK.Text.Length == 0) err.Add("Unit (香港中文) is blank.");
					
					// txtUnitZHCN
//					if (this.txtUnitZHCN.Text.Length == 0) err.Add("Unit (中国中文) is blank.");
					
					
					// output error and reject operation
					if (err.Count > 0) {
						string errContext = "";
						bool first = true;
						foreach (string s in err) {
							errContext += (first ? "" : "\r\n") + s;
							first = false;
						}
						
						this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
						MessageBox.Show("Fields are incomplete: \r\n\r\n" + errContext + "\r\n\r\nPlease check your field if it's complete before continue.",
						                "Incomplete fields", 
						                MessageBoxButtons.OK,
						                MessageBoxIcon.Warning);
						SetFieldsEnabled(true);
						return;
					}
				}
				#endregion
				
				frmLoading.Value += 100 / steps;
				frmLoading.Title = "Inserting new Product record into database...";
				
				// if no err -> continue
				#region INSERT INTO Product
				{
					OleDbCommand cmdNewProduct = new OleDbCommand("INSERT INTO Product (" + Product.SQLAllRequiredColumnsInsert + ") VALUES (" + Product.SQLAllRequiredValuesInsertAttribute + ")");
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtProductID.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtBarcode.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtProductName.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtProductNameZHHK.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtProductNameZHCN.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtDescription.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtDescriptionZHHK.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtProductNameZHCN.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtPackagingInfo.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtPackagingInfoZHHK.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtPackagingInfoZHCN.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", Int32.Parse(this.txtQuantity.Text)));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtUnit.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtUnitZHHK.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", this.txtUnitZHCN.Text));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", Double.Parse(this.txtPrice.Text)));
					cmdNewProduct.Parameters.Add(new OleDbParameter("?", (string)this.cbxSubCategory.SelectedValue));
					
					if (DatabaseCommunicator.InsertIntoTable(cmdNewProduct) != 1) {
						this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
						MessageBox.Show("Error whilst inserting new Product record. \r\n\r\nOperation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						SetFieldsEnabled(true);
						return;
					}
				}
				#endregion
				
				frmLoading.Value += 100 / steps;
				
				#region INSERT INTO Discount (INSERT INTO DiscountOperation)
				{
					int added = 0;
					foreach (KeyValuePair<string, Discount> item in addDiscountCollection) {
						frmLoading.Title = "Inserting new Discount Operation record into database... (new from record " + (added + 1) + " of " + addDiscountCollection.Count + ")";
						
						Discount ad = item.Value;
						// INSERT INTO DiscountOperation
						if (!ad.LinkedDiscountOperation.UseExisting) {
							if (!DatabaseCommunicator.Inserter.InsertDiscountOperation(ad.LinkedDiscountOperation)) {
								MessageBox.Show("Error whilst inserting new Discount Operation record \"" + ad.LinkedDiscountOperation.DiscountID + "\". \r\n\r\n"
							                	+ "Operation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
						}
						
						frmLoading.Title = "Inserting new Discount record into database... (" + (added + 1) + " of " + addDiscountCollection.Count + ")";
						
						if (!DatabaseCommunicator.Inserter.InsertDiscount(ad, this.txtProductID.Text)) {
							this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
							MessageBox.Show("Error whilst inserting new Discount (linking to a product) record \"" + ad.LinkedDiscountOperation.DiscountID + "\". \r\n\r\n"
							                + "Operation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							SetFieldsEnabled(true);
							return;
						}
						
						frmLoading.Value += 100 / steps;
						added++;
					}
				}
				#endregion
				
				#region shelf usage
				{
					int added = 0;
					foreach (ListViewItem item in this.lsvShelfUsage.Items) {
						frmLoading.Title = "Inserting new Shelf Usage record into database... (" + (added + 1) + " of " + this.lsvShelfUsage.Items.Count + ")";
						
						if (!DatabaseCommunicator.Inserter.InsertShelfUsage(this.txtProductID.Text, item.Text)) {
							this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
							MessageBox.Show("Error whilst inserting new Shelf Usage record \"" + item.Text + "\". \r\n\r\n"
							                + "Operation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							SetFieldsEnabled(true);
							return;
						}
						
						frmLoading.Value += 100 / steps;
					}
				}
				#endregion
				
				#region in-shop warehouse usage
				{
					int added = 0;
					foreach (ListViewItem item in this.lsvInShopWarehouseUsage.Items) {
						frmLoading.Title = "Inserting new Shelf Usage record into database... (" + (added + 1) + " of " + this.lsvInShopWarehouseUsage.Items.Count + ")";
						
						if (!DatabaseCommunicator.Inserter.InsertInShopWarehouseUsage(this.txtProductID.Text, item.Text)) {
							this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
							MessageBox.Show("Error whilst inserting new In-shop Warehouse Usage record \"" + item.Text + "\". \r\n\r\n"
							                + "Operation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							SetFieldsEnabled(true);
							return;
						}
						
						frmLoading.Value += 100 / steps;
					}
				}
				#endregion
				
				#region image of product
				if (this.pnlProductImage.BackgroundImage == null) {
					ProductImageStorage.CleanUpImage(this.txtProductID.Text);
				} else {
					frmLoading.Title = "Saving image of product into product image datastore...";
					if (!ProductImageStorage.SaveImage(this.pnlProductImage.BackgroundImage, this.txtProductID.Text)) {
						this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
						MessageBox.Show("Error whilst saving product image into Product Image Data Store. \r\n\r\nOperation aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						SetFieldsEnabled(true);
						return;
					}
				}
				#endregion
				
				frmLoading.Title = "Complete";
				frmLoading.Value = 100;
				ClearFields();
				SetFieldsEnabled(true);
				this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); }));
				System.Media.SystemSounds.Question.Play();
				MessageBox.Show("Operation successful. All records are saved into database.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		private void BtnClearClick(object sender, EventArgs e)
		{
			ClearFields();
		}
		
		private void SetFieldsEnabled(bool enable)
		{
			this.cbxCategory.Enabled = enable;
			this.cbxSubCategory.Enabled = enable;
			this.txtProductID.Enabled = enable;
			this.btnAutoProductID.Enabled = enable;
			this.txtBarcode.Enabled = enable;
			this.txtPrice.Enabled = enable;
			this.txtProductName.Enabled = enable;
			this.txtProductNameZHHK.Enabled = enable;
			this.txtProductNameZHCN.Enabled = enable;
			this.txtDescription.Enabled = enable;
			this.txtDescriptionZHHK.Enabled = enable;
			this.txtDescriptionZHCN.Enabled = enable;
			this.txtPackagingInfo.Enabled = enable;
			this.txtPackagingInfoZHHK.Enabled = enable;
			this.txtPackagingInfoZHCN.Enabled = enable;
			this.txtQuantity.Enabled = enable;
			this.txtUnit.Enabled = enable;
			this.txtUnitZHHK.Enabled = enable;
			this.txtUnitZHCN.Enabled = enable;
			this.lsvDiscounts.Enabled = enable;
			this.btnDiscountsAdd.Enabled = enable;
			this.btnDiscountsDelete.Enabled = enable;
			this.btnShelfUsageAddEdit.Enabled = enable;
			this.btnShelfUsageDelete.Enabled = enable;
			this.btnInShopWarehouseUsageAddEdit.Enabled = enable;
			this.btnInShopWarehouseUsageDelete.Enabled = enable;
			this.btnImageChange.Enabled = enable;
			this.btnImageClear.Enabled = enable;
		}
		
		private void ClearFields()
		{
			this.cbxCategory.SelectedIndex = 0;
			this.cbxSubCategory.SelectedIndex = 0;
			this.txtProductID.Clear();
			this.txtBarcode.Clear();
			this.txtPrice.Clear();
			this.txtProductName.Clear();
			this.txtProductNameZHHK.Clear();
			this.txtProductNameZHCN.Clear();
			this.txtDescription.Clear();
			this.txtDescriptionZHHK.Clear();
			this.txtDescriptionZHCN.Clear();
			this.txtPackagingInfo.Clear();
			this.txtPackagingInfoZHHK.Clear();
			this.txtPackagingInfoZHCN.Clear();
			this.txtQuantity.Clear();
			this.txtUnit.Clear();
			this.txtUnitZHHK.Clear();
			this.txtUnitZHCN.Clear();
			this.lsvDiscounts.Clear();
			this.lsvShelfUsage.Clear();
			this.lsvInShopWarehouseUsage.Clear();
			this.pnlProductImage.BackgroundImage = null;
		}
		#endregion
		
		#region category / sub-category
		private void CbxCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (thrLoadSubCategory == null || !thrLoadSubCategory.IsAlive) {
				thrLoadSubCategory = new Thread(new ThreadStart(LoadSubCategoriesToUI));
				thrLoadSubCategory.Start();
			}
		}
		#endregion
		
		#region discount
		private void BtnDiscountsAddEdit_Click(object sender, EventArgs e)
		{
			FrmLoading frmLoading = new FrmLoading(false);
			this.BeginInvoke(new FrmLoading.RunWithNotBlockingThisThreadDelegate(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			DlgAddDiscountDetails dlgDiscountDetails = new DlgAddDiscountDetails();
			dlgDiscountDetails.Shown += delegate { this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); })); };
			if (dlgDiscountDetails.ShowDialog(this.ParentForm) == DialogResult.OK) {
				Discount newDiscount = dlgDiscountDetails.ResultDetails;
				
				if (addDiscountCollection.ContainsKey(newDiscount.LinkedDiscountOperation.DiscountID)) {
					MessageBox.Show("This product is already linked to a discountID:\""
					                + newDiscount.LinkedDiscountOperation.DiscountID
					                +"\".\r\n\r\n"
					                + "Hence, this discount info will not be added. Please try again. ", 
					                "Duplication of discountID", 
					                MessageBoxButtons.OK, 
					                MessageBoxIcon.Error);
					return;
				}
				
				// internal data storage
				addDiscountCollection.Add(newDiscount.LinkedDiscountOperation.DiscountID, newDiscount);
				
				// user interface
				ListViewItem lvi = new ListViewItem(newDiscount.LinkedDiscountOperation.DiscountID);
				lvi.SubItems.Add(newDiscount.LinkedDiscountOperation.UseExisting ? "\u2713" : "");
				lvi.SubItems.Add(newDiscount.Quantities + "");
				lvi.SubItems.Add(newDiscount.MinBuyPrice + "");
				this.lsvDiscounts.Items.Add(lvi);
			}
		}
		
		private void BtnDiscountsDelete_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.lsvDiscounts.SelectedItems) {
				// internal data storage
				addDiscountCollection.Remove(item.Text);
				
				// user interface
				this.lsvDiscounts.Items.Remove(item);
			}
		}
		#endregion
		
		#region shelf usage
		private void BtnShelfUsageAddEdit_Click(object sender, EventArgs e)
		{
			FrmLoading frmLoading = new FrmLoading(false);
			this.BeginInvoke(new FrmLoading.RunWithNotBlockingThisThreadDelegate(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			
			List<string> existingShelfUsage = new List<string>();
			foreach (ListViewItem item in this.lsvShelfUsage.Items) {
				existingShelfUsage.Add(item.Text);
			}
			
			DlgShelfUsage dlgShelfUsage = new DlgShelfUsage(existingShelfUsage);
			dlgShelfUsage.Shown += delegate { this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); })); };
			if (dlgShelfUsage.ShowDialog(this.ParentForm) == DialogResult.OK) {
				lsvShelfUsage.Items.Clear();
				
				foreach (DataRow row in dlgShelfUsage.SelectResultDataTable.Rows) {
					ListViewItem item = new ListViewItem((string)row["shelfLocation"]);
					item.SubItems.Add((string)row["wkPlcName"]);
					this.lsvShelfUsage.Items.Add(item);
				}
			}
		}
		
		private void BtnShelfUsageDelete_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.lsvShelfUsage.SelectedItems) {
				item.Remove();
			}
		}
		#endregion
		
		#region in-shop warehouse usage
		void BtnInShopWarehouseUsageAddEdit_Click(object sender, EventArgs e)
		{
			FrmLoading frmLoading = new FrmLoading(false);
			this.BeginInvoke(new FrmLoading.RunWithNotBlockingThisThreadDelegate(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			
			List<string> existingShelfUsage = new List<string>();
			foreach (ListViewItem item in this.lsvInShopWarehouseUsage.Items) {
				existingShelfUsage.Add(item.Text);
			}
			
			DlgInShopWarehouseUsage dlgInShopWarehouseUsage = new DlgInShopWarehouseUsage(existingShelfUsage);
			dlgInShopWarehouseUsage.Shown += delegate { this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); })); };
			if (dlgInShopWarehouseUsage.ShowDialog(this.ParentForm) == DialogResult.OK) {
				lsvInShopWarehouseUsage.Items.Clear();
				
				foreach (DataRow row in dlgInShopWarehouseUsage.SelectResultDataTable.Rows) {
					ListViewItem item = new ListViewItem((string)row["inShopWarehouseLoc"]);
					item.SubItems.Add((string)row["wkPlcName"]);
					this.lsvInShopWarehouseUsage.Items.Add(item);
				}
			}
		}
		
		private void BtnInShopWarehouseUsageDelete_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in this.lsvInShopWarehouseUsage.SelectedItems) {
				item.Remove();
			}
		}
		#endregion
		
		#region product image
		private void BtnImageChange_Click(object sender, EventArgs e)
		{
			if (this.ofdProductImage.ShowDialog() == DialogResult.OK) {
				Bitmap bmpProductImage = new Bitmap(this.ofdProductImage.FileName);
				this.pnlProductImage.BackgroundImage = bmpProductImage;
			}
		}
		
		private void BtnImageClear_Click(object sender, EventArgs e)
		{
			this.pnlProductImage.BackgroundImage = null;
		}
		#endregion
		
		#region auto assign product id
		private void BtnAutoProductID_Click(object sender, EventArgs e)
		{
			// SELECT MAX(productID) FROM Product WHERE productID LIKE 'BR*';
			string autoIDPrefix = (string)this.cbxSubCategory.SelectedValue;
			OleDbCommand cmdGetMaxProductID = new OleDbCommand("SELECT MAX(productID) FROM Product WHERE productID LIKE @like_productID");
			cmdGetMaxProductID.Parameters.AddWithValue("@like_productID", autoIDPrefix + "%");
			string maxIDInDatabase = autoIDPrefix + "00";
			Thread thrGetMaxProductID = new Thread(new ThreadStart(delegate {
			                                                       	try {
			                                                       		maxIDInDatabase = (string)DatabaseCommunicator.SelectSingleFromTable(cmdGetMaxProductID);
			                                                       	} catch (Exception) {
			                                                       		System.Media.SystemSounds.Beep.Play();
			                                                       		return;
			                                                       	}
			                                                       }));
			thrGetMaxProductID.Start();
			thrGetMaxProductID.Join();
			
			if (maxIDInDatabase.IndexOf(autoIDPrefix) == 0) {
				string indexOriginalString = maxIDInDatabase.Replace(autoIDPrefix, "");
				int index = 0;
				string indexStringFormat = "";
				
				foreach (char c in indexOriginalString) {
					if (c >= 48 && c <= 57)
						indexStringFormat += "0";
					else
						indexStringFormat += c.ToString();
				}
				
				if (Int32.TryParse(indexOriginalString, out index)) {
					this.txtProductID.Text = autoIDPrefix + "" + (++index).ToString(indexStringFormat);
				} else {
					System.Media.SystemSounds.Beep.Play();
				}
			} else {
				System.Media.SystemSounds.Beep.Play();
			}
		}
		#endregion
		
		private void UnsignedDoubleFields_TextChanged(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) {
				TextBox textbox = (TextBox)sender;
				
				// check data
				double x = 0;
				if (textbox.Text.Length > 0 && (!Double.TryParse(textbox.Text, out x) || x < 0)) {
					textbox.Text = _old_values.ContainsKey(textbox.Text) ? _old_values[textbox.Name] : "";
					return;
				}
				
				// record to history
				if (_old_values.ContainsKey(textbox.Name)) {
					_old_values[textbox.Name] = textbox.Text;
				} else {
					_old_values.Add(textbox.Name, textbox.Text);
				}
			}
		}
		
		private void UInt32Fields_TextChanged(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) {
				TextBox textbox = (TextBox)sender;
				
				// check data
				uint x = 0;
				if (textbox.Text.Length > 0 && !UInt32.TryParse(textbox.Text, out x)) {
					textbox.Text = _old_values.ContainsKey(textbox.Text) ? _old_values[textbox.Name] : "";
					return;
				}
				
				// record to history
				if (_old_values.ContainsKey(textbox.Name)) {
					_old_values[textbox.Name] = textbox.Text;
				} else {
					_old_values.Add(textbox.Name, textbox.Text);
				}
			}
		}
		
		private void ULongFields_TextChanged(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) {
				TextBox textbox = (TextBox)sender;
				
				// check data
				ulong x = 0;
				if (textbox.Text.Length > 0 && !UInt64.TryParse(textbox.Text, out x)) {
					textbox.Text = _old_values.ContainsKey(textbox.Text) ? _old_values[textbox.Name] : "";
					return;
				}
				
				// record to history
				if (_old_values.ContainsKey(textbox.Name)) {
					_old_values[textbox.Name] = textbox.Text;
				} else {
					_old_values.Add(textbox.Name, textbox.Text);
				}
			}
		}
	}
}
