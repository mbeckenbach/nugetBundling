using nugetBundling.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace nugetBundling.Helper
{
    /// <summary>
    /// Reads installed nuget packages and provides methods to find or detect existance.
    /// </summary>
    public class NugetReader
    {
        /// <summary>
        /// Gets the nuget packages.
        /// </summary>
        /// <value>
        /// The nuget packages.
        /// </value>
        public List<NugetPackage> NugetPackages { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NugetReader"/> class.
        /// </summary>
        public NugetReader()
        {
            this.NugetPackages = readPackages(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NugetReader"/> class.
        /// </summary>
        /// <param name="physicalPath">The application path needed for unit testing or if file is not at application root.</param>
        public NugetReader(string physicalPath)
        {
            this.NugetPackages = readPackages(physicalPath);
        }

        /// <summary>
        /// Finds the package by name.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <returns>The packages information</returns>
        public NugetPackage FindPackageByName(string packageName)
        {
            return this.NugetPackages.Where(x => x.Id.ToLower() == packageName.ToLower()).SingleOrDefault();
        }

        /// <summary>
        /// Determines whether the specified package name is installed.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <returns>The truth</returns>
        public bool IsInstalled(string packageName)
        {
            return (this.FindPackageByName(packageName) != null);
        }

        /// <summary>
        /// Reads the packages.
        /// </summary>
        /// <param name="physicalPath">The application path needed for unit testing or if file is not at application root.</param>
        /// <returns>
        /// List of all installed packages
        /// </returns>
        private List<NugetPackage> readPackages(string physicalPath)
        {
            string packagesConfigFile = File.ReadAllText(Path.Combine(physicalPath, "packages.config"), Encoding.UTF8);
            return xmlConverter.XmlToObjectList<NugetPackage>(packagesConfigFile, "//packages/package");
        }
    }
}