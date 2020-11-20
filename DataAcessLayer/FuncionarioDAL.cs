using Common;
using Entities;
using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{

    public class FuncionarioDAL
    {
        //Insere um funcionário
        public Response Insert(Funcionario funcionario)
        {

            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO FUNCIONARIOS (NOME, CPF, RG, EMAIL, SENHA, CARGO, RUA, BAIRRO, NUMEROCASA, ATIVO, ISADM) VALUES (@NOME, @CPF, @RG, @EMAIL, @SENHA, @CARGO, @RUA, @BAIRRO, @NUMEROCASA, @ATIVO, @ISADM)");
            conexao.CriaConexao();

            conexao.ParametroSql("@NOME", funcionario.Nome);
            conexao.ParametroSql("@CPF", funcionario.CPF);
            conexao.ParametroSql("@RG", funcionario.RG);
            conexao.ParametroSql("@EMAIL", funcionario.Email);
            conexao.ParametroSql("@SENHA", funcionario.Senha);
            conexao.ParametroSql("@CARGO", funcionario.Cargo);
            conexao.ParametroSql("@RUA", funcionario.Rua);
            conexao.ParametroSql("@BAIRRO", funcionario.Bairro);
            conexao.ParametroSql("@NUMEROCASA", funcionario.NumeroCasa);
            conexao.ParametroSql("@ATIVO", true);
            conexao.ParametroSql("@ISADM", funcionario.IsADM);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Funcionário cadastrado com sucesso!", "Verifique o Email, RG ou CPF!");
        }

        //Atualiza um funcionário
        public Response Update(Funcionario funcionario)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"UPDATE FUNCIONARIOS SET NOME = @NOME, SENHA = @SENHA, CARGO = @CARGO, RUA = @RUA, BAIRRO = @BAIRRO, NUMEROCASA = @NUMEROCASA, ISADM = @ISADM, CPF = @CPF, RG = @RG, EMAIL = @EMAIL WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@NOME", funcionario.Nome);
            conexao.ParametroSql("@SENHA", funcionario.Senha);
            conexao.ParametroSql("@CPF", funcionario.CPF);
            conexao.ParametroSql("@RG", funcionario.RG);
            conexao.ParametroSql("@EMAIL", funcionario.Email);
            conexao.ParametroSql("@RUA", funcionario.Rua);
            conexao.ParametroSql("@CARGO", funcionario.Cargo);
            conexao.ParametroSql("@BAIRRO", funcionario.Bairro);
            conexao.ParametroSql("@NUMEROCASA", funcionario.NumeroCasa);
            conexao.ParametroSql("@ISADM", funcionario.IsADM);
            conexao.ParametroSql("@ID", funcionario.ID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Atualizado com sucesso!", "Registro não encontrado!", "Verifique o Email, RG ou CPF!");
        }

        //Deleta um funcionário
        public Response Delete(Funcionario funcionario)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"DELETE FROM FUNCIONARIOS WHERE ID = @ID");
            conexao.CriaConexao();

            conexao.ParametroSql("@ID", funcionario.ID);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponseUpdateDelete(response, "Deletado com sucesso!", "Registro não encontrado!", "Erro no Banco de Dados, contate um ADM!");
        }

        //Pega todos os funcionários
        public QueryResponse<Funcionario> GetAll()
        {
            QueryResponse<Funcionario> response = new QueryResponse<Funcionario>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM FUNCIONARIOS WHERE ATIVO = 1";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Funcionario> funcionarios = new List<Funcionario>();

                while (reader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.ID = (int)reader["ID"];
                    funcionario.Nome = (string)reader["NOME"];
                    funcionario.CPF = (string)reader["CPF"];
                    funcionario.RG = (string)reader["RG"];
                    funcionario.Email = (string)reader["EMAIL"];
                    funcionario.Senha = (string)reader["SENHA"];
                    funcionario.Cargo = (CargosFuncionarios)reader["CARGO"];
                    funcionario.Rua = (string)reader["RUA"];
                    funcionario.Bairro = (string)reader["BAIRRO"];
                    funcionario.NumeroCasa = (int)reader["NUMEROCASA"];
                    funcionario.Ativo = (bool)reader["ATIVO"];
                    funcionario.IsADM = (bool)reader["ISADM"];
                    funcionarios.Add(funcionario);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = funcionarios;
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

        //Faz o login
        public SingleResponse<Funcionario> GetByLogin(Funcionario funcionario)
        {
            SingleResponse<Funcionario> response = new SingleResponse<Funcionario>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID, NOME, CARGO,EMAIL, ISADM FROM FUNCIONARIOS WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
            command.Parameters.AddWithValue("@EMAIL", funcionario.Email);
            command.Parameters.AddWithValue("@SENHA", funcionario.Senha);

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    response.Message = "Logado!";
                    Funcionario funcionario1 = new Funcionario();
                    funcionario1.ID = Convert.ToInt32(reader["ID"]);
                    funcionario1.Nome = Convert.ToString(reader["NOME"]);
                    funcionario1.Cargo = (CargosFuncionarios)reader["CARGO"];
                    funcionario1.Email = Convert.ToString(reader["EMAIL"]);
                    funcionario1.IsADM = Convert.ToBoolean(reader["ISADM"]);
                    response.Data = funcionario1;
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
    }
}
