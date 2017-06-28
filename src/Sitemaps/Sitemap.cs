using System.Collections.Generic;
using System.Xml.Linq;
using Essential.Extensions;

namespace Essential.Sitemaps
{
    public class Sitemap
    {
        public IEnumerable<string> Urls { get; private set; }

        public Sitemap(IEnumerable<string> urls)
        {
            Urls = urls;
        }        

        public IEnumerable<XElement> Generate(int maxUrlsPerSitemap = 1000)
        {
            var sitemaps = new List<XElement>();

            var chunks = Urls.Batch(maxUrlsPerSitemap);
            chunks.ForEach(urlsChunk => 
            {
                var sitemap = GenerateSitemap(urlsChunk);
                sitemaps.Add(sitemap);
            });

            return sitemaps;
        }

        XElement GenerateSitemap(IEnumerable<string> urls)
        {            
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var sitemap = new XElement(xmlns + "urlset");

            foreach (var url in urls)
            {
                sitemap.Add(
                    new XElement(xmlns + "url", 
                        new XElement(xmlns + "loc", url)
                    )
                );                
            }           

            return sitemap;      
        }        
    }
}
