using System.ComponentModel;

namespace SeleNUnit.WebObjects.Tags
{
    public enum TagNames
    {
        [Description("textarea")]
        TextArea,

        [Description("input")]
        Input,

        [Description("a")]
        Link,

        [Description("span")]
        Span,

        [Description("iframe")]
        InlineFrame,

        [Description("div")]
        Div,

        [Description("img")]
        Image,

        [Description("option")]
        Option
    }
}
