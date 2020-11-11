using Common;
using Entities;
using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class FuncionarioDAL
    {
        public Response Insert(Funcionario funcionario)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO FUNCIONARIOS (NOME, CPF, RG, EMAIL, SENHA, CARGO, RUA, BAIRRO, NUMEROCASA, ATIVO, ISADM) VALUES (@NOME, @CPF, @RG, @EMAIL, @SENHA, @CARGO, @RUA, @BAIRRO, @NUMEROCASA, @ATIVO, @ISADM)";
            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);
            command.Parameters.AddWithValue("@RG", funcionario.RG);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);
            command.Parameters.AddWithValue("@CARGO", funcionario.Cargo);
            command.Parameters.AddWithValue("@RUA", funcionario.Rua);
            command.Parameters.AddWithValue("@BAIRRO", funcionario.Bairro);
            command.Parameters.AddWithValue("@NUMEROCASA", funcionario.NumeroCasa);
            command.Parameters.AddWithValue("@ATIVO", true);
            command.Parameters.AddWithValue("@ISADM", funcionario.IsADM);

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

        public Response Update(Funcionario funcionario)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE FUNCIONARIOS SET NOME = @NOME, EMAIL = @EMAIL, SENHA = @SENHA, RUA = @RUA, BAIRRO = @BAIRRO, NUMEROCASA = @NUMEROCASA, ISADM = @ISADM WHERE ID = @ID";
            command.Parameters.AddWithValue("@NOME", funcionario.Nome);
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);
            command.Parameters.AddWithValue("@RUA", funcionario.Rua);
            command.Parameters.AddWithValue("@BAIRRO", funcionario.Bairro);
            command.Parameters.AddWithValue("@NUMEROCASA", funcionario.NumeroCasa);
            command.Parameters.AddWithValue("@ISADM", funcionario.IsADM);
            command.Parameters.AddWithValue("@ID", funcionario.ID);

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

        public Response Delete(Funcionario funcionario)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM FUNCIONARIOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", funcionario.ID);

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

        public QueryResponse<Funcionario> GetAll()
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE ATIVO = 1";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Funcionario> funcionarios = new List<Funcionario>();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.ID = (int)reader["ID"];
                    funcionario.Nome = (string)reader["NOME"];
                    funcionario.CPF = (string)reader["CPF"];
                    funcionario.RG = (string)reader["RG"];
                    funcionario.Email = (string)reader["EMAIL"];
                    funcionario.Senha = (string)reader["SENHA"];
                    funcionario.Cargo = (CargosFuncionarios)reader["CARGO"];
                    funcionario.Rua = (string)reader["RUA"];
                    funcionario.Bairro = (string)reader["BAIRRO"];
                    funcionario.NumeroCasa = (int)reader["NUMEROCASA"];
                    funcionario.Ativo = (bool)reader["ATIVO"];
                    funcionario.IsADM = (bool)reader["ISADM"];
                    funcionarios.Add(funcionario);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = funcionarios;
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

        public SingleResponse<Funcionario> GetByLogin(Funcionario funcionario)
        {
            SingleResponse<Funcionario> response = new SingleResponse<Funcionario>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID, NOME, EMAIL, ISADM FROM FUNCIONARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    response.Message = "Logado!";
                    Funcionario funcionario1 = new Funcionario();
                    funcionario1.ID = Convert.ToInt32(reader["ID"]);
                    funcionario1.Nome = Convert.ToString(reader["NOME"]);
                    funcionario1.Email = Convert.ToString(reader["EMAIL"]);
                    funcionario1.IsADM = Convert.ToBoolean(reader["ISADM"]);
                    response.Data = funcionario1;
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

        public Response IsCPFUnique(Funcionario funcionario)
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE CPF = @CPF";
            command.Parameters.AddWithValue("@CPF", funcionario.CPF);

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

        public Response IsRGUnique(Funcionario funcionario)
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE RG = @RG";
            command.Parameters.AddWithValue("@RG", funcionario.RG);

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

        public Response IsEmailUnique(Funcionario funcionario)
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE EMAIL = @EMAIL";
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);

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
