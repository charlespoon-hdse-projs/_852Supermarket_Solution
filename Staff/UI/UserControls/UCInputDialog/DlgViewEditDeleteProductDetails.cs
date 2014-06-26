using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class DlgViewEditDeleteProductDetails : Form
	{
//		private Thread thrLoadCategory;
		private Thread thrLoadSubCategory;
		internal ProductWithUnderlyings UsingProduct { get; private set; }
		internal DiscountCollection Discounts_WorkingCopy { get; private set; }
		internal List<string> ShelfUsages_WorkingCopy { get; private set; }
		internal List<string> InShopWarehouseUsage_WorkingCopy { get; private set; }
		internal Image OriginalProductImage { get; private set; }
		public OperationStates CurrentState {
			get { return _currentStatue; }
			private set {
				_currentStatue = value;
				switch (_currentStatue) {
					case DlgViewEditDeleteProductDetails.OperationStates.Loading:
						if (this.InvokeRequired) {
							this.Invoke(new ThreadStart(delegate {
							                            	this.btnSave.Enabled = false;
							                            	this.btnEdit.Enabled = false;
							                            	this.btnEdit.Text = "Edit";
							                            	this.btnDelete.Enabled = false;
							                            	SetFieldsEnabled(false);
							                            	SetFieldsReadonly(false);
							                            	BatchUnsetProductsFieldsChangesCheck();}));
						} else {
							this.btnSave.Enabled = false;
							this.btnEdit.Enabled = false;
							this.btnEdit.Text = "Edit";
							this.btnDelete.Enabled = false;
							SetFieldsEnabled(false);
							SetFieldsReadonly(false);
							BatchUnsetProductsFieldsChangesCheck();
						}
						break;
					case DlgViewEditDeleteProductDetails.OperationStates.View:
						if (this.InvokeRequired) {
							this.Invoke(new ThreadStart(delegate {
							                            	this.btnSave.Enabled = false;
							                            	this.btnEdit.Enabled = true;
							                            	this.btnEdit.Text = "Edit";
							                            	this.btnDelete.Enabled = true;
							                            	SetFieldsEnabled(true);
							                            	SetFieldsReadonly(true);
							                            	BatchUnsetProductsFieldsChangesCheck();}));
						} else {
							this.btnSave.Enabled = false;
							this.btnEdit.Enabled = true;
							this.btnEdit.Text = "Edit";
							this.btnDelete.Enabled = true;
							SetFieldsEnabled(true);
							SetFieldsReadonly(true);
							BatchUnsetProductsFieldsChangesCheck();
						}
						break;
					case DlgViewEditDeleteProductDetails.OperationStates.Edit:
						if (this.InvokeRequired) {
							this.Invoke(new ThreadStart(delegate {
							                            	this.btnSave.Enabled = true;
							                            	this.btnEdit.Enabled = true;
							                            	this.btnEdit.Text = "Cancel Edit";
							                            	this.btnDelete.Enabled = false;
							                            	SetFieldsEnabled(true);
							                            	SetFieldsReadonly(false);
							                            	BatchSetProductsFieldsChangesCheck();}));
						} else {
							this.btnSave.Enabled = true;
							this.btnEdit.Enabled = true;
							this.btnEdit.Text = "Cancel Edit";
							this.btnDelete.Enabled = false;
							SetFieldsEnabled(true);
							SetFieldsReadonly(false);
							BatchSetProductsFieldsChangesCheck();}
						break;
				}
			}
		}
		public bool Modified {
			get { return _modified; }
			private set {
				if (_modified != value) {
					if (value) {
						oText = this.Text;
						this.Text += "*";
						oLText = this.lblDetailTitle.Text;
						this.lblDetailTitle.Text += "*";
					} else {
						this.Text = oText;
						this.lblDetailTitle.Text = oLText;
					}
				}
				_modified = value;
			}
		}
		
		private Dictionary<string, string> cacheShelfLocations = new Dictionary<string, string>();
		private Dictionary<string, string> cacheInShopWarehouseLocations = new Dictionary<string, string>();
		public enum OperationStates { Loading, View, Edit }
		private OperationStates _currentStatue;
		bool _modified;
		string oText = "";
		string oLText = "";
		
		public delegate void RunOnUIThreadDelegate();
		
		public DlgViewEditDeleteProductDetails(ProductWithUnderlyings usingProduct)
		{
			InitializeComponent();
			CurrentState = OperationStates.Loading;
			this.UsingProduct = usingProduct;
			Discounts_WorkingCopy = DiscountCollection.Clone(UsingProduct.Discounts);
			ShelfUsages_WorkingCopy = new List<string>(usingProduct.ShelfUsages);
			InShopWarehouseUsage_WorkingCopy = new List<string>(UsingProduct.InShopWarehouseUsages);
		}
		
		private void SetFieldsEnabled(bool enable)
		{
			this.cbxCategory.Enabled = enable;
			this.cbxSubCategory.Enabled = enable;
			this.txtProductID.Enabled = enable;
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
			this.btnDiscountsAdd.Enabled = enable;
			this.btnDiscountsDelete.Enabled = enable;
			this.btnShelfUsageAddEdit.Enabled = enable;
			this.btnShelfUsageDelete.Enabled = enable;
			this.btnInShopWarehouseUsageAddEdit.Enabled = enable;
			this.btnInShopWarehouseUsageDelete.Enabled = enable;
			this.btnImageChange.Enabled = enable;
			this.btnImageClear.Enabled = enable;
		}
		
		private void SetFieldsReadonly(bool readOnly)
		{
			this.cbxCategory.Enabled = !readOnly;
			this.cbxSubCategory.Enabled = !readOnly;
			this.txtProductID.ReadOnly = readOnly;
			this.txtBarcode.ReadOnly = readOnly;
			this.txtPrice.ReadOnly = readOnly;
			this.txtProductName.ReadOnly = readOnly;
			this.txtProductNameZHHK.ReadOnly = readOnly;
			this.txtProductNameZHCN.ReadOnly = readOnly;
			this.txtDescription.ReadOnly = readOnly;
			this.txtDescriptionZHHK.ReadOnly = readOnly;
			this.txtDescriptionZHCN.ReadOnly = readOnly;
			this.txtPackagingInfo.ReadOnly = readOnly;
			this.txtPackagingInfoZHHK.ReadOnly = readOnly;
			this.txtPackagingInfoZHCN.ReadOnly = readOnly;
			this.txtQuantity.ReadOnly = readOnly;
			this.txtUnit.ReadOnly = readOnly;
			this.txtUnitZHHK.ReadOnly = readOnly;
			this.txtUnitZHCN.ReadOnly = readOnly;
			this.btnDiscountsAdd.Enabled = !readOnly;
			this.btnDiscountsDelete.Enabled = !readOnly;
			this.btnShelfUsageAddEdit.Enabled = !readOnly;
			this.btnShelfUsageDelete.Enabled = !readOnly;
			this.btnInShopWarehouseUsageAddEdit.Enabled = !readOnly;
			this.btnInShopWarehouseUsageDelete.Enabled = !readOnly;
			this.btnImageChange.Enabled = !readOnly;
			this.btnImageClear.Enabled = !readOnly;
		}
		
		private void CbxCategorySelectedIndexChanged(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine(sender + ", " + e);
			if (this.cbxSubCategory.Enabled) {
				thrLoadSubCategory = new Thread(new ThreadStart(delegate {
				                                                	LoadSubCategoriesToUI();
				                                                }));
				thrLoadSubCategory.Start();
			}
		}
		
		private void DlgViewEditDeleteProductDetails_Load(object sender, EventArgs e)
		{
			this.BeginInvoke(new RunOnUIThreadDelegate(delegate {
			                                           	LoadCategoriesToUI();
			                                           	LoadFieldsOntoUIFromProduct();
			                                           	this.cbxCategory.SelectedIndexChanged += CbxCategorySelectedIndexChanged;
			                                           }));
		}
		
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
		
		#region methods to load data onto fields
		private void LoadFieldsOntoUIFromProduct()
		{
			this.CurrentState = OperationStates.Loading;
			
			// title
			this.Text = this.lblDetailTitle.Text = "Product Details for #" + UsingProduct.ProductID;
			
			// category
			string categoryID = null;
			try {
				OleDbCommand cmd = new OleDbCommand("SELECT categoryID FROM SubCategory WHERE subCategoryID = ?");
				cmd.Parameters.Add(new OleDbParameter("?", UsingProduct.SubCategoryID));
				categoryID = (string)DatabaseCommunicator.SelectSingleFromTable(cmd);
			} catch (Exception) {
			}
			for (int i = 0; i < this.cbxCategory.Items.Count; i++) {
				object o = this.cbxCategory.Items[i];
				if (o.GetType() == typeof(DataRowView) && categoryID != null) {
					DataRowView drw = (DataRowView)o;
					if((string)drw["categoryID"] == categoryID) {
						this.cbxCategory.SelectedIndex = i;
						break;
					}
				}
			}
			
			LoadSubCategoriesToUI();
			
			// sub category
			for (int i = 0; i < this.cbxSubCategory.Items.Count; i++) {
				object o = this.cbxSubCategory.Items[i];
				if (o.GetType() == typeof(DataRowView) && UsingProduct.SubCategoryID != null) {
					DataRowView drw = (DataRowView)o;
					if((string)drw["subCategoryID"] == UsingProduct.SubCategoryID) {
						this.cbxSubCategory.SelectedIndex = i;
						break;
					}
				}
			}
			
			// title
			this.lblDetailTitle.Text.Replace("{productID}", UsingProduct.ProductID);
			// product id
			this.txtProductID.Text = UsingProduct.ProductID;
			// barcode
			this.txtBarcode.Text = UsingProduct.Barcode;
			// price
			this.txtPrice.Text = UsingProduct.Price.ToString("0.0#");
			// product name
			this.txtProductName.Text = UsingProduct.ProductName;
			// product name zhhk
			this.txtProductNameZHHK.Text = UsingProduct.ProductName_ZHHK;
			// product name zhcn
			this.txtProductNameZHCN.Text = UsingProduct.ProductName_ZHCN;
			// desc
			this.txtDescription.Text = UsingProduct.Description;
			// desc zhhk
			this.txtDescriptionZHHK.Text = UsingProduct.Description_ZHHK;
			// desc zhcn
			this.txtDescriptionZHCN.Text = UsingProduct.Description_ZHCN;
			// pack
			this.txtPackagingInfo.Text = UsingProduct.PackagingInfo;
			// pack zhhk
			this.txtPackagingInfoZHHK.Text = UsingProduct.PackagingInfo_ZHHK;
			// pack zhcn
			this.txtPackagingInfoZHCN.Text = UsingProduct.PackagingInfo_ZHCN;
			// quantity
			this.txtQuantity.Text = UsingProduct.Quantity + "";
			// unit
			this.txtUnit.Text = UsingProduct.Unit;
			// unit zhhk
			this.txtUnitZHHK.Text = UsingProduct.Unit_ZHHK;
			// unit zhcn
			this.txtUnitZHCN.Text = UsingProduct.Unit_ZHCN;
			// discounts
			this.lsvDiscounts.Items.Clear();
			foreach (KeyValuePair<string, Discount> d in UsingProduct.Discounts) {
				ListViewItem newDiscount = new ListViewItem();
				newDiscount.Name = d.Value.LinkedDiscountOperation.DiscountID; // optional
				newDiscount.Text = d.Value.LinkedDiscountOperation.DiscountID;
				newDiscount.SubItems.Add("\u2713");
				newDiscount.SubItems.Add(d.Value.Quantities + "");
				newDiscount.SubItems.Add(d.Value.MinBuyPrice.ToString("0.0#"));
				this.lsvDiscounts.Items.Add(newDiscount);
			}
			// shelf usage
			LoadShelfLocationsIntoCache();
			this.lsvShelfUsage.Items.Clear();
			foreach (string s in UsingProduct.ShelfUsages) {
				ListViewItem lvi = new ListViewItem(s);
				try {
					lvi.SubItems.Add(cacheShelfLocations[s]);
				} catch (Exception) {
				}
				this.lsvShelfUsage.Items.Add(lvi);
			}
			// in shop warehouse usage
			LoadInShopWarehouseLocationsIntoCache();
			this.lsvInShopWarehouseUsage.Items.Clear();
			foreach (string s in UsingProduct.InShopWarehouseUsages) {
				ListViewItem lvi = new ListViewItem(s);
				try {
					lvi.SubItems.Add(cacheInShopWarehouseLocations[s]);
				} catch (Exception) {
				}
				this.lsvInShopWarehouseUsage.Items.Add(lvi);
			}
			// image of product
			this.pnlProductImage.BackgroundImage = ProductImageStorage.LoadImage(UsingProduct.ProductID);
			OriginalProductImage = this.pnlProductImage.BackgroundImage;
			
			this.CurrentState = OperationStates.View;
		}
		
		private void LoadShelfLocationsIntoCache()
		{
			cacheShelfLocations.Clear();
			UsingProduct.ShelfUsages
				.ForEach(i =>
				         {
				         	try {
				         		string locName = (string)DatabaseCommunicator.SelectSingleFromTable(
				         			new OleDbCommand("SELECT wkPlcName " +
				         			                 "FROM WorkPlace " +
				         			                 "INNER JOIN Shelf " +
				         			                 "ON WorkPlace.wkPlcID = Shelf.wkPlcID " +
				         			                 "WHERE shelfLocation='" + i + "'")
				         		);
				         		cacheShelfLocations.Add(
				         			i,
				         			locName
				         		);
				         	} catch (Exception ex) {
				         		MessageBox.Show("Error loading location of shelf location into the cache.\r\n" +
				         		                "(Shelf Loc = " + i + ")\r\n\r\n" + ex.Message,
				         		                "Shelf Location Cache", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				         	}
				         });
		}
		
		private void LoadInShopWarehouseLocationsIntoCache()
		{
			cacheInShopWarehouseLocations.Clear();
			UsingProduct.InShopWarehouseUsages
				.ForEach(i =>
				         {
				         	try {
				         		string locName = (string)DatabaseCommunicator.SelectSingleFromTable(
				         			new OleDbCommand("SELECT wkPlcName " +
				         			                 "FROM WorkPlace " +
				         			                 "INNER JOIN InShopWarehouse " +
				         			                 "ON WorkPlace.wkPlcID = InShopWarehouse.wkPlcID " +
				         			                 "WHERE inShopWarehouseLoc='" + i + "'")
				         		);
				         		cacheInShopWarehouseLocations.Add(
				         			i,
				         			locName
				         		);
				         	} catch (Exception ex) {
				         		MessageBox.Show("Error loading location of In-shop Warehouse Location location into the cache.\r\n" +
				         		                "(In-shop warehouse Loc = " + i + ")\r\n\r\n" + ex.Message,
				         		                "In-shop Warehouse Location Cache", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				         	}
				         });
		}
		#endregion
		
		#region button save / edit / delete
		#region save eventhandlers / methods used
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			DlgConfirm dlgConfirm = new DlgConfirm();
			if (dlgConfirm.ShowDialog(this.ParentForm) != DialogResult.OK) return;
			
			// loading form
			FrmLoading frmLoading = new FrmLoading();
			this.BeginInvoke(new ThreadStart(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			
			// start work
			System.ComponentModel.BackgroundWorker bgwSaveWorkingCopy = new System.ComponentModel.BackgroundWorker();
			bgwSaveWorkingCopy.WorkerReportsProgress = true;
			bgwSaveWorkingCopy.DoWork += new System.ComponentModel.DoWorkEventHandler(BgwSaveWorkingCopy_DoWork);
			bgwSaveWorkingCopy.ProgressChanged += delegate(object _sender, System.ComponentModel.ProgressChangedEventArgs ex) {
				frmLoading.Title = (string)ex.UserState;
			};
			bgwSaveWorkingCopy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgwSaveWorkingCopy_RunWorkerCompleted);
			bgwSaveWorkingCopy.RunWorkerCompleted += delegate {
				if (frmLoading.InvokeRequired) {
					frmLoading.Invoke(new ThreadStart(delegate { frmLoading.Close(); }));
				} else {
					frmLoading.Close();
				}
			};
			bgwSaveWorkingCopy.RunWorkerAsync();
		}

		private void BgwSaveWorkingCopy_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			
			System.ComponentModel.BackgroundWorker bgwHost = (System.ComponentModel.BackgroundWorker)sender;
			
			if (this.CurrentState != OperationStates.Edit)
				throw new InvalidOperationException("Save work can only operated when CurrentState is OperationStatus.Edit");
			
//			this.CurrentState = OperationStates.Loading;
			
			bool productIDChanged = (this.txtProductID.Text != UsingProduct.ProductID);
			// change of product id causes all discount operation removed first
			if (productIDChanged) {
				#region discounts
				UsingProduct.Discounts
					.Select(i => i.Value.LinkedDiscountOperation.DiscountID)
					.ToList()
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Deleting Discount record " +
					         	                       "(discount ID = " + i + ", " +
					         	                       "product ID = " + this.txtProductID.Text + ") before changing product ID...");
					         	if (!DatabaseCommunicator.Deleter.DeleteDiscount(UsingProduct.ProductID, i)) {
					         		SaveDeleteWorkingCopyError("Cannot delete Discount record " +
					         		                           "(discount ID = " + i + ", " +
					         		                           "product ID = " + UsingProduct.ProductID + ") \r\n" +
					         		                           "before updating Product info together with its Product ID.");
					         		throw new Exception();
					         	}
					         });
				#endregion
				
				#region shelf usage
				UsingProduct.ShelfUsages.ForEach(i =>
				                                 {
				                                 	bgwHost.ReportProgress(0, "Deleting Shelf Usage record " +
				                                 	                       "(product ID = " + this.txtProductID.Text + ", " +
				                                 	                       "Shelf Location= " + i + ") before changing product ID...");
				                                 	if (!DatabaseCommunicator.Deleter.DeleteShelfUsage(UsingProduct.ProductID, i)) {
				                                 		
				                                 		SaveDeleteWorkingCopyError("Cannot delete Shelf Usage record " +
				                                 		                           "(product ID = " + UsingProduct.ProductID + ", " +
				                                 		                           "Shelf Location= " + i + ") \r\n" +
				                                 		                           "before updating Product info together with its Product ID.");
				                                 		throw new Exception();
				                                 	}
				                                 });
				#endregion
				
				#region in shop warehouse usage
				UsingProduct.InShopWarehouseUsages.ForEach(i =>
				                                           {
				                                           	bgwHost.ReportProgress(0, "Deleting In-shop Warehouse Usage record " +
				                                           	                       "(product ID = " + this.txtProductID.Text + ", " +
				                                           	                       "In-shop Warehouse Location= " + i + ") before changing product ID...");
				                                           	if (!DatabaseCommunicator.Deleter.DeleteInShopWarehouseUsage(UsingProduct.ProductID, i)) {
				                                           		
				                                           		SaveDeleteWorkingCopyError("Cannot delete Discount record " +
				                                           		                           "(product ID = " + UsingProduct.ProductID + ", " +
				                                           		                           "In-shop Warehouse Location= " + i + ") \r\n" +
				                                           		                           "before updating Product info together with its Product ID.");
				                                           		throw new Exception();
				                                           	}
				                                           });
				#endregion
			}
			
			// udate this product record
			Dictionary<string, object> productDiff = null;
			this.Invoke(new ThreadStart(delegate { productDiff = ProductChangeDifference(); }));
			if (productDiff.Count > 0) {
				bgwHost.ReportProgress(0, "Updating Product information...");
				OleDbCommand cmdUpdateProduct = new OleDbCommand("UPDATE Product SET ");
				bool first = true;
				foreach (KeyValuePair<string, object> item in productDiff) {
					cmdUpdateProduct.CommandText += (first ? "" : ", ") + item.Key + " = ? ";
					cmdUpdateProduct.Parameters.Add(new OleDbParameter("?", item.Value));
					first = false;
				}
				cmdUpdateProduct.CommandText += "WHERE productID = ?";
				cmdUpdateProduct.Parameters.Add(new OleDbParameter("?", UsingProduct.ProductID));
				if (DatabaseCommunicator.UpdateFromTable(cmdUpdateProduct) != 1) {
					SaveDeleteWorkingCopyError("Cannot update product information.");
					throw new Exception();
				}
			}
			
			// update discount records
			List<Discount> discountAdd = null;
			List<Discount> discountRemove = null;
			Dictionary<Discount, RecordState> discountDiff = null;
			this.Invoke(new ThreadStart(delegate { discountDiff = DiscountCollectionChangeDifference(); }));
			if (productIDChanged) {
				discountAdd = discountDiff.Where(i => i.Value != RecordState.Remove).Select(i => i.Key).ToList();
			} else {
				discountAdd = discountDiff.Where(i => i.Value == RecordState.New).Select(i => i.Key).ToList();
				discountRemove = discountDiff.Where(i => i.Value == RecordState.Remove).Select(i => i.Key).ToList();
			}
			#region remove discount [u]+ discountoperation[/u]
			if (discountRemove != null && discountRemove.Count > 0) {
				// discount
				discountRemove
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Removing discount " +
					         	                       "(discount ID = " + i.LinkedDiscountOperation.DiscountID + ", " +
					         	                       "product ID = " + this.txtProductID.Text + ")...");
					         	if (!DatabaseCommunicator.Deleter.DeleteDiscount(this.txtProductID.Text, i.LinkedDiscountOperation.DiscountID)) {
					         		SaveDeleteWorkingCopyError("Cannot delete Discount record " +
					         		                           "(discount ID = " + i.LinkedDiscountOperation.DiscountID + ", " +
					         		                           "product ID = " + this.txtProductID.Text + ").");
					         		throw new Exception();
					         	}
					         });
				
				// discount operation (if discount operation is alone)
