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
        [Route("[action]")]
        public ActionResult <List<Departamentos>> GetDepartamentosLocalidad (string localidad)
        {
            return this.repo.FindDepartamentosLoc(localidad);
        }
    }
}
