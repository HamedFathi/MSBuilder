using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using MSBuilder.Extensions;

namespace MSBuilder
{
    public class ProjectWriter
    {
        private string _guid = "";
        public string Name { get; set; }
        public string Directory { get; set; }
        public ProjectWriter(string name, string path)
        {
            Name = name;
            Directory = path;

            if (Path.HasExtension(Directory))
            {
                throw new Exception("You should set directory path not file path!");
            }


            _guid = Guid.NewGuid().ToString("B");

            var declaration = _document.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = _document.CreateElement("Project");

            XmlElement r = _document.DocumentElement;
            _document.InsertBefore(declaration, r);

            root.SetAttribute("ToolsVersion", "4.0");
            root.SetAttribute("xmlns", "http://schemas.microsoft.com/developer/msbuild/2003");
            _document.AppendChild(root);
        }

        public Func<string, string> ProcessOnXml { get; set; }
        public Func<string, string> ProcessOnXmlLineByLine { get; set; }

        public string ProjectId => _guid;

        private XmlDocument _document = new XmlDocument();
        private List<PropertyGroup> pgs = new List<PropertyGroup>();
        private List<CompileItemGroup> cigs = new List<CompileItemGroup>();
        private List<ReferenceItemGroup> aris = new List<ReferenceItemGroup>();
        private List<ProjectReferenceItemGroup> prigs = new List<ProjectReferenceItemGroup>();
        private List<ImportItemGroup> iigs = new List<ImportItemGroup>();
        private List<string> xmls = new List<string>();
        private List<ContentItemGroup> contents = new List<ContentItemGroup>();
        private List<EmbeddedResourceItemGroup> erigs = new List<EmbeddedResourceItemGroup>();
        private List<NoneItemGroup> nones = new List<NoneItemGroup>();
        private List<ChooseItemGroup> chooses = new List<ChooseItemGroup>();
        private List<TaskItemGroup> tasks = new List<TaskItemGroup>();

        public string ToXml()
        {
            foreach (var item in pgs)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in cigs)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in aris)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in prigs)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in iigs)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in xmls)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item;
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in contents)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in erigs)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in nones)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in chooses)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }
            foreach (var item in tasks)
            {
                XmlDocumentFragment xfrag = _document.CreateDocumentFragment();
                xfrag.InnerXml = item.GetXml();
                _document.DocumentElement.AppendChild(xfrag);
            }

            var result = _document.InnerXml.PrettyXml();

            if (ProcessOnXmlLineByLine != null)
            {
                var final = new List<string>();
                var list = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                foreach (var item in list)
                {
                    final.Add(ProcessOnXmlLineByLine(item));
                }
                result = final.Aggregate((a, b) => a + Environment.NewLine + b);
            }
            if (ProcessOnXml != null)
                result = ProcessOnXml(result);

            return result.PrettyXml();
        }

        public void Save()
        {
            if (!System.IO.Directory.Exists(Directory))
            {
                System.IO.Directory.CreateDirectory(Directory);
            }
            File.WriteAllText(Directory + Path.DirectorySeparatorChar + Name + ".csproj", ToXml());
        }

        public void AddXmlChild(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
                xmls.Add(xml);

        }

        public void AddProjectExtensions(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
                xmls.Add("<ProjectExtensions>" + xml + "</ProjectExtensions>");

        }
        public PropertyGroup CreatePropertyGroup()
        {
            var pg = new PropertyGroup();
            pgs.Add(pg);
            return pg;
        }

        public CompileItemGroup CreateCompileItemGroup()
        {
            var cig = new CompileItemGroup();
            cigs.Add(cig);
            return cig;
        }

        public ContentItemGroup CreateContentItemGroup()
        {
            var con = new ContentItemGroup();
            contents.Add(con);
            return con;
        }
        public ChooseItemGroup CreateChooseItemGroup()
        {
            var ch = new ChooseItemGroup();
            chooses.Add(ch);
            return ch;
        }
        public ReferenceItemGroup CreateReferenceItemGroup()
        {
            var ari = new ReferenceItemGroup();
            aris.Add(ari);
            return ari;
        }

        public EmbeddedResourceItemGroup CreateEmbeddedResourceItemGroup()
        {
            var emb = new EmbeddedResourceItemGroup();
            erigs.Add(emb);
            return emb;
        }

        public NoneItemGroup CreateNoneItemGroup()
        {
            var non = new NoneItemGroup();
            nones.Add(non);
            return non;
        }

        public ProjectReferenceItemGroup CreateProjectReferenceItemGroup()
        {
            var pri = new ProjectReferenceItemGroup();
            prigs.Add(pri);
            return pri;
        }

        public ImportItemGroup CreateImportItemGroup()
        {
            var iig = new ImportItemGroup();
            iigs.Add(iig);
            return iig;
        }

        public TaskItemGroup CreateTaskItemGroup()
        {
            var task = new TaskItemGroup();
            tasks.Add(task);
            return task;
        }
    }
}