# UPM Package Template

This is a template for a basic Unity UPM package. It requires [dotnet-script](https://github.com/filipw/dotnet-script) for configuration.

1. Copy the contents of this folder (minus `.git/`) to an empty folder.
2. Run `dotnet script setup.csx` and fill out the necessary properties
    - Package prefix: prefix for package identifier e.g. `com` / `net`
    - Company: Company short name (for assembly / package identifier naming, e.g. "Cyriaca")
    - Company (long): Company long name (for license, e.g. "Cyriaca Software")
    - Name: Package short name (for assembly / package identifier naming, e.g. "MoonSharp")
    - Display name: Package long name (for display in UPM window, e.g. "MoonSharp Integration")
    - Description: Package description

### Notes

The defaults assume package prefix `com`, company short-name `Cyriaca`, and company long-name `Cyriaca Software` - this can be changed in `setup.csx`.

The template includes an MIT license file that should be replaced or removed (along with removing lines containing "LICENSE" in `setup.csx`) if an MIT license is not desired.

`setup.csx` modifies the package files in-place. `.meta` files with random GUIDs are generated.
