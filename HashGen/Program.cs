/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 21/6/2014
 * Time: 1:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace Hash
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Input password string:");
			string pass = Console.ReadLine();
			Console.WriteLine();
			Console.WriteLine("==============================");
			Console.WriteLine();
			SimpleCrypto.ICryptoService cs = new SimpleCrypto.PBKDF2();
			string saltGen = cs.GenerateSalt();
			Console.WriteLine("Generated Salt:");
			Console.WriteLine(saltGen);
			Console.WriteLine();
			Console.WriteLine("Computed Hashed Password:");
			Console.WriteLine(cs.Compute(pass, saltGen));
			Console.WriteLine();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}