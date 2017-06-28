using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Essential.Extensions
{
    public static class XElementExtensions
    {
        public static void Save(this XElement element, string fileName)
        {
            using (var fileStream = File.Create(fileName))
            {
                element.Save(fileStream);
            }
        }

        public static XElement WrapXElements(this IEnumerable<XElement> childElements, string rootName = "")
        {
            if (string.IsNullOrWhiteSpace(rootName))
            {
                rootName = $"{childElements.First().Name}s";
            }

            return new XElement(rootName, childElements);
        }
    }
}
