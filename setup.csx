#!/usr/bin/env dotnet-script
#r "nuget: Ask, 1.2.0"

Ask.Rep("Package prefix", "PACKAGE_PREFIX", "com");
Ask.Rep("Company", "COMPANY_HERE", "Cyriaca", extra: v => ("COMPANY_LOWER_HERE", v.ToLowerInvariant()));
Ask.Rep("Company (long)", "COMPANY_LONG_HERE", "Cyriaca Software");
Ask.Rep("Name", "NAME_HERE", extra: v => ("NAME_LOWER_HERE", v.ToLowerInvariant()));
Ask.Rep("Display name", "NAME_DISPLAY_HERE");
Ask.Rep("Description", "DESC_HERE");
Wait.Enter("Press enter to apply");
Set.Rep("DATE_HERE", DateTime.UtcNow.ToString("yyyy-M-d"));
Set.Rep("YEAR_HERE", DateTime.UtcNow.ToString("yyyy"));
Set.Rep("_TEMPLATE_", "");
File.Delete("omnisharp.json");
File.Delete("README.md");

foreach (var path in Get.SplitNonEmptyLines(@"
Documentation~/NAME_HERE.md
Editor/COMPANY_HERE.NAME_HERE.Editor.asmdef
Runtime/COMPANY_HERE.NAME_HERE.asmdef
Tests/Editor/COMPANY_HERE.NAME_HERE.Editor.Tests.asmdef
Tests/Runtime/COMPANY_HERE.NAME_HERE.Tests.asmdef
CHANGELOG.md
LICENSE
package.json
README_TEMPLATE_.md
")) Do.FileRep(path, Do.Rep(path));

foreach (var path in Get.SplitNonEmptyLines($@"
Editor
Editor/COMPANY_HERE.NAME_HERE.Editor.asmdef
Runtime
Runtime/COMPANY_HERE.NAME_HERE.asmdef
Tests
Tests/Editor
Tests/Editor/COMPANY_HERE.NAME_HERE.Editor.Tests.asmdef
Tests/Runtime
Tests/Runtime/COMPANY_HERE.NAME_HERE.Tests.asmdef
CHANGELOG.md
LICENSE
package.json
README_TEMPLATE_.md
"))
{
    string rPath = Do.Rep(path);
    using var writer = File.CreateText($"{rPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)}.meta");
    writer.WriteLine("fileFormatVersion: 2");
    writer.WriteLine($"guid: {Guid.NewGuid().ToString("N")}");
    bool dir = Directory.Exists(rPath);
    if (dir) writer.WriteLine(@"folderAsset: yes");
    writer.Write(Path.GetExtension(rPath) switch
    {
        _ when dir => "DefaultImporter:",
        _ when Path.GetFileName(rPath) == "package.json" => "PackageManifestImporter:",
        ".md" => "TextScriptImporter:",
        ".txt" => "TextScriptImporter:",
        ".asmdef" => "AssemblyDefinitionImporter:",
        _ => "DefaultImporter:"
    });
    writer.WriteLine(@"
  externalObjects: {}
  userData: 
  assetBundleName: 
  assetBundleVariant: ");
}

WriteLine("Complete. Delete setup.csx now.");