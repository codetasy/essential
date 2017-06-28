using System;
using System.IO;

namespace Essential.Url
{
    public class Url
    {
        public static string ExtractUrlPath(string url)
        {
            var path = url;

            if (!url.StartsWith("/"))
            {
                url = (url.Contains("://")) ? url : "http://" + url;

                Uri uri;
                path = (Uri.TryCreate(url, UriKind.Absolute, out uri)) ? uri.AbsolutePath : url;
            }

            return Path.HasExtension(path) ? path.Replace(Path.GetExtension(path), "") : path;
        }
    }
}
