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
    public class ItensEntradaBLL : BaseValidator<ItensEntrada>
    {
        EntradaProdutoDAL entradaProdutoDAL = new EntradaProdutoDAL();
        public Response InsertItem(ItensEntrada item)
        {
            Response response = Validate(item);
            if (response.Success)
            {
                return entradaProdutoDAL.InsertItem(item);
            }
            return response;
        }

        public QueryResponse<Itens_Produto> GetProdutoInfo()
        {
            QueryResponse<Itens_Produto> response = entradaProdutoDAL.GetProdutoInfo();
            return response;
        }

        public override Response Validate(ItensEntrada item)
        {
            AddError(item.Quantidade.VerificaQuantidadeItens());

            return base.Validate(item);
        }
    }
}
