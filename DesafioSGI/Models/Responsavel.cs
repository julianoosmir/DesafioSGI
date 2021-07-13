using DesafioSGI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSGI.Models
{
    public class Responsavel
    {
        public int responsavelId { get; set; }

        [MaxLength(180)]
        [MinLength(3)]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Data De Nacimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Min18Anos]
        public DateTime? DataDeNacimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(14, ErrorMessage = "apenas 14 digitos")]
        public string cpf { get; set; }
       

    }
}
