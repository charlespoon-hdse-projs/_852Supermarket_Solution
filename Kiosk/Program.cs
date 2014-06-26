/*
 * Created by SharpDevelop.
 * User: Lenovo
 * Date: 6/9/2014
 * Time: 8:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Windows.Forms;

namespace SDP_02
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			// read ini file for touch setting
			bool forceTouch = false;
			try {
				string[] ini = File.ReadAllLines("touch.ini");
				foreach (string c in ini) {
					if (c == "force=true")
						forceTouch = true;
				}
			} catch (Exception) {
			}
			
			Application.Run(new MainForm(forceTouch));
		}
		
	}
}
