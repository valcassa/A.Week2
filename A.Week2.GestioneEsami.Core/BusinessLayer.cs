using A.Week2.GestioneEsami.Core.RepositoryInterfaces;
using A.Week2.GestioneEsami.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Core.Entities
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryCorsiDiLaurea corsiDiLaureaRepo;
        private readonly IRepositoryImmatricolazione immatricolazioneRepo;
        private readonly IRepositoryStudente studenteRepo;
        private readonly IRepositoryEsami esamiRepo;
        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiDiLaurea corsiDiLaurea,
            IRepositoryImmatricolazione immatricolazione, IRepositoryStudente studente)
        {
            corsiRepo = corsi;
            corsiDiLaureaRepo = corsiDiLaurea;
            immatricolazioneRepo = immatricolazione;
            studenteRepo = studente;
        }


        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInizio = DateTime.Now;
            imm._CorsoDiLaurea = GetCorsi(cdl);

            int ore = imm.DataInizio.Hour;
            int minuti = imm.DataInizio.Minute;
            var secondi = imm.DataInizio.Second;
            var matricola = String.Concat(ore, minuti, secondi);

            imm.Matricola = Convert.ToInt32(matricola);

            immatricolazioneRepo.Insert(imm);
            imm = immatricolazioneRepo.GetByDate(imm);

            s._Immatricolazione = imm;
            return s;
        }


        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRepo.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRepo.GetCorsiByCorsoDiLaurea(cdl);
            cdl.Corsi = corsi;
            var cfuTotali = corsi.Sum(c => c.CreditiFormativi);
            cdl.Cfu = cfuTotali;
            return cdl;
        }



        public bool RandomEsamePassato(Esame esameDaSostenere)
        {
            Esame e = new Esame();
            if (e.Passato == true)
            {
                e.Passato = true;
            }
            else { Console.WriteLine("Esame non passato"); }
            return false;
        }

        public void UpdateEsamePassato()
        {
            Esame e = new Esame();
            Immatricolazione i = new Immatricolazione();
            Corso c = new Corso();
            Studente s = new Studente();

            if (e.Passato == true)
            {
                e.Passato = true;
                i.CfuAccumulati = i.CfuAccumulati + c.CreditiFormativi;
                if (i.CfuAccumulati == 180)
                    s.LaureaRichiesta = true;
            }

        }
        public bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s)
        {
            var cfuOk = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi <= s._Immatricolazione._CorsoDiLaurea.Cfu;
            if (cfuOk && !s.LaureaRichiesta)
                return true;
            else
                return false;
        }

 

        public List<Esame> FetchEsami()
        {
            return esamiRepo.Fetch();
        }

        public Studente Accedi(string matricola, string password)
        {
            Studente _stud = new Studente();
            Immatricolazione imm = new Immatricolazione();

            password = String.Concat(_stud.Nome, _stud.Cognome);
            imm.Matricola = Convert.ToInt32(matricola);


            _stud._Immatricolazione = imm;
            return _stud;
        }

        Esame IBusinessLayer.AggiungiadEsame(Esame esameDaSostenere)
        {
            List<Esame> esame = new List<Esame>();

            if (esameDaSostenere == null) throw new ArgumentException();
            corsiDiLaureaRepo.Add(esameDaSostenere);

            return esameDaSostenere;
        }
    }
}
    
