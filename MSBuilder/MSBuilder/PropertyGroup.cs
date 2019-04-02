using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
    public class PropertyGroup : IEnumerable<Property>
    {
        private string _name = "";
        private string _value = "";
        private Dictionary<string, string> _dic = new Dictionary<string, string>();
        private List<Property> properties = new List<Property>();

        public void AddProperty(Property property)
        {
            properties.Add(property);
        }

        public void AddAttribute(string name, string value)
        {
            _dic.Add(name, value);
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("PropertyGroup");

            var props = "";
            if (properties.Count > 0)
                props = properties.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);

            child.InnerXml = props;

            foreach (var item in _dic)
            {
                child.SetAttribute(item.Key, item.Value);
            }
            document.AppendChild(child);
            return document.OuterXml;
        }

        public IEnumerator<Property> GetEnumerator()
        {
            return properties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Property this[int number]
        {
            get
            {
                return properties[number];
            }
            set
            {
                properties[number] = value;
            }
        }
    }
}