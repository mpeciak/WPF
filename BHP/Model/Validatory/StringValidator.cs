using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.Validatory
{
    public class StringValidator: Validator
    {
        public static string SprawdzCzyZaczynaSieOdDuzej(String wartosc)
        {
            try
            {
                if(!char.IsUpper(wartosc,0))
                {
                    return "Rozpocznij dużą literą";
                }
            }
            catch (Exception) { };
            return null;
        }

    }
}
