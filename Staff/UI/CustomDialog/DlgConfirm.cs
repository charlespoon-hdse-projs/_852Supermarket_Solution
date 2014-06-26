/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 22/6/2014
 * Time: 15:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDP1_01
{
	/// <summary>
	/// Description of Confirm.
	/// </summary>
	public partial class DlgConfirm : Form
	{
		int secLeftToEnableBtnYes = 5;
		bool tmrYesEnableFastForward = false;
		
		public DlgConfirm()
		{
			InitializeComponent();
		}
		
		private void Confirm_Load(object sender, EventArgs e)
		{
			this.tmrYesEnable.Start();
		}
		
		private void Confirm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.tmrYesEnable.Stop();
		}
		
		private void TimerYesEnable_Tick(object sender, EventArgs e)
		{
			this.btnYes.Text = "Yes (" + --secLeftToEnableBtnYes + ")";
			if (secLeftToEnableBtnYes <= 0) {
				this.btnYes.Text = "Yes";
				this.btnYes.Enabled = true;
				this.tmrYesEnable.Stop();
			}
		}
		
		private void BtnYes_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void BtnNo_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void DlgConfirm_MouseMove(object sender, MouseEventArgs e)
		{
			if (!this.btnYes.Enabled && 
			   e.X >= this.btnYes.Location.X && e.X < this.btnYes.Location.X + this.btnYes.Width &&
			   e.Y >= this.btnYes.Location.Y && e.Y < this.btnYes.Location.Y + this.btnYes.Height)
			{
				if (!tmrYesEnableFastForward) {
					this.tmrYesEnable.Interval = 500;
					tmrYesEnableFastForward = true;
				}
			}
		}
	}
}
