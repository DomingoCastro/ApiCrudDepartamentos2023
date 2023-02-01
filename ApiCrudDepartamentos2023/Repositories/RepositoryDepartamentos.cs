using ApiCrudDepartamentos2023.Data;
using ApiCrudDepartamentos2023.Model;

namespace ApiCrudDepartamentos2023.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }
        public List<Departamentos> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }
        public Departamentos FindDepartamento(int id)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == id
                           select datos;
            return consulta.FirstOrDefault();
        }
        public List<string> GetLocalidades()
        {
            var consulta = (from datos in this.context.Departamentos
                            select datos.Localidad).Distinct();
            return consulta.ToList();
        }
        public List<Departamentos> FindDepartamentosLoc(string localidad)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.Localidad == localidad
                           select datos;
            return consulta.ToList();
        }
        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamentos departamento = new Departamentos();
            departamento.IdDepartamento = id;
            departamento.Nombre= nombre;
            departamento.Localidad = localidad;
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateDepartamentoAsync (int id, string nombre, string localidad)
        {
            Departamentos departamentos = this.FindDepartamento(id);
            departamentos.Nombre= nombre;
            departamentos.Localidad= localidad;
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamentos departamento = this.FindDepartamento(id);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }
    }
}
