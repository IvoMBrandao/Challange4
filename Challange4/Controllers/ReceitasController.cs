
using Microsoft.AspNetCore.Mvc;
using Challange4.Models;
using Challange4.Repositorio;


namespace Challange4.Controllers
{
    [ApiController]
    [Route("Receitas")]
    public class ReceitasController : ControllerBase
    {
        
        private readonly IReceitasRepositorio _Icontext;

        public ReceitasController(  IReceitasRepositorio icontext)
        {
           
            _Icontext = icontext;
        }


        [HttpGet]

        public async Task<List<Receitas>> GetAllAsync()
        {
            var receitas = await _Icontext.GetAllAsync();
            return receitas;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest("Modelo inválido. Não é permitido campos em branco.");
            }

            var receitas= await _Icontext.GetPerIdAsync(id);
             return Ok(receitas);
        }

       

        [HttpPost]
        public async Task<IActionResult> PostAsync(Receitas receitas)
        {

            if (!ModelState.IsValid)
            {
                BadRequest("Modelo inválido. Não é permitido campos em branco.");
            }
               

            var receita = _Icontext.PostAsync(receitas);
            return ( await receita);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Receitas receita, int id)
        {
            

            var receitas = _Icontext.PutAsync(receita, id);
            return (await receitas);
        }

       
        [HttpDelete]


        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                BadRequest("Modelo inválido. Não é permitido campos em branco.");
            }
            var receita = _Icontext.DeleteAsync(id);
            return Ok(await receita);
        }

    }
}

