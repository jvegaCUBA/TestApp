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
        [MaxLength(30, ErrorMessageResourceName = "MAX_LENGHT_EXCEDED", ErrorMessageResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FIELD_REQUIRED_MSG")]
        public string ContacName { get; set; }
        [MaxLength(12, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "MAX_LENGHT_EXCEDED")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(pattern: @"^\(?([0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessageResourceName = "PHONE_FORMAT_INCORRECT", ErrorMessageResourceType = typeof(Resources))]
        public string Phone { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FIELD_REQUIRED_MSG")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        [Range(1, 5)]
        public int? Ranking { get; set; }
        public bool? IsFavourite { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FIELD_REQUIRED_MSG")]
        public int ContactTypeId { get; set; }
        [AllowHtml]
        public string Text { get; set; }

    }
}
