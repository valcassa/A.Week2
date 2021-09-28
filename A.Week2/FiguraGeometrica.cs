using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2
{
    public abstract class FiguraGeometrica
    {
        public string Nome { get; set; }
        public double Area { get; set; }
        public string PrintNome(){
        return $"{Nome}";
        }

        public abstract string  PrintPerimetro { get; set; }
        public abstract string  PrintArea { get; set; }
        public abstract string  CalcoloArea { get; set; }
    }


}
