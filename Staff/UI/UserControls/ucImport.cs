/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 8:19 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	/// <summary>
	/// Description of ucImport.
	/// </summary>
	public partial class ucImport : UserControl
	{
		private List<Product> parsedProducts = new List<Product>();
		
		public ucImport()
		{
			InitializeComponent();
		}
		
		private void BtnBrowseClick(object sender, EventArgs e)
		{
			if (this.ofdCSVImport.ShowDialog() == DialogResult.OK) {
				bgwReadFile.RunWorkerAsync(this.ofdCSVImport.FileName);
			}
		}
		
		private void TxtPathLeave(object sender, EventArgs e)
		{
//			bgwReadFile.RunWorkerAsync(this.ofdCSVImport.FileName);
		}
		
		private void TxtPathKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) {
				bgwReadFile.RunWorkerAsync(this.ofdCSVImport.FileName);
			}
		}
		
		private void OpenFilePreview(String filePath) {
			try {
				
				string[] arr1 = File.ReadAllLines(filePath);
				
				string[][] arr2 = new string[arr1.Length][];
				for (int i = 0; i < arr1.Length; i++) {
					arr2[i] = arr1[i].Split(new char[] {','}, 6);
				}
				
				parsedProducts = Product.Parse(arr2);
			} catch (Exception e) {
				MessageBox.Show(e.Message, e.ToString());
			}
			
			foreach (Product p in parsedProducts) {
				// Barcode  Sub-Category  Description  Qty  Unit
				ListViewItem lvi = new ListViewItem();
				lvi.Name = p.Barcode; // optional
				lvi.Text = p.Barcode;
				lvi.SubItems.Add(p.SubCategoryID);
				lvi.SubItems.Add(p.Description);
				lvi.SubItems.Add(p.Quantity + "");
				lvi.SubItems.Add(p.Unit);
				if (this.InvokeRequired) {
					this.Invoke(new ThreadStart(delegate { this.lsvPreview.Items.Add(lvi); }));
				} else {
					this.lsvPreview.Items.Add(lvi);
				}
			}
		}
		
		private void BgwReadFileDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			OpenFilePreview((string)e.Argument);
		}
		
		private void BtnImportClick(object sender, EventArgs e)
		{
			if (new DlgConfirm().ShowDialog(this.ParentForm) != DialogResult.OK) return;
			
			System.ComponentModel.BackgroundWorker bgwImportIntoDB = new System.ComponentModel.BackgroundWorker();
			bgwImportIntoDB.WorkerReportsProgress = true;
			bgwImportIntoDB.DoWork += new System.ComponentModel.DoWorkEventHandler(BgwImportIntoDB_DoWork);
			bgwImportIntoDB.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(bgwImportIntoDB_RunWorkerCompleted);
			bgwImportIntoDB.RunWorkerAsync();
		}

		private void bgwImportIntoDB_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			int err = (int)e.Result;
			if (err > 0)
				MessageBox.Show(err + " of " + parsedProducts.Count + " items cannot be imported.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			else
				MessageBox.Show("All items are successfully imported.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
			
//			this.txtPreview.Clear();
			this.lsvPreview.Items.Clear();
			this.txtPath.Clear();
		}
		
		private void BgwImportIntoDB_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			System.ComponentModel.BackgroundWorker bgwHost = (System.ComponentModel.BackgroundWorker)sender;
			
			int step = 0;
			int error = 0;
			foreach (Product p in parsedProducts) {
				bgwHost.ReportProgress(++step / parsedProducts.Count, step);
				if (!DatabaseCommunicator.Inserter.InsertProduct(p))
					error++;
			}
			
			e.Result = error;
		}
	}
}
