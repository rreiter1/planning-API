using System;
using APIplanning.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIplanning.Controllers
{
    public class planningController : ApiController
    {
        //Permet de créer une séance.
        [HttpPost]
        public HttpResponseMessage AddSeance([FromBody] Seance s)
        {
            if (s != null)
            {
                SeanceDAO dao = new SeanceDAO();
                dao.addSeance(s);
                return Request.CreateResponse(HttpStatusCode.Created, s);
            }
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, s);
        }

        //recupere une proposition de seance selon son id (id de seance).
        [HttpGet]
        public List<proposer> GetById(int id)
        {
            SeanceDAO dao = new SeanceDAO();
            List<proposer> LesProposerParSeance = dao.getProposerSeance(id);
            return LesProposerParSeance;
        }

        //Verifie une tentative de connexion.
        [HttpGet]
        public string verifMDP(string email , string mdp)
        {
            SeanceDAO dao = new SeanceDAO();
            string connection = dao.connection(email, mdp);
            return connection;
        }
        
        //recupere toute les seance.
        [HttpGet]
        public IEnumerable<Seance> GetAll()
        {
            SeanceDAO dao = new SeanceDAO();
            List<Seance> lesSeances = dao.getAllSeances();
            return lesSeances.ToList();
        }

        //Supprime une seance
        [HttpDelete]
        public string DeleteSeance(int id)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.deleteSeance(id);
            return "Contact supprimé id " + id;
        }
        

        //Supprime une proposition d'un moniteur sur une seance
        [HttpDelete]
        public string DeleteProposer(int idSeance , int idMoniteur)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.deleteProposer(idSeance, idMoniteur);
            return "La Seance " + idSeance + "n'a plus la proposition de ce moniteur" ;
        }

        //ajouter une proposition sur une seance
        [HttpPost]
        public string insertProposer(int id_seance,int moniteur)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.insertProposer(id_seance,moniteur);
            return "Séance ajouté";
        }

        /*
         a supprimer inutile (je crois ) 
        [HttpPut]
        public string UpdateContact(string Name, int Id)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.updateSeance(Id, Name);
            return "Mise à jour du contact avec le nom " + Name + " and Id " + Id;
        }*/
    }
}
