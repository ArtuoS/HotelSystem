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
    public class EntradaProdutoBLL : BaseValidator<EntradaProduto>
    {
        EntradaProdutoDAL entradaProdutoDAL = new EntradaProdutoDAL();
        public Response InsertEntrada(EntradaProduto entrada)
        {
            Response response = Validate(entrada);
            if (response.Success)
            {
                return entradaProdutoDAL.InsertEntrada(entrada);
            }
            return response;
        }
        public SingleResponse<EntradaProduto> GetEntradaID(EntradaProduto entrada)
        {
            SingleResponse<EntradaProduto> response = entradaProdutoDAL.GetEntradaID(entrada);
            return response;
        }

        public override Response Validate(EntradaProduto entrada)
        {
            AddError(entrada.Itens.ListaEstaVazia());

            return base.Validate(entrada);
        }
    }
}
