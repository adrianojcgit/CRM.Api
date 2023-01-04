using CMR.Api.Domain.Entities;
using CRM.Api.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.UI.Controllers
{
    [Route("CLiente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
		public ClienteController(ApplicationDbContext context)
        {
            _context = context;
		}

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _context.Clientes.AsNoTracking().ToList();
            if (clientes is null)
                return NotFound("Clientes não encontrados.");

            return clientes;
        }
        [HttpGet("{cnpj}")]
        public ActionResult<Cliente> GetByCnpj(string cnpj)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.CnpjParametro == cnpj);
            if (cliente is null)
                return NotFound("Cliente não encontrado.");

            return cliente;
        }

        [HttpGet("Nome/{NomeEmpresarial}")]
        public ActionResult<IEnumerable<Cliente>> GetByNomeEmpresarial(string NomeEmpresarial)
        {
            var cliente = _context.Clientes.Where(x => x.NomeEmpresarial.Contains(NomeEmpresarial)).ToList();
            if (cliente is null)
                return NotFound("Registro não encontrado.");

            return cliente;
        }



    }
}
