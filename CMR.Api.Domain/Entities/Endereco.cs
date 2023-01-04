﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMR.Api.Domain.Entities
{
	public class Endereco
	{
		public Endereco()
		{
			Cliente = new Cliente();
		}
		public int Id { get; set; }
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string CEP { get; set; }
		public int ClienteId { get; set; }
		public virtual Cliente Cliente { get; set; }
	}
}