//				discountRemove
//					.Select(i => i.LinkedDiscountOperation)
//					.Where(i => !i.UseExisting)
//					.ToList()
//					.ForEach(i =>
//					         {
//					         	if (!DatabaseCommunicator.Deleter.DeleterDiscountOperation(i.DiscountID)) {
//									SaveWorkingCopyError("Cannot delete Discount Operation record (discount ID = " + i.DiscountID + ").");
//									throw new Exception();
//								}
//					         });
			}
			#endregion
			#region add discount + discountoperation
			if (discountAdd != null && discountAdd.Count > 0) {
				// discount operation (discount depend on this by discount.discountid)
				discountAdd
					.Select(i => i.LinkedDiscountOperation)
					.Where(i => !i.UseExisting)
					.ToList()
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Adding discount operation " +
					         	                       "(discount ID = " + i.DiscountID + ")...");
					         	if (!DatabaseCommunicator.Inserter.InsertDiscountOperation(i)) {
					         		SaveDeleteWorkingCopyError("Cannot insert Discount Operation record (discount ID = " + i.DiscountID + ").");
					         		throw new Exception();
					         	}
					         });
				
				// discount
				discountAdd
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Adding discount " +
					         	                       "(discount ID = " + i.LinkedDiscountOperation.DiscountID + ", " +
					         	                       "product ID = " + this.txtProductID.Text + ")...");
					         	if (!DatabaseCommunicator.Inserter.InsertDiscount(i, this.txtProductID.Text)) {
					         		SaveDeleteWorkingCopyError("Cannot insert Discount record " +
					         		                           "(discount ID = " + i.LinkedDiscountOperation.DiscountID + ", " +
					         		                           "product ID = " + this.txtProductID.Text + ").");
					         		throw new Exception();
					         	}
					         });
			}
			#endregion
			
			// update shelf usage records
			List<string> shelfUsageAdd = null;
			List<string> shelfUsageRemove = null;
			Dictionary<string, RecordState> shelfDiff = null;
			this.Invoke(new ThreadStart(delegate { shelfDiff = ShelfUsageChangeDifference(); }));
			if (productIDChanged) {
				shelfUsageAdd = shelfDiff.Where(i => i.Value != RecordState.Remove).Select(i => i.Key).ToList();
			} else {
				shelfUsageAdd = shelfDiff.Where(i => i.Value == RecordState.New).Select(i => i.Key).ToList();
				shelfUsageRemove = shelfDiff.Where(i => i.Value == RecordState.Remove).Select(i => i.Key).ToList();
			}
			#region remove shelf usage
			if (shelfUsageRemove != null && shelfUsageRemove.Count > 0) {
				// discount
				shelfUsageRemove
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Removing shelf usage " +
					         	                       "(product ID = " + this.txtProductID.Text + ", " +
					         	                       "shelf location = " + i + ")...");
					         	if (!DatabaseCommunicator.Deleter.DeleteShelfUsage(this.txtProductID.Text, i)) {
					         		SaveDeleteWorkingCopyError("Cannot delete Shelf Usage record " +
					         		                           "(product ID = " + this.txtProductID.Text + ", " +
					         		                           "shelf location = " + i + ").");
					         		throw new Exception();
					         	}
					         });
			}
			#endregion
			#region add shelf usage
			if (shelfUsageAdd != null && shelfUsageAdd.Count > 0) {
				shelfUsageAdd
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Adding shelf usage " +
					         	                       "(product ID = " + this.txtProductID.Text + ", " +
					         	                       "shelf location = " + i + ")...");
					         	if (!DatabaseCommunicator.Inserter.InsertShelfUsage(this.txtProductID.Text, i)) {
					         		SaveDeleteWorkingCopyError("Cannot insert Shelf Usage record " +
					         		                           "(product ID = " + this.txtProductID.Text + ", " +
					         		                           "shelf location = " + i + ").");
					         		throw new Exception();
					         	}
					         });
			}
			#endregion
			
			// update in shop warehouse usage records
			List<string> inShopWarehouseUsageAdd = null;
			List<string> inShopWarehouseUsageRemove = null;
			Dictionary<string, RecordState> inShopWarehouseDiff = null;
			this.Invoke(new ThreadStart(delegate { inShopWarehouseDiff = InShopWarehouseUsageChangeDifference(); }));
			if (productIDChanged) {
				inShopWarehouseUsageAdd = inShopWarehouseDiff.Where(i => i.Value != RecordState.Remove).Select(i => i.Key).ToList();
			} else {
				inShopWarehouseUsageAdd = inShopWarehouseDiff.Where(i => i.Value == RecordState.New).Select(i => i.Key).ToList();
				inShopWarehouseUsageRemove = inShopWarehouseDiff.Where(i => i.Value == RecordState.Remove).Select(i => i.Key).ToList();
			}
			#region rmv in shop warehouse usage
			if (inShopWarehouseUsageAdd != null && inShopWarehouseUsageAdd.Count > 0) {
				inShopWarehouseUsageAdd
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Removing shelf usage " +
					         	                       "(product ID = " + this.txtProductID.Text + ", " +
					         	                       "shelf location = " + i + ")...");
					         	if (!DatabaseCommunicator.Inserter.InsertInShopWarehouseUsage(this.txtProductID.Text, i)) {
					         		SaveDeleteWorkingCopyError("Cannot insert Shelf Usage record " +
					         		                           "(product ID = " + this.txtProductID.Text + ", " +
					         		                           "in-shop warehouse location = " + i + ").");
					         		throw new Exception();
					         	}
					         });
			}
			#endregion
			#region add in shop warehouse usage
			if (inShopWarehouseUsageRemove != null && inShopWarehouseUsageRemove.Count > 0) {
				// discount
				inShopWarehouseUsageRemove
					.ForEach(i =>
					         {
					         	bgwHost.ReportProgress(0, "Adding In-shop Warehouse Usage " +
					         	                       "(product ID = " + this.txtProductID.Text + ", " +
					         	                       "in-shop warehouse location = " + i + ")...");
					         	if (!DatabaseCommunicator.Deleter.DeleteInShopWarehouseUsage(this.txtProductID.Text, i)) {
					         		SaveDeleteWorkingCopyError("Cannot delete In-shop Warehouse Usage record " +
					         		                           "(product ID = " + this.txtProductID.Text + ", " +
					         		                           "in-shop warehouse location = " + i + ").");
					         		throw new Exception();
					         	}
					         });
			}
			#endregion
			
			// update image of product
			bool picIsDiff = false;
			this.Invoke(new ThreadStart(delegate { picIsDiff = CheckProductImageChanged(); }));
			if (picIsDiff) {
				bgwHost.ReportProgress(0, "Updating product image...");
				if (!ProductImageStorage.SaveImage(this.pnlProductImage.BackgroundImage, this.txtProductID.Text))
					throw new Exception("Error saving image: external component \"GDI+\" error");
			}
			
			this.CurrentState = OperationStates.View;
		}
		
		private void bgwSaveWorkingCopy_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			Thread thr = new Thread(
				new ThreadStart(
					delegate {
						Product n1 = new Product();
						if (UsingProduct.ProductID != this.txtProductID.Text) {
							try {
								n1 = DatabaseCommunicator.Selector.SelectProductFromProductID(this.txtProductID.Text);
							} catch (Exception) {
								n1 = DatabaseCommunicator.Selector.SelectProductFromProductID(UsingProduct.ProductID);
							}
						} else {
							n1 = DatabaseCommunicator.Selector.SelectProductFromProductID(UsingProduct.ProductID);
						}
						ProductWithUnderlyings n2 = n1.ToProductWithUnderlyings();
						n2.GetUnderlyingDetails();
						UsingProduct = n2;
						Discounts_WorkingCopy = UsingProduct.Discounts;
						ShelfUsages_WorkingCopy = UsingProduct.ShelfUsages;
						InShopWarehouseUsage_WorkingCopy = UsingProduct.InShopWarehouseUsages;
					}));
			thr.Start();
			thr.Join();
			this.BeginInvoke(new RunOnUIThreadDelegate(delegate {
			                                           	this.cbxCategory.SelectedIndexChanged -= CbxCategorySelectedIndexChanged;
			                                           	LoadFieldsOntoUIFromProduct();
			                                           	this.cbxCategory.SelectedIndexChanged += CbxCategorySelectedIndexChanged;
			                                           }));
			if (e.Error != null) {
				MessageBox.Show("Error on update!\r\n\r\n" +
				                e.Error.Message +
				                #if DEBUG
				                e.Error.StackTrace +
				                #endif
				                "\r\n\r\n" +
				                "Current product information are reloaded.",
				                "Update",
				                MessageBoxButtons.OK, MessageBoxIcon.Error);
			} else {
				MessageBox.Show("Update successful!", "Update",
				                MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		private void SaveDeleteWorkingCopyError(string message)
		{
			MessageBox.Show("Error:\r\n\r\n" +
			                message + "\r\n\r\n" +
			                "Operation aborted.", "Error updating Product Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
			this.CurrentState = OperationStates.Edit;
		}
		
		private void SaveDeleteWorkingCopyWarning(string message)
		{
			MessageBox.Show("Warning:\r\n\r\n" +
			                message + "\r\n\r\n" +
			                "Operation will omit this error and try to continue.", "Warning updating Product Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			this.CurrentState = OperationStates.Edit;
		}
		#endregion
		
		private void BtnEditClick(object sender, System.EventArgs e)
		{
			if (this.CurrentState == OperationStates.View) {
				this.CurrentState = OperationStates.Edit;
			} else if (this.CurrentState == OperationStates.Edit) {
				this.CurrentState = OperationStates.Loading;
				this.BeginInvoke(new RunOnUIThreadDelegate(delegate {
				                                           	this.cbxCategory.SelectedIndexChanged -= CbxCategorySelectedIndexChanged;
				                                           	LoadFieldsOntoUIFromProduct();
				                                           	this.cbxCategory.SelectedIndexChanged += CbxCategorySelectedIndexChanged;
				                                           	this.Modified = false;
				                                           }));
				this.CurrentState = OperationStates.View;
			}
		}
		
		private void BtnDeleteClick(object sender, System.EventArgs e)
		{
			if (new DlgConfirm().ShowDialog(this.ParentForm) != DialogResult.OK) return;
			
			this.CurrentState = OperationStates.Loading;
			
			FrmLoading frmLoading = new FrmLoading();
			this.BeginInvoke(new ThreadStart(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			System.ComponentModel.BackgroundWorker bgwDeleteProduct = new System.ComponentModel.BackgroundWorker();
			bgwDeleteProduct.WorkerReportsProgress = true;
			bgwDeleteProduct.DoWork += new System.ComponentModel.DoWorkEventHandler(bgwDeleteProduct_DoWork);
			bgwDeleteProduct.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgwDeleteProduct_RunWorkerCompleted);
			bgwDeleteProduct.RunWorkerCompleted += delegate {
				if (frmLoading.InvokeRequired) {
					frmLoading.Invoke(new ThreadStart(delegate { frmLoading.Close(); }));
				} else {
					frmLoading.Close();
				}
			};
			bgwDeleteProduct.ProgressChanged += delegate(object _sender, System.ComponentModel.ProgressChangedEventArgs ex) {
				frmLoading.Title = (string)ex.UserState;
			};
			bgwDeleteProduct.RunWorkerAsync();
		}

		private void bgwDeleteProduct_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null) {
				Product n1 = new Product();
				if (UsingProduct.ProductID != this.txtProductID.Text) {
					try {
						n1 = DatabaseCommunicator.Selector.SelectProductFromProductID(this.txtProductID.Text);
					} catch (Exception) {
						n1 = DatabaseCommunicator.Selector.SelectProductFromProductID(UsingProduct.ProductID);
					}
				} else {
					n1 = DatabaseCommunicator.Selector.SelectProductFromProductID(UsingProduct.ProductID);
				}
				ProductWithUnderlyings n2 = n1.ToProductWithUnderlyings();
				n2.GetUnderlyingDetails();
				UsingProduct = n2;
				this.BeginInvoke(new RunOnUIThreadDelegate(delegate {
				                                           	this.cbxCategory.SelectedIndexChanged -= CbxCategorySelectedIndexChanged;
				                                           	LoadFieldsOntoUIFromProduct();
				                                           	this.cbxCategory.SelectedIndexChanged += CbxCategorySelectedIndexChanged;
				                                           	MessageBox.Show("Error on delete!\r\n\r\n" +
				                                           	                e.Error.Message +
				                                           	                #if DEBUG
				                                           	                e.Error.StackTrace +
				                                           	                #endif
				                                           	                "\r\n\r\n" +
				                                           	                "Current product information are reloaded.",
				                                           	                "Delete",
				                                           	                MessageBoxButtons.OK, MessageBoxIcon.Error);
				                                           }));
			} else {
				MessageBox.Show("Delete successful!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void bgwDeleteProduct_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			System.ComponentModel.BackgroundWorker bgwHost = (System.ComponentModel.BackgroundWorker)sender;
			
			// discounts
			UsingProduct.Discounts
				.Select(i => i.Value.LinkedDiscountOperation.DiscountID)
				.ToList()
				.ForEach(i =>
				         {
				         	bgwHost.ReportProgress(0, "Deleting discount record " +
				         	                       "(discount ID = " + i + ", " +
				         	                       "product ID = " + UsingProduct.ProductID + ")...");
				         	if (!DatabaseCommunicator.Deleter.DeleteDiscount(UsingProduct.ProductID, i)) {
				         		SaveDeleteWorkingCopyError("Error deleting discount record " +
				         		                           "(discount ID = " + i + ", " +
				         		                           "product ID = " + UsingProduct.ProductID + ")");
				         		throw new Exception();
				         	}
				         	
				         	try {
				         		int thisDLinkCount = (int)DatabaseCommunicator.SelectSingleFromTable(
				         			new OleDbCommand("SELECT COUNT(*) FROM Discount WHERE discountID = '" + i + "'")
				         		);
				         		
				         		if (thisDLinkCount == 0) {
				         			if (MessageBox.Show(
				         				"The discount (discount ID = " + i + ") has no associated product right now.\r\n" +
				         				"Do you want to remove this discount?",
				         				"Alone discount (discount ID = " + i,
				         				MessageBoxButtons.YesNo,
				         				MessageBoxIcon.Exclamation,
				         				MessageBoxDefaultButton.Button2) == DialogResult.Yes
				         			   ) {
				         				bgwHost.ReportProgress(0, "Deleting discount operation record " +
				         				                       "(discount ID = " + i + ")...");
				         				DatabaseCommunicator.Deleter.DeleteDiscountOperation(i);
				         			}
				         		}
				         	} catch (Exception) {
				         	}
				         });
			
			// shelf usage
			UsingProduct.ShelfUsages
				.ForEach(i =>
				         {
				         	bgwHost.ReportProgress(0, "Deleting Shelf Location record " +
				         	                       "(product ID = " + UsingProduct.ProductID + ", " +
				         	                       "Shelf Location = " + i + ")...");
				         	if (!DatabaseCommunicator.Deleter.DeleteShelfUsage(UsingProduct.ProductID, i)) {
				         		SaveDeleteWorkingCopyError("Error deleting Shelf Location record " +
				         		                           "(product ID = " + UsingProduct.ProductID + ", " +
				         		                           "Shelf Location = " + i + ")");
				         		throw new Exception();
				         	}
				         });
			
			// iswh usage
			UsingProduct.InShopWarehouseUsages
				.ForEach(i =>
				         {
				         	bgwHost.ReportProgress(0, "Deleting In-shop Warehouse Location record " +
				         	                       "(product ID = " + UsingProduct.ProductID + ", " +
				         	                       "In-shop Warehouse Location = " + i + ")...");
				         	if (!DatabaseCommunicator.Deleter.DeleteInShopWarehouseUsage(UsingProduct.ProductID, i)) {
				         		SaveDeleteWorkingCopyError("Error deleting In-shop Warehouse Location record " +
				         		                           "(product ID = " + UsingProduct.ProductID + ", " +
				         		                           "In-shop Warehouse Location = " + i + ")");
				         		throw new Exception();
				         	}
				         });
			
			// product image
			this.pnlProductImage.BackgroundImage = null;
			ProductImageStorage.CleanUpImage(UsingProduct.ProductID);
			
			// product
			bgwHost.ReportProgress(0, "Deleting Product record " +
			                       "(product ID = " + UsingProduct.ProductID + ")...");
			if (!DatabaseCommunicator.Deleter.DeleteProduct(UsingProduct.ProductID)) {
				SaveDeleteWorkingCopyError("Error deleting Product record " +
				                           "(product ID = " + UsingProduct.ProductID + ")");
				throw new Exception();
			}
		}
		#endregion
		
		#region discount
		private void BtnDiscountsAddClick(object sender, EventArgs e)
		{
			FrmLoading frmLoading = new FrmLoading(false);
			this.BeginInvoke(new FrmLoading.RunWithNotBlockingThisThreadDelegate(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			DlgAddDiscountDetails dlgDiscountDetails = new DlgAddDiscountDetails();
			dlgDiscountDetails.Shown += delegate { this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); })); };
			if (dlgDiscountDetails.ShowDialog(this.ParentForm) == DialogResult.OK) {
				Discount newDiscount = dlgDiscountDetails.ResultDetails;
				
				if (Discounts_WorkingCopy.ContainsKey(newDiscount.LinkedDiscountOperation.DiscountID)) {
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
				Discounts_WorkingCopy.Add(newDiscount.LinkedDiscountOperation.DiscountID, newDiscount);
				
				// user interface
				ListViewItem lvi = new ListViewItem(newDiscount.LinkedDiscountOperation.DiscountID);
				lvi.SubItems.Add(newDiscount.LinkedDiscountOperation.UseExisting ? "\u2713" : "");
				lvi.SubItems.Add(newDiscount.Quantities + "");
				lvi.SubItems.Add(newDiscount.MinBuyPrice + "");
				this.lsvDiscounts.Items.Add(lvi);
				
				OnFieldsValuesChangeEventHandler(sender, e);
			}
		}
		
		private void BtnDiscountsDeleteClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to delete selected discounts?",
			                    "Delete Discounts",
			                    MessageBoxButtons.YesNo,
			                    MessageBoxIcon.Exclamation,
			                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
				return;
			
			foreach (ListViewItem item in this.lsvDiscounts.SelectedItems) {
				// internal data storage
				Discounts_WorkingCopy.Remove(item.Text);
				
				// user interface
				this.lsvDiscounts.Items.Remove(item);
			}
			
			OnFieldsValuesChangeEventHandler(sender, e);
		}
		
		private void BtnDiscountViewEditClick(object sender, EventArgs e)
		{
			if (this.lsvDiscounts.SelectedItems.Count == 0 || this.lsvDiscounts.SelectedItems.Count > 1) {
				System.Media.SystemSounds.Beep.Play();
				return;
			}
			
			FrmLoading frmLoading = new FrmLoading(false);
			this.BeginInvoke(new FrmLoading.RunWithNotBlockingThisThreadDelegate(delegate { frmLoading.ShowDialog(this.ParentForm); }));
			Discount selectedDiscount = Discounts_WorkingCopy[this.lsvDiscounts.SelectedItems[0].Text];
			DlgEditDiscountDetails dlgEditDiscountDetails = new DlgEditDiscountDetails(selectedDiscount, this.CurrentState != OperationStates.Edit);
			dlgEditDiscountDetails.Shown += delegate { this.Invoke(new RunOnUIThreadDelegate(delegate { frmLoading.Close(); })); };
			if (dlgEditDiscountDetails.ShowDialog(this.ParentForm) == DialogResult.OK) {
				Discount newDiscount = dlgEditDiscountDetails.UsingDiscount;
				
				if (Discounts_WorkingCopy.ContainsKey(newDiscount.LinkedDiscountOperation.DiscountID)) {
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
				Discounts_WorkingCopy.Add(newDiscount.LinkedDiscountOperation.DiscountID, newDiscount);
				
				// user interface
				ListViewItem lvi = new ListViewItem(newDiscount.LinkedDiscountOperation.DiscountID);
				lvi.SubItems.Add(newDiscount.LinkedDiscountOperation.UseExisting ? "\u2713" : "");
				lvi.SubItems.Add(newDiscount.Quantities + "");
				lvi.SubItems.Add(newDiscount.MinBuyPrice + "");
				this.lsvDiscounts.Items.Add(lvi);
				
				OnFieldsValuesChangeEventHandler(sender, e);
			}
		}
		#endregion
		
		#region shelf usage
		private void BtnShelfUsageAddEditClick(object sender, EventArgs e)
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
				// internal data storage
				ShelfUsages_WorkingCopy = new List<string>(dlgShelfUsage.SelectResultList);
				
				// UI
				lsvShelfUsage.Items.Clear();
				
				foreach (DataRow row in dlgShelfUsage.SelectResultDataTable.Rows) {
					ListViewItem item = new ListViewItem((string)row["shelfLocation"]);
					item.SubItems.Add((string)row["wkPlcName"]);
					this.lsvShelfUsage.Items.Add(item);
				}
				
				OnFieldsValuesChangeEventHandler(sender, e);
			}
		}
		
		private void BtnShelfUsageDeleteClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to delete selected shelf usages?",
			                    "Delete Shelf Usage",
			                    MessageBoxButtons.YesNo,
			                    MessageBoxIcon.Exclamation,
			                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
				return;
			
			foreach (ListViewItem item in this.lsvShelfUsage.SelectedItems) {
				// internal storage
				ShelfUsages_WorkingCopy.Remove(item.Text);
				// UI
				item.Remove();
			}
			
			OnFieldsValuesChangeEventHandler(sender, e);
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
				// internal data storage
				this.InShopWarehouseUsage_WorkingCopy = new List<string>(dlgInShopWarehouseUsage.SelectResultList);
				
				// UI
				lsvInShopWarehouseUsage.Items.Clear();
				
				foreach (DataRow row in dlgInShopWarehouseUsage.SelectResultDataTable.Rows) {
					ListViewItem item = new ListViewItem((string)row["inShopWarehouseLoc"]);
					item.SubItems.Add((string)row["wkPlcName"]);
					this.lsvInShopWarehouseUsage.Items.Add(item);
				}
				
				OnFieldsValuesChangeEventHandler(sender, e);
			}
		}
		
		private void BtnInShopWarehouseUsageDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure to delete selected in-shop warehouse usages?",
			                    "Delete In-shop Warehouse Usage",
			                    MessageBoxButtons.YesNo,
			                    MessageBoxIcon.Exclamation,
			                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
				return;
			
			foreach (ListViewItem item in this.lsvInShopWarehouseUsage.SelectedItems) {
				// internal data storage
				InShopWarehouseUsage_WorkingCopy.Remove(item.Text);
				// UI
				item.Remove();
			}
			
			OnFieldsValuesChangeEventHandler(sender, e);
		}
		#endregion
		
		#region check modification
		private enum RecordState { Remain, New, Remove };
		
		#region product
		private bool CheckProductChangeDifference()
		{
			return ProductChangeDifference().Count != 0;
		}
		
		private Dictionary<string, object> ProductChangeDifference()
		{
			Dictionary<string, object> ret = new Dictionary<string, object>();
			
			try {
				// product id
				if (UsingProduct.ProductID != this.txtProductID.Text) ret.Add("productID", this.txtProductID.Text);
				// barcode
				if (UsingProduct.Barcode != this.txtBarcode.Text) ret.Add("barcode", this.txtBarcode.Text);
				// product name
				if (UsingProduct.ProductName != this.txtProductName.Text) ret.Add("productName", this.txtProductID.Text);
				// product name zhhk
				if (UsingProduct.ProductName_ZHHK != this.txtProductNameZHHK.Text) ret.Add("productName_ZHHK", this.txtProductNameZHHK.Text);
				// product name zhcn
				if (UsingProduct.ProductName_ZHCN != this.txtProductNameZHCN.Text) ret.Add("productName_ZHCN", this.txtProductNameZHCN.Text);
				// description
				if (UsingProduct.Description != this.txtDescription.Text) ret.Add("description", this.txtDescription.Text);
				// description ZHHK
				if (UsingProduct.Description_ZHHK != this.txtDescriptionZHHK.Text) ret.Add("description_ZHHK", this.txtDescriptionZHHK.Text);
				// description ZHCN
				if (UsingProduct.Description_ZHCN != this.txtDescriptionZHCN.Text) ret.Add("description_ZHCN", this.txtDescriptionZHCN.Text);
				// pack info
				if (UsingProduct.PackagingInfo != this.txtPackagingInfo.Text) ret.Add("packagingInfo", this.txtPackagingInfo.Text);
				// pack info ZHHK
				if (UsingProduct.PackagingInfo_ZHHK != this.txtPackagingInfoZHHK.Text) ret.Add("packagingInfo_ZHHK", this.txtPackagingInfoZHHK.Text);
				// pack info ZHCN
				if (UsingProduct.PackagingInfo_ZHCN != this.txtPackagingInfoZHCN.Text) ret.Add("packagingInfo_ZHCN", this.txtPackagingInfoZHCN.Text);
				// quantity
				if (UsingProduct.Quantity != Int16.Parse(this.txtQuantity.Text)) ret.Add("quantity", Int16.Parse(this.txtQuantity.Text));
				// unit
				if (UsingProduct.Unit != this.txtUnit.Text) ret.Add("unit", this.txtUnit.Text);
				// unit zhhk
				if (UsingProduct.Unit_ZHHK != this.txtUnitZHHK.Text) ret.Add("unit_ZHHK", this.txtUnitZHHK.Text);
				// unit zhcn
				if (UsingProduct.Unit_ZHCN != this.txtUnitZHCN.Text) ret.Add("unit_ZHCN", this.txtUnitZHCN.Text);
				// price
				if (UsingProduct.Price != Decimal.Parse(this.txtPrice.Text)) ret.Add("price", Decimal.Parse(this.txtPrice.Text));
				// sub category
				if (UsingProduct.SubCategoryID != (string)this.cbxSubCategory.SelectedValue) ret.Add("productID", this.cbxSubCategory.SelectedValue);
			} catch (Exception) {
			}
			
			return ret;
		}
		#endregion
		
		#region discount collection
		private bool CheckDiscountCollectionChangeDifference()
		{
			return DiscountCollectionChangeDifference().Count != 0;
		}
		
		private Dictionary<Discount, RecordState> DiscountCollectionChangeDifference()
		{
			Dictionary<Discount, RecordState> ret = new Dictionary<Discount, DlgViewEditDeleteProductDetails.RecordState>();
			
			// remain items
			foreach (KeyValuePair<string, Discount> item in UsingProduct.Discounts) {
				if (Discounts_WorkingCopy.ContainsKey(item.Key)) {
					ret.Add(Discounts_WorkingCopy[item.Key], RecordState.Remain);
				}
			}
			// new items
			foreach (KeyValuePair<string, Discount> item in Discounts_WorkingCopy) {
				if (!UsingProduct.Discounts.ContainsKey(item.Value.LinkedDiscountOperation.DiscountID)) {
					ret.Add(item.Value, RecordState.New);
				}
			}
			// removing items
			foreach (KeyValuePair<string, Discount> item in UsingProduct.Discounts) {
				if (!Discounts_WorkingCopy.ContainsKey(item.Value.LinkedDiscountOperation.DiscountID)) {
					ret.Add(item.Value, RecordState.Remove);
				}
			}
			
			return ret;
		}
		#endregion discount collection
		
		#region shelf usage
		private bool CheckShelfUsageChangeDifference()
		{
			return ShelfUsageChangeDifference().Count != 0;
		}
		
		private Dictionary<string, RecordState> ShelfUsageChangeDifference()
		{
			Dictionary<string, RecordState> ret = new Dictionary<string, DlgViewEditDeleteProductDetails.RecordState>();
			
			// remain items
			List<string> remain = UsingProduct.ShelfUsages.Intersect(ShelfUsages_WorkingCopy).ToList();
			remain.ForEach(i => ret.Add(i, RecordState.Remain));
			// new items
			ShelfUsages_WorkingCopy.Except(remain).ToList().ForEach(i => ret.Add(i, RecordState.New));
			// removing items
			UsingProduct.ShelfUsages.Except(remain).ToList().ForEach(i => ret.Add(i, RecordState.Remove));
			
			return ret;
		}
		#endregion
		
		#region in shop warehouse usage
		private bool CheckInShopWarehouseUsageChangeDifference()
		{
			return InShopWarehouseUsageChangeDifference().Count != 0;
		}
		
		private Dictionary<string, RecordState> InShopWarehouseUsageChangeDifference()
		{
			Dictionary<string, RecordState> ret = new Dictionary<string, DlgViewEditDeleteProductDetails.RecordState>();
			
			// remain items
			List<string> remain = UsingProduct.InShopWarehouseUsages.Intersect(InShopWarehouseUsage_WorkingCopy).ToList();
			remain.ForEach(i => ret.Add(i, RecordState.Remain));
			// new items
			InShopWarehouseUsage_WorkingCopy.Except(remain).ToList().ForEach(i => ret.Add(i, RecordState.New));
			// removing items
			UsingProduct.InShopWarehouseUsages.Except(remain).ToList().ForEach(i => ret.Add(i, RecordState.Remove));
			
			return ret;
		}
		#endregion
		
		private bool CheckProductImageChanged()
		{
			return this.pnlProductImage.BackgroundImage != OriginalProductImage;
		}
		
		private void BatchSetProductsFieldsChangesCheck()
		{
			this.cbxCategory.SelectedIndexChanged += OnFieldsValuesChangeEventHandler;
			this.cbxSubCategory.SelectedIndexChanged += OnFieldsValuesChangeEventHandler;
			this.txtProductID.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtBarcode.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtPrice.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtProductName.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtProductNameZHHK.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtProductNameZHCN.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtDescription.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtDescriptionZHHK.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtDescriptionZHCN.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtPackagingInfo.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtPackagingInfoZHHK.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtPackagingInfoZHCN.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtQuantity.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtUnit.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtUnitZHHK.TextChanged += OnFieldsValuesChangeEventHandler;
			this.txtUnitZHCN.TextChanged += OnFieldsValuesChangeEventHandler;
		}
		
		private void BatchUnsetProductsFieldsChangesCheck()
		{
			this.cbxCategory.SelectedIndexChanged -= OnFieldsValuesChangeEventHandler;
			this.cbxSubCategory.SelectedIndexChanged -= OnFieldsValuesChangeEventHandler;
			this.txtProductID.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtBarcode.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtPrice.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtProductName.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtProductNameZHHK.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtProductNameZHCN.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtDescription.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtDescriptionZHHK.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtDescriptionZHCN.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtPackagingInfo.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtPackagingInfoZHHK.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtPackagingInfoZHCN.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtQuantity.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtUnit.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtUnitZHHK.TextChanged -= OnFieldsValuesChangeEventHandler;
			this.txtUnitZHCN.TextChanged -= OnFieldsValuesChangeEventHandler;
		}
		
		// TODO: more efficient? OnFieldsValuesChangeEventHandler
		private void OnFieldsValuesChangeEventHandler(object sender, EventArgs e)
		{
			this.Modified = (CheckProductChangeDifference() || CheckDiscountCollectionChangeDifference() ||
			                 CheckShelfUsageChangeDifference() || CheckInShopWarehouseUsageChangeDifference() ||
			                 CheckProductImageChanged());
		}
		
		private void BtnImageClear_Click(object sender, EventArgs e)
		{
			this.pnlProductImage.BackgroundImage = null;
			
			OnFieldsValuesChangeEventHandler(sender, e);
		}
		
		private void BtnImageChange_Click(object sender, EventArgs e)
		{
			if (this.ofdProductImage.ShowDialog() == DialogResult.OK) {
				Bitmap bmpProductImage = new Bitmap(this.ofdProductImage.FileName);
				this.pnlProductImage.BackgroundImage = bmpProductImage;
			}
			
			OnFieldsValuesChangeEventHandler(sender, e);
		}
	}
	#endregion
}