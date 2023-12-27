using System.Text.RegularExpressions;

namespace ProyectoMerck.Helpers
{
    public static class RegexHelper
    {


        public static bool IsMailValid(string mail)
        {

            string regexCode = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex reg = new Regex(regexCode);

            return reg.IsMatch(mail);

        }


    }
}
