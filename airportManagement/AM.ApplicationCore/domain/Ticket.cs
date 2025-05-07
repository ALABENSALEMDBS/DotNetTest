using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace AM.ApplicationCore.domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Classe { get; set; }
        public string Destination { get; set; }

        public virtual ICollection<ReservationTicket> reservations { get; set; }
    }
}
