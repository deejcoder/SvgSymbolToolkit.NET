using SvgSymbolToolkit.Models;

namespace SvgSymbolToolkit.Infrastructure
{
    public class SvgFileAnalyzer
    {
        public SvgFileAnalyzer() { }


        /// <summary>
        /// Analyzes a SVG file and returns info about that file
        /// </summary>
        /// <param name="svgFilePath"></param>
        /// <returns></returns>
        public static async Task<SvgInfo> GetInfo(string svgFilePath)
        {
            Models.svg svgModel = await SvgFileReader.ReadFromFile(svgFilePath);

            SvgInfo info = new();

            foreach(Models.svgSymbol symbol in svgModel.symbol)
            {
                info.Symbols.Add(new SvgSymbolInfo(symbol.id, symbol.title));
            }

            return info;
        }
    }
}
