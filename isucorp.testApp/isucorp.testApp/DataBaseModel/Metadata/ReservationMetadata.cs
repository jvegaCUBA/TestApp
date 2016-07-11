using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isucorp.testApp.DataBaseModel.Metadata
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using System.Web.UI.HtmlControls;

    using isucorp.testApp.Resources;

    class ReservationMetadata
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FIELD_REQUIRED_MSG")]
        public string ContacName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FIELD_REQUIRED_MSG")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Range(1,5)]
        public int? Ranking { get; set; }
        public bool? IsFavourite { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FIELD_REQUIRED_MSG")]
        public int ContactTypeId { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        
    }
}
