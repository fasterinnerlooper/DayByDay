using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace DayByDay.Tests.Tests
{
    public class ManifestTests
    {
        [Fact]
        public void AllManifestImagesExist()
        {
            var manifestPath = Path.Combine("..", "Package.appxmanifest");
            if (!File.Exists(manifestPath))
            {
                manifestPath = "Package.appxmanifest";
            }

            var doc = XDocument.Load(manifestPath);
            var assetAttributes = doc
                .Descendants()
                .Attributes()
                .Where(a => a.Value.StartsWith("Assets", StringComparison.OrdinalIgnoreCase)
                            && a.Value.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                .Select(a => a.Value.Replace("\\", "/"))
                .Distinct();

            foreach (var asset in assetAttributes)
            {
                var baseName = Path.GetFileNameWithoutExtension(asset);
                var matches = Directory.GetFiles("Assets", $"{baseName}.scale-*", SearchOption.TopDirectoryOnly);
                Assert.True(matches.Length > 0, $"Missing scaled files for {asset}");
            }
        }
    }
}
