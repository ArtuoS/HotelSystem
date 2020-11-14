using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ItensEntrada
    {
        public int EntradaID { get; set; }
        public int ProdutoID { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
