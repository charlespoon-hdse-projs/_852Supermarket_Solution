/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 3:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP1_01
{
	partial class MaintainData
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			this.components = new System.ComponentModel.Container();
			this.spmk = new System.Windows.Forms.Label();
			this.tpgSearch = new System.Windows.Forms.TabPage();
			this.ucSearchEditDelete1 = new SDP1_01.UcSearchView();
			this.tpgAdd = new System.Windows.Forms.TabPage();
			this.ucAdd1 = new SDP1_01.ucAdd();
			this.tpgImport = new System.Windows.Forms.TabPage();
			this.ucImport1 = new SDP1_01.ucImport();
			this.tbcMain = new System.Windows.Forms.TabControl();
			this.lblLogout = new System.Windows.Forms.LinkLabel();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblUsername = new System.Windows.Forms.Label();
			this.lblSystemTime = new System.Windows.Forms.Label();
			this.timerRefreshTime = new System.Windows.Forms.Timer(this.components);
			this.tpgSearch.SuspendLayout();
			this.tpgAdd.SuspendLayout();
			this.tpgImport.SuspendLayout();
			this.tbcMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// spmk
			// 
			this.spmk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.spmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.spmk.Location = new System.Drawing.Point(12, 9);
			this.spmk.Name = "spmk";
			this.spmk.Size = new System.Drawing.Size(539, 53);
			this.spmk.TabIndex = 5;
			this.spmk.Text = "852 Supermakert\r\nProduct Catalogue Enquiry && Maintenance Application";
			this.spmk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tpgSearch
			// 
			this.tpgSearch.Controls.Add(this.ucSearchEditDelete1);
			this.tpgSearch.Location = new System.Drawing.Point(4, 22);
			this.tpgSearch.Name = "tpgSearch";
			this.tpgSearch.Padding = new System.Windows.Forms.Padding(3);
			this.tpgSearch.Size = new System.Drawing.Size(752, 462);
			this.tpgSearch.TabIndex = 0;
			this.tpgSearch.Text = "Search";
			this.tpgSearch.UseVisualStyleBackColor = true;
			// 
			// ucSearchEditDelete1
			// 
			this.ucSearchEditDelete1.AutoScroll = true;
			this.ucSearchEditDelete1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ucSearchEditDelete1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucSearchEditDelete1.Location = new System.Drawing.Point(3, 3);
			this.ucSearchEditDelete1.Name = "ucSearchEditDelete1";
			this.ucSearchEditDelete1.Size = new System.Drawing.Size(746, 456);
			this.ucSearchEditDelete1.TabIndex = 0;
			// 
			// tpgAdd
			// 
			this.tpgAdd.Controls.Add(this.ucAdd1);
			this.tpgAdd.Location = new System.Drawing.Point(4, 22);
			this.tpgAdd.Name = "tpgAdd";
			this.tpgAdd.Padding = new System.Windows.Forms.Padding(3);
			this.tpgAdd.Size = new System.Drawing.Size(752, 462);
			this.tpgAdd.TabIndex = 1;
			this.tpgAdd.Text = "Add";
			this.tpgAdd.UseVisualStyleBackColor = true;
			// 
			// ucAdd1
			// 
			this.ucAdd1.AutoScroll = true;
			this.ucAdd1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucAdd1.Location = new System.Drawing.Point(3, 3);
			this.ucAdd1.Name = "ucAdd1";
			this.ucAdd1.Padding = new System.Windows.Forms.Padding(10);
			this.ucAdd1.Size = new System.Drawing.Size(746, 456);
			this.ucAdd1.TabIndex = 0;
			// 
			// tpgImport
			// 
			this.tpgImport.Controls.Add(this.ucImport1);
			this.tpgImport.Location = new System.Drawing.Point(4, 22);
			this.tpgImport.Name = "tpgImport";
			this.tpgImport.Padding = new System.Windows.Forms.Padding(3);
			this.tpgImport.Size = new System.Drawing.Size(752, 462);
			this.tpgImport.TabIndex = 2;
			this.tpgImport.Text = "Import";
			this.tpgImport.UseVisualStyleBackColor = true;
			// 
			// ucImport1
			// 
			this.ucImport1.AutoScroll = true;
			this.ucImport1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucImport1.Location = new System.Drawing.Point(3, 3);
			this.ucImport1.Name = "ucImport1";
			this.ucImport1.Size = new System.Drawing.Size(746, 456);
			this.ucImport1.TabIndex = 0;
			// 
			// tbcMain
			// 
			this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tbcMain.Controls.Add(this.tpgSearch);
			this.tbcMain.Controls.Add(this.tpgAdd);
			this.tbcMain.Controls.Add(this.tpgImport);
			this.tbcMain.Location = new System.Drawing.Point(12, 65);
			this.tbcMain.Name = "tbcMain";
			this.tbcMain.SelectedIndex = 0;
			this.tbcMain.Size = new System.Drawing.Size(760, 488);
			this.tbcMain.TabIndex = 0;
			// 
			// lblLogout
			// 
			this.lblLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLogout.Location = new System.Drawing.Point(730, 9);
			this.lblLogout.Name = "lblLogout";
			this.lblLogout.Size = new System.Drawing.Size(42, 17);
			this.lblLogout.TabIndex = 6;
			this.lblLogout.TabStop = true;
			this.lblLogout.Text = "Logout";
			this.lblLogout.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblLogout.Click += new System.EventHandler(this.LblLogoutClick);
			// 
			// lblUser
			// 
			this.lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUser.Location = new System.Drawing.Point(585, 9);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(33, 17);
			this.lblUser.TabIndex = 7;
			this.lblUser.Text = "User: ";
			this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUsername
			// 
			this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblUsername.Location = new System.Drawing.Point(624, 9);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(100, 17);
			this.lblUsername.TabIndex = 8;
			this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSystemTime
			// 
			this.lblSystemTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSystemTime.Location = new System.Drawing.Point(585, 39);
			this.lblSystemTime.Name = "lblSystemTime";
			this.lblSystemTime.Size = new System.Drawing.Size(187, 23);
			this.lblSystemTime.TabIndex = 9;
			this.lblSystemTime.Text = "SysDate(day)";
			this.lblSystemTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerRefreshTime
			// 
			this.timerRefreshTime.Tick += new System.EventHandler(this.TimerRefreshTimeTick);
			// 
			// MaintainData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblSystemTime);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.lblUser);
			this.Controls.Add(this.lblLogout);
			this.Controls.Add(this.tbcMain);
			this.Controls.Add(this.spmk);
			this.DoubleBuffered = true;
			this.Name = "MaintainData";
			this.Size = new System.Drawing.Size(784, 565);
			this.Load += new System.EventHandler(this.MaintainDataLoad);
			this.tpgSearch.ResumeLayout(false);
			this.tpgAdd.ResumeLayout(false);
			this.tpgImport.ResumeLayout(false);
			this.tbcMain.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Timer timerRefreshTime;
		private SDP1_01.ucImport ucImport1;
		private SDP1_01.ucAdd ucAdd1;
		private SDP1_01.UcSearchView ucSearchEditDelete1;
		private System.Windows.Forms.Label lblSystemTime;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.LinkLabel lblLogout;
		private System.Windows.Forms.TabPage tpgSearch;
		private System.Windows.Forms.TabPage tpgAdd;
		private System.Windows.Forms.TabPage tpgImport;
		private System.Windows.Forms.TabControl tbcMain;
		private System.Windows.Forms.Label spmk;
	}
}
