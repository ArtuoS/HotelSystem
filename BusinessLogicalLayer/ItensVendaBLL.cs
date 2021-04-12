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
    public class ItensVendaBLL : BaseValidator<ItensVenda>
    {
        VendaProdutoDAL vendaProdutoDAL = new VendaProdutoDAL();

        // Insere um item na venda
        public Response InsertItem(ItensVenda item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return vendaProdutoDAL.InsertItem(item);
            }
            return response;
        }

        // Recebe e valida um item
        public override Response Validate(ItensVenda item)
        {
            AddError(item.ProdutoID.VerificaEstoque(item.Quantidade));

            return base.Validate(item);
        }
    }
}
