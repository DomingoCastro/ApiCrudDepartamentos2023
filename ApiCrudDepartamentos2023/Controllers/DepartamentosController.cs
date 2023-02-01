using ApiCrudDepartamentos2023.Model;
using ApiCrudDepartamentos2023.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudDepartamentos2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Departamentos>> GetDepartamentos()
        {
            return this.repo.GetDepartamentos();
        }
        [HttpGet("{id}")]
        public ActionResult<Departamentos> FindDepartamento(int id)
        {
            return this.repo.FindDepartamento(id);
        }
        [HttpGet]
        [Route("[action]")]
        public ActionResult <List<string>> GetLocalidades()
        {
            return this.repo.GetLocalidades();
        }
        [HttpGet]
        [Route("[action]/{localidad}")]
        public ActionResult <List<Departamentos>> GetDepartamentosLocalidad (string localidad)
        {
            return this.repo.FindDepartamentosLoc(localidad);
        }
        // METODO INSERT POR URL
        [HttpPost]
        [Route("[action]/{id}/{nombre}/{localidad}")]
        public async Task InsertarDepartamento(int id, string nombre, string localidad)
        {
            await this.repo.InsertDepartamentoAsync(id, nombre, localidad);
        }
        //EL SEGUNDO METODO RECIBIRA EL DEPT POR BODY
        //ESTE METODO ES EL QUE TIENE POR DEFECTO CUALQUIER CONTROLLER
        //PARA POST, POR LO QUE NO HAY QUE UTILIZAR ROUTE
        [HttpPost]
        public async Task InsertarDepartamento(Departamentos departamento)
        {
           await this.repo.InsertDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
        }

        //EL METODO PUT POR DEFECTO TAMBIEN RECIBE UN OBJETO
        [HttpPut]
        public async Task UpdateDepartamento(Departamentos departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
        }
        //EL METODO DELETE POR DEFECTO RECIBE UN ID
        [HttpDelete("{id}")]
        public async Task DeleteDepartamento(int id)
        {
            await this.repo.DeleteDepartamentoAsync(id);
        }
    }
}
