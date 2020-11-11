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
    public class FornecedorDAL
    {
        public Response Insert(Fornecedor fornecedor)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO FORNECEDORES (RAZAOSOCIAL, NOME, CNPJ, TELEFONECELULAR, EMAIL, ATIVO) VALUES (@RAZAOSOCIAL, @NOME, @CNPJ, @TELEFONECELULAR, @EMAIL, @ATIVO)";
            command.Parameters.AddWithValue("@RAZAOSOCIAL", fornecedor.RazaoSocial);
            command.Parameters.AddWithValue("@NOME", fornecedor.Nome);
            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
            command.Parameters.AddWithValue("@TELEFONECELULAR", fornecedor.TelefoneCelular);
            command.Parameters.AddWithValue("@EMAIL", fornecedor.Email);
            command.Parameters.AddWithValue("@ATIVO", true);

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
                response.Message = "Fornecedor cadastrado com sucesso!";
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

        public Response Update(Fornecedor fornecedor)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE FORNECEDORES SET RAZAOSOCIAL = @RAZAOSOCIAL, NOME = @NOME, TELEFONECELULAR = @TELEFONECELULAR, EMAIL = @EMAIL WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", fornecedor.ID);
            command.Parameters.AddWithValue("@RAZAOSOCIAL", fornecedor.RazaoSocial);
            command.Parameters.AddWithValue("@NOME", fornecedor.Nome);
            command.Parameters.AddWithValue("@TELEFONECELULAR", fornecedor.TelefoneCelular);
            command.Parameters.AddWithValue("@EMAIL", fornecedor.Email);

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
                response.Message = "Fornecedor atualizado com sucesso!";
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

        public Response Delete(Fornecedor fornecedor)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM FORNECEDORES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", fornecedor.ID);

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
                response.Message = "Fornecedor excluído com sucesso!";
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
        public Response Disable(Fornecedor fornecedor)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE FORNECEDORES SET ATIVO = 0 WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", fornecedor.ID);

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
                response.Message = "Fornecedor desativado com sucesso!";
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
        public QueryResponse<Fornecedor> GetAll()
        {
            QueryResponse<Fornecedor> response = new QueryResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FORNECEDORES WHERE ATIVO = 1";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Fornecedor> fornecedores = new List<Fornecedor>();

                while (reader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.ID = (int)reader["ID"];
                    fornecedor.RazaoSocial = (string)reader["RAZAOSOCIAL"];
                    fornecedor.Nome = (string)reader["NOME"];
                    fornecedor.CNPJ = (string)reader["CNPJ"];
                    fornecedor.TelefoneCelular = (string)reader["TELEFONECELULAR"];
                    fornecedor.Email = (string)reader["EMAIL"];
                    fornecedor.Ativo = (bool)reader["ATIVO"];
                    fornecedores.Add(fornecedor);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = fornecedores;
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
        public SingleResponse<Fornecedor> GetByRazaoSocial(Fornecedor fornecedor)
        {
            SingleResponse<Fornecedor> response = new SingleResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FORNECEDORES WHERE RAZAOSOCIAL = @RAZAOSOCIAL";
            command.Parameters.AddWithValue("@RAZAOSOCIAL", fornecedor.RazaoSocial);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    fornecedor.ID = (int)reader["ID"];
                    fornecedor.CNPJ = (string)reader["CNPJ"];
                    response.Data = fornecedor;
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
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
        }
    }
}
