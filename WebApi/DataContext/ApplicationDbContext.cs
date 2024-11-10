using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataContext
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            
        }

        // o DbtSer entende que tem que criar uma trabela dentro de funcionarios e ela vai ter a estrutura que esta dentro de Funcionarios Model.
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
