using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesisWenAdmin.Valitations;

namespace TesisWenAdmin.Models
{
    [MetadataType(typeof(busMetadata))]

    public partial class bus
    {
    }

    
    public class busMetadata
    {
        [BusValidation]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(8, ErrorMessage = "Maximo de caracteres permitido 8")]
        public string Patente { get; set; }

    }
}