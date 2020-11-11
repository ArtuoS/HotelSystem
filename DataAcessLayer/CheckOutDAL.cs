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
    public class CheckOutDAL
    {
        public Response Insert(CheckOut checkOut)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command1 = new SqlCommand();

            command1.CommandText = "INSERT INTO CHECKOUT (QUARTOID, CLIENTEID, DATASAIDA, VALOR) VALUES (@QUARTOID, @CLIENTEID, @DATASAIDA, @VALOR);";
            command1.Parameters.AddWithValue("@QUARTOID", checkOut.QuartoID);
            command1.Parameters.AddWithValue("@CLIENTEID", checkOut.ClienteID);
            command1.Parameters.AddWithValue("@DATASAIDA", checkOut.DataSaida);
            command1.Parameters.AddWithValue("@VALOR", checkOut.Valor);

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

                command2.CommandText = "UPDATE QUARTOS SET OCUPADO = @OCUPADO WHERE ID = @ID";
                command2.Parameters.AddWithValue("@ID", checkOut.QuartoID);
                command2.Parameters.AddWithValue("@OCUPADO", false);

                command2.Connection = connection;

                transaction.Rollback();

                transaction = connection.BeginTransaction();
                command2.Transaction = transaction;
                command2.ExecuteScalar();

                SqlCommand command3 = new SqlCommand();
                command3.Transaction = transaction;

                command3.CommandText = "DELETE FROM CHECKIN WHERE ID = @ID";
                command3.Parameters.AddWithValue("@ID", checkOut.ID);

                command3.Connection = connection;

                command3.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Check-out realizado com sucesso!";
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
        /*
        public Response Update(CheckOut checkOut)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE CLIENTES SET NOME = @NOME, TELEFONEFIXO = @TELEFONEFIXO, TELEFONECELULAR = @TELEFONECELULAR, EMAIL = @EMAIL, ATIVO = @ATIVO WHERE ID = @ID";

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
        public Response Delete(CheckOut checkOut)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command1 = new SqlCommand();
            command1.CommandText = "DELETE FROM checkOut WHERE ID = @ID";
            command1.Parameters.AddWithValue("@ID", checkOut.ID);

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

                command2.CommandText = "UPDATE QUARTOS SET OCUPADO = @OCUPADO WHERE ID = @ID";
                command2.Parameters.AddWithValue("@ID", checkOut.QuartoID);
                command2.Parameters.AddWithValue("@OCUPADO", false);

                command2.Connection = connection;

                int nLinhasAfetadas = command2.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = "Registro não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Excluído com sucesso!";
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
        */
        public QueryResponse<CheckOut> GetAll()
        {
            QueryResponse<CheckOut> response = new QueryResponse<CheckOut>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CHECKOUT";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<CheckOut> checkOuts = new List<CheckOut>();

                while (reader.Read())
                {
                    CheckOut checkOut = new CheckOut();
                    checkOut.ID = (int)reader["ID"];
                    checkOut.QuartoID = (int)reader["QUARTOID"];
                    checkOut.ClienteID = (int)reader["CLIENTEID"];
                    checkOut.DataSaida = (DateTime)reader["DATASAIDA"];
                    checkOut.Valor = (double)reader["VALOR"];
                    checkOuts.Add(checkOut);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = checkOuts;
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
