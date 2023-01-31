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
        public List<Departamentos> FindDepartamentosLoc (string localidad)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.Localidad == localidad
                           select datos;
            return consulta.ToList();
        }
    }
}
