namespace MSBuilder.Template
{
    public class WebApplicationTemplate : ProjectTemplate
    {
        public WebApplicationTemplate(string name, string path) : base(name, path)
        {
            Name = name;
            Path = path;
        }

        public override ProjectWriter CreateTemplate()
        {
            var project = new ProjectWriter(Name, Path);






            return project;
        }
    }
}