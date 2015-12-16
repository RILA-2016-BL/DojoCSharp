using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JeuDeNim.Models
{
    public class JeuViewModels
    {

        [Required]
        [StringLength(10, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 2)]
        [Display(Name = "Ton Pseudo jeune padawan :")]
        public string Pseudo { get; set; }

        [Required]
        [Range(2, 5, ErrorMessage = "Ce nombre de ligne n'est pas autorisé. Choisis entre 2 et 5...")]
        [Display(Name = "Nombre de lignes :")]
        public int NbLignes { get; set; }

        [Required]
        [Display(Name = "Tu commences ?")]
        public bool JeCommence { get; set; } = true;



    }
}