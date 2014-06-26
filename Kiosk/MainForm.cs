/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Interop;

namespace SDP_02
{
	public partial class MainForm : Form
	{
		#region field vars
		private InputPanelConfigurationLib.InputPanelConfiguration inputPanelConfig;
		private System.Windows.Automation.AutomationElement MainForm_AutomationElements;
		private readonly bool forceTouch;
		private string strOldBarcode = "";
		private string langSuffix = "";
		#endregion
		
		#region ctor
		
		public MainForm() : this(false)
		{
		}
		
		public MainForm(bool forceTouch)
		{
			
			this.forceTouch = forceTouch;
			InitializeComponent();
		}
		
		#endregion
		
		// method
		private void InitCategoryListsAsync() {
			Thread thrInitCategoryLists = new Thread(new ThreadStart(InitCategoryLists));
			thrInitCategoryLists.Start();
		}
		
		private void InitCategoryLists() {
			// not wasting time to check if running this method on same thread
			this.cbxCategory.SelectedIndexChanged -= new System.EventHandler(this.CbxCategorySelectedIndexChanged);
			LoadCategory();
			this.cbxCategory.SelectedIndexChanged += new System.EventHandler(this.CbxCategorySelectedIndexChanged);
			LoadSubCategory();
		}
		
		private void UpdateStatus(int percentage, string status) {
			this.Invoke(
				new UpdateStatusDelegate(
					delegate {
						this.lblPercentText.Text = percentage + "%";
						this.pgbProgressBar.Value = percentage;
						this.lblStatusText.Text = status;
					}
				)
			);
		}
		
		private delegate void UpdateStatusDelegate();
		
		// eventhandlers
		
		private void MainFormLoad(object sender, EventArgs e)
		{
			// Enables WPF to mark edit field as supporting text pattern (Automation Concept)
			MainForm_AutomationElements = System.Windows.Automation.AutomationElement.FromHandle(this.Handle);
			
			try {
				// Windows 8 API to enable touch keyboard to monitor for focus tracking in this WPF application
				inputPanelConfig = new InputPanelConfigurationLib.InputPanelConfiguration();
				inputPanelConfig.EnableFocusTracking();
			} catch (System.Runtime.InteropServices.COMException) {
//				MessageBox.Show("The Input Panel Configuration cannot be implemented.\r\n\r\n"
//				                + "It is mostly because the system is not a Windows 8 PC, or \r\n"
//				                + "The sytem has lost the Win8 API \"tiptsf.dll\" or \r\n"
//				                + "its COMs not registered.\r\n\r\n"
//				                + "Please start touch in \"Force\" mode.",
//				                Application.ProductName,
//				                MessageBoxButtons.OK,
//				                MessageBoxIcon.Exclamation);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			
			InitCategoryListsAsync();
		}
		
		private void typableFieldFocusEnter(object sender, EventArgs e)
		{
			if (this.forceTouch) {
				Process.Start(@"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe");
			}
		}
		
		private void langChgBtnClick(object sender, EventArgs e)
		{
			string culture = "en";
			if (sender == this.btnZHHK) {
				culture = "zh-HK";
			} else if (sender == this.btnZHCN) {
				culture = "zh-CN";
			} else if (sender == this.btnEN) {
				culture = "en";
			}
			
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
			
			this.Controls.Clear();
			this.InitializeComponent();
			InitCategoryListsAsync();
		}
		
		void CbxCategorySelectedIndexChanged(object sender, EventArgs e)
		{
			LoadSubCategory();
		}
		
		#region bgwSqlQuery
		
		private void BgwSqlQueryDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			e.Result = System.DateTime.Now.Ticks;
			// telling user that the progress has started
			bgwSqlQuery.ReportProgress(0, "Connecting to database");
			
			if (e.Argument == null || e.Argument.GetType() != typeof (WhereClause))
				throw new ArgumentOutOfRangeException("The SQL query background worker can only work with one Kiosk.WhereClauseCollection object passed into.");
			
			if (this.listViewProductDetails.InvokeRequired) {
				this.listViewProductDetails.Invoke(new ClearListViewDelegate(this.listViewProductDetails.Items.Clear));
			} else {
				this.listViewProductDetails.Items.Clear();
			}
			
			WhereClause where = (WhereClause) e.Argument;
			
			int connectFailCount = 0;
			while (true) {
				try {
					db_conn.Open();
					break;
				} catch (OleDbException) {
					MessageBox.Show("Connection-level error between this application and database has occured.\r\n"
					                + "Please check your settings and restart this application.\r\n"
					                + "\r\nThis application is about to close.",
					                Application.ProductName,
					                MessageBoxButtons.OK,
					                MessageBoxIcon.Error);
					Application.Exit();
					break;
				} catch (InvalidOperationException) {
					if (++connectFailCount >= 5) {
						db_conn.Close();
					}
					Thread.Sleep(2000);
				}
			}
			bgwSqlQuery.ReportProgress(20, "Fetching query results from database");
			
			// dataset of product
			DataSet dtsProduct = new DataSet();
			// "SELECT barcode, productName, description, quantity, unit, price FROM Product"
			OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT productID, productName" + langSuffix + ", barcode, price, quantity, unit" + langSuffix + ", description" + langSuffix
			                                                + " FROM Product"
			                                                + " WHERE " + where.ToString() + ";",
			                                                db_conn);
			adapter.Fill(dtsProduct);
			
