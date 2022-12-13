using Challange4.Data.Dtos;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Challange4.Repositorio
{
    public interface IReceitasRepositorio
    {
        Task<List<ReadReceitasDto>> GetAllAsync();
        Task<IActionResult> GetPerIdAsync(int id);
        Task<IActionResult> PostAsync(CreateReceitasDto receitas );
        Task<IActionResult> PutAsync(UpdateReceitasDto receita,int id);
        Task<Receitas> DeleteAsync(int id);
        Task<IActionResult> GetPerDescription(string description);
        Task<IActionResult> GetPerMonth(string Years , string Month );
    }
}
