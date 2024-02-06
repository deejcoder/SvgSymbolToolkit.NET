using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SvgSymbolToolkit.Models;
using System.Text.RegularExpressions;

namespace SvgSymbolToolkit.Infrastructure
{
    public partial class CSharpCodeGenerator
    {
        private readonly Configuration Configuration;

        public CSharpCodeGenerator(Configuration configuration)
        {
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Outputs the generated code to a specified file
        /// </summary>
        /// <param name="svgInfo"></param>
        /// <param name="outputFilePath"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public async Task WriteToFile(SvgInfo svgInfo)
        {
            FileInfo path = new(Configuration.OutputFilePath);

            if(path.Directory == null || !System.IO.Directory.Exists(path.Directory.FullName))
            {
                throw new DirectoryNotFoundException(Configuration.OutputFilePath);
            }

            string output = WriteToString(svgInfo);

            using StreamWriter writer = new(Configuration.OutputFilePath);

            await writer.WriteAsync(output);
        }

        /// <summary>
        /// Outputs SVG info to .NET code so that symbols can easily be referenced when developing within .NET
        /// </summary>
        /// <param name="svgInfo"></param>
        /// <returns></returns>
        public string WriteToString(SvgInfo svgInfo)
        {
            FileInfo inputFileInfo = new(Configuration.SvgFilePath);

            string dirtyCode = string.Empty;

            // if this gets more advance consider using templates
            dirtyCode += $"namespace {Configuration.Namespace};";
            dirtyCode += "\r\n";
            dirtyCode += $"public class {Configuration.ClassName} {{";

            dirtyCode += "\r\n";

            foreach (SvgSymbolInfo symbol in svgInfo.Symbols)
            {
                string friendlyId = GetFriendlyName(symbol.Id);
                dirtyCode += $"public const string {friendlyId} = \"{symbol.Id}\";\r\n";
            }

            dirtyCode += "\r\n";

            dirtyCode += $"private readonly static Dictionary<string, string> Symbols = new() {{\r\n";

            foreach(SvgSymbolInfo symbol in svgInfo.Symbols)
            {
                string friendlyId = GetFriendlyName(symbol.Id);
                dirtyCode += $"{{ nameof({friendlyId}), {friendlyId} }},\r\n";
            }

            dirtyCode += "};\r\n";

            // helper function to get a symbol as a SVG
            dirtyCode += $@"public static string GetSymbolById(string id)
            {{
                if(Symbols.TryGetValue(id, out string? value))
                {{
                    return $""<svg class=\""icon\""><use href=\""\\{inputFileInfo.Name}#{{value}}\"" /></svg>"";
                }}
                return string.Empty;
            }}";

            // helper function to get a list of symbols as SVGs
            dirtyCode += $@"public static Dictionary<string, string> GetSymbols()
            {{
                Dictionary<string, string> values = [];
                foreach (KeyValuePair<string, string> pair in Symbols)
                {{
                    values.Add(pair.Key, GetSymbolById(pair.Key));
                }}

                return values;
            }}";

            dirtyCode += "}";

            return FormatCode(dirtyCode);
        }

        /// <summary>
        /// Formats the code with indents
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string FormatCode(string code)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            SyntaxNode root = tree.GetRoot().NormalizeWhitespace();
            return root.ToFullString();
        }

        /// <summary>
        /// Returns a friendly name to use as property (or private member) names
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        private static string GetFriendlyName(string name)
        {
            name = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(name);

            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            name = name.Replace("_", "");

            if (!SymbolTitlePattern().Match(name).Success)
            {
                throw new FormatException($"The symbol '{name}' has an invalid title. Please ensure the title follows the regex '^[a-zA-Z0-9_]*$'");
            }

            return name;
        }

        [GeneratedRegex(@"^[a-zA-Z0-9]*$")]
        private static partial Regex SymbolTitlePattern();
    }
}