			int drawnCount = 0;
			foreach (DataRow row in dtsProduct.Tables[0].Rows) {
				bgwSqlQuery.ReportProgress(50 +  50 * drawnCount / dtsProduct.Tables[0].Rows.Count, "Showing results (" + drawnCount + " of " + dtsProduct.Tables[0].Rows.Count + ")");
				// ProductName, Barcode, Price, Qty, Shelf, Discount, Desc
				string productID = (string) row["productID"];
				string productName = (string) row["productName" + langSuffix];
				string barcode = (string) row["barcode"];
				decimal price = (decimal) row["price"];
				string quantity = ((short) row["quantity"]) + " " + ((string) row["unit" + langSuffix]);
				string shelf = "";
				int discountCount = 0;
				string description = (string) row["description" + langSuffix];
				
				// dataset of discount count
				DataSet dtsDiscountCount = new DataSet();
				OleDbDataAdapter adapterDiscountCount = new OleDbDataAdapter("SELECT count(discountID)  FROM Discount WHERE productID = \'" + productID + "\' GROUP BY productID;", db_conn);
				adapterDiscountCount.Fill(dtsDiscountCount);
				try {
					discountCount = (int) dtsDiscountCount.Tables[0].Rows[0][0];
				} catch (Exception) {
				}
				
				// calculate max discount
				// HACK: hahahaha fake calc max discount
				decimal egDiscountPrice = 0.0m;
				if (discountCount > 0) {
					DataSet dtsDiscountOpr = new DataSet();
					OleDbDataAdapter adapterDiscountP = new OleDbDataAdapter("SELECT TOP 1 DiscountOperation.discountOperator, DiscountOperation.discountOperandNum FROM DiscountOperation INNER JOIN Discount ON DiscountOperation.discountID = Discount.discountID WHERE Discount.productID=\'" + productID + "\';", db_conn);
					adapterDiscountP.Fill(dtsDiscountOpr);
					decimal discountOperandNum = (decimal)((float)dtsDiscountOpr.Tables[0].Rows[0]["discountOperandNum"]);
					switch (((string)dtsDiscountOpr.Tables[0].Rows[0]["discountOperator"])) {
						case "+":
							egDiscountPrice = price + discountOperandNum;
							break;
						case "-":
							egDiscountPrice = price - discountOperandNum;
							break;
						case "*":
							egDiscountPrice = price * discountOperandNum;
							break;
						case "/":
							egDiscountPrice = price / discountOperandNum;
							break;
					}
				}
				
				// dataset of shelf locations
				DataSet dtsShelfLoc = new DataSet();
				OleDbDataAdapter adapterShelfLoc = new OleDbDataAdapter("SELECT shelfLocation FROM ShelfUsage WHERE productID = \'" + productID + "\';", db_conn);
				adapterShelfLoc.Fill(dtsShelfLoc);
				for (int i = 0; i < dtsShelfLoc.Tables[0].Rows.Count; i++) {
					shelf += (i > 0 ? ", " : "") + dtsShelfLoc.Tables[0].Rows[i][0];
				}
				
				ListViewItem newItem = new ListViewItem(productName);
				newItem.SubItems.Add(barcode);
				newItem.SubItems.Add(price.ToString());
				newItem.SubItems.Add(quantity);
				newItem.SubItems.Add(shelf);
				newItem.SubItems.Add(discountCount.ToString() + (egDiscountPrice == 0.0m ? "" : " (eg after:" + egDiscountPrice + ")"));
				newItem.SubItems.Add(description);
				
				if (this.listViewProductDetails.InvokeRequired) {
					this.listViewProductDetails.Invoke(new AddItemToListViewDelegate(this.listViewProductDetails.Items.Add), newItem);
				} else {
					this.listViewProductDetails.Items.Add(newItem);
				}
			}
			
