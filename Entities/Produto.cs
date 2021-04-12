using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Produto
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public double ValorUnitario { get; set; }
		public int QtdEstoque { get; set; }
	}
}
