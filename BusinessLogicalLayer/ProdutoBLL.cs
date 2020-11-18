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
    public class ProdutoBLL : BaseValidator<Produto>
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();
        public Response Insert(Produto produto)
        {
            Response response = Validate(produto);
            if (response.Success)
            {
                return produtoDAL.Insert(produto);
            }
            return response;
        }
        public Response Update(Produto produto)
        {
            Response response = Validate(produto);
            if (response.Success)
            {
                return produtoDAL.Update(produto);
            }
            return response;
        }
        public Response Delete(Produto produto)
        {
            return produtoDAL.Delete(produto);
        }

        public QueryResponse<Produto> GetAll()
        {
            QueryResponse<Produto> response = produtoDAL.GetAll();
            return response;
        }

        public QueryResponse<Produto> GetAllComEstoque()
        {
            QueryResponse<Produto> response = produtoDAL.GetAllComEstoque();
            //ACEITAR SOMENTE .2 DPS DA VIRGULA
            return response;
        }

        public SingleResponse<Produto> GetByNome(Produto produto)
        {
            SingleResponse<Produto> response = produtoDAL.GetByNome(produto);
            return response;
        }


        public SingleResponse<Produto> GetById(int id)
        {
            SingleResponse<Produto> response = produtoDAL.GetById(id);
            return response;
        }


        public override Response Validate(Produto produto)
        {
            AddError(produto.Nome.ValidaNomeProduto());

            AddError(produto.Descricao.ValidaDescricaoProduto());

            return base.Validate(produto);
        }
    }
}
