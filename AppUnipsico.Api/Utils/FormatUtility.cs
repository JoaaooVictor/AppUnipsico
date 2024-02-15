using System.Globalization;

namespace AppUnipsico.Api.Utils
{
    public static class FormatUtility
    {
        public static string FormatCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").ToUpper();
        }

        public static DateTime FormatDateTime(DateTime dateTime)
        {
            return Convert.ToDateTime(dateTime.ToString("dd-MM-yyyy"));
        }
    }
}
