using Challange4.Models;
using Challange4.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Challange4.Controllers
{
    [ApiController]
    [Route("Despesas")]
    public class DespesasController:ControllerBase
    {

            private readonly IDespesasRepositorio _Icontext;

            public DespesasController(IDespesasRepositorio icontext)
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
                    var descri = await _Icontext.GetPerDescription(descricao);
                    return Ok(descri);
                }
                return Ok(await _Icontext.GetAllAsync());

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


            [HttpGet("{id}")]
            public async Task<IActionResult> GetPerIdAsync(int id)
            {
            if (!ModelState.IsValid)
            {
                BadRequest("Modelo inválido. Não é permitido campos em branco.");
            }
            var despesas = await _Icontext.GetPerIdAsync(id);
                return Ok(despesas);
            }

        [HttpGet("{Years}/{Month}")]

        public async Task<IEnumerable> GetPerMonth(string Years, string Month)
        {
            var Data = _Icontext.GetPerMonth(Years, Month);
            return await Data;
        }

        [HttpPost]
            public async Task<IActionResult> PostAsync(Despesas despesas)
            {

                if (!ModelState.IsValid)
                {
                    BadRequest("Modelo inválido. Não é permitido campos em branco.");
                }


                var despesa = _Icontext.PostAsync(despesas);
                return (await despesa);
            }

            [HttpPut]
            public async Task<IActionResult> PutAsync(Despesas despesa, int id)
            {
               
                var despesas = _Icontext.PutAsync(despesa, id);
                return (await despesas);
            }


            [HttpDelete]


            public async Task<IActionResult> DeleteAsync(int id)
            {
            if (!ModelState.IsValid)
            {
                BadRequest("Modelo inválido. Não é permitido campos em branco.");
            }
            var despesa = _Icontext.DeleteAsync(id);
                return Ok(await despesa);
            }

        }
    }

