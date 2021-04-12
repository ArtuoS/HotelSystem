using BusinessLogicalLayer;
using Common;
using DataAcessLayer;
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
    public partial class FormFornecedor : Form
    {
        public FormFornecedor()
        {
            InitializeComponent();
        }

        // Chamado ao carregar o formulário
        private void FormFornecedor_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        FornecedorBLL fornecedorBLL = new FornecedorBLL();

        // Atualiza o datagridview com os fornecedores
        private void UpdateGridView()
        {
            QueryResponse<Fornecedor> response = fornecedorBLL.GetAll();
            if (response.Success)
            {
                dgvFornecedores.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        // Adiciona um fornecedor
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Fornecedor fornecedor = new Fornecedor();
            try
            {
                fornecedor.RazaoSocial = txtRazaoSocial.Text;
                fornecedor.Nome = txtNome.Text;
                fornecedor.CNPJ = txtCNPJ.Text;
                fornecedor.TelefoneCelular = txtTelefoneC.Text;
                fornecedor.Email = txtEmail.Text;

                Response response = fornecedorBLL.Insert(fornecedor);
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

        // Deleta um fornecedor
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.ID = int.Parse(txtID.Text);

                Response response = fornecedorBLL.Delete(fornecedor);
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

        // Atualiza um fornecedor
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.ID = int.Parse(txtID.Text);
                fornecedor.RazaoSocial = txtRazaoSocial.Text;
                fornecedor.Nome = txtNome.Text;
                fornecedor.CNPJ = txtCNPJ.Text;
                fornecedor.TelefoneCelular = txtTelefoneC.Text;
                fornecedor.Email = txtEmail.Text;

                Response response = fornecedorBLL.Update(fornecedor);
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

        // Fecha o formulário
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Preenche os campos com os valores do datagridview
        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFornecedores.SelectedRows.Count > 0)
            {
                string ID = dgvFornecedores.SelectedRows[0].Cells[0].Value + string.Empty;
                string RAZAOSOCIAL = dgvFornecedores.SelectedRows[0].Cells[1].Value + string.Empty;
                string NOME = dgvFornecedores.SelectedRows[0].Cells[2].Value + string.Empty;
                string CNPJ = dgvFornecedores.SelectedRows[0].Cells[3].Value + string.Empty;
                string TELEFONECELULAR = dgvFornecedores.SelectedRows[0].Cells[4].Value + string.Empty;
                string EMAIL = dgvFornecedores.SelectedRows[0].Cells[5].Value + string.Empty;

                txtID.Text = ID;
                txtRazaoSocial.Text = RAZAOSOCIAL;
                txtNome.Text = NOME;
                txtCNPJ.Text = CNPJ;
                txtTelefoneC.Text = TELEFONECELULAR;
                txtEmail.Text = EMAIL;
            }
        }
    }
}
