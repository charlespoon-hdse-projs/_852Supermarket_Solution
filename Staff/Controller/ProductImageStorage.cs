using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SDP1_01
{
	internal static class ProductImageStorage
	{
		private const string ImageStoragePath = @".\";
		
		internal static Bitmap LoadImage(string productID)
		{
			string filePath = ParseProductIDToImagePath(productID);
			if (File.Exists(filePath)) {
				Stream ms = new MemoryStream(File.ReadAllBytes(filePath));
				return new Bitmap(ms);
			}
			return null;
		}
		
		internal static bool SaveImage(Image image, string productID)
		{
			try {
				BuildProductImagePathDirectory(productID);
				image.Save(ParseProductIDToImagePath(productID), ImageFormat.Png);
				return true;
			}
			#if DEBUG
			catch (Exception ex) {
				System.Windows.Forms.MessageBox.Show("Error during saving image: \r\n" + ex.Message);
				
				return false;
			}
			#endif
			#if !DEBUG
			catch (Exception) {
				return false;
			}
			#endif
		}
		
		internal static void CleanUpImage(string productID)
		{
			string filePath = ParseProductIDToImagePath(productID);
			if (File.Exists(filePath))
				File.Delete(filePath);
		}
		
		private static string ParseProductIDToImagePath(string productID)
		{
            System.Collections.Generic.List<string> path = new System.Collections.Generic.List<string>();
			path.Add(ImageStoragePath);
			path.Add(productID[0].ToString());
			if (productID.Length > 1)
				path.Add(productID[1].ToString());
			if (productID.Length > 2)
				path.Add(productID);
			path[path.Count - 1] += ".png";
			
			return Path.Combine(path.ToArray());
		}
		
		private static void BuildProductImagePathDirectory(string productID)
		{
			string dir = Path.GetDirectoryName(ParseProductIDToImagePath(productID));
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
		}
	}
}
