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
    public class FornecedorDAL
    {
        // Insere um fornecedor
        public Response Insert(Fornecedor fornecedor)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO FORNECEDORES (RAZAOSOCIAL, NOME, CNPJ, TELEFONECELULAR, EMAIL, ATIVO) VALUES (@RAZAOSOCIAL, @NOME, @CNPJ, @TELEFONECELULAR, @EMAIL, @ATIVO)");
            conexao.CriaConexao();

            conexao.ParametroSql("@RAZAOSOCIAL", fornecedor.RazaoSocial);
            conexao.ParametroSql("@NOME", fornecedor.Nome);
            conexao.ParametroSql("@CNPJ", fornecedor.CNPJ);
            conexao.ParametroSql("@TELEFONECELULAR", fornecedor.TelefoneCelular);
            conexao.ParametroSql("@EMAIL", fornecedor.Email);
            conexao.ParametroSql("@ATIVO", true);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Fornecedor cadastrado com sucesso!", "Verifique o Email, RG ou CPF!");
        }

        // Atualiza um fornecedor
        public Response Update(Fornecedor fornecedor)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE FORNECEDORES SET RAZAOSOCIAL = @RAZAOSOCIAL, NOME = @NOME, TELEFONECELULAR = @TELEFONECELULAR, EMAIL = @EMAIL, CNPJ = @CNPJ WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@ID", fornecedor.ID);
            conexao.ParametroSql("@RAZAOSOCIAL", fornecedor.RazaoSocial);
            conexao.ParametroSql("@NOME", fornecedor.Nome);
            conexao.ParametroSql("@CNPJ", fornecedor.CNPJ);
            conexao.ParametroSql("@EMAIL", fornecedor.Email);
            conexao.ParametroSql("@TELEFONECELULAR", fornecedor.TelefoneCelular);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Fornecedor atualizado com sucesso!", "Registro não encontrado!", "Verifique o Email, RG ou CPF!");
        }

        // Deleta um fornecedor
        public Response Delete(Fornecedor fornecedor)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"DELETE FROM FORNECEDORES WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@ID", fornecedor.ID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Fornecedor excluído com sucesso!", "Registro não encontrado!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Pega todos os fornecedores
        public QueryResponse<Fornecedor> GetAll()
        {
            QueryResponse<Fornecedor> response = new QueryResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FORNECEDORES WHERE ATIVO = 1";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Fornecedor> fornecedores = new List<Fornecedor>();

                while (reader.Read())
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.ID = (int)reader["ID"];
                    fornecedor.RazaoSocial = (string)reader["RAZAOSOCIAL"];
                    fornecedor.Nome = (string)reader["NOME"];
                    fornecedor.CNPJ = (string)reader["CNPJ"];
                    fornecedor.TelefoneCelular = (string)reader["TELEFONECELULAR"];
                    fornecedor.Email = (string)reader["EMAIL"];
                    fornecedor.Ativo = (bool)reader["ATIVO"];
                    fornecedores.Add(fornecedor);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = fornecedores;
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

        // Pega o fornecedor pela razão social
        public SingleResponse<Fornecedor> GetByRazaoSocial(Fornecedor fornecedor)
        {
            SingleResponse<Fornecedor> response = new SingleResponse<Fornecedor>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FORNECEDORES WHERE RAZAOSOCIAL = @RAZAOSOCIAL";
            command.Parameters.AddWithValue("@RAZAOSOCIAL", fornecedor.RazaoSocial);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    fornecedor.ID = (int)reader["ID"];
                    fornecedor.CNPJ = (string)reader["CNPJ"];
                    response.Data = fornecedor;
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
