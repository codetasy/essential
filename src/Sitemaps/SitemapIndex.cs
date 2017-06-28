using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Essential.Sitemaps
{
    class SitemapIndex
    {
         public IEnumerable<string> Urls { get; private set; }

        public SitemapIndex(IEnumerable<string> urls)
        {
            Urls = urls;
        }                
        public XElement Generate()
        {
            return GenerateIndex(Urls, DateTime.Now.ToString("yyyy-MM-dd"));
        }

        XElement GenerateIndex(IEnumerable<string> urls, string lastmod)
        {            
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var sitemap = new XElement(xmlns + "sitemapindex");

            foreach (var url in urls)
            {
                sitemap.Add(
                    new XElement(xmlns + "sitemap", 
                        new XElement(xmlns + "loc", url),
                        new XElement(xmlns + "lastmod", lastmod)
                    )
                );                
            }           

            return sitemap;      
        }   
    }
}
