using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class ContentItem 
    {
        public string Include { get; set; }
        public string Link { get; set; }
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
            XmlElement child = document.CreateElement("Compile");
            if (string.IsNullOrEmpty(Include))
            {
                throw new Exception("Include can not be empty !");
            }
            child.SetAttribute("Include", Include);
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

            if (!string.IsNullOrEmpty(Link))
            {
                XmlElement ag = document.CreateElement("Link");
                ag.InnerText = Link;
                child.AppendChild(ag);
            }

            document.AppendChild(child);
            return document.OuterXml;
        }
    }
}