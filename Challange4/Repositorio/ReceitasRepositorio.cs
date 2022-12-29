using AutoMapper;
using Challange4.Data;
using Challange4.Data.Dtos;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Challange4.Repositorio
{
    public class ReceitasRepositorio : ControllerBase, IReceitasRepositorio
    {

        private readonly FinancaContext _context;
        private IMapper _mapper;

        public ReceitasRepositorio(FinancaContext Context, IMapper mapper)
        {
            _context = Context;
            _mapper = mapper;
        }

        public async Task<List<ReadFinancaDto>> GetAllAsync()
        {
            return _mapper.Map<List<ReadFinancaDto>>(await _context.Receitas.ToListAsync());
        }

        public async Task<IActionResult> GetPerIdAsync(int id)
        {
            var receita = await _context.Receitas.FirstOrDefaultAsync(Receitas => Receitas.Id == id);
            var receitaDto =  _mapper.Map<ReadFinancaDto>(receita);
            
                return  Ok(receitaDto);
        }


        public async Task<IActionResult> PostAsync(CreateFinancaDto receitaDto)
        {
            Receitas receita = _mapper.Map<Receitas>(receitaDto);
            var Verificar = (await GetAllAsync()).Where(x =>
           CheckDescriptionSameMonth(

                x.Descricao,
                receitaDto.Descricao,
                x.Data,
                receitaDto.Data,
                x.Valor,
                receitaDto.Valor
          )).FirstOrDefault();

            if (Verificar != null)
                return BadRequest("Não é possível adicionar receitas iguais no mesmo mês.");

            await _context.Receitas.AddAsync(receita);
            await _context.SaveChangesAsync();
            return Ok (receitaDto);
        }

        public bool CheckDescriptionSameMonth(

           String descricao1,
           String descricao2,
           DateTime data1,
           DateTime data2,
           double valor1,
          double valor2

      )

        {
           
                return  data1.ToString("MM/yy") == data2.ToString("MM/yy") && descricao1 == descricao2 && valor1==valor2;
         
        }

        public async Task<IActionResult> PutAsync([FromBody] UpdateFinancaDto receitaDto, int id)
        {
            Receitas receitas = await _context.Receitas.FirstOrDefaultAsync(Receitas => Receitas.Id == id);

            if (receitas == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado ");
            }
            var Verificar =(await GetAllAsync()).Where(x =>
             CheckDescriptionSameMonth(        

                  x.Descricao,
                  receitaDto.Descricao,
                  x.Data,
                  receitaDto.Data,
                  x.Valor,
                  receitaDto.Valor
            )).FirstOrDefault();


            if (Verificar != null)
                return BadRequest("Não é possível adicionar receitas iguais no mesmo mês.");


            _mapper.Map(receitaDto, receitas);
            _context.Update(receitas);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        public async   Task<IActionResult> DeleteAsync(int id)
        {
            var receita = await _context.Receitas.FirstOrDefaultAsync(Receitas => Receitas.Id == id); ;

            if(receita == null)
            {
                return NotFound();
            }

            _context.Remove(receita);
            await _context.SaveChangesAsync();
          
            return NoContent();
        }

        public async Task<IActionResult> GetPerDescription(string description)
        {
            
            var descricao = await _context.Receitas.Where(x => x.Descricao.Contains(description)).ToListAsync();
            var descricoesDto = _mapper.Map<List<ReadFinancaDto>>(descricao);


            return Ok(descricoesDto);
            
         
        }

        public async Task<IActionResult> GetPerMonth(string Years , string Month)
        {

            var Data =await _context.Receitas.Where(x => x.Data.Year.ToString().Equals(Years) &&
            x.Data.Month.ToString().Equals(Month)).ToListAsync(); 

            var DataDto = _mapper.Map<List<ReadFinancaDto>>(Data);
            return Ok(DataDto);

         
        }
    }



    

}

