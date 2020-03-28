using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace APIplanning.Models
{
    [DataContract]
    public class Seance
    { 

        private int id;
        private string jour;
        private string descriptif;
        private DateTime debut;
        private DateTime fin;
        private int categorie;


        [DataMember]
        public int Id { get => id; set => id = value; }

        [DataMember]
        public string Jour { get => jour; set => jour = value; }

        [DataMember]
        public string Descriptif { get => descriptif; set => descriptif = value; }

        [DataMember]
        public DateTime Debut { get => debut; set => debut = value; }

        [DataMember]
        public DateTime Fin { get => fin; set => fin = value; }

        [DataMember]
        public int Categorie { get => categorie; set => categorie = value; }

        public Seance(int id, string j, string desc, DateTime de, DateTime fi, int cate)
        {
            this.Id = id;
            this.Jour = j;
            this.Descriptif = desc;
            this.Debut = de;
            this.Fin = fi;
            this.Categorie = cate;
        }
    }
}