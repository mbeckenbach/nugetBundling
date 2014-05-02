using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace nugetBundling.Models
{
    /// <summary>
    /// XML model of packages config
    /// </summary>
    [XmlRoot(ElementName = "package")]
    public class NugetPackage
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the target framework.
        /// </summary>
        /// <value>
        /// The target framework.
        /// </value>
        [XmlAttribute(AttributeName = "targetFramework")]
        public string TargetFramework { get; set; }
    }
}
