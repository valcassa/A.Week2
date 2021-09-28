using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2
{
    public class Persona
    {
        public string Nome { get; set; }
        public DateTime Nascita { get; set; }
        public Sesso Sex { get; set; }

        public enum Sesso
        {
            Maschio,
            Femmina
        }
        public Persona(string n, DateTime birth, Sesso sex)
        {
            Nome = n;
            Nascita = birth;
            Sex = sex;
        }

        public void GetEta()
        {
            //Qui viene restituta l'età della persona
        }
    }
}

alterMyObject(Persona p){

    p.Nome = Mario;

}


alterMyObject(int i){

   i= i++;
    // i=i+1; ++i; i+=1
}


