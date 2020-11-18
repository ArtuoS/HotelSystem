using BusinessLogicalLayer.Extensions;
using Common;
using DataAcessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
                entrada.DataEntrada = DateTime.Now;
                entrada.Valor = entrada.Itens.Sum(w => w.Valor * w.Quantidade);
                using (TransactionScope scope = new TransactionScope())
                {
                    SingleResponse<EntradaProduto> responseEntrada = entradaProdutoDAL.InsertEntrada(entrada);
                    if (responseEntrada.Success)
                    {
                        foreach (ItensEntrada item in entrada.Itens)
                        {
                            ItensEntradaBLL itensEntradaBLL = new ItensEntradaBLL();
                            SingleResponse<EntradaProduto> responseEntradaID = entradaProdutoDAL.GetEntradaID(entrada);
                            item.EntradaID = responseEntradaID.Data.ID;
                            itensEntradaBLL.InsertItem(item);
                            entradaProdutoDAL.AtualizaPreco(item.ProdutoID, item.Valor, item.Quantidade);
                            entradaProdutoDAL.AtualizaEstoque(item.ProdutoID, item.Quantidade);
                        }
                    }
                    scope.Complete();
                }
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

            //verifica valor unitario

            return base.Validate(entrada);
        }
    }
}
