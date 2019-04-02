using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class NoneItem 
    {
        public string Include { get; set; }
        public string Link { get; set; }
        public string Generator { get; set; }
        public string LastGenOutput { get; set; }
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
            XmlElement child = document.CreateElement("None");
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
                XmlElement st = document.CreateElement("Link");
                st.InnerText = Link;
                child.AppendChild(st);
            }
            if (!string.IsNullOrEmpty(Generator))
            {
                XmlElement du = document.CreateElement("Generator");
                du.InnerText = Generator;
                child.AppendChild(du);
            }

            if (!string.IsNullOrEmpty(LastGenOutput))
            {
                XmlElement ag = document.CreateElement("LastGenOutput");
                ag.InnerText = LastGenOutput;
                child.AppendChild(ag);
            }

            document.AppendChild(child);
            return document.OuterXml;
        }
    }
}