using Challange4.Data.Dtos;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Challange4.Repositorio
{
    public interface IReceitasRepositorio
    {
        Task<List<ReadFinancaDto>> GetAllAsync();
        Task<IActionResult> GetPerIdAsync(int id);
        Task<IActionResult> PostAsync(CreateFinancaDto receitas );
        Task<IActionResult> PutAsync(UpdateFinancaDto receita,int id);
        Task<IActionResult> DeleteAsync(int id);
        Task<IActionResult> GetPerDescription(string description);
        Task<IActionResult> GetPerMonth(string Years , string Month );
    }
}
