using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MSBuilder.Extensions
{
    internal static class Extensions
    {
        internal static XmlElement ToXmlElement(this string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            return root;
        }
        internal static string PrettyXml(this string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            //settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return @"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine + stringBuilder;
        }
        internal static string GetDescription(this System.Enum value)
        {
            var type = value.GetType();
            var name = System.Enum.GetName(type, value);
            if (name != null)
            {
                var field = type.GetField(name);
                var attr = field?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    return attr.Description;
                }
            }
            return null;
        }
        internal static string ToXmlString(this XmlDocument xmlDoc)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    xmlDoc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString().Replace(@"<?xml version=""1.0"" encoding=""utf-16""?>", "");
                }
            }
        }
    }
}