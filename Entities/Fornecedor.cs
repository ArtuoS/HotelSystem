﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Fornecedor
	{
		public int ID { get; set; }
		public string RazaoSocial { get; set; }
		public string Nome { get; set; }
		public string CNPJ { get; set; }
		public string TelefoneCelular { get; set; }
		public string Email { get; set; }
		public bool Ativo { get; set; }
	}
}