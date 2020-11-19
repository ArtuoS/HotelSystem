using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Itens_Consumidos
    {
        public int VendaID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public double ValorTotal { get; set; }
    }
}
