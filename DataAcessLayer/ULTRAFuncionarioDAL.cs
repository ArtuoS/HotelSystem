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
    /*
    public class ULTRAFuncionarioDAL
    {
        
        public Response Insert(Funcionario funcionario, Endereco endereco)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command1 = new SqlCommand();

            command1.CommandText = "INSERT INTO ENDERECOS (RUA, BAIRRO, NUMEROCASA) VALUES (@RUA, @BAIRRO, @NUMEROCASA); SELECT SCOPE_IDENTITY();";
            command1.Parameters.AddWithValue("@RUA", endereco.Rua);
            command1.Parameters.AddWithValue("@BAIRRO", endereco.Bairro);
            command1.Parameters.AddWithValue("@NUMEROCASA", endereco.NumeroCasa);

            command1.Connection = connection;
            SqlTransaction transaction = null;
            try
            {
                connection.Open();

                transaction = connection.BeginTransaction();

                command1.Transaction = transaction;
                int idGeradoEndereco = Convert.ToInt32(command1.ExecuteScalar());

                SqlCommand command2 = new SqlCommand();
                command2.Transaction = transaction;

                command2.CommandText = "INSERT INTO FUNCIONARIOS (NOME, CPF, RG, EMAIL, SENHA, ATIVO, ENDERECOID, ISADM) VALUES (@NOME, @CPF, @RG, @EMAIL, @SENHA, @ATIVO, @ENDERECOID, @ISADM)";
                command2.Parameters.AddWithValue("@NOME", funcionario.Nome);
                command2.Parameters.AddWithValue("@CPF", funcionario.CPF);
                command2.Parameters.AddWithValue("@RG", funcionario.RG);
                command2.Parameters.AddWithValue("@EMAIL", funcionario.Email);
                command2.Parameters.AddWithValue("@SENHA", funcionario.Senha);
                command2.Parameters.AddWithValue("@ATIVO", true);
                command2.Parameters.AddWithValue("@ENDERECOID", idGeradoEndereco);
                command2.Parameters.AddWithValue("@ISADM", true);

                command2.Connection = connection;

                command2.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Cadastrado com sucesso!";
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
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }
            return response;
        }
        
        public Response Update(Funcionario funcionario, Endereco endereco)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command1 = new SqlCommand();

            command1.CommandText = "UPDATE CLIENTES SET RUA = @RUA, BAIRRO = @BAIRRO, NUMEROCASA = @NUMEROCASA WHERE ID = @ID; SELECT SCOPE_IDENTITY();";
            command1.Parameters.AddWithValue("@RUA", endereco.Rua);
            command1.Parameters.AddWithValue("@BAIRRO", endereco.Bairro);
            command1.Parameters.AddWithValue("@NUMEROCASA", endereco.NumeroCasa);
            command1.Parameters.AddWithValue("@ID", endereco.ID);

            command1.Connection = connection;
            SqlTransaction transaction = null;

            try 
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE CLIENTES SET NOME = @NOME, ATIVO = @ATIVO WHERE ID = @ID";
                command.Parameters.AddWithValue("@NOME", funcionario.Nome);
                command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
                command.Parameters.AddWithValue("@SENHA", funcionario.Senha);
                command.Parameters.AddWithValue("@ATIVO", funcionario.Ativo);
                command.Parameters.AddWithValue("@ID", funcionario.ID);

                command.Connection = connection;

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
                transaction.Commit();
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
    }
 */
}
