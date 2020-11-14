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
    public class ClienteDAL
    {
        public Response Insert(Cliente cliente)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO CLIENTES (NOME, CPF, RG, TELEFONEFIXO, TELEFONECELULAR, EMAIL, ATIVO) VALUES (@NOME, @CPF, @RG, @TELEFONEFIXO, @TELEFONECELULAR, @EMAIL, @ATIVO)";
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@CPF", cliente.CPF);
            command.Parameters.AddWithValue("@RG", cliente.RG);
            command.Parameters.AddWithValue("@TELEFONEFIXO", cliente.TelefoneFixo);
            command.Parameters.AddWithValue("@TELEFONECELULAR", cliente.TelefoneCelular);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
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
                response.Message = "Cadastrado com sucesso!";
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

        public Response Update(Cliente cliente)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE CLIENTES SET NOME = @NOME, TELEFONEFIXO = @TELEFONEFIXO, TELEFONECELULAR = @TELEFONECELULAR, EMAIL = @EMAIL, ATIVO = @ATIVO WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", cliente.ID);
            command.Parameters.AddWithValue("@NOME", cliente.Nome);
            command.Parameters.AddWithValue("@TELEFONEFIXO", cliente.TelefoneFixo);
            command.Parameters.AddWithValue("@TELEFONECELULAR", cliente.TelefoneCelular);
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);
            command.Parameters.AddWithValue("@ATIVO", cliente.Ativo);

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
                response.Message = "Atualizado com sucesso!";
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

        public Response Delete(Cliente cliente)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM CLIENTES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", cliente.ID);

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
                response.Message = "Excluído com sucesso!";
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

        public Response DesativaCliente(Cliente cliente)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE CLIENTES SET ATIVO = @ATIVO WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", cliente.ID);
            command.Parameters.AddWithValue("@ATIVO", false);

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
                response.Message = "Cliente desativado com sucesso!";
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

        public QueryResponse<Cliente> GetAll()
        {
            QueryResponse<Cliente> response = new QueryResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE ATIVO = 1";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.ID = (int)reader["ID"];
                    cliente.Nome = (string)reader["NOME"];
                    cliente.CPF = (string)reader["CPF"];
                    cliente.RG = (string)reader["RG"];
                    cliente.TelefoneFixo = (string)reader["TELEFONEFIXO"];
                    cliente.TelefoneCelular = (string)reader["TELEFONECELULAR"];
                    cliente.Email = (string)reader["EMAIL"];
                    cliente.Ativo = (bool)reader["ATIVO"];
                    clientes.Add(cliente);
                }
                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = clientes;
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

        public SingleResponse<Cliente> GetById(Cliente cliente)
        {
            SingleResponse<Cliente> response = new SingleResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", cliente.ID);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cliente.ID = (int)reader["ID"];
                    cliente.Nome = (string)reader["NOME"];
                    cliente.CPF = (string)reader["CPF"];
                    cliente.RG = (string)reader["RG"];
                    cliente.TelefoneFixo = (string)reader["TELEFONEFIXO"];
                    cliente.TelefoneCelular = (string)reader["TELEFONECELULAR"];
                    cliente.Email = (string)reader["EMAIL"];
                    cliente.Ativo = (bool)reader["ATIVO"];
                    response.Data = cliente;
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

        public SingleResponse<Cliente> GetByNome(Cliente cliente)
        {
            SingleResponse<Cliente> response = new SingleResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE NOME = @NOME";
            command.Parameters.AddWithValue("@NOME", cliente.Nome);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    cliente.ID = (int)reader["ID"];
                    cliente.Nome = (string)reader["NOME"];
                    response.Data = cliente;
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

        public Response IsCPFUnique(Cliente cliente)
        {
            QueryResponse<Cliente> response = new QueryResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE CPF = @CPF";
            command.Parameters.AddWithValue("@CPF", cliente.CPF);

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

        public Response IsRGUnique(Cliente cliente)
        {
            QueryResponse<Cliente> response = new QueryResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE RG = @RG";
            command.Parameters.AddWithValue("@RG", cliente.RG);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "RG já cadastrado!";
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

        public Response IsEmailUnique(Cliente cliente)
        {
            QueryResponse<Cliente> response = new QueryResponse<Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CLIENTES WHERE EMAIL = @EMAIL";
            command.Parameters.AddWithValue("@EMAIL", cliente.Email);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = false;
                    response.Message = "Email já cadastrado!";
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
    }
}
