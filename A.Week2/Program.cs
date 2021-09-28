using System;

namespace A.Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cerchio lmc = new Cerchio();
            //lmc.Id = 3; // SET - salva il valore
            //int id = lmc.id; // GET - restituisci valore proprietà Id

            //lmc.Eta = 1991;
            //var eta = lmc.Eta;
            //lmc.Nome = "Arianna";
            //var nome = lmc.Nome;


            // - dot Notation
            Cerchio cerchio = new Cerchio();
            Centro centro = new Centro();
            centro.x = 5;
            centro.Y = 2.2;
            cerchio.CoordCentro = centro;
            cerchio.Nome = "Cerchio";
            cerchio.Raggio = 12;
            Console.WriteLine(cerchio.PrintNome());


            Rettangolo rettangolo = new Rettangolo();
            rettangolo.Nome = "Rettangolo";
            rettangolo.Base = 10;
            rettangolo.Altezza = 20;

            Console.WriteLine(rettangolo.PrintNome());
            Console.WriteLine(rettangolo.PrintPerimetro());
            Console.WriteLine(rettangolo.PrintArea());


            Triangolo triangolo = new Triangolo();
            triangolo.Nome = "Triangolo";
            triangolo.Lato1 = 6;
            triangolo.Lato2 = 9;
            triangolo.Base = 12;
            triangolo.Altezza = 3;

            Console.WriteLine(triangolo.Nome);
            Console.WriteLine(triangolo.PrintPerimetro());
            Console.WriteLine(triangolo.PrintArea());
        }
    }
}
