/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 21/6/2014
 * Time: 5:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class DialogIdle : Form
	{
		public DialogIdle()
		{
			InitializeComponent();
		}
		
		private void DlgIdle_Load(object sender, EventArgs e)
		{
			this.timerInterrupt.Start();
		}
		
		private void DialogIdle_Shown(object sender, EventArgs e)
		{
			System.Media.SystemSounds.Question.Play();
		}
		
		private void TimerInterrupt_Tick(object sender, EventArgs e)
		{
			if (Misc.GetLastInputTime() == 0) {
				this.Close();
			}
		}
	}
}
