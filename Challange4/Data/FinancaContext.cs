using Challange4.Models;
using Microsoft.EntityFrameworkCore;


namespace Challange4.Data
{
    public class FinancaContext : DbContext
    {
        public FinancaContext(DbContextOptions<FinancaContext> options) : base(options)
        {

        }
        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Despesas> Despesas { get; set; }
    }

   
}
