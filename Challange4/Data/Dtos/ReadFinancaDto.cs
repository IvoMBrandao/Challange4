using Challange4.Models.Enum;

namespace Challange4.Data.Dtos
{
    public class ReadFinancaDto
    {
        public string Descricao { get; set; }     
        public double Valor { get; set; }
        public CategoriasEnum Categorias { get; set; } = 0;
        public DateTime Data { get; set; }
    }
}
