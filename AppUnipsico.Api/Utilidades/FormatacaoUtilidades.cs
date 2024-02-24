using System.Globalization;

namespace AppUnipsico.Api.Utils
{
    public static class FormatacaoUtilidades
    {
        public static string FormataCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").ToUpper();
        }

        public static DateTime FormataData(DateTime dateTime)
        {
            return Convert.ToDateTime(dateTime.ToString("dd-MM-yyyy"));
        }
    }
}
