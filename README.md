# SvgSymbolToolkit.NET
This tool was developed to make it easier to work with SVG symbols, when trying to dynamically load specific icons, list all icons, or work with multiple icon sets.

When working with multiple icon sets, each set will have a single SVG file with many symbols where each symbol has a matching "id" in each file.


This tool only supports command line arguments.

Required arguments include:
* -i : the input svg file path
* -o : the output path (folder and file name)
* -n : the namespace to use in the generated code
* -c : the class name of the class where the generated code resides


Code generation only supports .NET 8.


## Workflow:
* Using [Nucleo](https://nucleoapp.com/) import all icons to a set.
* Export required icons (or all) as an SVG <symbol> file. Set 'Base CSS class' to 'icon'. Prefix is optional. Select 'use external reference for <use> and specify the file name (which is the same as in the input file name [-i])
* Use this tool to generate .NET code e.g
```
SvgSymbolToolkit.exe -i icons.svg -o IconLoader.cs -n MySolution.MyProject.MyFolder -c IconLoader
```
