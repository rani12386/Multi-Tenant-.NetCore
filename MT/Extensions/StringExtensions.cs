using System.Web;

namespace MT.Extensions;
public static class StringExtensions
{
    public static string HtmlEncode(this string value)
    {
        return HttpUtility.JavaScriptStringEncode(value);
    }
}
