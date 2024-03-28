using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class ValidationTest
    {
        public static bool Name( string? name)
        {
            if(name!=null && name!="")
                foreach (char c in name)
                    if (!char.IsLetter(c) && c != ' ')
                        return false;

            return true;
        }

        public static bool Number(int? num )
        {
            if(num != null)
            {
                return num > 0 || num == -1;
            }
            return false;
        }

        public static bool Id( string? id)
        {
            if (id != null)
            {
                if (id.Length != 9)
                    return false;

                // וודא שכל התווים הם ספרות
                if (!id.All(char.IsDigit))
                    return false;

                // חשב את סכום המקטעים הזוגיים
                int evenSum = 0;
                for (int i = 0; i < id.Length; i += 2)
                {
                    evenSum += int.Parse(id[i].ToString());
                }

                // חשב את סכום המקטעים האי-זוגיים
                int oddSum = 0;
                for (int i = 1; i < id.Length; i += 2)
                {
                    int digit = int.Parse(id[i].ToString()) * 2;
                    oddSum += digit / 10 + digit % 10;
                }

                // חשב את סכום כל הספרות
                int totalSum = evenSum + oddSum;

                // המספר תעודת הזהות תקין אם הסכום חלק ב-10 ללא שארית
                return (totalSum % 10 == 0);
            }
            return false;
        }

        public static bool PastDate(DateTime? _date)
        {
            return (_date == null ||_date <= DateTime.Now);
        }

        public static bool FutureDate(DateTime? _date)
        {
            return (_date == null || _date >= DateTime.Now);
        }



        public static bool PhoneNumber(string? phoneNumber)
        {
            if (phoneNumber != null)
            {

                // בניית תבנית המספר של מספר טלפון - עם רקע של 10 ספרות, עם אופציה להוספת סימנים
                string pattern = @"^\+?(\d{1,3})?[- .]?\(?\d{2,3}\)?[- .]?\d{3}[- .]?\d{4}$";

                // בדיקת התאמה של המספר טלפון לתבנית המוגדרת
                return Regex.IsMatch(phoneNumber, pattern);
            }
            return false;
        }



}
}
