﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Cliente
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string RG { get; set; }
		public string TelefoneFixo { get; set; }
		public string TelefoneCelular { get; set; }
		public string Email { get; set; }
		public bool Ativo { get; set; }
	}
}
