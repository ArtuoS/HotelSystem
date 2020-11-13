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
    public partial class FormRegistroProdutos : Form
    {
        public FormRegistroProdutos()
        {
            InitializeComponent();
        }

        EntradaProdutoBLL entradaProdutoBLL = new EntradaProdutoBLL();
        ItensEntradaBLL itensEntradaBLL = new ItensEntradaBLL();
        FornecedorBLL fornecedorBLL = new FornecedorBLL();
        ProdutoBLL produtoBLL = new ProdutoBLL();
        int listIndex;

        private void FormRegistroProdutos_Load(object sender, EventArgs e)
        {

            QueryResponse<Fornecedor> responseFornecedor = fornecedorBLL.GetAll();
            cbFornecedor.DataSource = responseFornecedor.Data;
            cbFornecedor.ValueMember = "RAZAOSOCIAL";

            QueryResponse<Produto> responseProduto = produtoBLL.GetAll();
            cbProduto.DataSource = responseProduto.Data;
            cbProduto.ValueMember = "NOME";

            UpdateGridView();
        }


        List<Itens_Produto> itens_Produtos = new List<Itens_Produto>();
        EntradaProduto entradaProduto = new EntradaProduto();
        ItensEntrada itensEntrada = new ItensEntrada();

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                entradaProduto.DataEntrada = DateTime.Now;
                entradaProduto.FornecedorID = int.Parse(txtIDFornecedor.Text);
                entradaProduto.FuncionarioID = Environments.FuncionarioLogado.ID;

                Response response = entradaProdutoBLL.InsertEntrada(entradaProduto);

                foreach (ItensEntrada item in entradaProduto.Itens)
                {
                    SingleResponse<EntradaProduto> singleResponse = entradaProdutoBLL.GetEntradaID(entradaProduto);
                    entradaProduto.Itens.Where(i => item.EntradaID == 0);
                    item.EntradaID = singleResponse.Data.ID;
                    Response response1 = itensEntradaBLL.InsertItem(item);
                }
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    FerramentasTextBox.LimpaTextBoxes(this);
                    itens_Produtos.Clear();
                    UpdateGridView();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            ItensEntrada itensEntrada1 = new ItensEntrada();
            try
            {
                itensEntrada1.ProdutoID = int.Parse(txtIDProduto.Text);
                itensEntrada1.Valor = double.Parse(txtValorUnitario.Text);
                itensEntrada1.Quantidade = int.Parse(txtQuantidade.Text);
                ClonaValores(itensEntrada, itensEntrada1);

                entradaProduto.Valor += (itensEntrada.Valor * itensEntrada.Quantidade);
                txtValor.Text = Convert.ToString(entradaProduto.Valor);
                itens_Produtos.Add(ConversaoClasses(cbProduto.GetItemText(cbProduto.SelectedItem), itensEntrada1));
                entradaProduto.Itens.Add(itensEntrada1);
                UpdateGridView();
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }

        }

        private void cbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.RazaoSocial = cbFornecedor.GetItemText(cbFornecedor.SelectedItem);
            SingleResponse<Fornecedor> response = fornecedorBLL.GetByRazaoSocial(fornecedor);
            txtCNPJ.Text = fornecedor.CNPJ;
            txtIDFornecedor.Text = Convert.ToString(fornecedor.ID);
        }

        private void cbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            produto.Nome = cbProduto.GetItemText(cbProduto.SelectedItem);
            SingleResponse<Produto> response = produtoBLL.GetByNome(produto);
            txtIDProduto.Text = Convert.ToString(produto.ID);
            txtDescricao.Text = produto.Descricao;
        }

        public void ClonaValores(ItensEntrada ie1, ItensEntrada ie2)
        {
            ie1.ProdutoID = ie2.ProdutoID;
            ie1.Valor = ie2.Valor;
            ie1.Quantidade = ie2.Quantidade;
        }

        public Itens_Produto ConversaoClasses(string produto, ItensEntrada itemEntrada)
        {
            Itens_Produto item = new Itens_Produto();
            item.Produto = produto;
            item.Quantidade = itemEntrada.Quantidade;
            item.Valor = itemEntrada.Valor;
            return item;
        }

        private void UpdateGridView()
        {
            var bindingList = new BindingList<Itens_Produto>(itens_Produtos);
            var source = new BindingSource(bindingList, null);
            dgvItens.DataSource = source;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            itens_Produtos.RemoveAt(listIndex);
            entradaProduto.Itens.RemoveAt(listIndex);
            dgvItens.DataSource = itens_Produtos.ToList();
            MessageBox.Show("Produto deletado!");
        }

        private void dgvItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItens.SelectedRows.Count > 0)
            {
                listIndex = e.RowIndex;
                MessageBox.Show("Produto selecionado!");
            }
        }

        private void dgvItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


        }
    }
}
