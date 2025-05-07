using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace AM.ApplicationCore.domain
{
    public class ReservationTicket
    {
        public DateTime DateReservation { get; set; }
        public float Prix {  get; set; }

        public  virtual Ticket Ticket { get; set; }
        public virtual Passenger Passenger { get; set; }

        [ForeignKey("Passenger")]
        public string passenger_FK { get; set; }

        [ForeignKey("Ticket")]
        public int ticket_FK { get; set; }

    }
}
