using AutoMapper;
using Challange4.Data.Dtos;
using Challange4.Models;
using Challange4.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Challange4.Controllers
{
    [ApiController]
    [Route("Despesas")]
    public class DespesasController : ControllerBase
    {

        private readonly IDespesasRepositorio _Icontext;
        private readonly IMapper _mapper;

        public DespesasController(IDespesasRepositorio icontext, IMapper mapper)
        {
            _mapper = mapper;
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
                    return descri;
                }
                return Ok(await _Icontext.GetAllAsync());

            }
            catch (Exception)
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
                var despesas = await _Icontext.GetPerIdAsync(id);
                return despesas;
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
        public async Task<IActionResult> PostAsync(CreateFinancaDto despesas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest("Modelo inválido. Não é permitido campos em branco.");
                }


                var despesa = _Icontext.PostAsync(despesas);
                return await despesa;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateFinancaDto despesa, int id)
        {
            try
            {

                var despesas = _Icontext.PutAsync(despesa, id);
                return (await despesas);

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
                var despesa = _Icontext.DeleteAsync(id);
                return await despesa;
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}

