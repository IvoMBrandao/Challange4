﻿using Challange4.Data;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Challange4.Repositorio
{
    public class ReceitasRepositorio : ControllerBase, IReceitasRepositorio
    {

        private readonly FinancaContext _context;

        public ReceitasRepositorio(FinancaContext Context)
        {
            _context = Context;

        }

        public async Task<List<Receitas>> GetAllAsync()
        {
            return (await _context.Receitas.ToListAsync());

        }

        public async Task<Receitas> GetPerIdAsync(int id)
        {
            return await _context.Receitas.FirstOrDefaultAsync(Receitas => Receitas.Id == id);
        }


        public async Task<IActionResult> PostAsync(Receitas receitas)
        {
            var Verificar = (await GetAllAsync()).Where(x =>
              CheckDescriptionSameMonth(

                  x.Descricao,
                  receitas.Descricao,
                  x.Data,
                  receitas.Data

            )).FirstOrDefault();


            if (Verificar != null)
                return BadRequest("Não é possível adicionar receitas iguais no mesmo mês.");



            await _context.Receitas.AddAsync(receitas);
            await _context.SaveChangesAsync();
            return Ok( receitas);
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

        public async Task<IActionResult> PutAsync([FromBody] Receitas receita, int id)
        {
            Receitas receitas = await GetPerIdAsync(id);// arrumar pois não aceitas upcast

            if (receitas == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado ");
            }

            var Verificar = (await GetAllAsync()).Where(x =>
             CheckDescriptionSameMonth(

                 x.Descricao,
                 receitas.Descricao,
                 x.Data,
                 receitas.Data

           )).FirstOrDefault();


            if (Verificar != null)
                return BadRequest("Não é possível adicionar receitas iguais no mesmo mês.");


            receitas.Descricao = receita.Descricao;
            receitas.Valor = receita.Valor;
            receitas.Data = receita.Data;
            _context.Update(receita);
            await _context.SaveChangesAsync();
            return Ok(receita);

        }

        public async Task<Receitas> DeleteAsync(int id)
        {
            var receita = await GetPerIdAsync(id);

            _context.Remove(receita);
            await _context.SaveChangesAsync();
            return receita;
        }
    }





}

//public async Task<ActionResult<Receitas>> GetDescricaoAsync(string descri)
//{
//    var descricao = (await GetAllAsync()).
//        Where(x => x.Descricao.Equals(descri)).ToList();

//      return descri == null ? NotFound(): Ok(descri);
//}
