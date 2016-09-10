using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesisWenAdmin.Valitations
{
    public class CiudadValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (TesisWenAdmin.ciudad)validationContext.ObjectInstance;

            var db = new TesisbdEntities();
            string nom = model.Nombre;
            var ciudad = db.ciudad.Where(c => c.Nombre == nom).FirstOrDefault();
            if(ciudad != null)
            {
                return new ValidationResult("Esta ciudad ya existe");
            }
            return ValidationResult.Success;
        }
    }
}