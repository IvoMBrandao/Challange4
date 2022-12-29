using AutoMapper;
using Challange4.Data;
using Challange4.Data.Dtos;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Challange4.Repositorio
{
    public class DespesasRepositorio:ControllerBase,IDespesasRepositorio
    {
        private readonly FinancaContext _context;
        private IMapper _mapper;


        public DespesasRepositorio(FinancaContext Context, IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;  

        }

        public async Task<List<ReadFinancaDto>> GetAllAsync()
        {
            return _mapper.Map<List<ReadFinancaDto>>(await _context.Despesas.ToListAsync());
            //Arrumar
        }

        public async Task<IActionResult> GetPerIdAsync(int id)
        {

            var despesas =  await _context.Despesas.FirstOrDefaultAsync(Despesas => Despesas.Id == id);
            var despesasDto = _mapper.Map<ReadFinancaDto>(despesas);

            return Ok(despesasDto);

        }


        public async Task<IActionResult> PostAsync(CreateFinancaDto despesasDto)
        {
            Despesas despesas = _mapper.Map<Despesas>(despesasDto);
            var Verificar = (await GetAllAsync()).Where(x =>
              CheckDescriptionSameMonth(
                  x.Descricao,
                  despesasDto.Descricao,
                  x.Data,
                  despesasDto.Data
            )).FirstOrDefault();

            if (Verificar != null)
                return BadRequest("Não é possível adicionar receitas iguais no mesmo mês.");

            await _context.Despesas.AddAsync(despesas);
            await _context.SaveChangesAsync();
            return Ok (despesasDto);
        }

        public bool CheckDescriptionSameMonth(

          String descricao1,
          String descricao2,
           DateTime data1,
          DateTime data2
      )
        {
            return data1.ToString("MM/yy") == data2.ToString("MM/yy") && descricao1 == descricao2;
        }

        public async Task<IActionResult> PutAsync([FromBody] UpdateFinancaDto despesasDto, int id)
        {
            Despesas despesa =await _context.Despesas.FirstOrDefaultAsync(x => x.Id==id);
            
            var Verificar = (await GetAllAsync()).Where(x =>
             CheckDescriptionSameMonth(


                 x.Descricao,
                 despesasDto.Descricao,
                 x.Data,
                 despesasDto.Data

           )).FirstOrDefault();

            if (despesa == null)
            {
                return BadRequest($"Usuario para o ID:{id} não foi encontrado ");
            }

            if (Verificar != null)

                return BadRequest("Não é possível adicionar despesas iguais no mesmo mês.");





            _mapper.Map(despesasDto, despesa);
            _context.Update(despesa);
            await _context.SaveChangesAsync();
            return Ok(despesa);

        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var despesa = await _context.Despesas.FirstOrDefaultAsync(x=> x.Id == id);

            _context.Remove(despesa);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        public async Task<IActionResult> GetPerDescription(string description)
        {
            var descricao = await _context.Despesas.Where(x => x.Descricao.Contains(description)).ToListAsync();
            var descricoesDto = _mapper.Map<List<ReadFinancaDto>>(descricao);


            return Ok(descricoesDto);
        }

        public async Task<IEnumerable> GetPerMonth(string Years, string Month)
        {

            var Data = (await GetAllAsync()).
                Where(x => x.Data.ToString("yyyy/MM") == $"{Years}/{Month}").ToList();
            var DataDto = _mapper.Map<List<ReadFinancaDto>>(Data);
            return (Data);
        }
    }
}

