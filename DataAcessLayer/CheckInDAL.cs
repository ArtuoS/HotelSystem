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
    public class CheckInDAL
    {
        // Insere um check-in
        public Response Insert(CheckIn checkIn)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command1 = new SqlCommand();

            command1.CommandText = "INSERT INTO CHECKIN (QUARTOID, CLIENTEID, DATAENTRADA, DATASAIDAPREVISTA) VALUES (@QUARTOID, @CLIENTEID, @DATAENTRADA, @DATASAIDAPREVISTA);";
            command1.Parameters.AddWithValue("@QUARTOID", checkIn.QuartoID);
            command1.Parameters.AddWithValue("@CLIENTEID", checkIn.ClienteID);
            command1.Parameters.AddWithValue("@DATAENTRADA", checkIn.DataEntrada);
            command1.Parameters.AddWithValue("@DATASAIDAPREVISTA", checkIn.DataSaidaPrevista);

            command1.Connection = connection;
            SqlTransaction transaction = null;
            try
            {
                connection.Open();

                transaction = connection.BeginTransaction();

                command1.Transaction = transaction;
                int QuartoCheckInID = checkIn.QuartoID;
                command1.ExecuteScalar();

                SqlCommand command2 = new SqlCommand();
                command2.Transaction = transaction;

                command2.CommandText = "UPDATE QUARTOS SET OCUPADO = @OCUPADO WHERE ID = @ID";
                command2.Parameters.AddWithValue("@ID", QuartoCheckInID);
                command2.Parameters.AddWithValue("@OCUPADO", true);

                command2.Connection = connection;

                command2.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Check-in realizado com sucesso!";
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

        // Atualiza um check-in
        public Response Update(Cliente cliente)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE CHECKIN SET NOME = @NOME, TELEFONEFIXO = @TELEFONEFIXO, TELEFONECELULAR = @TELEFONECELULAR, EMAIL = @EMAIL, ATIVO = @ATIVO WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@ID", cliente.ID);
            conexao.ParametroSql("@NOME", cliente.Nome);
            conexao.ParametroSql("@TELEFONEFIXO", cliente.TelefoneFixo);
            conexao.ParametroSql("@TELEFONECELULAR", cliente.TelefoneCelular);
            conexao.ParametroSql("@EMAIL", cliente.Email);
            conexao.ParametroSql("@ATIVO", cliente.Ativo);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Check-in atualizado com sucesso!", "Registro não encontrado!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Deleta um check-in
        public Response Delete(CheckIn checkIn)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command1 = new SqlCommand();
            command1.CommandText = "DELETE FROM CHECKIN WHERE ID = @ID";
            command1.Parameters.AddWithValue("@ID", checkIn.ID);

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
                command2.Parameters.AddWithValue("@ID", checkIn.QuartoID);
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

        // Pega todos os check-ins
        public QueryResponse<CheckIn> GetAll()
        {
            QueryResponse<CheckIn> response = new QueryResponse<CheckIn>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CHECKIN";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<CheckIn> checkIns = new List<CheckIn>();

                while (reader.Read())
                {
                    CheckIn checkIn = new CheckIn();
                    checkIn.ID = (int)reader["ID"];
                    checkIn.QuartoID = (int)reader["QUARTOID"];
                    checkIn.ClienteID = (int)reader["CLIENTEID"];
                    checkIn.DataEntrada = (DateTime)reader["DATAENTRADA"];
                    checkIn.DataSaidaPrevista = (DateTime)reader["DATASAIDAPREVISTA"];
                    checkIns.Add(checkIn);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = checkIns;
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

        // Pega um check-in pelo ID
        public SingleResponse<CheckIn> GetById(int id)
        {
            SingleResponse<CheckIn> response = new SingleResponse<CheckIn>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM CHECKIN WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CheckIn checkIn = new CheckIn();
                    checkIn.ID = (int)reader["ID"];
                    checkIn.QuartoID = (int)reader["QUARTOID"];
                    checkIn.ClienteID = (int)reader["CLIENTEID"];
                    checkIn.DataEntrada = (DateTime)reader["DATAENTRADA"];
                    checkIn.DataSaidaPrevista = (DateTime)reader["DATASAIDAPREVISTA"];
                    response.Data = checkIn;
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
