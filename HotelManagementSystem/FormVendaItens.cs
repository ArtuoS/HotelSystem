using BusinessLogicalLayer;
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


        private void FormVendaItens_Load(object sender, EventArgs e)
        {
            cbCPF.Visible = false;
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            cbCliente.DataSource = response.Data;
            cbCliente.ValueMember = "NOME";
            cbCPF.DataSource = response.Data;
            cbCPF.ValueMember = "CPF";

            UpdateGridView();
            UpdateGridViewCarrinho();
        }

        List<Itens_Produto> itens_Produtos = new List<Itens_Produto>();
        VendaProduto vendaProduto = new VendaProduto();
        ItensVenda itensVenda = new ItensVenda();

        ProdutoBLL produtoBLL = new ProdutoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        VendaProdutoBLL vendaProdutoBLL = new VendaProdutoBLL();
        ItensVendaBLL itensVendaBLL = new ItensVendaBLL();

        int listIndex;

        public void UpdateGridView()
        {
            QueryResponse<Produto> response = produtoBLL.GetAll();
            if (response.Success)
            {
                dgvProdutos.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        public void UpdateGridViewCarrinho()
        {
            var bindingList = new BindingList<Itens_Produto>(itens_Produtos);
            var source = new BindingSource(bindingList, null);
            dgvCarrinho.DataSource = source;
        }

        private void cbCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            foreach (Cliente cliente in response.Data)
            {
                if (cbCPF.GetItemText(cbCPF.SelectedItem) == cliente.CPF)
                {
                    txtCPF.Text = cliente.CPF;
                    txtID.Text = Convert.ToString(cliente.ID);
                }
            }
        }

        private void dgvCarrinho_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCarrinho.SelectedRows.Count > 0)
            {
                listIndex = e.RowIndex;
                MessageBox.Show("Produto selecionado!");
            }


        }

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

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                vendaProduto.DataVenda = DateTime.Now;
                //vendaProduto.FuncionarioID = Environments.FuncionarioLogado.ID;
                vendaProduto.FuncionarioID = 45;


                Response response = vendaProdutoBLL.InsertEntrada(vendaProduto);
                Response response1;

                foreach (ItensVenda item in vendaProduto.Itens)
                {
                    SingleResponse<VendaProduto> singleResponse = vendaProdutoBLL.GetEntradaID(vendaProduto);
                    vendaProduto.Itens.Where(i => item.VendaID == 0);
                    item.VendaID = singleResponse.Data.ID;
                    response1 = itensVendaBLL.InsertItem(item);
                }

                if (response.Success)
                {
                    MessageBox.Show(response.Message);
                    itens_Produtos.Clear();
                    UpdateGridView();
                    UpdateGridViewCarrinho();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Insira valores válidos!");
            }
        }

        private void btnAddNoCarrinho_Click(object sender, EventArgs e)
        {
            ItensVenda itensVenda1 = new ItensVenda();
            try
            {
                itensVenda1.ProdutoID = int.Parse(txtProdutoID.Text);
                itensVenda1.Valor = double.Parse(txtValorUnitario.Text);
                itensVenda1.Quantidade = int.Parse(txtQuantidadeItens.Text);
                ClonaValores(itensVenda, itensVenda1);

                vendaProduto.Valor += (itensVenda.Quantidade * itensVenda.Valor);
                txtValor.Text = Convert.ToString(vendaProduto.Valor);
                itens_Produtos.Add(ConversaoClasses(txtProduto.Text, itensVenda1));
                vendaProduto.Itens.Add(itensVenda1);
                UpdateGridViewCarrinho();

            }
            catch (FormatException)
            {
                MessageBox.Show("Insira a quantidade de itens para adicionar ao carrinho!");
            }
        }
        public void ClonaValores(ItensVenda iv1, ItensVenda iv2)
        {
            iv1.ProdutoID = iv2.ProdutoID;
            iv1.Valor = iv2.Valor;
            iv1.Quantidade = iv2.Quantidade;
        }

        public Itens_Produto ConversaoClasses(string produto, ItensVenda itemVenda)
        {
            Itens_Produto item = new Itens_Produto();
            item.Produto = produto;
            item.Quantidade = itemVenda.Quantidade;
            item.Valor = itemVenda.Valor;
            return item;
        }
    }
}
