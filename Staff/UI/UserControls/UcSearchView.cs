using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class UcSearchView : UserControl
	{
		internal ProductCollection SearchResult { get; private set; }
		
		public UcSearchView()
		{
			InitializeComponent();
			this.cbxSearchColumn.SelectedIndex = this.cbxSearchColumn.Items.Count >= 5 ? 4 : -1;
		}
		
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			string searchValue = txtSearchValue.Text.Trim();
			
			OleDbCommand cmdSearch = null;
			switch (((string)this.cbxSearchColumn.SelectedItem)) {
				case "Category ID":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM SubCategory "
					                             + "INNER JOIN Product "
					                             + "ON SubCategory.subCategoryID = Product.subCategoryID "
					                             + "WHERE SubCategory.CategoryID LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Category Name":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Category "
					                             + "INNER JOIN (SubCategory INNER JOIN Product ON SubCategory.subCategoryID = Product.subCategoryID) "
					                             + "ON Category.categoryID = SubCategory.categoryID "
					                             + "WHERE Category.name LIKE ? "
					                             + "OR Category.name_ZHHK LIKE ? "
					                             + "OR Category.name_ZHCN LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Sub-Category ID":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Product "
					                             + "WHERE Product.subCategoryID LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Sub-Category Name":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM SubCategory "
					                             + "INNER JOIN Product "
					                             + "ON SubCategory.subCategoryID = Product.subCategoryID "
					                             + "WHERE SubCategory.name LIKE ? "
					                             + "OR SubCategory.name_ZHHK LIKE ? "
					                             + "OR SubCategory.name_ZHCN LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Product ID":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Product "
					                             + "WHERE productID LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Product Barcode":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Product "
					                             + "WHERE barcode LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Product Name":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Product "
					                             + "WHERE productName LIKE ? "
					                             + "OR productName_ZHHK LIKE ? "
					                             + "OR productName_ZHCN LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Product Price":
					string _operator = "=";
					double _value = 0.0;
					if (searchValue[0] == '=' && searchValue[1] == '=') {
						_operator = "=";
						Double.TryParse(searchValue.Substring(2), out _value);
					} else if (searchValue[0] == '=') {
						_operator = "=";
						Double.TryParse(searchValue.Substring(1), out _value);
					} else if (searchValue[0] == '>' && searchValue[1] == '=') {
						_operator = ">=";
						Double.TryParse(searchValue.Substring(2), out _value);
					} else if (searchValue[0] == '>') {
						_operator = ">";
						Double.TryParse(searchValue.Substring(1), out _value);
					} else if (searchValue[0] == '<' && searchValue[1] == '=') {
						_operator = "<=";
						Double.TryParse(searchValue.Substring(2), out _value);
					} else if (searchValue[0] == '<') {
						_operator = "<";
						Double.TryParse(searchValue.Substring(1), out _value);
					}
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Product "
					                             + "WHERE price " + _operator + " ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", _value));
					break;
				case "Linked to Discount ID":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM Discount "
					                             + "INNER JOIN Product "
					                             + "ON Discount.productID = Product.productID "
					                             + "WHERE Discount.discountID LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Linked to Shelf Location ID":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM ShelfUsage "
					                             + "INNER JOIN Product "
					                             + "ON ShelfUsage.productID = Product.productID "
					                             + "WHERE ShelfUsage.shelfLocation LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
				case "Linked to In-shop Warehouse ID":
					cmdSearch = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " "
					                             + "FROM InShopWarehouseUsage "
					                             + "INNER JOIN Product "
					                             + "ON InShopWarehouseUsage.productID = Product.productID "
					                             + "WHERE InShopWarehouseUsage.inShopWarehouseLoc LIKE ?");
					cmdSearch.Parameters.Add(new OleDbParameter("?", "%" + searchValue + "%"));
					break;
			}
			
			if (cmdSearch != null) {
				this.BeginInvoke(new ThreadStart(delegate {
				                           	this.SearchResult = ProductCollection.Parse(DatabaseCommunicator.SelectFromTable(cmdSearch));
				                           	ListAllSearchResultsOnUI();
				                           }));
			}
		}
		
		private void ListAllSearchResultsOnUI()
		{
			this.lsvSearchResult.Items.Clear();
			
			foreach (Product p in this.SearchResult) {
				ListViewItem newListView = new ListViewItem();
				// (name)
				newListView.Name = p.ProductID; // optional
				// Product ID
				newListView.Text = p.ProductID;
				// Barcode
				newListView.SubItems.Add(p.Barcode);
				// Name
				newListView.SubItems.Add(p.ProductName + " " + p.ProductName_ZHHK + " " + p.ProductName_ZHCN);
				// Qty
				newListView.SubItems.Add(p.Quantity + " " + p.Unit + " " + p.Unit_ZHHK + " " + p.Unit_ZHCN);
				// HK$
				newListView.SubItems.Add(p.Price.ToString("0.0#"));
				
				if (this.InvokeRequired) {
					this.Invoke(new ThreadStart(delegate { this.lsvSearchResult.Items.Add(newListView); }));
				} else {
					this.lsvSearchResult.Items.Add(newListView);
				}
			}
		}
		
		private void LsvSearchResult_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lsvSearchResult.SelectedIndices.Count == 0)
				return;
			
			int selectedIndex = this.lsvSearchResult.SelectedIndices[0];
			ShowProductSummaryOnUI(this.SearchResult[selectedIndex]);
			if (this.SearchResult[selectedIndex].GetType() != typeof(ProductWithUnderlyings)) {
				this.SearchResult[selectedIndex] = this.SearchResult[selectedIndex].ToProductWithUnderlyings();
				this.BeginInvoke(new ThreadStart(delegate {
				                                 	((ProductWithUnderlyings)this.SearchResult[selectedIndex]).GetUnderlyingDetails();
				                                 	ShowUnderlyingDetailsOnUI((ProductWithUnderlyings)this.SearchResult[selectedIndex]);
				                                 }));
			} else {
				ShowUnderlyingDetailsOnUI((ProductWithUnderlyings)this.SearchResult[selectedIndex]);
			}
		}
		
		private void ShowProductSummaryOnUI(Product product)
		{
			this.btnViewDetails.Enabled = false;
			
			// Product ID
			this.txtProductID.Text = product.ProductID;
			// Barcode
			this.txtBarcode.Text = product.Barcode;
			// Price
			this.txtPrice.Text = product.Price.ToString("0.0#");
			// Product Name
			this.txtProductName.Text = product.ProductName + " " + product.ProductName_ZHHK + " " + product.ProductName_ZHCN;
			// Per-item packaging info
			this.txtPackagingInfo.Text = product.PackagingInfo + " " + product.PackagingInfo_ZHHK + " " + product.PackagingInfo_ZHCN;
			// Quantity
			this.txtQuantity.Text = product.Quantity + " " + product.Unit + " " + product.Unit_ZHHK + " " + product.Unit_ZHCN;
			// Description
			this.txtDescription.Text = product.Description;
			this.txtDescriptionZHHK.Text = product.Description_ZHHK;
			this.txtDescriptionZHCN.Text = product.Description_ZHCN;
			// Linked Discount
			this.txtLinkedDiscount.Text = "(Loading...)";
			// Shelf Using
			this.txtShelfUsing.Text = "(Loading...)";
			// ISWh Using
			this.txtInShopWarehouseUsing.Text = "(Loading...)";
			// image of product
			this.pnlProductImage.BackgroundImage = ProductImageStorage.LoadImage(product.ProductID);
		}
		
		// [Product.cs] -> public ProductWithUnderlyings GetUnderlyingDetails(ProductWithUnderlyings product)
		
		private void ShowUnderlyingDetailsOnUI(ProductWithUnderlyings product)
		{
			// show results on ui
			this.txtLinkedDiscount.Text = product.Discounts.Count + "";
			this.txtShelfUsing.Text = product.ShelfUsages.Count + "";
			this.txtInShopWarehouseUsing.Text = product.ShelfUsages.Count + "";
			this.btnViewDetails.Enabled = true;
		}
		
		private void TxtSearchValue_KeyUp(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) && this.txtSearchValue.Text.Length > 0) {
				this.btnSearch.PerformClick();
			}
		}
		
		private void BtnViewDetails_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.lsvSearchResult.SelectedIndices[0];
			Product SelectedProduct = this.SearchResult[selectedIndex];
			if (SelectedProduct.GetType() == typeof(ProductWithUnderlyings)) {
				DlgViewEditDeleteProductDetails dlgViewEditDeleteProductDetails = new DlgViewEditDeleteProductDetails((ProductWithUnderlyings)SelectedProduct);
				dlgViewEditDeleteProductDetails.ShowDialog(this);
			}
		}
		
		private void LsvSearchResultMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Clicks > 1 && e.Button == MouseButtons.Left && this.btnViewDetails.Enabled)
				this.btnViewDetails.PerformClick();
		}
	}
}
