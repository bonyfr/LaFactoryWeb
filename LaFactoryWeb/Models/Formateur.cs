using System;
using System.Collections.Generic;
using System.Text;

namespace LaFactoryWeb.Models
{
    public class Formateur
    {
        public int Id { get; set; }
        public bool Externe { get; set; }
        public int? UtilisateurId { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public List<Competence> Competences { get; set; } = new List<Competence>();
        public List<Module> Modules { get; set; } = new List<Module>();

        public Formateur()
        {
        }

        public Formateur(bool externe)
        {
            Externe = externe;
        }
    }
}
