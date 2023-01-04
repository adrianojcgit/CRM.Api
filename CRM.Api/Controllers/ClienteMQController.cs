using CRM.Api.Application.DTO;
using CRM.Api.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace CRM.Api.UI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ClienteMQController : ControllerBase
	{
		private readonly IClienteRabbitService _ctx;

		public ClienteMQController(IClienteRabbitService ctx)
		{
			_ctx = ctx;
		}

		//[HttpGet("{cnpj}")]
		//public async Task<ActionResult<ClienteDTO>> GetByCnpj(string cnpj)
		//{
		//	var cliente = await _ctx.GetByCnpj(cnpj);
		//	return cliente;
		//}

		[HttpGet("Porte/{porte}")]
		public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetByPorte(string porte)
		{
			IEnumerable<ClienteDTO> cliente = await _ctx.GetByPorte(porte);
			//
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "Clientes por Porte",
									 durable: false,
									 exclusive: false,
									 autoDelete: false,
									 arguments: null);

				string json = JsonSerializer.Serialize(cliente);
				var body = Encoding.UTF8.GetBytes(json);

				channel.BasicPublish(exchange: "",
									 routingKey: "Clientes por Porte",
									 basicProperties: null,
									 body: body);

			}
			//
			return cliente.ToList();
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAll()
		{
			IEnumerable<ClienteDTO> cliente = await _ctx.GetAll();
			//
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "Todos Clientes",
									 durable: false,
									 exclusive: false,
									 autoDelete: false,
									 arguments: null);

				string json = JsonSerializer.Serialize(cliente);
				var body = Encoding.UTF8.GetBytes(json);

				channel.BasicPublish(exchange: "",
									 routingKey: "Todos Clientes",
									 basicProperties: null,
									 body: body);

			}
			//
			return cliente.ToList();
		}

		[HttpGet("{cnpj}")]
		public async Task<ActionResult<ClienteDTO>> GetMQByCnpj(string cnpj)
		{
			var cliente = await _ctx.GetByCnpj(cnpj);
			//
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "Clientes por CNPJ",
									 durable: false,
									 exclusive: false,
									 autoDelete: false,
									 arguments: null);

				string json = JsonSerializer.Serialize(cliente);
				var body = Encoding.UTF8.GetBytes(json);

				channel.BasicPublish(exchange: "",
									 routingKey: "Clientes por CNPJ",
									 basicProperties: null,
									 body: body);
				
			}
			//
			return cliente;
		}
	}
}
