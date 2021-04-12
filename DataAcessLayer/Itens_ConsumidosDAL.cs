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
    public class Itens_ConsumidosDAL
    {
        // Pega os itens consumidos pelo cliente
        public QueryResponse<Itens_Consumidos> GetItensConsumidosByCliente(int clienteID)
        {
            QueryResponse<Itens_Consumidos> response = new QueryResponse<Itens_Consumidos>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT iv.VENDAID, iv.PRODUTOID, p.NOME, iv.VALOR, iv.QUANTIDADE, (iv.QUANTIDADE * iv.VALOR) AS VALORTOTAL FROM ITENSVENDA iv INNER JOIN PRODUTOS AS p ON iv.PRODUTOID = p.ID WHERE iv.CLIENTEID = @CLIENTEID AND iv.FOIPAGO = 0";
            command.Parameters.AddWithValue("@CLIENTEID", clienteID);

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Itens_Consumidos> itensConsumidos = new List<Itens_Consumidos>();

                while (reader.Read())
                {
                    Itens_Consumidos item = new Itens_Consumidos();
                    item.VendaID = (int)reader["VENDAID"];
                    item.ProdutoID = (int)reader["PRODUTOID"];
                    item.Nome = (string)reader["NOME"];
                    item.Quantidade = (int)reader["QUANTIDADE"];
                    item.Valor = (double)reader["VALOR"];
                    item.ValorTotal = (double)reader["VALORTOTAL"];
                    itensConsumidos.Add(item);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = itensConsumidos;
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
    }
}
