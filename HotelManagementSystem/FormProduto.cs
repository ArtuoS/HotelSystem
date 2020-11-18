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
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
        }

        ProdutoBLL produtoBLL = new ProdutoBLL();

        private void FormProduto_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

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

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto();
                produto.Nome = txtNome.Text;
                produto.Descricao = txtDescricao.Text;

                Response response = produtoBLL.Insert(produto);
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto();
                produto.ID = int.Parse(txtID.Text);
                produto.Nome = txtNome.Text;
                produto.Descricao = txtDescricao.Text;

                Response response = produtoBLL.Update(produto);
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto();
                produto.ID = int.Parse(txtID.Text);

                Response response = produtoBLL.Delete(produto);
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }

        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                string ID = dgvProdutos.SelectedRows[0].Cells[0].Value + string.Empty;
                string NOME = dgvProdutos.SelectedRows[0].Cells[1].Value + string.Empty;
                string DESCRICAO = dgvProdutos.SelectedRows[0].Cells[2].Value + string.Empty;
                string VALORUNITARIO = dgvProdutos.SelectedRows[0].Cells[3].Value + string.Empty;

                txtID.Text = ID;
                txtNome.Text = NOME;
                txtDescricao.Text = DESCRICAO;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
