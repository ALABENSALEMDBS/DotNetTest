using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace AM.ApplicationCore.domain
{
    public class Passenger 
    {
        [Required(ErrorMessage = "La date de naissance est obligatoire.")]
        [DataType(DataType.Date, ErrorMessage = "La date de naissance doit être valide.")]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "L'adresse e-mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le format de l'e-mail est invalide.")]
        public String EmailAddress { get; set; }


        public virtual FullName FullName { get; set; }       //  <<<<<*******************************************************


        [Key, StringLength(7)]
        public String PassportNumber { get; set; }

        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "Format de date invalide (JJ/MM/AAAA).")]

        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Le mot de passe doit contenir au moins une majuscule, une minuscule, un chiffre, un caractère spécial, et faire au moins 8 caractères.")]
        //==> Mot de passe fort (au moins 1 maj, 1 min, 1 chiffre, 1 caractère spécial, min 8 caractères)

        //[RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Adresse e-mail invalide.")]

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le numéro de téléphone doit contenir exactement 8 chiffres.")]
        public int TelNumber { get; set; }


        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName + "\nEmailAddress: " + EmailAddress;
        }

        //public bool CheckProfile(String nom, String prenom)
        //{
        //    return FirstName==nom && LastName==prenom;
        //}

        //public bool CheckProfile(String nom, String prenom,String email)
        //{
        //    return FirstName == nom && LastName == prenom && EmailAddress.Equals(email);
        //}

        public bool CheckProfile(String nom, String prenom, String email=null)
        {  if(email == null)
                return FullName.FirstName == nom && FullName.LastName == prenom;
           else
                return FullName.FirstName == nom && FullName.LastName == prenom && EmailAddress.Equals(email);

        }

        public virtual void PassengerType()
        {
            Console.WriteLine("i m passenger");
        }




        public virtual ICollection<ReservationTicket> reservations { get; set; }


    }
}
