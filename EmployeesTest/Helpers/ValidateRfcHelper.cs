using System.Text.RegularExpressions;

namespace EmployeesTest.Helpers
{
    public static class ValidateRfcHelper
    {
        public static bool IsRfcValid(this string rfc)
        {
            var match = Regex.Match(rfc,
                @"^([A-Z,Ñ,&]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[A-Z|\d]{3})$");
            return match.Success;
        }
    }
}
