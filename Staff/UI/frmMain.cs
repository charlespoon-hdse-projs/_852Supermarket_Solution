/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 10/6/2014
 * Time: 4:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent();
			
			Login login = new Login();
			login.Dock = DockStyle.Fill;
			this.Controls.Add(login);
		}
	}
}
