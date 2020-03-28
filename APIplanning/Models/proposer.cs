using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIplanning.Models
{
    public class proposer
    {
        private int id_seance;
        private int id_moniteur;

        public int Id_seance { get => id_seance; set => id_seance = value; }
        public int Id_moniteur { get => id_moniteur; set => id_moniteur = value; }


        public proposer(int idS , int idM)
        {
            Id_seance = idS;
            Id_moniteur = idM;
        }
    }
}