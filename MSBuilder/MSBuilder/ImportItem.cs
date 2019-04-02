using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class ImportItem
    {
        public string Project { get; set; }
        public string Condition { get; set; }

        private Dictionary<string, string> attrs = new Dictionary<string, string>();
        public void AddAttribute(string name, string value)
        {
            attrs.Add(name, value);
        }
        private List<string> xmls = new List<string>();
        public void AddXmlChild(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
                xmls.Add(xml);
        }
        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("Import");

            child.SetAttribute("Project", Project);

            if (!string.IsNullOrEmpty(Condition))
            {
                child.SetAttribute("Condition", Condition);
            }

            if (attrs.Count > 0)
            {
                foreach (var item in attrs)
                    child.SetAttribute(item.Key, item.Value);
            }

            foreach (var item in xmls)
            {
                XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                xfrag.InnerXml = item;
                document.DocumentElement.AppendChild(xfrag);
            }

            document.AppendChild(child);
            return document.OuterXml;
        }
    }
}