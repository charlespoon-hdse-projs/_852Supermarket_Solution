/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 10/6/2014
 * Time: 4:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP1_01
{
	partial class Login
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
			this.button2 = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.spmk = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.pw = new System.Windows.Forms.Label();
			this.userID = new System.Windows.Forms.Label();
			this.bgwLogin = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(379, 285);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 14;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// btnLogin
			// 
			this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnLogin.Location = new System.Drawing.Point(298, 285);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(75, 23);
			this.btnLogin.TabIndex = 13;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.BtnLoginClick);
			// 
			// spmk
			// 
			this.spmk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.spmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.spmk.Location = new System.Drawing.Point(96, 92);
			this.spmk.Name = "spmk";
			this.spmk.Size = new System.Drawing.Size(409, 100);
			this.spmk.TabIndex = 12;
			this.spmk.Text = "852 Supermakert\r\nProduct Catalogue Enquiry\r\n&&\r\nMaintenance Application";
			this.spmk.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtPassword.Location = new System.Drawing.Point(231, 243);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '●';
			this.txtPassword.Size = new System.Drawing.Size(216, 20);
			this.txtPassword.TabIndex = 11;
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtUsernameKeyUp);
			// 
			// txtUsername
			// 
			this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtUsername.Location = new System.Drawing.Point(231, 204);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(216, 20);
			this.txtUsername.TabIndex = 10;
			this.txtUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtUsernameKeyUp);
			// 
			// pw
			// 
			this.pw.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pw.Location = new System.Drawing.Point(146, 246);
			this.pw.Name = "pw";
			this.pw.Size = new System.Drawing.Size(68, 17);
			this.pw.TabIndex = 9;
			this.pw.Text = "Password:";
			// 
			// userID
			// 
			this.userID.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.userID.Location = new System.Drawing.Point(146, 207);
			this.userID.Name = "userID";
			this.userID.Size = new System.Drawing.Size(68, 15);
			this.userID.TabIndex = 8;
			this.userID.Text = "User name:";
			// 
			// bgwLogin
			// 
			this.bgwLogin.WorkerSupportsCancellation = true;
			this.bgwLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwLogin_DoWork);
			this.bgwLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgwLogin_RunWorkerCompleted);
			// 
			// Login
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.spmk);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.pw);
			this.Controls.Add(this.userID);
			this.Name = "Login";
			this.Size = new System.Drawing.Size(600, 400);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.ComponentModel.BackgroundWorker bgwLogin;
		private System.Windows.Forms.Label userID;
		private System.Windows.Forms.Label pw;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label spmk;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button button2;
	}
}
