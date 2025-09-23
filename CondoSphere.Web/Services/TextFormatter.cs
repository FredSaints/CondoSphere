using System.Net;
using System.Text.RegularExpressions;

namespace CondoSphere.Web.Services
{
    public static class TextFormatter
    {
       
        private static readonly Regex UrlRegex = new(
            @"(?<![""'>])\b((?:https?://|www\.)[\w\-.~:/?#\[\]@!$&'()*+,;=%]+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string ToClickableHtml(string? text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";


            var html = WebUtility.HtmlEncode(text);


            html = UrlRegex.Replace(html, m =>
            {
                var url = m.Groups[1].Value;

                int openPar = url.Count(c => c == '(');
                int closePar = url.Count(c => c == ')');
                while (url.Length > 0)
                {
                    char last = url[^1];
                    bool isTrail =
                        last == '.' || last == ',' || last == '!' || last == '?' ||
                        last == ':' || last == ';' || last == '…' ||
                        (last == ')' && closePar > openPar); 
                    if (!isTrail) break;
                    if (last == ')') closePar--;
                    url = url[..^1];
                }

                var href = url.StartsWith("www.", StringComparison.OrdinalIgnoreCase)
                    ? "https://" + url
                    : url;

                return $"<a href=\"{href}\" target=\"_blank\" rel=\"noopener noreferrer\" class=\"link-primary\">{WebUtility.HtmlEncode(url)}</a>";
            });

            html = html.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "<br/>");
            return html;
        }
    }
}
