using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IAppServiceCliente _appServiceCliente;
        public ClienteController(IAppServiceCliente appServiceCliente)
        {
            this._appServiceCliente = appServiceCliente;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _appServiceCliente.GetAll();
            return Ok(clientes);
        }
    }
}