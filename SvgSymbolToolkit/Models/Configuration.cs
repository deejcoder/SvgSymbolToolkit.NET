using CommandLine;

namespace SvgSymbolToolkit.Models
{
    public class Configuration
    {
        [Option('i', "input", Required = true, HelpText = "Input SVG file path")]
        public string SvgFilePath { get; set; } = string.Empty;

        [Option('o', "output", Required = true, HelpText = "Output file path")]
        public string OutputFilePath { get; set; } = string.Empty;

        [Option('n', "namespace", Required = true, HelpText = "The namespace for the output file")]
        public string Namespace { get; set; } = string.Empty;

        [Option('c', "class", Required = true, HelpText = "The class name for the output file")]
        public string ClassName { get; set; } = string.Empty;
    }
}
