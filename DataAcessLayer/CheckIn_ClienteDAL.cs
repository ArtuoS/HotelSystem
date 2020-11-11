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
    public class CheckIn_ClienteDAL
    {
        public QueryResponse<CheckIn_Cliente> GetData()
        {
            QueryResponse<CheckIn_Cliente> response = new QueryResponse<CheckIn_Cliente>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT c.ID, c.QUARTOID, c.CLIENTEID, cl.NOME, c.DATAENTRADA, c.DATASAIDAPREVISTA FROM CHECKIN c INNER JOIN CLIENTES cl ON c.CLIENTEID = cl.ID";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<CheckIn_Cliente> checkIns = new List<CheckIn_Cliente>();

                while (reader.Read())
                {
                    CheckIn_Cliente checkInCliente = new CheckIn_Cliente();
                    checkInCliente.ID = (int)reader["ID"];
                    checkInCliente.QuartoID = (int)reader["QUARTOID"];
                    checkInCliente.ClienteID = (int)reader["CLIENTEID"];
                    checkInCliente.ClienteNome = (string)reader["NOME"];
                    checkInCliente.DataEntrada = (DateTime)reader["DATAENTRADA"];
                    checkInCliente.DataSaidaPrevista = (DateTime)reader["DATASAIDAPREVISTA"];
                    checkIns.Add(checkInCliente);
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
                // finally sempre é executado, independente de exceções ou returns!
                connection.Close();
            }

        }
    }
}
