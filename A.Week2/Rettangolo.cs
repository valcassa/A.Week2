using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2
{
    public class Rettangolo : Poligono
    {
        public override string PrintPerimetro() { var perimetro = (Base + Altezza) * 2; return $"Perimetro = {perimetro}"; }
        public override string PrintArea() { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string CalcoloArea() { var area = Base * Altezza; Area = area; }
         
