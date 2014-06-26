using System;
using System.IO;

public static class WebProductImageStorage
{
    private const string ImageStoragePath = @".\";

    public static string GetImageLocation(string productID)
    {
        System.Collections.Generic.List<string> path = new System.Collections.Generic.List<string>();
        path.Add(ImageStoragePath);
        path.Add(productID[0].ToString());
        if (productID.Length > 1)
            path.Add(productID[1].ToString());
        if (productID.Length > 2)
            path.Add(productID);
        path[path.Count - 1] += ".png";

        string pathStr = Path.Combine(path.ToArray());

        if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~") + pathStr))
            return pathStr;
        return null;
    }
}
