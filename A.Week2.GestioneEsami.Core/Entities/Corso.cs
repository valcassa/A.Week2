using System;

namespace A.Week2.GestioneEsami.Core
{
        public class Corso
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public int CreditiFormativi { get; set; }
            public int IdCorsoLaurea { get; set; }

        public string Print()
        {

            return $"{Nome} ha {CreditiFormativi} cfu";
        }
    }

    }