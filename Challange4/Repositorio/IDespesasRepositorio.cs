using Challange4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challange4.Repositorio
{

    
        public interface IDespesasRepositorio
        {
            Task<List<Despesas>> GetAllAsync();
            Task<Despesas> GetPerIdAsync(int id);
            Task<IActionResult> PostAsync(Despesas receitas);
            Task<IActionResult> PutAsync(Despesas receita, int id);
            Task<Despesas> DeleteAsync(int id);
        }
    
    
}
