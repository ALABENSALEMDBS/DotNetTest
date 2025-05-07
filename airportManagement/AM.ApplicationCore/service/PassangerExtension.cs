using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;

namespace AM.ApplicationCore.service
{
    public static class PassangerExtension
    {

        public static void UpperFullName(this Passenger p)
        {
        p.FullName.FirstName = p.FullName.FirstName[0].ToString().ToUpper() + p.FullName.FirstName.Substring(1);
            p.FullName.LastName = p.FullName.LastName[0].ToString().ToUpper() + p.FullName.LastName.Substring(1);

        }
    }
}
