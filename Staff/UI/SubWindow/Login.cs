/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 10/6/2014
 * Time: 4:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class Login : UserControl
	{
		Thread thrComputeHash = null;
		
		public Login()
		{
			InitializeComponent();
		}
		
		private delegate void RunOnUIThreadDelegate();
		
		private void BtnLoginClick(object sender, EventArgs e)
		{
			this.bgwLogin.RunWorkerAsync();
		}
		
		private void TxtUsernameKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
				this.btnLogin.PerformClick();
		}
		
		private void Button2Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		private void BgwLogin_DoWork(object sender, DoWorkEventArgs e)
		{
			string inputUsername = "";
			string inputPassword = "";
			
			IAsyncResult loadingDialogAsyncResult = null;
			FrmLoading loadingDialog = new FrmLoading("Loading user info from database...");
			loadingDialog.Closed += new EventHandler(loadingDialog_ClosedWhenBgwLoginNotComplete);
			
			this.Invoke(new RunOnUIThreadDelegate(delegate {
			                                      	loadingDialogAsyncResult = this.BeginInvoke(new ThreadStart(delegate { loadingDialog.ShowDialog(); }));
			                                      	this.txtUsername.Enabled = false;
			                                      	this.txtPassword.Enabled = false;
			                                      	inputUsername = this.txtUsername.Text;
			                                      	inputPassword = this.txtPassword.Text;
			                                      }));
			
			OleDbCommand passwordSelector = new OleDbCommand("SELECT empHashed, empSalt FROM Employee WHERE empLoginName = @empLoginName");
			passwordSelector.Parameters.AddWithValue("@empLoginName", inputUsername);
			DataRow resultQuery = DatabaseCommunicator.SelectFromTable(passwordSelector).Rows[0];
			
			if (this.bgwLogin.CancellationPending) {
				return;
			}
			
			loadingDialog.Invoke(new RunOnUIThreadDelegate(delegate { loadingDialog.Text = "Validating Credential..."; }));
			
			string hashed = (string)resultQuery["empHashed"];
			string salt = (string)resultQuery["empSalt"];
			SimpleCrypto.ICryptoService cryptoService = new SimpleCrypto.PBKDF2();
			
			if (this.bgwLogin.CancellationPending) {
				return;
			}
			
			loadingDialog.Closed += new EventHandler(loadingDialog_ClosedWhilstComputingHash);
			string inputHashed = "";
			thrComputeHash = new Thread(new ThreadStart(delegate {
			                                            	inputHashed = cryptoService.Compute(inputPassword, salt);
			                                            }));
			thrComputeHash.Name = "Compute Hash using PBKDF2";
			thrComputeHash.Start();
			thrComputeHash.Join();
			loadingDialog.Closed -= loadingDialog_ClosedWhilstComputingHash;
			
			loadingDialog.Closed -= loadingDialog_ClosedWhenBgwLoginNotComplete;
			loadingDialog.Invoke(new RunOnUIThreadDelegate(delegate { loadingDialog.Close(); }));
			this.EndInvoke(loadingDialogAsyncResult);
			
			if (inputHashed == hashed) {
				this.Invoke(new RunOnUIThreadDelegate(delegate {
				                                      	// hiding current login field to show maintain data usercontrol
				                                      	this.Hide();
				                                      	
				                                      	// creating maintain data usercontrol with necessary information
				                                      	// TODO: I NEED TOKEN!!!
				                                      	MaintainData maintainData = new MaintainData();
				                                      	maintainData.Name = "maintainData";
				                                      	maintainData.Dock = DockStyle.Fill;
				                                      	
				                                      	// writing some field about user credential...
				                                      	maintainData.showingUsername = this.txtUsername.Text;
				                                      	
				                                      	// adding maintain data to parent controls collection
				                                      	this.ParentForm.SuspendLayout();
				                                      	this.ParentForm.Controls.Add(maintainData);
				                                      	this.ParentForm.ResumeLayout();
				                                      	
				                                      	// ...and removing itself
				                                      	this.Parent.Controls.Remove(this);
				                                      }));
			} else {
				// easter egg
				if (txtUsername.Text == "you are an idiot" || txtUsername.Text == "***") {
					System.Diagnostics.Process.Start("https://www.youtube.com/embed/PMV_wyLnVwk?autoplay=1&start=3");
				} else {
					MessageBox.Show("The specified username and password matching cannot be found.\r\nPlease try again.", "Invalid Credential", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		void loadingDialog_ClosedWhenBgwLoginNotComplete(object sender, EventArgs e)
		{
			this.bgwLogin.CancelAsync();
		}

		void loadingDialog_ClosedWhilstComputingHash(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
		
		private void BgwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (thrComputeHash != null) {
				thrComputeHash.Abort();
			}
		}
	}
}
