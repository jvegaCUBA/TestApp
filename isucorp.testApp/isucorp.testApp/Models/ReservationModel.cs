using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isucorp.testApp.DataBaseModel
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using isucorp.testApp.DataBaseModel.Metadata;

    [MetadataType(typeof(ReservationMetadata))]
    public partial class Reservation
    {
        
    }
}
