namespace SvgSymbolToolkit.Models
{
    public class SvgSymbolInfo(string id, string title)
    {
        public string Id { get; set; } = id;
        public string Title { get; set; } = title;
    }
}
