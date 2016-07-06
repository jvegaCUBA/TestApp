using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isucorp.testApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RankingModel
    {
        [Required]
        public int ReservationId { get; set; }
        [Required]
        [Range(1,5)]
        public int Ranking { get; set; }
    }
}
