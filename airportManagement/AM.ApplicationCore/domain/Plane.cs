using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Plane
    {
        #region exemple java
        //public int Capacity;


        //public int GetCapacity() {  return Capacity; }
        //public void SetCapacity(int capacity) { Capacity = capacity; }
        #endregion


        #region getset

        //public int MyProperty { get; private set; }   //propg +tabulation

        //// ***************  //propfull +tabulation***************
        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        ////**********************************e
        #endregion


        [Required(ErrorMessage = "La capacité est obligatoire.")]
        [Range(0, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif.")]
        public int Capacity { get; set; }   //prop +tabulation
        public DateTime ManufactureDate { get; set; }

        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        public string Aireline {  get; set; }


        public virtual ICollection<Flight> Flights { get; set; }


        public override string ToString()
        {
            return "PlaneType: " + PlaneType + " ==> Capacity: " + Capacity + " ==>ManufactureDate: " + ManufactureDate;
        }
    }
}
