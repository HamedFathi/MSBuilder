using System;
using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class WhenItem 
    {
        public string Condition { get; set; }
        private List<IItemGroup> groups = new List<IItemGroup>();


        private List<string> xmls = new List<string>();

        public void AddItemGroup(IItemGroup itemGroup)
        {
            groups.Add(itemGroup);
        }
        public void AddXmlChild(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
                xmls.Add(xml);
        }
        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("When");
            if (string.IsNullOrEmpty(Condition))
            {
                throw new Exception("Condition can not be empty !");
            }

            child.SetAttribute("Condition", Condition);
            document.AppendChild(child);
            if (groups.Count > 0)
            {
                foreach (var item in groups)
                {
                    XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                    xfrag.InnerXml = item.GetXml();
                    document.DocumentElement.AppendChild(xfrag);
                }
            }

            foreach (var item in xmls)
            {
                XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                xfrag.InnerXml = item;
                document.DocumentElement.AppendChild(xfrag);
            }
            //document.AppendChild(child);
            return document.OuterXml;
        }
    }
}