using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Extensions
{
    static class StringExtensions
    {
        public static string ValidadorEmail(this string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (rg.IsMatch(email))
            {
                return "";
            }
            return "Email Inválido!";
        }

        public static string ValidadorCPF(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return "CPF inválido!";
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return "";
        }

        public static string ValidadorCNPJ(this string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return "CNPJ inválido!";
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return "";
        }

        public static string ValidaNome(this string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return "O nome deve ser informado!";
            }
            else if (nome.Length < 3 || nome.Length > 100)
            {
                return "O nome deve ter entre 3 e 100 caractéres!";
            }
            return "";
        }

        public static string ValidaDescricaoProduto(this string descricao)
        {
            if (string.IsNullOrEmpty(descricao))
            {
                return "A descrição deve ser informada!";
            }
            else if (descricao.Length < 3 || descricao.Length > 120)
            {
                return "A descrição deve ter entre 3 e 120 caractéres!";
            }
            return "";
        }

        public static string ValidaPessoasMaximas(this int pessoas)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(pessoas)))
            {
                return "Insira o número de pessoas máximas!";
            }
            else if (pessoas > 8)
            {
                return "Nossos quartos não tem capacidade para mais de oito pessoas!";
            }
            return "";
        }

        public static string ValidaValorQuarto(double valor, TipoQuartos quarto)
        {
            if (valor > 0)
            {
                if (quarto == TipoQuartos.Econômico && valor < 80)
                {
                    return "O valor do quarto econômico deve ser de no mínimo R$80,00";
                }
                else if (quarto == TipoQuartos.Executivo && valor < 180)
                {
                    return "O valor do quarto executivo deve ser de no mínimo R$180,00";
                }
                else if (quarto == TipoQuartos.Suíte && valor < 300)
                {
                    return "O valor da suíte deve ser de no mínimo R$300,00";
                }
                return "";
            }
            return "Insira um valor válido!";
        }

        public static string VerificaDatas(this DateTime dataSaida)
        {
            if (dataSaida < DateTime.Now)
            {
                return "A data de saída precisa ser após a data de entrada!";
            }
            return "";
        }

        public static string VerificaEndereco(string rua, string bairro, int numeroCasa)
        {
            if (!string.IsNullOrEmpty(rua))
            {
                if (!string.IsNullOrEmpty(bairro))
                {
                    if (numeroCasa > 0)
                    {
                        return "";
                    }
                }
            }
            return "Endereço inválido, verifique os campos novamente!";
        }

        public static string ValidaTelefone(this string telefone, int tipoNumero)
        {
            if (!string.IsNullOrEmpty(telefone))
            {
                if (tipoNumero == 0)
                {
                    if (telefone.Length != 11)
                    {
                        return "Número de celular inválido!";
                    }
                }
                if (tipoNumero == 1)
                {
                    if (telefone.Length != 10)
                    {
                        return "Número de telefone inválido!";
                    }
                }
                return "";
            }
            return "Insira um número válido!";
        }

        public static string ListaEstaVazia<T>(this List<T> lista)
        {
            if (!lista.Any())
            {
                return "A lista esta vazia!";
            }
            return "";
        }

        /*
        public static string CalculaValorProdutos(double valor, int quantidade)
        {
            if (quantidade > 1)
            {
                valor *= quantidade;
                return "";
            }
            return "Quantidade de itens inválida!";
        }
        */
    }
}