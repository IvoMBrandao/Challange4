using Challange4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challange4.Repositorio
{
    public interface IReceitasRepositorio
    {
        Task<List<Receitas>> GetAllAsync();
        Task<Receitas> GetPerIdAsync(int id);
        Task<IActionResult> PostAsync(Receitas receitas);
        Task<IActionResult> PutAsync(Receitas receita,int id);
        Task<Receitas> DeleteAsync(int id);
    }
}
