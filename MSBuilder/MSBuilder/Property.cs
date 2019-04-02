using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class Property
    {
        private string _name = "";
        private string _value = "";
        private Dictionary<string, string> _dic = new Dictionary<string, string>();

        public Property(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public void AddAttribute(string name, string value)
        {
            _dic.Add(name, value);
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement(_name);
            root.InnerText = _value;

            foreach (var item in _dic)
            {
                root.SetAttribute(item.Key, item.Value);
            }
            document.AppendChild(root);
            return document.OuterXml;
        }
    }
}