using Challange4.Data.Dtos;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Challange4.Repositorio
{


    public interface IDespesasRepositorio
    {
        Task<List<ReadFinancaDto>> GetAllAsync();
        Task<IActionResult> GetPerIdAsync(int id);
        Task<IActionResult> PostAsync(CreateFinancaDto despesasDto);
        Task<IActionResult> PutAsync(UpdateFinancaDto despesasDto, int id);
        Task<IActionResult> DeleteAsync(int id);
        Task<IActionResult> GetPerDescription(string description);
        Task<IEnumerable> GetPerMonth(string Years, string Month);
    }


}
