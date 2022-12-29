using Challange4.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Challange4.Data.Dtos
{
    public class CreateFinancaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        public CategoriasEnum Categorias { get; set; } = 0;
        [Required]
        public DateTime Data { get; set; }

     
    }


   
}
