
using Microsoft.AspNetCore.Mvc;
using Challange4.Models;
using Challange4.Repositorio;
using System.Collections;

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

        public async Task<IActionResult> GetAllAsync(string? descricao)
        {
            try
            {
                if (descricao != null)
                {
                    var desc = (await _Icontext.GetPerDescription(descricao));
                    return Ok(desc);


                }

                return Ok(await _Icontext.GetAllAsync());

            }

            catch
            {
                return StatusCode(500);
            }




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

        [HttpGet("{Years}/{Month}")]

        public async Task<IEnumerable> GetPerMonth(string Years , string Month )
        {
            var Data = _Icontext.GetPerMonth(Years, Month);
            return await Data;
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

