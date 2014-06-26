/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 3:54 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class MaintainData : UserControl
	{
		private DialogIdle dlgIdle;
		private Form parent = null;
		
		internal string showingUsername {
			get {
				return this.lblUsername.Text;
			}
			set {
				this.lblUsername.Text = value;
			}
		}
		
		public MaintainData() : this(null)
		{
		}
		
		public MaintainData(Form parent)
		{
			this.parent = parent;
			InitializeComponent();
		}
		
		// methods
		private void Logout()
		{
			// cut-out database connection
			
			// hiding itself
			this.Hide();
			
			// creating login interface
			Login login = new Login();
			login.Name = "login";
			login.Dock = DockStyle.Fill;
//			login.Location = new Point(5, 5);
			
			// adding login interface
//			if (parent == null) parent = this.ParentForm;
			parent.SuspendLayout();
			parent.Controls.Add(login);
			parent.ResumeLayout();
			
			// ... and removing itself
			parent.Controls.Remove(this);
		}
		
		// Event Handlers
		private void TimerRefreshTimeTick(object sender, EventArgs e)
		{
			this.lblSystemTime.Text = DateTime.Now.ToString("HH:mm:ss dd MMM yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
			
			// kick if idle for 5 minutes
			uint lastInput = Misc.GetLastInputTime();
			if (lastInput >= 300) { // 5 minutes
				this.timerRefreshTime.Stop();
				dlgIdle.Close();
				Logout();
			} else if (lastInput >= 240) { // 4 minutes (1 minute left and kick)
				if (dlgIdle == null || !dlgIdle.Visible) {
					dlgIdle = new DialogIdle();
					dlgIdle.Visible = false;
					dlgIdle.Show(parent);
				}
			}
		}
		
		private void MaintainDataLoad(object sender, EventArgs e)
		{
			this.timerRefreshTime.Start();
			if (parent == null) parent = this.ParentForm;
		}
		
		private void LblLogoutClick(object sender, EventArgs e)
		{
			Logout();
		}
		
		private delegate void idlePromptDelegate();
	}
}
