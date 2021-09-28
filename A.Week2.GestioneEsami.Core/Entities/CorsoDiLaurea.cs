using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Core
{
  public class CorsoDiLaurea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnniDiCorso { get; set; }
        public int? Cfu { get; set; }
        public List<Corso> Corsi { get; set; }
        public CorsiDisponibili CorsiDisp { get; set; }

      

        public enum CorsiDisponibili
        {
            Matematica,
            Fisica,
            Informatica,
            Ingegneria,
            Lettere
        }

        public string Print()
        {
            return $"{Nome} dura {AnniDiCorso} anni";
        }
    }
}