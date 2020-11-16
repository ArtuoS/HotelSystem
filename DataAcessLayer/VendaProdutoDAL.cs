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
    public class VendaProdutoDAL
    {
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

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO ITENSVENDA (VENDAID, PRODUTOID, VALOR, QUANTIDADE, CLIENTEID) VALUES (@VENDAID, @PRODUTOID, @VALOR, @QUANTIDADE, @CLIENTEID)";
            command.Parameters.AddWithValue("@VENDAID", itens.VendaID);
            command.Parameters.AddWithValue("@PRODUTOID", itens.ProdutoID);
            command.Parameters.AddWithValue("@VALOR", itens.Valor);
            command.Parameters.AddWithValue("@QUANTIDADE", itens.Quantidade);
            command.Parameters.AddWithValue("@CLIENTEID", itens.ClienteID);

            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                response.Success = true;
                response.Message = "Item vendido com sucesso!";
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

        public SingleResponse<VendaProduto> GetVendaID(VendaProduto vendaProduto)
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

        public Response AtualizaEstoque(int quantidade, int produtoID)
        {
            Response response = new Response();

            // responsável por realizar conexão física com o banco
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConnectionString.GetConnectionString();

            // responsável por executar uma query no banco
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE PRODUTOS SET QTDESTOQUE = QTDESTOQUE - @QUANTIDADE WHERE ID = @PRODUTOID";
            command.Parameters.AddWithValue("@QUANTIDADE", quantidade);
            command.Parameters.AddWithValue("@PRODUTOID", produtoID);

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
                response.Message = "Estoque atualizado com sucesso!";
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


        //SELECT p.NOME, iv.VALOR, iv.QUANTIDADE, (iv.QUANTIDADE * iv.VALOR) AS VALORTOTAL FROM ITENSVENDA iv INNER JOIN PRODUTOS AS p ON iv.PRODUTOID = p.ID WHERE iv.CLIENTEID = @CLIENTEID
    }
}
