using ApiCrudDepartamentos2023.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudDepartamentos2023.Data
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options) { }
        public DbSet<Departamentos> Departamentos { get; set;}
    }
}
