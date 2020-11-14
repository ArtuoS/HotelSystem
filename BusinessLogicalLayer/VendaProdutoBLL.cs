using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class VendaProdutoBLL : BaseValidator<VendaProduto>
    {
        VendaProdutoDAL vendaProdutoDAL = new VendaProdutoDAL();
        public Response InsertEntrada(VendaProduto venda)
        {
            Response response = Validate(venda);
            if (response.Success)
            {
                return vendaProdutoDAL.InsertEntrada(venda);
            }
            return response;
        }
        /*
        public SingleResponse<EntradaProduto> GetEntradaID(VendaProduto venda)
        {
            SingleResponse<EntradaProduto> response = vendaProdutoDAL.GetEntradaID(venda);
            return response;
        }
        */

        public SingleResponse<VendaProduto> GetEntradaID(VendaProduto venda)
        {
            SingleResponse<VendaProduto> response = vendaProdutoDAL.GetEntradaID(venda);
            return response;
        }


        public override Response Validate(VendaProduto venda)
        {
            AddError(venda.Itens.ListaEstaVazia());

            return base.Validate(venda);
        }
    }
}
