using DesafioSGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSGI.Utils
{
    public class ValidarIdadeAluno : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var aluno = (Aluno)validationContext.ObjectInstance;

            if (aluno.DataDeNacimento == null)
                return new ValidationResult("Data de nascimento é obrigatório!");

            var age = DateTime.Today.Year - aluno.DataDeNacimento.Value.Year;

            return (age > 6)
                ? ValidationResult.Success
                : new ValidationResult("A idade deve ser maior que 6 anos!");
        }
    }
}
