using A.Week2.GestioneEsami.Core;
using A.Week2.GestioneEsami.Core.Entities;
using A.Week2.GestioneEsami.Core.RepositoryInterfaces;
using A.Week2.GestioneEsami.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestioneEsami
{
     
    public class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCorsi(), 
            new RepositoryCorsiDiLaurea(), new RepositoryImmatricolazione(), new RepositoryStudente());

        static void Main(string[] args)
        {

            bool continuare = true;
            int scelta;
            bool uscita = true;
            Studente s = new Studente();

            do
            {
                do
                {
                    Console.WriteLine("Premi 1 per immatricolarti");
                    Console.WriteLine("Premi 2 per accedere");
                    Console.WriteLine("Premi 3 per iscriverti ad un esame");
                    Console.WriteLine("Premi 0 per uscire");

                    continuare = int.TryParse(Console.ReadLine(), out scelta);
                } while (!continuare);

                switch (scelta)
                {
                    case 1:
                        s = Immatricolazione();
                        break;
                    case 2:
                        s = Accedi();
                        break;
                    case 3:
                        IscriversiAdEsame(s);
                        break;
                    case 0:
                        uscita = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non corretta");
                        break;
                }
            } while (uscita);
        }
        
        private static Studente Immatricolazione()
        {
            string nome = String.Empty;
            bool continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo nome");
                nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(nome))
                    continuare = false;
            } while (continuare);

            string cognome = String.Empty;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo cognome");
                cognome = Console.ReadLine();
                if (!String.IsNullOrEmpty(cognome))
                    continuare = false;
             
            } while (continuare);

            int annoNascita;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci l'anno di nascita");
                continuare = int.TryParse(Console.ReadLine(), out annoNascita);
            } while (!continuare);

            Studente s = new Studente(nome, cognome, annoNascita);

            List<CorsoDiLaurea> corsiDiLaurea = bl.FetchCorsiDiLaurea();
            foreach (var corsoDiLaurea in corsiDiLaurea)
            {
                Console.WriteLine(corsoDiLaurea.Print());
            }

            var nomeCdL = Console.ReadLine();
             CorsoDiLaurea cdl = corsiDiLaurea.Where(c => c.Nome == nomeCdL).SingleOrDefault();

            s = bl.CreaImmatricolazione(s, cdl);

            return s;
        }


        private static Studente Accedi()
        {
            string matricola = String.Empty;
            bool continuare = true;

             
            do
            {
                Console.WriteLine("Inserisci la tua matricola");
                matricola = Console.ReadLine();
                if (!String.IsNullOrEmpty(matricola))
                    continuare = false;

            } while (continuare);

            string password;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci la password");
                password = Console.ReadLine();
                if (!String.IsNullOrEmpty(password))
                    continuare = false;
            } while (!continuare);

        
            Studente s = new Studente();

            List<Esame> esami = bl.FetchEsami();
            foreach (var listaEsami in esami)
            {
                Console.WriteLine(listaEsami.Print());
            }

            var students = Console.ReadLine();
            Esame e = esami.Where(esami => esami.Nome == students).SingleOrDefault();

            s = bl.Accedi(matricola, password); 

            return s;
        }



        private static void IscriversiAdEsame(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._CorsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }
            string esame = String.Empty;
            Corso corsoScelto;
            do
            {
                Console.WriteLine("A quale esame vuoi iscriverti?");
                esame = Console.ReadLine();
                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();
            } while (corsoScelto == null);

            bool possibileIscriversi = bl.VerificaCfuPerIscrizioneEsame(corsoScelto, s);
            if (possibileIscriversi)
            {
                Esame esameDaSostenere = new Esame();
                esameDaSostenere.Nome = corsoScelto.Nome;
                esameDaSostenere.Passato = false;
                esameDaSostenere.IdStudente = s.Id;
                esameDaSostenere = bl.AggiungiadEsame(esameDaSostenere); // Insert + return id;


                bool esamePassato = bl.RandomEsamePassato(esameDaSostenere);  //         esameDaSostenere.Passato = true;
                if (esameDaSostenere.Passato)
                {

                    bl.UpdateEsamePassato(); // update
                }

            }
        }

    }

}  