			db_conn.Close();
		}
		
		private delegate void ClearListViewDelegate();
		delegate ListViewItem AddItemToListViewDelegate(ListViewItem value);
		
		private void DatabaseBackgroundWorkers_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			string senderTxt = "";
			if (sender == this.bgwSqlQuery) {
				senderTxt = "Product Query";
			} else if ((Control)sender != null) {
				senderTxt = ((Control)sender).Name;
			} else {
				senderTxt = sender.ToString();
			}
			
			senderTxt += ": " + (string) e.UserState;
			UpdateStatus(e.ProgressPercentage, senderTxt);
		}
		
		private void DatabaseBackgroundWorkers_Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			double timeElapsed = (DateTime.Now.Ticks - (long) e.Result) / TimeSpan.TicksPerMillisecond;
			string statusText = "Query excuted in " + String.Format("{0:N2}ms", timeElapsed) + ", resulting in " + this.listViewProductDetails.Items.Count + " items. ";
			DatabaseBackgroundWorkers_ProgressChanged(sender, new System.ComponentModel.ProgressChangedEventArgs(100, statusText));
		}
		
		#endregion
		
		#region LoadCategory
		
		void LoadCategory()
		{
			long start = System.DateTime.Now.Ticks;
			// telling user that the progress has started
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(0, "Connecting to database"));
			
			dstCategory = new DataSet();
			
			int connectFailCount = 0;
			while (true) {
				try {
					db_conn.Open();
					break;
				} catch (OleDbException) {
					MessageBox.Show("Connection-level error between this application and database has occured.\r\n"
					                + "Please check your settings and restart this application.\r\n"
					                + "\r\nThis application is about to close.",
					                Application.ProductName,
					                MessageBoxButtons.OK,
					                MessageBoxIcon.Error);
					Application.Exit();
					break;
				} catch (InvalidOperationException) {
					if (++connectFailCount >= 5) {
						db_conn.Close();
					}
					Thread.Sleep(2000);
				}
			}
			
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(20, "Fetching query results from database"));
			
			OleDbDataAdapter adpCategory = new OleDbDataAdapter("SELECT categoryID, name" + langSuffix + " FROM Category", db_conn);
			adpCategory.Fill(dstCategory);
			
			db_conn.Close();
			
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(50, "Showing results"));
			if (this.cbxCategory.InvokeRequired) {
				this.cbxCategory.Invoke(new UpdateCbxCategory_Delegate(this.UpdateCbxCategory));
			} else {
				UpdateCbxCategory();
			}
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(100, "Complete refresh list"));
		}
		
		private delegate void UpdateCbxCategory_Delegate();
		
		private void UpdateCbxCategory()
		{
			this.cbxCategory.DataSource = dstCategory.Tables[0];
			this.cbxCategory.DisplayMember = "name" + langSuffix;
			this.cbxCategory.ValueMember = "categoryID";
		}
		
		#endregion
		
		#region LoadSubCategory
		
		void LoadSubCategory()
		{
			long start = System.DateTime.Now.Ticks;
			// telling user that the progress has started
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(0, "Connecting to database"));
			
			dstSubCategory = new DataSet();
			
			int connectFailCount = 0;
			while (true) {
				try {
					db_conn.Open();
					break;
				} catch (OleDbException) {
					MessageBox.Show("Connection-level error between this application and database has occured.\r\n"
					                + "Please check your settings and restart this application.\r\n"
					                + "\r\nThis application is about to close.",
					                Application.ProductName,
					                MessageBoxButtons.OK,
					                MessageBoxIcon.Error);
					Application.Exit();
					break;
				} catch (InvalidOperationException) {
					if (++connectFailCount >= 5) {
						db_conn.Close();
					}
					Thread.Sleep(2000);
				}
			}
			
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(20, "Fetching query results from database"));
			string selectedCategoryID = "";
			this.cbxCategory.Invoke(new UpdateCbxSubCategory_Delegate(delegate { selectedCategoryID = (string) this.cbxCategory.SelectedValue; }));
			OleDbDataAdapter adbSubCategory = new OleDbDataAdapter("SELECT subCategoryID" + langSuffix + ", name FROM SubCategory WHERE categoryID=\'" + selectedCategoryID + "\';", db_conn);
			adbSubCategory.Fill(dstSubCategory);
			
			db_conn.Close();
			
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(50, "Showing results"));
			if (this.cbxSubCategory.InvokeRequired) {
				this.cbxSubCategory.Invoke(new UpdateCbxSubCategory_Delegate(this.UpdateCbxSubCategory));
			} else {
				UpdateCbxSubCategory();
			}
			DatabaseBackgroundWorkers_ProgressChanged(this, new System.ComponentModel.ProgressChangedEventArgs(100, "Complete refresh list"));
		}
		
		private delegate void UpdateCbxSubCategory_Delegate();
		
		private void UpdateCbxSubCategory()
		{
			this.cbxSubCategory.DataSource = dstSubCategory.Tables[0];
			this.cbxSubCategory.ValueMember = "subCategoryID" + langSuffix;
			this.cbxSubCategory.DisplayMember = "name";
		}
		
		#endregion
		
		#region txtBarcode / btnBarcodeSearch
		
		void TxtBarcodeKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return || e.KeyData == Keys.Enter) {
				this.btnBarcodeSearch.PerformClick();
			}
		}
		
		void TxtBarcode_TextChanged(object sender, EventArgs e)
		{
			ulong n = 0;
			if(!UInt64.TryParse(this.txtBarcode.Text, out n) && this.txtBarcode.Text.Length > 0) {
				this.txtBarcode.Text = strOldBarcode;
			} else {
				strOldBarcode = this.txtBarcode.Text;
			}
			this.lblBarcodeHelp.Visible = !(this.txtBarcode.Text.Length > 0);
		}
		
		
		void BtnBarcodeSearch_Click(object sender, EventArgs e)
		{
			if (!bgwSqlQuery.IsBusy)
				this.bgwSqlQuery.RunWorkerAsync(new WhereClause("barcode", this.txtBarcode.Text));
		}
		
		#endregion
		
		void BtnEnter_Click(object sender, EventArgs e)
		{
			this.bgwSqlQuery.RunWorkerAsync(new WhereClause("subCategoryID", this.cbxSubCategory.SelectedValue));
		}
	}
}
