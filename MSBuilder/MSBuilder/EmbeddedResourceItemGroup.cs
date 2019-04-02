using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
    public class EmbeddedResourceItemGroup : IEnumerable<EmbeddedResourceItem>, IItemGroup
    {
        private List<EmbeddedResourceItem> _asmRef = new List<EmbeddedResourceItem>();

        public void AddEmbeddedResourceItem(EmbeddedResourceItem item)
        {
            _asmRef.Add(item);
        }

        public IEnumerator<EmbeddedResourceItem> GetEnumerator()
        {
            return _asmRef.GetEnumerator();
        }

        public EmbeddedResourceItem this[int number]
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