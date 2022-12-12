using Challange4.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Challange4.Models
{
    public class Despesas
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }

        public CategoriasEnum Categorias { get; set; } = 0;

        [Required]
        public DateTime Data { get; set; }


    }


}
