using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Calcola il perimetro e area delle seguenti figure geometriche con proprietà Nome
// cerchio (centro raggio), rettangolo (b h), triangolo (b, h, l1, l2) 
// tutte le figure geometriche hanno metodo che stampa il nome, uno il perimetro e uno l'area

namespace A.Week2
{
    public class Cerchio : FiguraGeometrica
    {
        public double Raggio { get; set; }
        public Centro CoordCentro { get; set; }
        public override string PrintNome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string PrintPerimetro(){ 
        var perimetro = Raggio*2 Math.PI; }
        public override string PrintArea() { return $"{Area}"; }
    }
    public struct Centro
    {
        public double x { get; set; }
        public double Y { get; set; }
    }
        //public int Eta // implicito
        //{  get
        //    {
        //        return eta;

        //    }
        //    set
        //    {
        //        eta = DateTime.Now.Year - value;
        //    }
        //}

    }
}