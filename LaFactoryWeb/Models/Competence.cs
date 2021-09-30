using System;
using System.Collections.Generic;
using System.Text;

namespace LaFactoryWeb.Models
{
    public class Competence
    {
        public int FormateurId { get; set; }
        public int MatiereId { get; set; }
        public Formateur Formateur { get; set; }
        public Matiere Matiere { get; set; }

        public Competence()
        {
        }

        public Competence(Formateur formateur, Matiere matiere)
        {
            Formateur = formateur;
            Matiere = matiere;
        }
    }
}
