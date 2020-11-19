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
    public class VendaProdutoDAL
    {
        /*
        public SingleResponse<VendaProduto> InsertVenda(VendaProduto vendaProduto)
        {
            SingleResponse<VendaProduto> response = new SingleResponse<VendaProduto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO VENDAPRODUTOS (DATAVENDA, VALOR, FUNCIONARIOID) VALUES (@DATAVENDA, @VALOR, @FUNCIONARIOID)";
            command.Parameters.AddWithValue("@DATAVENDA", vendaProduto.DataVenda);
            command.Parameters.AddWithValue("@VALOR", vendaProduto.Valor);
            command.Parameters.AddWithValue("@FUNCIONARIOID", vendaProduto.FuncionarioID);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item(ns) vendido(s) com sucesso!";
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

        public Response InsertItem(ItensVenda itens)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO ITENSVENDA (VENDAID, PRODUTOID, VALOR, QUANTIDADE, CLIENTEID, FOIPAGO) VALUES (@VENDAID, @PRODUTOID, @VALOR, @QUANTIDADE, @CLIENTEID, @FOIPAGO)");
            conexao.CriaConexao();

            conexao.ComandoSql("@VENDAID", itens.VendaID);
            conexao.ComandoSql("@PRODUTOID", itens.ProdutoID);
            conexao.ComandoSql("@VALOR", itens.Valor);
            conexao.ComandoSql("@QUANTIDADE", itens.Quantidade);
            conexao.ComandoSql("@CLIENTEID", itens.ClienteID);
            conexao.ComandoSql("@FOIPAGO", false);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Item(ns) vendido(s) com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        public SingleResponse<VendaProduto> GetVendaID(int id)
        {
            SingleResponse<VendaProduto> response = new SingleResponse<VendaProduto>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT IDENT_CURRENT ('VENDAPRODUTOS') AS CURRENT_ID";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    VendaProduto vendaProduto = new VendaProduto();
                    vendaProduto.ID = Convert.ToInt32(reader["CURRENT_ID"]);
                    response.Data = vendaProduto;
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

        public SingleResponse<VendaProduto> GetVendaById(int id)
        {
            SingleResponse<VendaProduto> response = new SingleResponse<VendaProduto>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM VENDAPRODUTOS";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    VendaProduto vendaProduto = new VendaProduto();
                    vendaProduto.ID = Convert.ToInt32(reader["CURRENT_ID"]);
                    response.Data = vendaProduto;
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

        public Response PagarItem(int clienteID, int vendaID, int produtoID, double valor)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE ITENSVENDA SET FOIPAGO = 1 WHERE CLIENTEID = @CLIENTEID, VENDAID = @VENDAID, PRODUTOID = @PRODUTOID, VALOR = @VALOR";
            command.Parameters.AddWithValue("@CLIENTEID", clienteID);
            command.Parameters.AddWithValue("@VENDAID", vendaID);
            command.Parameters.AddWithValue("@PRODUTOID", produtoID);
            command.Parameters.AddWithValue("@VALOR", valor);

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
                response.Message = "Item pago!";
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
        */
        public SingleResponse<VendaProduto> InsertVenda(VendaProduto vendaProduto)
        {
            SingleResponse<VendaProduto> response = new SingleResponse<VendaProduto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO VENDAPRODUTOS (DATAVENDA, VALOR, FUNCIONARIOID) VALUES (@DATAVENDA, @VALOR, @FUNCIONARIOID)";
            command.Parameters.AddWithValue("@DATAVENDA", vendaProduto.DataVenda);
            command.Parameters.AddWithValue("@VALOR", vendaProduto.Valor);
            command.Parameters.AddWithValue("@FUNCIONARIOID", vendaProduto.FuncionarioID);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item(ns) vendido(s) com sucesso!";
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

        public Response InsertItem(ItensVenda itens)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO ITENSVENDA (VENDAID, PRODUTOID, VALOR, QUANTIDADE, CLIENTEID, FOIPAGO) VALUES (@VENDAID, @PRODUTOID, @VALOR, @QUANTIDADE, @CLIENTEID, @FOIPAGO)");
            conexao.CriaConexao();

            conexao.ParametroSql("@VENDAID", itens.VendaID);
            conexao.ParametroSql("@PRODUTOID", itens.ProdutoID);
            conexao.ParametroSql("@VALOR", itens.Valor);
            conexao.ParametroSql("@QUANTIDADE", itens.Quantidade);
            conexao.ParametroSql("@CLIENTEID", itens.ClienteID);
            conexao.ParametroSql("@FOIPAGO", false);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Item(ns) vendido(s) com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        public SingleResponse<VendaProduto> GetVendaID(int id)
        {
            SingleResponse<VendaProduto> response = new SingleResponse<VendaProduto>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT IDENT_CURRENT ('VENDAPRODUTOS') AS CURRENT_ID";

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    VendaProduto vendaProduto = new VendaProduto();
                    vendaProduto.ID = Convert.ToInt32(reader["CURRENT_ID"]);
                    response.Data = vendaProduto;
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

        public SingleResponse<VendaProduto> GetVendaById(int id)
        {
            SingleResponse<VendaProduto> response = new SingleResponse<VendaProduto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM VENDAPRODUTOS WHERE ID = @ID";
            command.Parameters.AddWithValue("@ID", id);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    VendaProduto vendaProduto = new VendaProduto();
                    vendaProduto.ID = Convert.ToInt32(reader["ID"]);
                    vendaProduto.DataVenda = Convert.ToDateTime(reader["DATAVENDA"]);
                    vendaProduto.Valor = Convert.ToInt32(reader["VALOR"]);
                    vendaProduto.FornecedorID = Convert.ToInt32(reader["FUNCIONARIOID"]);
                    vendaProduto.FuncionarioID = Convert.ToInt32(reader["FORNECEDORID"]);
                    response.Data = vendaProduto;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Venda não encontrada!";
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

        public Response PagarItem(int clienteID, int vendaID, int produtoID, double valor)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE ITENSVENDA SET FOIPAGO = 1 WHERE CLIENTEID = @CLIENTEID AND VENDAID = @VENDAID AND PRODUTOID = @PRODUTOID AND VALOR = @VALOR");
            conexao.CriaConexao();

            conexao.ParametroSql("@CLIENTEID", clienteID);
            conexao.ParametroSql("@VENDAID", vendaID);
            conexao.ParametroSql("@PRODUTOID", produtoID);
            conexao.ParametroSql("@VALOR", valor);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Item(ns) vendido(s) com sucesso!", "Erro no Banco de Dados, contate um ADM!");


        }
    }
}
