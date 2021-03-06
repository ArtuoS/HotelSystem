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
    public class EntradaProdutoDAL
    {
        // Insere uma entrada
        public SingleResponse<EntradaProduto> InsertEntrada(EntradaProduto entradaProduto)
        {
            SingleResponse<EntradaProduto> response = new SingleResponse<EntradaProduto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO ENTRADAPRODUTOS (DATAENTRADA, VALOR, FUNCIONARIOID, FORNECEDORID) VALUES (@DATAENTRADA, @VALOR, @FUNCIONARIOID, @FORNECEDORID)";
            command.Parameters.AddWithValue("@DATAENTRADA", entradaProduto.DataEntrada);
            command.Parameters.AddWithValue("@VALOR", entradaProduto.Valor);
            command.Parameters.AddWithValue("@FUNCIONARIOID", entradaProduto.FuncionarioID);
            command.Parameters.AddWithValue("@FORNECEDORID", entradaProduto.FornecedorID);

            command.Connection = connection;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item(ns) cadastrado(s) com sucesso!";
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

        // Insere um item
        public Response InsertItem(ItensEntrada itens)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO ITENSENTRADA (ENTRADAID, PRODUTOID, VALOR, QUANTIDADE) VALUES (@ENTRADAID, @PRODUTOID, @VALOR, @QUANTIDADE)");
            conexao.CriaConexao();

            conexao.ParametroSql("@ENTRADAID", itens.EntradaID);
            conexao.ParametroSql("@PRODUTOID", itens.ProdutoID);
            conexao.ParametroSql("@VALOR", itens.Valor);
            conexao.ParametroSql("@QUANTIDADE", itens.Quantidade);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Item inserido com sucesso!", "Erro no Banco de Dados, contate um ADM!");
        }

        // Pega informações do produto
        public QueryResponse<Itens_Produto> GetProdutoInfo()
        {
            QueryResponse<Itens_Produto> response = new QueryResponse<Itens_Produto>();

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT p.NOME, ie.VALOR, ie.QUANTIDADE FROM ITENSENTRADA ie INNER JOIN PRODUTOS p ON ie.PRODUTOID = p.ID WHERE ie.ENTRADAID = @ie.ENTRADAID";

            command.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Itens_Produto> itens = new List<Itens_Produto>();

                while (reader.Read())
                {
                    Itens_Produto item = new Itens_Produto();
                    item.Produto = (string)reader["NOME"];
                    item.Valor = (double)reader["VALOR"];
                    item.Quantidade = (int)reader["QUANTIDADE"];
                    itens.Add(item);
                }

                response.Success = true;
                response.Message = "Dados selecionados com sucesso!";
                response.Data = itens;
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

        // Pega o ID da entrada
        public SingleResponse<EntradaProduto> GetEntradaID(EntradaProduto entradaProduto)
        {
            SingleResponse<EntradaProduto> response = new SingleResponse<EntradaProduto>();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT IDENT_CURRENT ('ENTRADAPRODUTOS') AS CURRENT_ID"; //ID FROM ENTRADAPRODUTOS WHERE VALOR = @VALOR AND DATAENTRADA = @DATAENTRADA AND FUNCIONARIOID = @FUNCIONARIOID AND FORNECEDORID = @FORNECEDORID

            command.Connection = connection;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    response.Success = true;
                    entradaProduto.ID = Convert.ToInt32(reader["CURRENT_ID"]);
                    response.Data = entradaProduto;
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
