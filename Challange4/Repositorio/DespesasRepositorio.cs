using Challange4.Data;
using Challange4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Challange4.Repositorio
{
    public class DespesasRepositorio:ControllerBase,IDespesasRepositorio
    {
        private readonly FinancaContext _context;

        public DespesasRepositorio(FinancaContext Context)
        {
            _context = Context;

        }

        public async Task<List<Despesas>> GetAllAsync()
        {
            return (await _context.Despesas.ToListAsync());

        }

        public async Task<Despesas> GetPerIdAsync(int id)
        {
            return await _context.Despesas.FirstOrDefaultAsync(Despesas => Despesas.Id == id);
        }


        public async Task<IActionResult> PostAsync(Despesas despesas)
        {
            var Verificar = (await GetAllAsync()).Where(x =>
              CheckDescriptionSameMonth(

                  x.Descricao,
                  despesas.Descricao,
                  x.Data,
                  despesas.Data

            )).FirstOrDefault();

            if (Verificar != null)
            
                return BadRequest("Não é possível adicionar receitas iguais no mesmo mês.");
            


            await _context.Despesas.AddAsync(despesas);
            await _context.SaveChangesAsync();
            return Ok (despesas);
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

        public async Task<IActionResult> PutAsync([FromBody] Despesas despesa, int id)
        {
            Despesas despesas = await GetPerIdAsync(id);

            var Verificar = (await GetAllAsync()).Where(x =>
             CheckDescriptionSameMonth(

                 x.Descricao,
                 despesas.Descricao,
                 x.Data,
                 despesas.Data

           )).FirstOrDefault();

            if (despesas == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado ");
            }

            if (Verificar != null)

                return BadRequest("Não é possível adicionar despesas iguais no mesmo mês.");



           

            despesas.Descricao = despesa.Descricao;
            despesas.Valor = despesa.Valor;
            despesas.Data = despesa.Data;
            _context.Update(despesa);
            await _context.SaveChangesAsync();
            return Ok(despesa);

        }

        public async Task<Despesas> DeleteAsync(int id)
        {
            var despesa = await GetPerIdAsync(id);

            _context.Remove(despesa);
            await _context.SaveChangesAsync();
            return despesa;
        }
    }
}

