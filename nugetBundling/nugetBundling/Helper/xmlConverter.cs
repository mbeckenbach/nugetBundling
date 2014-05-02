using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace nugetBundling.Helper
{
    public static class xmlConverter
    {
        /// <summary>
        /// Converts a single XML tree to the type of T
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="xml">XML string to convert</param>
        /// <returns></returns>
        public static T XmlToObject<T>(string xml)
        {
            using (var xmlStream = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(XmlReader.Create(xmlStream));
            }
        }

        /// <summary>
        /// Converts the XML to a list of T
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="xml">XML string to convert</param>
        /// <param name="nodePath">XML Node path to select <example>//People/Person</example></param>
        /// <returns></returns>
        public static List<T> XmlToObjectList<T>(string xml, string nodePath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            var returnItemsList = new List<T>();

            foreach (XmlNode xmlNode in xmlDocument.SelectNodes(nodePath))
            {
                returnItemsList.Add(XmlToObject<T>(xmlNode.OuterXml));
            }

            return returnItemsList;
        }
    }
}