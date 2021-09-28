using A.Week2.GestioneEsami.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Core
{
    public interface IBusinessLayer
    {
        List<CorsoDiLaurea> FetchCorsiDiLaurea();
        CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl);
        Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl);
        bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s);
        bool RandomEsamePassato(Esame esameDaSostenere);
        void UpdateEsamePassato();
        List<Esame> FetchEsami();
        Studente Accedi(string matricola, string password);
        Esame AggiungiadEsame(Esame esameDaSostenere);
    }
}