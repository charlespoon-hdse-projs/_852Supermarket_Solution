using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class DlgInShopWarehouseUsage : Form
	{
		/// <summary>
		/// The result of selection of this dialog. The DataTable includes selected "inShopWarehouseLoc" and "wkPlcName" columns from table "InShopWarehouse".
		/// </summary>
		internal DataTable SelectResultDataTable { get; private set; }
		internal List<string> SelectResultList { get; private set; }
		private List<string> existingSelected;
		
		public DlgInShopWarehouseUsage() : this(null)
		{
		}
		
		public DlgInShopWarehouseUsage(List<string> existingSelected)
		{
			this.existingSelected = existingSelected;
			InitializeComponent();
		}
		
		private void AddInShopWarehouseUsage_Load(object sender, EventArgs e)
		{
			LoadExistingInShopWarehouseListToUI();
			CheckExistingSelected();
		}
		
		private void LoadExistingInShopWarehouseListToUI()
		{
			OleDbCommand cmdInShopWarehouses = new OleDbCommand("SELECT inShopWarehouseLoc, wkPlcName, "
			                                                    + "inShopWarehouseLoc & ' (' & wkPlcName & ')' AS inShopWarehouseLocHumanReadable "
			                                                    + "FROM InShopWarehouse "
			                                                    + "INNER JOIN WorkPlace "
			                                                    + "ON InShopWarehouse.wkPlcID = WorkPlace.wkPlcID;");
			this.clbInShopWarehouses.DataSource = DatabaseCommunicator.SelectFromTable(cmdInShopWarehouses);
			this.clbInShopWarehouses.DisplayMember = "inShopWarehouseLocHumanReadable";
			this.clbInShopWarehouses.ValueMember = "inShopWarehouseLoc";
		}
		
		private void CheckExistingSelected()
		{
			if (existingSelected != null) {
				for (int i = 0; i < this.clbInShopWarehouses.Items.Count; i++) {
					DataRowView drv = (DataRowView)this.clbInShopWarehouses.Items[i];
					
					if (existingSelected.Contains((string)drv.Row["inShopWarehouseLoc"]))
						this.clbInShopWarehouses.SetItemChecked(i, true);
				}
			}
		}
		
		private void BtnOK_Click(object sender, EventArgs e)
		{
			List<string> listInShopWarehouseResult = new List<string>();
			
			DataTable dtbInShopWarehousesResult = ((DataTable)this.clbInShopWarehouses.DataSource).Copy();
			dtbInShopWarehousesResult.Rows.Clear();
			foreach (DataRowView drv in this.clbInShopWarehouses.CheckedItems) {
				listInShopWarehouseResult.Add((string)drv["inShopWarehouseLoc"]);
				dtbInShopWarehousesResult.Rows.Add(drv.Row.ItemArray);
			}
			dtbInShopWarehousesResult.Columns.Remove("inShopWarehouseLocHumanReadable");
			this.SelectResultDataTable = dtbInShopWarehousesResult;
			this.SelectResultList = listInShopWarehouseResult;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
