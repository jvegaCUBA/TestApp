using System.Collections.Generic;

namespace isucorp.testApp.DataBaseModel
{
    public class ContactType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Reservation> Reservations { get; set; } 
    }
}
