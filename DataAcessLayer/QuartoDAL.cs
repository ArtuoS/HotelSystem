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

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO QUARTOS (TIPOQUARTO, VALORNOITE, PESSOASMAXIMAS, OCUPADO) VALUES (@TIPOQUARTO, @VALORNOITE, @PESSOASMAXIMAS, @OCUPADO)");
            conexao.CriaConexao();

            conexao.ComandoSql("@TIPOQUARTO", quarto.TipoQuarto);
            conexao.ComandoSql("@VALORNOITE", quarto.ValorNoite);
            conexao.ComandoSql("@PESSOASMAXIMAS", quarto.PessoasMaximas);
            conexao.ComandoSql("@OCUPADO", quarto.Ocupado);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Quarto cadastrado com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        public Response Update(Quarto quarto)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE QUARTOS SET TIPOQUARTO = @TIPOQUARTO, VALORNOITE = @VALORNOITE, PESSOASMAXIMAS = @PESSOASMAXIMAS, OCUPADO = @OCUPADO WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ComandoSql("@ID", quarto.ID);
            conexao.ComandoSql("@TIPOQUARTO", quarto.TipoQuarto);
            conexao.ComandoSql("@VALORNOITE", quarto.ValorNoite);
            conexao.ComandoSql("@PESSOASMAXIMAS", quarto.PessoasMaximas);
            conexao.ComandoSql("@OCUPADO", quarto.Ocupado);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Quarto atualizado com sucesso!", "Quarto não encontrado!", "Erro no Banco de Dados, contate um ADM!");
        }

        public Response Delete(Quarto quarto)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"DELETE FROM QUARTOS WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ComandoSql("@ID", quarto.ID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Quarto deletado com sucesso!", "Quarto não encontrado!", "Erro no Banco de Dados, contate um ADM!");

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

        public SingleResponse<Quarto> GetById(int id)
        {
            SingleResponse<Quarto> response = new SingleResponse<Quarto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM QUARTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Quarto quarto = new Quarto();
                    quarto.ID = (int)reader["ID"];
                    quarto.TipoQuarto = (TipoQuartos)reader["TIPOQUARTO"];
                    quarto.ValorNoite = (double)reader["VALORNOITE"];
                    quarto.PessoasMaximas = (int)reader["PESSOASMAXIMAS"];
                    quarto.Ocupado = (bool)reader["OCUPADO"];
                    response.Data = quarto;
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
