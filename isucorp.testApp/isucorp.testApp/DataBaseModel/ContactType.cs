using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isucorp.testApp.DataBaseModel
{
    public class ContactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Reservation> Reservations { get; set; } 
    }
}
