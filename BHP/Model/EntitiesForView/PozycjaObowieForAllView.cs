using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHP.Model.EntitiesForView
{
    public class PozycjaObowieForAllView
    {
        public long? IdObowia { get; set; }
        public long? IdOdziezy { get; set; }
        public string NazwaObowia { get; set; }
        public int? IloscObowia { get; set; }
        public string NazwaOdziezy { get; set; }
        public int? IloscOdziezy { get; set; }
        public string  RozmiarOdziezy { get; set; }
        public string RozmiarObowia { get; set; }

    }
}
