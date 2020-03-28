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
        [HttpGet]
        public List<proposer> GetById(int id)
        {
            SeanceDAO dao = new SeanceDAO();
            List<proposer> LesProposerParSeance = dao.getProposerSeance(id);
            return LesProposerParSeance;
        }
        [HttpGet]
        public string verifMDP(string email , string mdp)
        {
            SeanceDAO dao = new SeanceDAO();
            string connection = dao.connection(email, mdp);
            return connection;
        }
        

        [HttpGet]
        public IEnumerable<Seance> GetAll()
        {
            SeanceDAO dao = new SeanceDAO();
            List<Seance> lesSeances = dao.getAllSeances();
            return lesSeances.ToList();
        }

        [HttpDelete]
        public string DeleteContact(int id)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.deleteSeance(id);
            return "Contact supprimé id " + id;
        }

        [HttpDelete]
        public string DeleteProposer(int idSeance , int idMoniteur)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.deleteProposer(idSeance, idMoniteur);
            return "La Seance " + idSeance + "n'a plus la proposition de ce moniteur" ;
        }

        [HttpPost]
        public string insertProposer(int id_seance,int moniteur)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.insertProposer(id_seance,moniteur);
            return "Séance ajouté";
        }

        [HttpPut]
        public string UpdateContact(string Name, int Id)
        {
            SeanceDAO dao = new SeanceDAO();
            dao.updateSeance(Id, Name);
            return "Mise à jour du contact avec le nom " + Name + " and Id " + Id;
        }
    }
}
