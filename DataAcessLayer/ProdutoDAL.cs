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
        /*
        public Response Insert(Produto produto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO PRODUTOS (NOME, DESCRICAO, VALORUNITARIO, QTDESTOQUE) VALUES (@NOME, @DESCRICAO, @VALORUNITARIO, @QTDESTOQUE)";
            command.Parameters.AddWithValue("@ID", produto.ID);
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@VALORUNITARIO", produto.ValorUnitario);
            command.Parameters.AddWithValue("@QTDESTOQUE", 0);
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
                response.Message = "Produto cadastrado com sucesso!";
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

        public Response Update(Produto produto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, VALORUNITARIO = @VALORUNITARIO WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@VALORUNITARIO", produto.ValorUnitario);
            command.Parameters.AddWithValue("@ID", produto.ID);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Produto atualizado com sucesso!";
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

        public Response Delete(Produto produto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", produto.ID);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Produto excluído com sucesso!";
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

        public SingleResponse<Produto> GetByNome(Produto produto)
        {
            SingleResponse<Produto> response = new SingleResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE NOME = @NOME";
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            //command.Parameters.AddWithValue("@ID", produto.ID);
            //command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            //command.Parameters.AddWithValue("@QTDESTOQUE", produto.QtdEstoque);
            //command.Parameters.AddWithValue("@VALORUNITARIO", produto.ValorUnitario);


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

        public Response IsProdutoAvaible(Produto produto)
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@CPF", produto.ID);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "CPF já cadastrado!";
                }
                else
                {
                    response.Success = true;
                    response.Message = "";
                }

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

        public Response AtualizaEstoqueEntrada(int produtoID, int quantidade)
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

        public Response AtualizaEstoqueVenda(int produtoID, int quantidade)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE - @QUANTIDADE WHERE ID = @PRODUTOID";
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
        */

        public Response Insert(Produto produto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO PRODUTOS (NOME, DESCRICAO, VALORUNITARIO, QTDESTOQUE) VALUES (@NOME, @DESCRICAO, @VALORUNITARIO, @QTDESTOQUE)";
            command.Parameters.AddWithValue("@ID", produto.ID);
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@VALORUNITARIO", produto.ValorUnitario);
            command.Parameters.AddWithValue("@QTDESTOQUE", 0);
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
                response.Message = "Produto cadastrado com sucesso!";
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

        public Response Update(Produto produto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET NOME = @NOME, DESCRICAO = @DESCRICAO, VALORUNITARIO = @VALORUNITARIO WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            command.Parameters.AddWithValue("@VALORUNITARIO", produto.ValorUnitario);
            command.Parameters.AddWithValue("@ID", produto.ID);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Produto atualizado com sucesso!";
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

        public Response Delete(Produto produto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", produto.ID);

            // SqlCommando -> O QUE
            // SqlConnection -> ONDE
            command.Connection = connection;

            // Realiza, de fato, a conexão física com o banco.
            // Lança erros caso a base na exista ou esteja ocupada.
            try
            {
                connection.Open();
                int nLinhasAfetadas = command.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Produto excluído com sucesso!";
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

        public SingleResponse<Produto> GetByNome(Produto produto)
        {
            SingleResponse<Produto> response = new SingleResponse<Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE NOME = @NOME";
            command.Parameters.AddWithValue("@NOME", produto.Nome);
            //command.Parameters.AddWithValue("@ID", produto.ID);
            //command.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
            //command.Parameters.AddWithValue("@QTDESTOQUE", produto.QtdEstoque);
            //command.Parameters.AddWithValue("@VALORUNITARIO", produto.ValorUnitario);


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

        public Response IsProdutoAvaible(Produto produto)
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM PRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@CPF", produto.ID);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "CPF já cadastrado!";
                }
                else
                {
                    response.Success = true;
                    response.Message = "";
                }

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

        public Response AtualizaEstoqueEntrada(int produtoID, int quantidade)
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

        public Response AtualizaEstoqueVenda(int produtoID, int quantidade)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE - @QUANTIDADE WHERE ID = @PRODUTOID";
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
    }
}
