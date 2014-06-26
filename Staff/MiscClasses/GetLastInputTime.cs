/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 21/6/2014
 * Time: 4:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.InteropServices;

namespace SDP1_01
{
	public static partial class Misc
	{
		[StructLayout( LayoutKind.Sequential)]
		private struct LASTINPUTINFO
		{
		    public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));
		
		    [MarshalAs(UnmanagedType.U4)]
		    public UInt32 cbSize;    
		    [MarshalAs(UnmanagedType.U4)]
		    public UInt32 dwTime;
		}
		
		[DllImport("user32.dll")]
		private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
		
		[DllImport("Kernel32.dll")]
		private static extern uint GetLastError();
		
		/// <summary>
		/// Get the Last input time in ticks
		/// </summary>
		/// <returns>The time lapse, in ticks.</returns>
		public static uint GetLastInputTime()
		{
			uint idleTime = 0;
			LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
			lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
			lastInputInfo.dwTime = 0;
			
			uint envTicks = (uint)Environment.TickCount;
			
			if (GetLastInputInfo( ref lastInputInfo) )
			{
				uint lastInputTick = lastInputInfo.dwTime;
				idleTime = envTicks - lastInputTick;
			}
			
			return ((idleTime> 0 ) ? (idleTime / 1000) : 0);
		}
	}
}
