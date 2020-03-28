using APIplanning.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace APIplanning
{
    public class SeanceDAO
    {
        private MySqlConnection conn;


        //connecteur
        public SeanceDAO()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=nadia;pwd=0550002D;database=planning-ligue;";
            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }

        // revenvoie la liste de toute les seance
        public List<Seance> getAllSeances()
        {
            List<Seance> lesSeances = new List<Seance>();
            string requete = "select * from seance";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
               Seance c = new Seance(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
                   rdr[2].ToString(), Convert.ToDateTime(rdr[3].ToString()), Convert.ToDateTime(rdr[4].ToString()), Convert.ToInt32(rdr[5].ToString()));
                lesSeances.Add(c);
            }
            rdr.Close();
            return lesSeances;
        }

        //renvoie la seance selon son Id
        public Seance getSeance(int id)
        {
            string requete = "select * from seance where id = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Seance laSeance;
            if (rdr.Read())
            {
                laSeance = new Seance(Convert.ToInt16(rdr[0].ToString()), rdr[1].ToString(),
                   rdr[2].ToString(), Convert.ToDateTime(rdr[3].ToString()), Convert.ToDateTime(rdr[4].ToString()), Convert.ToInt32(rdr[5].ToString()));
            }
            else
                laSeance = null;
            rdr.Close();
            return laSeance;            
        }

        //inutile
        /*
        public void updateSeance(int id, string descriptif)
        {
            string requete = "Update seance SET descriptif = '" + descriptif + "' WHERE id = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            cmd.ExecuteNonQuery();
        }*/


        //Cree la seance
        public bool addSeance(Seance s)
        {
            string requete = "INSERT INTO `seance` (`id`, `jour`, `descriptif`, `debut`, `fin`, `la_categorie`) VALUES('" + s.Id + "', '" + s.Jour + "', '" + s.Descriptif + "', '" + s.Debut.ToString("yyyy-M-d h:m:s") + "', '" + s.Fin.ToString("yyyy-M-d h:m:s") + "', '" + s.Categorie + "');";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return true;
        }

        //supprimer une Seance selon son id
        public bool deleteSeance(int id)
        {
            string requete = "DELETE FROM `seance` WHERE id = " + id;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return true;
        }


        //ajouter une proposition selon l'id de la seance et du moniteur
        public bool insertProposer(int id,int moniteur)
        {
            string requete = "INSERT INTO proposer (id_seance,id_moniteur) VALUES (" + id + "," + moniteur + ")";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return true;
        }


        //supprimer une position selon l'id de la seance et du moniteur
        public bool deleteProposer(int idSeance , int idMoniteur)
        {
            string requete = "DELETE FROM proposer WHERE id_seance = " + idSeance + " and id_moniteur = " + idMoniteur + " ;";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return true;
        }

        //retourne la liste des proposition des moniteur selon l'id de la seance
        public List<proposer> getProposerSeance(int id_seance)
        {
            List<proposer> ps = new List<proposer>();
            string requete = "select * from proposer where id_seance = "+id_seance;
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                proposer p = new proposer(Convert.ToInt32(rdr[0]), Convert.ToInt32(rdr[1]));
                ps.Add(p);
            }
            rdr.Close();
            return ps;
        }

        //Verifie la connexion
        public string connection(string email, string mdp)
        {
            string requete = "SELECT connexion('"+email+"','"+mdp+"')";
            MySqlCommand cmd = new MySqlCommand(requete, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if(rdr.Read())
            {
                return (string)rdr[0];
            }
            else
            {
                return "Probleme !";
            }
        }
    }
}
