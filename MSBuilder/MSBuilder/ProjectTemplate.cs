namespace MSBuilder
{
    public abstract class ProjectTemplate
    {
        public string  Name { get; set; }
        public string Path { get; set; }

        public abstract ProjectWriter CreateTemplate();

        public ProjectTemplate(string name,string path)
        {
            Name = name;
            Path = path;
        }
    }
}
