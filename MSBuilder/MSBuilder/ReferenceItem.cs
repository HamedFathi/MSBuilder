using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class ReferenceItem 
    {
        public string Include { get; set; }
        public string HintPath { get; set; }
        public bool? Private { get; set; } = null;

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
            XmlElement child = document.CreateElement("Reference");
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

            if (!string.IsNullOrEmpty(HintPath))
            {
                XmlElement name = document.CreateElement("HintPath");
                name.InnerText = HintPath;
                child.AppendChild(name);

            }

            if (Private.HasValue)
            {
                XmlElement name = document.CreateElement("Private");
                name.InnerText = Private.Value ? "True" : "False";
                child.AppendChild(name);

            }

            document.AppendChild(child);
            return document.OuterXml;
        }
    }
}