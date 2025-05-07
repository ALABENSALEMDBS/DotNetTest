using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public String Function { get; set; }

        [DataType(DataType.Currency)]
        public Double Salary { get; set; }



        public override string ToString()
        {
            return "Function: " + Function + "\nSalary: " + Salary;
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("i m staff");
        }
    }
}
