
using Microsoft.AspNetCore.Mvc;
using Challange4.Models;
using Challange4.Repositorio;
using System.Collections;
using Challange4.Data.Dtos;
using AutoMapper;
using NuGet.Protocol.Plugins;
using System.Net;

namespace Challange4.Controllers
{
    [ApiController]
    [Route("Receitas")]
    public class ReceitasController : ControllerBase
    {

        private readonly IReceitasRepositorio _Icontext;
        private readonly IMapper _mapper;

        public ReceitasController(IReceitasRepositorio icontext,IMapper mapper)
        {
            _mapper=mapper; 
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

                    return desc;


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

                var receitas = await _Icontext.GetPerIdAsync(id);
                return receitas;
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
                var Data = await _Icontext.GetPerMonth(Years, Month);
                return Data;

            }


            catch (Exception)
            {
                return StatusCode(500);
            }

            
              
           
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateReceitasDto receitas)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    BadRequest("Modelo inválido. Não é permitido campos em branco.");
                }


                var receita =await _Icontext.PostAsync(receitas);
                return receita;
            }
            catch (Exception )
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(UpdateReceitasDto receita, int id)
        {
            try
            {


                var receitas = await _Icontext.PutAsync(receita, id);
                return receitas;
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

