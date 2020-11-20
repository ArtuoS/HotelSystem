using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAcessLayer
{
    public class CheckOutDAL
    {
        // Insere um check-out
        public Response Insert(CheckOut checkOut)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Response response = new Response();
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConnectionString.GetConnectionString();

                SqlCommand command1 = new SqlCommand();

                command1.CommandText = "INSERT INTO CHECKOUT (QUARTOID, CLIENTEID, DATASAIDA, VALOR, CHECKINID) VALUES (@QUARTOID, @CLIENTEID, @DATASAIDA, @VALOR, @CHECKINID);";
                command1.Parameters.AddWithValue("@QUARTOID", checkOut.QuartoID);
                command1.Parameters.AddWithValue("@CLIENTEID", checkOut.ClienteID);
                command1.Parameters.AddWithValue("@DATASAIDA", checkOut.DataSaida);
                command1.Parameters.AddWithValue("@VALOR", checkOut.Valor);
                command1.Parameters.AddWithValue("@CHECKINID", checkOut.CheckInID);

                command1.Connection = connection;
                try
                {
                    connection.Open();

                    command1.ExecuteScalar();

                    SqlCommand command2 = new SqlCommand();

                    command2.CommandText = "UPDATE QUARTOS SET OCUPADO = @OCUPADO WHERE ID = @ID";
                    command2.Parameters.AddWithValue("@ID", checkOut.QuartoID);
                    command2.Parameters.AddWithValue("@OCUPADO", false);

                    command2.Connection = connection;

                    command2.ExecuteScalar();

                    SqlCommand command3 = new SqlCommand();

                    //DELETE FROM CHECKIN WHERE PRIMARYKEY = @CHECKINID
                    command3.CommandText = "DELETE FROM CHECKIN WHERE ID = @CHECKINID";
                    command3.Parameters.AddWithValue("@CHECKINID", checkOut.CheckInID);

                    command3.Connection = connection;

                    command3.ExecuteNonQuery();
                    response.Success = true;
                    response.Message = "Check-out realizado com sucesso!";
                    scope.Complete();
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
        }

        // Pega todos os check-outs
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
