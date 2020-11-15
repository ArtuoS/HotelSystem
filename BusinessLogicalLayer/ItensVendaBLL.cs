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
        public Response InsertItem(ItensVenda item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return vendaProdutoDAL.InsertItem(item);
            }
            return response;
        }

        /*
        public QueryResponse<Itens_Produto> GetProdutoInfo()
        {
            QueryResponse<Itens_Produto> response = entradaProdutoDAL.GetProdutoInfo();
            return response;
        }
        */

        public override Response Validate(ItensVenda item)
        {
            //AddError(StringExtensions.CalculaValorProdutos(item.Valor, item.Quantidade));

            AddError(item.ProdutoID.VerificaEstoque());

            return base.Validate(item);
        }
    }
}
