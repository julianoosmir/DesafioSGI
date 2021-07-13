using DesafioSGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSGI.Utils
{
    public class ValidarResponsavelAluno : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var aluno = (Aluno)validationContext.ObjectInstance;

            var age = DateTime.Today.Year - aluno.DataDeNacimento.Value.Year;

            return (age > 18 || aluno.responsavelId != null)
             ? ValidationResult.Success
             : new ValidationResult("Responsável é obrigatório para alunos menores de 18 anos de idade");


        }
    }
}
