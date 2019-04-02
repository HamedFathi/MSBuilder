using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
    public class ChooseItemGroup : IEnumerable<WhenItemGroup>, IItemGroup
    {
        private List<WhenItemGroup> _when = new List<WhenItemGroup>();
        private List<IItemGroup> _igs = new List<IItemGroup>();

        public void AddWhenItemGroup(WhenItemGroup item)
        {
            _when.Add(item);
        }

        public IEnumerator<WhenItemGroup> GetEnumerator()
        {
            return _when.GetEnumerator();
        }

        public void AddOtherwiseGroup(IItemGroup item)
        {
            _igs.Add(item);
            if (_igs.Count > 1)
            {
                throw new Exception("You can have only one Otherwise!");
            }
        }

        public WhenItemGroup this[int number]
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
            XmlElement child = document.CreateElement("Choose");

            var props = _when.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);
            child.InnerXml = props;
            document.AppendChild(child);

            if (_igs.Count != 0)
            {
                XmlElement child2 = document.CreateElement("Otherwise");
                child2.InnerXml = _igs[0].GetXml();
                document.DocumentElement.AppendChild(child2);

            }

            return document.OuterXml;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}