﻿using BusinessLogicalLayer.Extensions;
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

        // Insere um produto 
        public Response Insert(Produto produto)
        {
            Response response = Validate(produto);
            if (response.Success)
            {
                return produtoDAL.Insert(produto);
            }
            return response;
        }

        // Atualiza um produto
        public Response Update(Produto produto)
        {
            Response response = Validate(produto);
            if (response.Success)
            {
                return produtoDAL.Update(produto);
            }
            return response;
        }

        // Deleta um produto
        public Response Delete(Produto produto)
        {
            return produtoDAL.Delete(produto);
        }

        // Pega todos os produtos
        public QueryResponse<Produto> GetAll()
        {
            QueryResponse<Produto> response = produtoDAL.GetAll();
            return response;
        }

        // Pega todos os produtos com estoque
        public QueryResponse<Produto> GetAllComEstoque()
        {
            QueryResponse<Produto> response = produtoDAL.GetAllComEstoque();
            return response;
        }

        // Pega um produto pelo nome
        public SingleResponse<Produto> GetByNome(Produto produto)
        {
            SingleResponse<Produto> response = produtoDAL.GetByNome(produto);
            return response;
        }

        // Pega um produto pelo ID
        public SingleResponse<Produto> GetById(int id)
        {
            SingleResponse<Produto> response = produtoDAL.GetById(id);
            return response;
        }

        // Recebe e valida um produto
        public override Response Validate(Produto produto)
        {
            AddError(produto.Nome.ValidaNomeProduto());

            AddError(produto.Descricao.ValidaDescricaoProduto());

            return base.Validate(produto);
        }
    }
}
