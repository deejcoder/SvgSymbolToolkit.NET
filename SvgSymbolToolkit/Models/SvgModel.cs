namespace SvgSymbolToolkit.Models;


// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/svg")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2000/svg", IsNullable = false)]
public partial class svg
{

    private svgSymbol[] symbolField;

    private string styleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("symbol")]
    public svgSymbol[] symbol
    {
        get
        {
            return this.symbolField;
        }
        set
        {
            this.symbolField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string style
    {
        get
        {
            return this.styleField;
        }
        set
        {
            this.styleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/svg")]
public partial class svgSymbol
{

    private string titleField;

    private svgSymbolG gField;

    private string idField;

    private string viewBoxField;

    /// <remarks/>
    public string title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public svgSymbolG g
    {
        get
        {
            return this.gField;
        }
        set
        {
            this.gField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string viewBox
    {
        get
        {
            return this.viewBoxField;
        }
        set
        {
            this.viewBoxField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/svg")]
public partial class svgSymbolG
{

    private svgSymbolGPath[] pathField;

    private string classField;

    private string strokeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("path")]
    public svgSymbolGPath[] path
    {
        get
        {
            return this.pathField;
        }
        set
        {
            this.pathField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string @class
    {
        get
        {
            return this.classField;
        }
        set
        {
            this.classField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string stroke
    {
        get
        {
            return this.strokeField;
        }
        set
        {
            this.strokeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2000/svg")]
public partial class svgSymbolGPath
{

    private string classField;

    private string dField;

    private string fillField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string @class
    {
        get
        {
            return this.classField;
        }
        set
        {
            this.classField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string d
    {
        get
        {
            return this.dField;
        }
        set
        {
            this.dField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fill
    {
        get
        {
            return this.fillField;
        }
        set
        {
            this.fillField = value;
        }
    }
}

