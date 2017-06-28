using System.Xml.Linq;
using Essential.Extensions;

namespace Essential.Xml
{
    public class XmlPartitioner
    {
        /// <summary>
        /// Split an xml file by elementName and the amount of specified parts into multiple files
        /// </summary>
        /// <param name="fileName">The xml path/file name e.g. /folder/books.xml</param>
        /// <param name="elementName">The element name to split by e.g. Book</param>
        /// <param name="parts">Try to split in n parts e.g. 5</param>
        public void SplitXmlFile(string fileName, string elementName, int parts) 
        {
            var xml = XElement.Load(fileName);
            var xmlChunks = xml.Descendants(elementName).Split(parts);

            var counter = 1;
            xmlChunks.ForEach(chunk =>
            {
                chunk.WrapXElements().Save($"{counter}_{fileName}");
                counter++;
            });
        }      
    }
}
