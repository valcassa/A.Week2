using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Core.Entities
{
    public class Esame
    {
        public string Nome { get; set; }
        public bool Passato { get; set; }
        public int IdStudente { get; set; }

        public string Print()
        {
            return $"{Nome}: Passato? {Passato} ";
        }
    }
}
