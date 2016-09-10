using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesisWenAdmin.Valitations
{
    public class BusValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (TesisWenAdmin.bus)validationContext.ObjectInstance;

            var db = new TesisbdEntities();
            string pat = model.Patente;
            var bus = db.bus.Where(b => b.Patente == pat).FirstOrDefault();
            if (bus != null)
            {
                return new ValidationResult("Este bus ya existe");
            }
            return ValidationResult.Success;
        }

    }
}
