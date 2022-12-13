using Challange4.Data;
using Challange4.Models;
using Challange4.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Challange4.Controllers
{
    [ApiController]
    [Route("Resumo")]
    public class ResumoController:ControllerBase
    {
        public readonly IResumoRepositorio _context;

        public ResumoController(IResumoRepositorio context)
        {
            _context = context;
        }


        [HttpGet("{year}/{month}")]

        public async Task<IActionResult> ResumoReceitaMes(string year,string Month)
        {
            try
            {
                return await _context.ResumoMes(year,Month);
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }

      
    }
}
