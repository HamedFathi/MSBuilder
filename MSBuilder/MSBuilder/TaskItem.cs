using System.Collections.Generic;
using System.Xml;

namespace MSBuilder
{
    public class TaskItem
    {
        public string Name { get; set; }
        public string Inputs { get; set; }
        public string Outputs { get; set; }
        public string Returns { get; set; }
        public bool? KeepDuplicateOutputs { get; set; } = null;
        public string BeforeTargets { get; set; }
        public string AfterTargets { get; set; }
        public string DependsOnTargets { get; set; }
        public string Condition { get; set; }
        public string Label { get; set; }

        private List<string> list = new List<string>();
        private List<PropertyGroup> props = new List<PropertyGroup>();
        private List<Error> errs = new List<Error>();


        public void AddTaskContent(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
                list.Add(xml);
        }


        public void AddPropertyGroup(PropertyGroup propertyGroup)
        {
            props.Add(propertyGroup);
        }


        public void AddError(List<Error> errors)
        {
            errs.AddRange(errors);
        }

        private List<string> xmls = new List<string>();
        public void AddXmlChild(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
                xmls.Add(xml);
        }
        public string GetXml()
        {
            XmlDocument document = new XmlDocument();
            XmlElement child = document.CreateElement("Target");
            if (!string.IsNullOrEmpty(Name))
            {
                child.SetAttribute("Name", Name);
            }
            if (!string.IsNullOrEmpty(Inputs))
            {
                child.SetAttribute("Inputs", Inputs);
            }
            if (!string.IsNullOrEmpty(Outputs))
            {
                child.SetAttribute("Outputs", Outputs);
            }
            if (!string.IsNullOrEmpty(Returns))
            {
                child.SetAttribute("Returns", Returns);
            }
            if (KeepDuplicateOutputs.HasValue)
            {
                child.SetAttribute("Inputs", KeepDuplicateOutputs.Value ? "true" : "false");
            }
            if (!string.IsNullOrEmpty(BeforeTargets))
            {
                child.SetAttribute("BeforeTargets", BeforeTargets);
            }
            if (!string.IsNullOrEmpty(AfterTargets))
            {
                child.SetAttribute("AfterTargets", AfterTargets);
            }
            if (!string.IsNullOrEmpty(DependsOnTargets))
            {
                child.SetAttribute("DependsOnTargets", DependsOnTargets);
            }
            if (!string.IsNullOrEmpty(Condition))
            {
                child.SetAttribute("Condition", Condition);
            }
            if (!string.IsNullOrEmpty(Label))
            {
                child.SetAttribute("Label", Label);
            }
            document.AppendChild(child);

            foreach (var l in list)
            {
                XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                xfrag.InnerXml = l.Trim();
                document.DocumentElement.AppendChild(xfrag);
            }

            foreach (var item in props)
            {
                XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                document.DocumentElement.AppendChild(xfrag);
            }

            foreach (var item in errs)
            {
                XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                XmlElement eChild = document.CreateElement("Error");
                if (!string.IsNullOrEmpty(item.Condition))
                {
                    eChild.SetAttribute("Condition", item.Condition);
                }
                if (!string.IsNullOrEmpty(item.Text))
                {
                    eChild.SetAttribute("Text", item.Text);
                }
                document.DocumentElement.AppendChild(eChild);
            }

            foreach (var item in xmls)
            {
                XmlDocumentFragment xfrag = document.CreateDocumentFragment();
                xfrag.InnerXml = item;
                document.DocumentElement.AppendChild(xfrag);
            }

            return document.OuterXml;
        }
    }
}