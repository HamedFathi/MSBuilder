using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class CompileItem 
    {
        public string Include { get; set; }
        public string SubType { get; set; }
        public string DependentUpon { get; set; }
        public string AutoGen { get; set; }
        public bool? DesignTimeSharedInput { get; set; } = null;

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

            if (!string.IsNullOrEmpty(AutoGen))
            {
                XmlElement ag = document.CreateElement("AutoGen");
                ag.InnerText = AutoGen;
                child.AppendChild(ag);
            }
            if (DesignTimeSharedInput.HasValue)
            {
                XmlElement ag = document.CreateElement("DesignTimeSharedInput");
                ag.InnerText = DesignTimeSharedInput.Value ? "True" : "False";
                child.AppendChild(ag);
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