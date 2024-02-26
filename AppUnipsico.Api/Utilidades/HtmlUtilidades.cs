using HtmlAgilityPack;
using iText.Html2pdf;

namespace AppUnipsico.Api.Utilidades
{
    public static class HtmlUtilidades
    {
        public static Stream ConverteHtmlParaPdf(string arquivoHtml)
        {
            MemoryStream stream = new MemoryStream();

            HtmlConverter.ConvertToPdf(arquivoHtml, stream);
            stream.Position = 0;
            return stream;
        }
    }
}
