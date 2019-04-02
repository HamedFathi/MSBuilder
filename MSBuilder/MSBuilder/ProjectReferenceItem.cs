using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class ProjectReferenceItem 
    {
        public string Include { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }

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
        internal string ProjectGuid
        {
            get; private set;
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("ProjectReference");
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
            XmlElement proj = document.CreateElement("Project");
            proj.InnerText = ProjectGuid = ProjectId.ToString("B");
            child.AppendChild(proj);

            XmlElement name = document.CreateElement("Name");
            name.InnerText = Name;
            child.AppendChild(name);

            document.AppendChild(child);
            return document.OuterXml;
        }
    }
}