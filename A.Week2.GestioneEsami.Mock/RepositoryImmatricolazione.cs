﻿using A.Week2.GestioneEsami.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.Week2.GestioneEsami.Mock
{
   public class RepositoryImmatricolazione : IRepositoryImmatricolazione
    {
        public static List<Immatricolazione> immatricolazioni = new List<Immatricolazione>();
        public List<Immatricolazione> Fetch()
        {
            return immatricolazioni;        }
        

        public Immatricolazione GetByDate(Immatricolazione imm)
        {
            return immatricolazioni.Where(i => i.DataInizio == imm.DataInizio).SingleOrDefault();
        }

        public void Insert(Immatricolazione item)
        {
            if (immatricolazioni.Count() == 0)
            {
                item.Id = 1;
            }
            else
            {
                item.Id = immatricolazioni.Max(i => i.Id) + 1;
            }
            immatricolazioni.Add(item);
        }
    }
}
