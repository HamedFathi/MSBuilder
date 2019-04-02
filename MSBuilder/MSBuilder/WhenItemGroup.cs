using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
  

    public class WhenItemGroup : IEnumerable<WhenItem>, IItemGroup
    {
        private List<WhenItem> _when = new List<WhenItem>();
        private List<IItemGroup> _other = new List<IItemGroup>();

        public void AddWhenItem(WhenItem item)
        {
            _when.Add(item);
        }
        public void AddChooseItem(IItemGroup item)
        {
            _other.Add(item);
        }
        public IEnumerator<WhenItem> GetEnumerator()
        {
            return _when.GetEnumerator();
        }

        public WhenItem this[int number]
        {
            get
            {
                return _when[number];
            }
            set
            {
                _when[number] = value;
            }
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();

            //  XmlElement child = document.CreateElement("ItemGroup");

            var props = _when.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);

           // child.InnerXml = props;

           // document.AppendChild(child);
            return props;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}