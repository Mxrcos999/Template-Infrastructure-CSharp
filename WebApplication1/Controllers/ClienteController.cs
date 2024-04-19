using Domain;
using Microsoft.AspNetCore.Mvc;
using Modelo_para_camada_de_dados__Infrascture_.Repositories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IRepoCliente _repo;
        public ClienteController(IRepoCliente repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<ActionResult> PostAsync(Cliente cliente)
        {
            if(await _repo.PostAsync(cliente, default))
                return Ok(cliente);

            return BadRequest();
        }
    }
}
