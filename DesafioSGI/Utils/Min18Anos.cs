using DesafioSGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSGI.Utils
{
    public class Min18Anos : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var responsavel = (Responsavel)validationContext.ObjectInstance;



            if (responsavel.DataDeNacimento == null)
                return new ValidationResult("Data de nascimento é obrigatório!");

            var age = DateTime.Today.Year - responsavel.DataDeNacimento.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("A idade deve ser maior que 18 anos!");
        }
    }
}
