using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MSBuilder
{
    public class ProjectReferenceItemGroup : IEnumerable<ProjectReferenceItem>, IItemGroup
    {
        private List<ProjectReferenceItem> _projRef = new List<ProjectReferenceItem>();

        public void AddProjectReferenceItem(ProjectReferenceItem item)
        {
            _projRef.Add(item);
        }

        public IEnumerator<ProjectReferenceItem> GetEnumerator()
        {
            return _projRef.GetEnumerator();
        }

        public ProjectReferenceItem this[int number]
        {
            get
            {
                return _projRef[number];
            }
            set
            {
                _projRef[number] = value;
            }
        }

        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("ItemGroup");

            var props = _projRef.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);

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