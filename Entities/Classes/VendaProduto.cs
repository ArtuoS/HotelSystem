using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class VendaProduto
	{
		public int ID { get; set; }
		public int ProdutoID { get; set; }
		public int ReservaID { get; set; }
		public DateTime DataCompra { get; set; }
		public int QtdCompra { get; set; }
	}
}
