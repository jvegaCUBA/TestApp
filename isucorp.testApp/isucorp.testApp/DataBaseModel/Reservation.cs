using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace isucorp.testApp.DataBaseModel
{
    using System.ComponentModel.DataAnnotations.Schema;

    
    public partial class Reservation
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        public string ContacName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public string Text { get; set; }
        public int? Ranking { get; set; }
        public bool? IsFavourite { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
    }
}
