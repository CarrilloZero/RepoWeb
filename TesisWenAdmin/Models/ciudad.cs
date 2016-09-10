using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TesisWenAdmin.Valitations;

namespace TesisWenAdmin
{
    [MetadataType(typeof(ciudadMetadata))]

    public partial class ciudad
    {

    }

    public class ciudadMetadata
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage = "Solo se aceptan letras")]
        [StringLength(30, ErrorMessage = "Maximo de caracteres permitido 30")]
        [CiudadValidation]
        public string Nombre { get; set; }

   
    }
}