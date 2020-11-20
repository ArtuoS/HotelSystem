using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer
{
    public class LimpezaQuartoDAL
    {
        public Response Insert(LimpezaQuarto limpeza)
        {
            Response response = new Response();

            ConexaoBanco conexao = new ConexaoBanco(@"INSERT INTO LIMPEZAQUARTOS (QUARTOID, FUNCIONARIOID, DATALIMPEZA) VALUES (@QUARTOID, @FUNCIONARIOID, @DATALIMPEZA)");
            conexao.CriaConexao();

            conexao.ParametroSql("@FUNCIONARIOID", limpeza.FuncionarioID);
            conexao.ParametroSql("@QUARTOID", limpeza.QuartoID);
            conexao.ParametroSql("@DATALIMPEZA", limpeza.DataLimpeza);

            conexao.IniciaConexao();
            return conexao.ProcessaInformacoesResponse(response, "Limpeza realizada!", "Erro no Banco de Dados, contate um ADM!");
        }
    }
}
