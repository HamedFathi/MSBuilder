using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
    public class ReferenceItemGroup : IEnumerable<ReferenceItem>,IItemGroup
    {
        private List<ReferenceItem> _asmRef = new List<ReferenceItem>();

        public void AddReferenceItem(ReferenceItem item)
        {
            _asmRef.Add(item);
        }

        public IEnumerator<ReferenceItem> GetEnumerator()
        {
            return _asmRef.GetEnumerator();
        }

        public ReferenceItem this[int number]
        {
            get
            {
                return _asmRef[number];
            }
            set
            {
                _asmRef[number] = value;
            }
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("ItemGroup");

            var props = _asmRef.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);

            child.InnerXml = props;

            document.AppendChild(child);
            return document.OuterXml;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}