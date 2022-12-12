using Challange4.Data;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challange4.Repositorio
{
    public class ResumoRepositoio:ControllerBase,IResumoRepositorio
    {
        public readonly FinancaContext _context;

        public ResumoRepositoio(FinancaContext context )
        {
            _context=context;
        }



        public async Task<IActionResult> ResumoMes( string Year, string Month)
        {
            var resumoReceita =  _context.Receitas.Where(data => data.Data.Year.ToString() == Year
            && data.Data.Month.ToString() == Month).ToList().Select(resum => resum.Valor);

            var resumoDespesa = _context.Despesas.Where(data => data.Data.Year.ToString() == Year
           && data.Data.Month.ToString() == Month).ToList().Select(resum => resum.Valor);

            var resumoPorCategoria = _context.Despesas.Where(data => data.Data.Year.ToString() == Year
           && data.Data.Month.ToString() == Month).ToList().
           GroupBy(x => x.Categorias).
           Select(x => new
           {
               Categoria = Enum.GetName(x.Key),
               QuantidadeDeDespesas = x.Count(),
               total = x.Sum(t => t.Valor)

           }

           ).ToList();



            var resumoPerDataReceita = resumoReceita.Sum();
            var resumoPerDataDespesa = resumoDespesa.Sum();
            var SaldoDoMes = resumoPerDataReceita - resumoPerDataDespesa;

            


            return Ok(new{resumoPerDataReceita, resumoPerDataDespesa, SaldoDoMes, resumoPorCategoria});
           
        }

      
    }
}
