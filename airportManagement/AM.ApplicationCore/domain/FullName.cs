using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.domain
{
    //[Owned]    //*****  ne pas besoin d'un class 
    public class FullName
    {
        [MinLength(3, ErrorMessage = "Le prénom doit contenir au moins 3 caractères."), MaxLength(25, ErrorMessage = "Le prénom ne doit pas dépasser 25 caractères.")]
        public String FirstName { get; set; }
       
        public String LastName { get; set; }
    }
}
