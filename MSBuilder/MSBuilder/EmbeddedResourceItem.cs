using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class EmbeddedResourceItem 
    {
        public string Include { get; set; }
        public string DependentUpon { get; set; }
        public string Generator { get; set; }
        public string LastGenOutput { get; set; }
        public string SubType { get; set; }



        private Dictionary<string, string> attrs = new Dictionary<string, string>();
        public void AddAttribute(string name,string value)
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
            XmlElement child = document.CreateElement("EmbeddedResource");
            if (string.IsNullOrEmpty(Include))
            {
                throw new Exception("Include can not be empty !");
            }
            child.SetAttribute("Include", Include);

            if(attrs.Count > 0)
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

            if (!string.IsNullOrEmpty(SubType))
            {
                XmlElement st = document.CreateElement("SubType");
                st.InnerText = SubType;
                child.AppendChild(st);
            }
            if (!string.IsNullOrEmpty(DependentUpon))
            {
                XmlElement du = document.CreateElement("DependentUpon");
                du.InnerText = DependentUpon;
                child.AppendChild(du);
            }

            if (!string.IsNullOrEmpty(Generator))
            {
                XmlElement ag = document.CreateElement("Generator");
                ag.InnerText = Generator;
                child.AppendChild(ag);
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