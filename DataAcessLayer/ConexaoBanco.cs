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
    public class ConexaoBanco
    {
        public ConexaoBanco(string comando)
        {
            ComandoTexto = comando;
        }

        public string ComandoTexto { get; set; }
        public SqlCommand sqlComando;
        public SqlConnection conexao;

        VendaProduto venda = new VendaProduto();

        public void CriaConexao()
        {
            conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString.GetConnectionString();

            sqlComando = new SqlCommand();
            sqlComando.CommandText = ComandoTexto;
        }

        public SqlParameter ComandoSql(string parameter, object value)
        {
            return sqlComando.Parameters.AddWithValue(parameter, EntitiesExtensions.ConvertToType(value));
        }

        public SqlConnection IniciaConexao()
        {
            return sqlComando.Connection = conexao;
        }

        public Response ProcessaInformacoesResponse(Response response, string mensagemSucesso, string mensagemErro)
        {
            try
            {
                conexao.Open();
                sqlComando.ExecuteNonQuery();
                response.Success = true;
                response.Message = mensagemSucesso;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = mensagemErro;
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            return response;
        }

        public Response ProcessaInformacoesResponseUpdateDelete(Response response, string mensagemSucesso, string mensagemErro, string mensagemErroBd)
        {
            try
            {
                conexao.Open();
                int nLinhasAfetadas = sqlComando.ExecuteNonQuery();
                if (nLinhasAfetadas != 1)
                {
                    response.Success = false;
                    response.Message = mensagemErro;
                    return response;
                }
                response.Success = true;
                response.Message = mensagemSucesso;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = mensagemErroBd;
                response.StackTrace = ex.StackTrace;
                response.ExceptionError = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            return response;
        }
    }
}
