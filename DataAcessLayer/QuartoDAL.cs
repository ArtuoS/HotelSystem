using Common;
using Entities;
using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class QuartoDAL
    {
        public Response Insert(Quarto quarto)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO QUARTOS (TIPOQUARTO, VALORNOITE, PESSOASMAXIMAS, OCUPADO) VALUES (@TIPOQUARTO, @VALORNOITE, @PESSOASMAXIMAS, @OCUPADO)";
            command.Parameters.AddWithValue("@TIPOQUARTO", quarto.TipoQuarto);
            command.Parameters.AddWithValue("@VALORNOITE", quarto.ValorNoite);
            command.Parameters.AddWithValue("@PESSOASMAXIMAS", quarto.PessoasMaximas);
            command.Parameters.AddWithValue("@OCUPADO", quarto.Ocupado);

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
                response.Message = "Quarto cadastrado com sucesso!";
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
        public Response Update(Quarto quarto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE QUARTOS SET TIPOQUARTO = @TIPOQUARTO, VALORNOITE = @VALORNOITE, PESSOASMAXIMAS = @PESSOASMAXIMAS, OCUPADO = @OCUPADO WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", quarto.ID);
            command.Parameters.AddWithValue("@TIPOQUARTO", quarto.TipoQuarto);
            command.Parameters.AddWithValue("@VALORNOITE", quarto.ValorNoite);
            command.Parameters.AddWithValue("@PESSOASMAXIMAS", quarto.PessoasMaximas);
            command.Parameters.AddWithValue("@OCUPADO", quarto.Ocupado);

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
                    response.Message = "Quarto não encontrado!";
                    return response;
                }
                response.Success = true;
                response.Message = "Quarto atualizado com sucesso!";
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
        public Response Delete(Quarto quarto)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM QUARTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", quarto.ID);

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
                response.Message = "Quarto excluído com sucesso!";
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
        public QueryResponse<Quarto> GetAll()
        {
            QueryResponse<Quarto> response = new QueryResponse<Quarto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM QUARTOS";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Quarto> quartos = new List<Quarto>();

                while (reader.Read())
                {
                    Quarto quarto = new Quarto();
                    quarto.ID = (int)reader["ID"];
                    quarto.TipoQuarto = (TipoQuartos)reader["TIPOQUARTO"];
                    quarto.ValorNoite = (double)reader["VALORNOITE"];
                    quarto.PessoasMaximas = (int)reader["PESSOASMAXIMAS"];
                    quarto.Ocupado = (bool)reader["OCUPADO"];
                    quartos.Add(quarto);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = quartos;
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
        public QueryResponse<Quarto> GetNotOccupied()
        {
            QueryResponse<Quarto> response = new QueryResponse<Quarto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM QUARTOS WHERE OCUPADO = 0";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Quarto> quartos = new List<Quarto>();

                while (reader.Read())
                {
                    Quarto quarto = new Quarto();
                    quarto.ID = (int)reader["ID"];
                    quarto.TipoQuarto = (TipoQuartos)reader["TIPOQUARTO"];
                    quarto.ValorNoite = (double)reader["VALORNOITE"];
                    quarto.PessoasMaximas = (int)reader["PESSOASMAXIMAS"];
                    quarto.Ocupado = (bool)reader["OCUPADO"];
                    quartos.Add(quarto);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = quartos;
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
