using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Funcionario
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string RG { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public CargosFuncionarios Cargo { get; set; }
		public string Rua { get; set; }
		public string Bairro { get; set; }
		public int NumeroCasa { get; set; }
		public bool Ativo { get; set; }
		public bool IsADM { get; set; }
	}
}
