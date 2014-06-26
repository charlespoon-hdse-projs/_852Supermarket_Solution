/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 21/6/2014
 * Time: 2:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	/// <summary>
	/// Description of Loading.
	/// </summary>
	public partial class FrmLoading : Form
	{
		internal bool PromptWhenClose { get; set; }
		internal bool Cancellable {
			get {
				bool result = false;
				if (this.InvokeRequired) {
					this.Invoke(new ThreadStart(delegate { result = this.btnCancel.Enabled; }));
				} else {
					result = this.btnCancel.Enabled;
				}
				return result;
			}
			set {
				if (this.InvokeRequired) {
					this.Invoke(new RunOnUIThreadDelegate(delegate { this.btnCancel.Enabled = value; }));
				} else {
					this.btnCancel.Enabled = value;
				}
			}
		}
		internal int Value {
			get {
				int result = 0;
				if (this.InvokeRequired) {
					this.Invoke(new ThreadStart(delegate { result = this.pgbMain.Value; }));
				} else {
					result = this.pgbMain.Value;
				}
				return result;
			}
			set {
				if (this.InvokeRequired) {
					this.Invoke(new RunOnUIThreadDelegate(delegate { this.pgbMain.Value = value; }));
				} else {
					this.pgbMain.Value = value;
				}
			}
		}
		internal string Title {
			get {
				string result = "";
				if (this.InvokeRequired) {
					this.Invoke(new ThreadStart(delegate { result = this.Text; }));
				} else {
					result = this.Text;
				}
				return result;
			}
			set {
				if (this.InvokeRequired) {
					this.Invoke(new RunOnUIThreadDelegate(delegate { this.Text = value; }));
				} else {
					this.Text = value;
				}
			}
		}
		
		private delegate void RunOnUIThreadDelegate();
		public delegate void RunWithNotBlockingThisThreadDelegate();
		
		public FrmLoading() : this("Loading...", ProgressBarStyle.Marquee, true, false)
		{
		}
		
		public FrmLoading(string title) : this(title, ProgressBarStyle.Marquee, true, false)
		{
		}
		
		public FrmLoading(bool cancellable) : this("Loading...", ProgressBarStyle.Marquee, cancellable, false)
		{
		}
		
		public FrmLoading(string title, ProgressBarStyle style, bool cancellable, bool promptWhenClose)
		{
			this.PromptWhenClose = promptWhenClose;
			InitializeComponent();
			this.Text = title;
			this.pgbMain.Style = style;
			this.Cancellable = cancellable;
		}
		
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			if (!PromptWhenClose || MessageBox.Show("Are you sure you want to cancel?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
				this.Close();
			}
		}
	}
}
