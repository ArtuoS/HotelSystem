﻿using BusinessLogicalLayer;
using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class FormVendaItens : Form
    {
        public FormVendaItens()
        {
            InitializeComponent();
        }

        // Método chamado ao carregar
        private void FormVendaItens_Load(object sender, EventArgs e)
        {
            cbCPF.Visible = true;
            btnAddNoCarrinho.Enabled = false;
            btnVender.Enabled = false;
            txtQuantidadeItens.Enabled = false;
            txtValor.Enabled = false;
            btnRemoverDoCarrinho.Enabled = false;
            dgvCarrinho.Enabled = false;
            dgvProdutos.Enabled = false;
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            cbCliente.DataSource = response.Data;
            cbCliente.ValueMember = "NOME";
            cbCPF.DataSource = response.Data;
            cbCPF.ValueMember = "CPF";

            UpdateGridView();
            UpdateGridViewCarrinho();
        }

        VendaProduto vendaProduto = new VendaProduto();
        ItensVenda itensVenda = new ItensVenda();

        ProdutoBLL produtoBLL = new ProdutoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        VendaProdutoBLL vendaProdutoBLL = new VendaProdutoBLL();
        List<Itens_Produto> itens_Produtos = new List<Itens_Produto>();
        //ItensVendaBLL itensVendaBLL = new ItensVendaBLL();

        int listIndex;
        string Message;
        double valorTemp = 0;
        int qtdTemp = 0;

        // Atualiza o datagridview com os produtos com estoque
        public void UpdateGridView()
        {
            QueryResponse<Produto> response = produtoBLL.GetAllComEstoque();
            if (response.Success)
            {
                dgvProdutos.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        // Atualiza o carrinho do cliente
        public void UpdateGridViewCarrinho()
        {
            var bindingList = new BindingList<Itens_Produto>(itens_Produtos);
            var source = new BindingSource(bindingList, null);
            dgvCarrinho.DataSource = source;
        }

        // Passa os valores do datagridview para as textboxes
        private void dgvCarrinho_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCarrinho.SelectedRows.Count > 0)
            {
                listIndex = e.RowIndex;

                string QUANTIDADE = dgvCarrinho.SelectedRows[0].Cells[2].Value + string.Empty;
                string VALOR = dgvCarrinho.SelectedRows[0].Cells[1].Value + string.Empty;
                qtdTemp = int.Parse(QUANTIDADE);
                valorTemp = double.Parse(VALOR);

                MessageBox.Show("Produto selecionado!");
            }
        }

        // Passa os valores do datagridview para as textboxes
        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                listIndex = e.RowIndex;
                MessageBox.Show("Produto selecionado!");
            }

            if (dgvProdutos.SelectedRows.Count > 0)
            {
                string IDPRODUTO = dgvProdutos.SelectedRows[0].Cells[0].Value + string.Empty;
                string NOMEPRODUTO = dgvProdutos.SelectedRows[0].Cells[1].Value + string.Empty;
                string VALORUNITARIO = dgvProdutos.SelectedRows[0].Cells[3].Value + string.Empty;
                string QUANTIDADE = dgvProdutos.SelectedRows[0].Cells[4].Value + string.Empty;

                txtProdutoID.Text = IDPRODUTO;
                txtProduto.Text = NOMEPRODUTO;
                txtValorUnitario.Text = VALORUNITARIO;
                txtQuantidade.Text = QUANTIDADE;
            }
        }

        // Insere a venda no banco de dados
        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                vendaProduto.FuncionarioID = Environments.FuncionarioLogado.ID;
                Response response = vendaProdutoBLL.InsertVenda(vendaProduto);

                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    txtValor.Text = "";
                    txtQuantidadeItens.Text = "";
                    vendaProduto.Valor = 0;
                    txtValor.Text = "";
                    cbCliente.Enabled = true;
                    Message = "";
                    btnAddNoCarrinho.Enabled = false;
                    btnVender.Enabled = false;
                    txtQuantidadeItens.Enabled = false;
                    txtValor.Enabled = false;
                    btnRemoverDoCarrinho.Enabled = false;
                    dgvCarrinho.Enabled = false;
                    dgvProdutos.Enabled = false;
                    itens_Produtos.Clear();
                    UpdateGridViewCarrinho();
                    UpdateGridView();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        // Adiciona um item ao carrinho de compras do cliente
        private void btnAddNoCarrinho_Click(object sender, EventArgs e)
        {
            ItensVenda itensVenda1 = new ItensVenda();
            try
            {
                if (int.Parse(txtQuantidadeItens.Text) != 0)
                {
                    itensVenda1.ProdutoID = int.Parse(txtProdutoID.Text);
                    itensVenda1.Valor = double.Parse(txtValorUnitario.Text);
                    itensVenda1.Quantidade = int.Parse(txtQuantidadeItens.Text);
                    itensVenda1.ClienteID = int.Parse(txtID.Text);
                    ClonaValores(itensVenda, itensVenda1);

                    vendaProduto.Valor += (itensVenda.Quantidade * itensVenda.Valor);
                    txtValor.Text = Convert.ToString(vendaProduto.Valor);
                    itens_Produtos.Add(ConversaoClasses(txtProduto.Text, itensVenda1));
                    vendaProduto.Itens.Add(itensVenda1);
                    UpdateGridViewCarrinho();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira a quantidade de itens para adicionar ao carrinho!");
            }
        }

        // Clona obj 1 para a obj 2
        public void ClonaValores(ItensVenda iv1, ItensVenda iv2)
        {
            iv1.ProdutoID = iv2.ProdutoID;
            iv1.Valor = iv2.Valor;
            iv1.Quantidade = iv2.Quantidade;
            iv1.ClienteID = iv2.ClienteID;
        }

        // Converte uma classe para outra
        // O método foi criado pois precisavamos instanciar uma nova variável para cada item dentro do carrinho de compras
        // e passar para outra variável com o mesmo datatype fora do encapsulamento.
        public Itens_Produto ConversaoClasses(string produto, ItensVenda itemVenda)
        {
            Itens_Produto item = new Itens_Produto();
            item.Produto = produto;
            item.Quantidade = itemVenda.Quantidade;
            item.Valor = itemVenda.Valor;
            return item;
        }

        // Passa os valores do datagridview para as textboxes
        private void btnSelecionaCliente_Click(object sender, EventArgs e)
        {
            if (ClienteFoiSelecionado(Message))
            {
                Message = "Cliente selecionado!";
                MessageBox.Show(Message);
                cbCliente.Enabled = false;
                btnAddNoCarrinho.Enabled = true;
                btnVender.Enabled = true;
                txtQuantidadeItens.Enabled = true;
                txtValor.Enabled = true;
                btnRemoverDoCarrinho.Enabled = true;
                dgvCarrinho.Enabled = true;
                dgvProdutos.Enabled = true;
            }
        }

        // Verifica se algum cliente foi selecionado
        public bool ClienteFoiSelecionado(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return true;
            }
            return false;
        }

        // A cada vez que o index do combobox muda é chamado e busca um cliente pelo CPF
        private void cbCPF_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.CPF = cbCPF.GetItemText(cbCPF.SelectedItem);
            if (cliente.CPF != "Entities.Cliente")
            {
                SingleResponse<Cliente> response = clienteBLL.GetByCpf(cliente.CPF);
                txtCPF.Text = cliente.CPF;
                txtID.Text = Convert.ToString(response.Data.ID);
            }
        }

        // Remove um item do carrinho de compras
        private void btnRemoverDoCarrinho_Click(object sender, EventArgs e)
        {
            try
            {
                if (valorTemp != 0 && qtdTemp != 0)
                {
                    vendaProduto.Valor -= (valorTemp * qtdTemp);
                    txtValor.Text = Convert.ToString(vendaProduto.Valor);
                    itens_Produtos.RemoveAt(listIndex);
                    vendaProduto.Itens.RemoveAt(listIndex);
                    dgvCarrinho.DataSource = itens_Produtos.ToList();
                    MessageBox.Show("Produto deletado!");
                }
                else
                {
                    MessageBox.Show("Nenhum produto foi selecionado!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        // Fecha o formulario
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
