using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2
{
    public class Triangolo : Poligono 
    { 
        public double  Lato1 { get; set; }
        public double Lato2 { get; set; }

        public abstract string PrintPerimetro() { var perimetro = Lato1+Lato2+Base; return $"Perimetro = {perimetro}"; }
        public abstract string PrintArea() { return Area; }
        public abstract void CalcoloArea() { var area = Lato2 * Lato2 / 2; }


    }
}
