﻿using Common;
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
        // Criei esta classe para a prática do clean code. Toda vez que uma class DAL era criada
        // precisava-mos fazer todos os comandos dos métodos abaixo manualmente
        // a digitação ficava cansativa e com esta classe alguns passos ficam muito mais fáceis.
        public ConexaoBanco(string comando)
        {
            ComandoTexto = comando;
        }

        public string ComandoTexto { get; set; }
        public SqlCommand sqlComando;
        public SqlConnection conexao;

        VendaProduto venda = new VendaProduto();

        // Cria conexao com o banco
        public void CriaConexao()
        {
            conexao = new SqlConnection();
            conexao.ConnectionString = ConnectionString.GetConnectionString();

            sqlComando = new SqlCommand();
            sqlComando.CommandText = ComandoTexto;
        }

        // Parâmetros para passar ao banco
        public SqlParameter ParametroSql(string parameter, object value)
        {
            return sqlComando.Parameters.AddWithValue(parameter, EntitiesExtensions.ConvertToType(value));
        }

        // Inicia conexão com o banco
        public SqlConnection IniciaConexao()
        {
            return sqlComando.Connection = conexao;
        }

        // Processa e verifica informações: Insert
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

        // Processa e verifica informações: Delete, Update
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
