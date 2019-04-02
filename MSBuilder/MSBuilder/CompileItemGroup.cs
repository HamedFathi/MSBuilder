using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
  

    public class CompileItemGroup : IEnumerable<CompileItem>, IItemGroup
    {
        private List<CompileItem> _compiles = new List<CompileItem>();

        public void AddCompileItem(CompileItem item)
        {
            _compiles.Add(item);
        }

        public IEnumerator<CompileItem> GetEnumerator()
        {
            return _compiles.GetEnumerator();
        }

        public CompileItem this[int number]
        {
            get
            {
                return _compiles[number];
            }
            set
            {
                _compiles[number] = value;
            }
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("ItemGroup");

            var props = _compiles.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);

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