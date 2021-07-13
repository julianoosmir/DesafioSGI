using DesafioSGI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSGI.Models
{
    public class Aluno {
        public int alunoId { get; set; }

        [MaxLength(180)]
        [MinLength(3)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "Data De Nacimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ValidarIdadeAluno]
        public DateTime? DataDeNacimento { get; set; }

        [ValidarDocumentoAluno]
        [Display(Name = "CPF")]
        [StringLength(14, ErrorMessage = "apenas 14 digitos")]
        public string cpf { get; set; }

        [ValidarDocumentoAluno]
        [Display(Name = "Numero de certidão")]
        [StringLength(32, ErrorMessage = "apenas 32 digitos")]
        public string numerodeCertidao { get; set; }

        [ValidarResponsavelAluno]
        [Display(Name = "responsavel")]
        public int? responsavelId { get; set; }

        [Display(Name = "responsavel")]
        public virtual Responsavel responsavel { get; set; }


    }
    

    
}
