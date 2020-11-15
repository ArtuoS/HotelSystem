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
    public class EntradaProdutoDAL
    {
        //Insert item
        //Insert entrada
        //scope_identity

        public SingleResponse<EntradaProduto> InsertEntrada(EntradaProduto entradaProduto)
        {
            SingleResponse<EntradaProduto> response = new SingleResponse<EntradaProduto>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO ENTRADAPRODUTOS (DATAENTRADA, VALOR, FUNCIONARIOID, FORNECEDORID) VALUES (@DATAENTRADA, @VALOR, @FUNCIONARIOID, @FORNECEDORID)";
            command.Parameters.AddWithValue("@DATAENTRADA", entradaProduto.DataEntrada);
            command.Parameters.AddWithValue("@VALOR", entradaProduto.Valor);
            command.Parameters.AddWithValue("@FUNCIONARIOID", entradaProduto.FuncionarioID);
            command.Parameters.AddWithValue("@FORNECEDORID", entradaProduto.FornecedorID);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item(ns) cadastrado(s) com sucesso!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
            return response;
        }

        /*
        public Response InsertItem(ItensEntrada itens)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO ITENSENTRADA (ENTRADAID, PRODUTOID, VALOR, QUANTIDADE) VALUES (@ENTRADAID, @PRODUTOID, @VALOR, @QUANTIDADE)";
            command.Parameters.AddWithValue("@ENTRADAID", itens.EntradaID);
            command.Parameters.AddWithValue("@PRODUTOID", itens.ProdutoID);
            command.Parameters.AddWithValue("@VALOR", itens.Valor);
            command.Parameters.AddWithValue("@QUANTIDADE", itens.Quantidade);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
            return response;
        }
        */

        public Response InsertItem(ItensEntrada itens)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command1 = new SqlCommand();
            command1.CommandText = "UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE + @QUANTIDADE WHERE ID = @PRODUTOID";
            command1.Parameters.AddWithValue("@QUANTIDADE", itens.Quantidade);
            command1.Parameters.AddWithValue("@PRODUTOID", itens.ProdutoID);

            command1.Connection = connection;
            SqlTransaction transaction = null;

            try
            {
                connection.Open();

                transaction = connection.BeginTransaction();

                command1.Transaction = transaction;
                command1.ExecuteScalar();

                SqlCommand command2 = new SqlCommand();
                command2.Transaction = transaction;

                command2.CommandText = "INSERT INTO ITENSENTRADA (ENTRADAID, PRODUTOID, VALOR, QUANTIDADE) VALUES (@ENTRADAID, @PRODUTOID, @VALOR, @QUANTIDADE)";
                command2.Parameters.AddWithValue("@ENTRADAID", itens.EntradaID);
                command2.Parameters.AddWithValue("@PRODUTOID", itens.ProdutoID);
                command2.Parameters.AddWithValue("@VALOR", itens.Valor);
                command2.Parameters.AddWithValue("@QUANTIDADE", itens.Quantidade);

                command2.Connection = connection;

                command2.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item cadastrado com sucesso!";
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }

        public QueryResponse<Itens_Produto> GetProdutoInfo()
        {
            QueryResponse<Itens_Produto> response = new QueryResponse<Itens_Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT p.NOME, ie.VALOR, ie.QUANTIDADE FROM ITENSENTRADA ie INNER JOIN PRODUTOS p ON ie.PRODUTOID = p.ID WHERE ie.ENTRADAID = @ie.ENTRADAID";
            //command.Parameters.AddWithValue("@ie.ENTRADAID", );

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Itens_Produto> itens = new List<Itens_Produto>();

                while (reader.Read())
                {
                    Itens_Produto item = new Itens_Produto();
                    item.Produto = (string)reader["NOME"];
                    item.Valor = (double)reader["VALOR"];
                    item.Quantidade = (int)reader["QUANTIDADE"];
                    itens.Add(item);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = itens;
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

        public SingleResponse<EntradaProduto> GetEntradaID(EntradaProduto entradaProduto)
        {
            SingleResponse<EntradaProduto> response = new SingleResponse<EntradaProduto>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT IDENT_CURRENT ('ENTRADAPRODUTOS') AS CURRENT_ID"; //ID FROM ENTRADAPRODUTOS WHERE VALOR = @VALOR AND DATAENTRADA = @DATAENTRADA AND FUNCIONARIOID = @FUNCIONARIOID AND FORNECEDORID = @FORNECEDORID

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    entradaProduto.ID = Convert.ToInt32(reader["CURRENT_ID"]);
                    response.Data = entradaProduto;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Funcionário(a) não encontrado(a)!";
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return response;
        }

        public Response AtualizaEstoque(int produtoID, int quantidade)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE + @QUANTIDADE WHERE ID = @PRODUTOID";
            command.Parameters.AddWithValue("@QUANTIDADE", quantidade);
            command.Parameters.AddWithValue("@PRODUTOID", produtoID);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Estoque atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
            return response;
        }

        public Response AtualizaPreco(int produtoID, double valor, int quantidade)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET VALORUNITARIO = ((VALORUNITARIO * QTDESTOQUE) + (@VALOR * @QUANTIDADE)) / (QTDESTOQUE + @QUANTIDADE) WHERE ID = @PRODUTOID";
            command.Parameters.AddWithValue("@PRODUTOID", produtoID);
            command.Parameters.AddWithValue("@QUANTIDADE", quantidade);
            command.Parameters.AddWithValue("@VALOR", valor);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Estoque atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Erro no Banco de Dados, contate um ADM!";
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
            return response;
        }
    }
}
