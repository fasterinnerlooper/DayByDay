using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DayByDay.Tests
{
    [TestClass]
    public class ManifestTests
    {
        [TestMethod]
        public void AllManifestImagesExist()
        {
            string rootDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));
            string manifestPath = Path.Combine(rootDir, "Package.appxmanifest");
            Assert.IsTrue(File.Exists(manifestPath), $"Manifest not found at {manifestPath}");

            XDocument doc = XDocument.Load(manifestPath);

            var imagePaths = doc.Descendants()
                .Attributes()
                .Select(a => a.Value)
                .Concat(doc.Descendants().Select(e => e.Value))
                .Where(v => v != null && (v.StartsWith("Assets/", StringComparison.OrdinalIgnoreCase) || v.StartsWith("Assets\\", StringComparison.OrdinalIgnoreCase)))
                .Distinct();

            foreach (var relative in imagePaths)
            {
                string normalized = relative.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar);
                string full = Path.Combine(rootDir, normalized);
                Assert.IsTrue(File.Exists(full), $"Missing asset: {relative}");
            }
        }
    }
}
