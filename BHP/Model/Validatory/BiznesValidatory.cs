using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.Validatory
{
    public class BiznesValidatory:Validator
    {
        public static string sprawdzIlosc(int? ilosc)
        {
            if (ilosc < 1 || ilosc > 10)
                return "Ilosc powinna  być z przedziału od 1 do 10";
            return null;
        }
    }
}