using DesafioSGI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSGI.Utils
{
    public class ValidarDocumentoAluno : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var aluno = (Aluno)validationContext.ObjectInstance;

            if(aluno.cpf == null && aluno.numerodeCertidao == null)
            {
                return new ValidationResult("Documento é obrigatório!");
            }
            else
            {
                return ValidationResult.Success;
            }
               
            
        }
    }
}
