﻿using A.Week2.GestioneEsami.Core;
using A.Week2.GestioneEsami.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;

namespace GestioneEsami
{
    public class RepositoryCorsiDiLaurea : IRepositoryCorsiDiLaurea
    {
        public static List<CorsoDiLaurea> corsiDiLaurea = new List<CorsoDiLaurea>()
        {
            new CorsoDiLaurea { Id = 1, Nome = "Matematica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 2, Nome = "Fisica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 3, Nome = "Informatica", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 4, Nome = "Ingegneria", AnniDiCorso = 3},
            new CorsoDiLaurea { Id = 5, Nome = "Lettere", AnniDiCorso = 3},
        };

        public List<CorsoDiLaurea> Fetch()
        {
            return corsiDiLaurea;
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }
}