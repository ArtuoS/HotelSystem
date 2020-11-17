using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Quarto
	{
		public int ID { get; set; }
		public TipoQuartos TipoQuarto { get; set; }
		public double ValorNoite { get; set; }
		public int PessoasMaximas { get; set; }
		public bool Ocupado { get; set; }
	}
}
