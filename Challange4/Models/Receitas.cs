using System.ComponentModel.DataAnnotations;

namespace Challange4.Models
{
    public class Receitas
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set; } 
    }
}
