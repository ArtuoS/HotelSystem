using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class ProdutoDAL
    {
        // Insere um produto
        public Response Insert(Produto produto)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO PRODUTOS (NOME, DESCRICAO, VALORUNITARIO, QTDESTOQUE) VALUES (@NOME, @DESCRICAO, @VALORUNITARIO, @QTDESTOQUE)");
            conexao.CriaConexao();

            conexao.ParametroSql("@ID", produto.ID);
            conexao.ParametroSql("@NOME", produto.Nome);
            conexao.ParametroSql("@DESCRICAO", produto.Descricao);
            conexao.ParametroSql("@VALORUNITARIO", produto.ValorUnitario);
            conexao.ParametroSql("@QTDESTOQUE", 0);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Produto cadastrado com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Atualiza um produto
        public Response Update(Produto produto)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE PRODUTOS SET NOME = @NOME, DESCRICAO = @DESCRICAO WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@NOME", produto.Nome);
            conexao.ParametroSql("@DESCRICAO", produto.Descricao);
            conexao.ParametroSql("@ID", produto.ID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Produto atualizado com sucesso!", "Registro não encontrado!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Deleta um produto
        public Response Delete(Produto produto)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"DELETE FROM PRODUTOS WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@ID", produto.ID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Produto excluído com sucesso!", "Registro não encontrado!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Pega todos os produtos
        public QueryResponse<Produto> GetAll()
        {
            QueryResponse<Produto> response = new QueryResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Produto> produtos = new List<Produto>();

                while (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.ID = (int)reader["ID"];
                    produto.Nome = (string)reader["NOME"];
                    produto.Descricao = (string)reader["DESCRICAO"];
                    produto.ValorUnitario = (double)reader["VALORUNITARIO"];
                    produto.QtdEstoque = (int)reader["QTDESTOQUE"];
                    produtos.Add(produto);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = produtos;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
                return response;
            }
            finally
            {
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
        }

        // Pega todos os produtos com estoque
        public QueryResponse<Produto> GetAllComEstoque()
        {
            QueryResponse<Produto> response = new QueryResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE QTDESTOQUE != 0";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Produto> produtos = new List<Produto>();

                while (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.ID = (int)reader["ID"];
                    produto.Nome = (string)reader["NOME"];
                    produto.Descricao = (string)reader["DESCRICAO"];
                    produto.ValorUnitario = (double)reader["VALORUNITARIO"];
                    produto.QtdEstoque = (int)reader["QTDESTOQUE"];
                    produtos.Add(produto);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = produtos;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
                return response;
            }
            finally
            {
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
        }

        // Pega um produto pelo nome
        public SingleResponse<Produto> GetByNome(Produto produto)
        {
            SingleResponse<Produto> response = new SingleResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE NOME = @NOME";
            command.Parameters.AddWithValue("@NOME", produto.Nome);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    produto.ID = (int)reader["ID"];
                    produto.Nome = (string)reader["NOME"];
                    produto.Descricao = (string)reader["DESCRICAO"];
                    produto.ValorUnitario = (double)reader["VALORUNITARIO"];
                    produto.QtdEstoque = (int)reader["QTDESTOQUE"];
                    response.Data = produto;
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
                return response;
            }
            finally
            {
                connection.Close();
            }
        }

        // Pega um produto pelo ID
        public SingleResponse<Produto> GetById(int id)
        {
            SingleResponse<Produto> response = new SingleResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Produto produto = new Produto();
                    produto.ID = (int)reader["ID"];
                    produto.Nome = (string)reader["NOME"];
                    produto.Descricao = (string)reader["DESCRICAO"];
                    produto.ValorUnitario = (double)reader["VALORUNITARIO"];
                    produto.QtdEstoque = (int)reader["QTDESTOQUE"];
                    response.Data = produto;
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
                return response;
            }
            finally
            {
                connection.Close();
            }
        }

        // Atualiza o estoque do produto na entrada
        public Response AtualizaEstoqueEntrada(int produtoID, int quantidade)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE + @QUANTIDADE WHERE ID = @PRODUTOID");
            conexao.CriaConexao();

            conexao.ParametroSql("@QUANTIDADE", quantidade);
            conexao.ParametroSql("@PRODUTOID", produtoID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Estoque atualizado com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Atualiza o preço do produto
        public Response AtualizaPreco(int produtoID, double valor, int quantidade)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE PRODUTOS SET VALORUNITARIO = ((VALORUNITARIO * QTDESTOQUE) + (@VALOR * @QUANTIDADE)) / (QTDESTOQUE + @QUANTIDADE) WHERE ID = @PRODUTOID");
            conexao.CriaConexao();

            conexao.ParametroSql("@PRODUTOID", produtoID);
            conexao.ParametroSql("@QUANTIDADE", quantidade);
            conexao.ParametroSql("@VALOR", valor);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Preço atualizado com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Atualiza o estoque do produto na venda
        public Response AtualizaEstoqueVenda(int produtoID, int quantidade)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE - @QUANTIDADE WHERE ID = @PRODUTOID");
            conexao.CriaConexao();

            conexao.ParametroSql("@PRODUTOID", produtoID);
            conexao.ParametroSql("@QUANTIDADE", quantidade);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Estoque atualizado com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }
    }
}
