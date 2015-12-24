using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace marienbad.Models
{
    public class ConfigModels
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Pseudonyme")]

        public string Nickname { get; set; }


        [Required]
        [Display(Name = "Nombre de ligne")]
        [Range(2,9, ErrorMessage ="Entrez un chiffre entre 2 et 9")]
        public int Row { get; set; }

        [Display(Name = "Je commence ")]
        public bool RememberMe { get; set; }
    }
    
}