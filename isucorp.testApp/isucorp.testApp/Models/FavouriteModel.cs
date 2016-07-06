using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isucorp.testApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FavouriteModel
    {
        [Required]
        public int ReservationId { get; set; }
        [Required]
        public bool Favourite { get; set; }
    }
}
