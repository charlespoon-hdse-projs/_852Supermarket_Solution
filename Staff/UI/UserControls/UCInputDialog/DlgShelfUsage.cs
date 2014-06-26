/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 22/6/2014
 * Time: 5:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace SDP1_01
{
	/// <summary>
	/// Description of AddShelfUsage.
	/// </summary>
	public partial class DlgShelfUsage : Form
	{
		/// <summary>
		/// The result of selection of this dialog. The DataTable includes selected "shelfLocation" and "wkPlcName" columns from table "Shelf".
		/// </summary>
		internal DataTable SelectResultDataTable { get; private set; }
		internal List<string> SelectResultList { get; private set; }
		private List<string> existingSelected;
		
		public DlgShelfUsage() : this(null)
		{
		}
		
		public DlgShelfUsage(List<string> existingSelected)
		{
			InitializeComponent();
			this.existingSelected = existingSelected;
		}
		
		private void AddShelfUsage_Load(object sender, EventArgs e)
		{
			LoadExistingShelfListToUI();
			if (existingSelected == null)
				existingSelected = new List<string>();
			else
				CheckExistingSelected();
		}
		
		private void LoadExistingShelfListToUI()
		{
			OleDbCommand cmdShelfs = new OleDbCommand("SELECT shelfLocation, wkPlcName, "
			                                          + "shelfLocation & ' (' & wkPlcName & ')' AS shelfLocationHumanReadable "
			                                          + "FROM Shelf "
			                                          + "INNER JOIN WorkPlace "
			                                          + "ON Shelf.wkPlcID = WorkPlace.wkPlcID");
			this.clbShelfs.DataSource = DatabaseCommunicator.SelectFromTable(cmdShelfs);
			this.clbShelfs.DisplayMember = "shelfLocationHumanReadable";
			this.clbShelfs.ValueMember = "shelfLocation";
		}
		
		private void CheckExistingSelected()
		{
			if (existingSelected != null) {
				for (int i = 0; i < this.clbShelfs.Items.Count; i++) {
					DataRowView drv = (DataRowView)this.clbShelfs.Items[i];
					
					if (existingSelected.Contains((string)drv.Row["shelfLocation"]))
						this.clbShelfs.SetItemChecked(i, true);
				}
			}
		}
		
		private void BtnOK_Click(object sender, EventArgs e)
		{
			List<string> listShelfResult = new List<string>();
			
			DataTable dtbShelfsResult = ((DataTable)this.clbShelfs.DataSource).Copy();
			dtbShelfsResult.Rows.Clear();
			foreach (DataRowView drv in this.clbShelfs.CheckedItems) {
				dtbShelfsResult.Rows.Add(drv.Row.ItemArray);
				listShelfResult.Add((string)drv["shelfLocation"]);
			}
			dtbShelfsResult.Columns.Remove("shelfLocationHumanReadable");
			this.SelectResultDataTable = dtbShelfsResult;
			this.SelectResultList = listShelfResult;
			this.Close();
		}
		
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
