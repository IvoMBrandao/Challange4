
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

        public ReceitasController(IReceitasRepositorio icontext)
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
            try
            {

                if (!ModelState.IsValid)
                {
                    BadRequest("Modelo inválido. Não é permitido campos em branco.");
                }

                var receitas = await _Icontext.GetPerIdAsync(id);
                return Ok(receitas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{Years}/{Month}")]

        public async Task<IActionResult> GetPerMonth(string Years, string Month)
        {
            try
            {

                var Data = _Icontext.GetPerMonth(Years, Month);
                return Ok(await Data);
            }

            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Receitas receitas)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    BadRequest("Modelo inválido. Não é permitido campos em branco.");
                }


                var receita = _Icontext.PostAsync(receitas);
                return (await receita);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Receitas receita, int id)
        {
            try
            {


                var receitas = _Icontext.PutAsync(receita, id);
                return (await receitas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


        [HttpDelete]


        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    BadRequest("Modelo inválido. Não é permitido campos em branco.");
                }
                var receita = _Icontext.DeleteAsync(id);
                return Ok(await receita);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}

