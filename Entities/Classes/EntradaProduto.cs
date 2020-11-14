using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class EntradaProduto
	{
		public int ID { get; set; }
		public double Valor { get; set; }
		public DateTime DataEntrada { get; set; }
		public int FornecedorID { get; set; }
		public int FuncionarioID { get; set; }
		public List<ItensEntrada> Itens { get; set; }
        public EntradaProduto()
        {
			this.Itens = new List<ItensEntrada>();
        }
	}
}
