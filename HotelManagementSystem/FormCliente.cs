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
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        // Chamado ao carregar o formulário
        private void FormCliente_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        ClienteBLL clienteBLL = new ClienteBLL();

        // Atualiza o datagridview com os clientes
        private void UpdateGridView()
        {
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            if (response.Success)
            {
                dgvCliente.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        // Preenche os campos com os valores do datagridview
        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCliente.SelectedRows.Count > 0)
            {
                string ID = dgvCliente.SelectedRows[0].Cells[0].Value + string.Empty;
                string NOME = dgvCliente.SelectedRows[0].Cells[1].Value + string.Empty;
                string CPF = dgvCliente.SelectedRows[0].Cells[2].Value + string.Empty;
                string RG = dgvCliente.SelectedRows[0].Cells[3].Value + string.Empty;
                string TELEFONEFIXO = dgvCliente.SelectedRows[0].Cells[4].Value + string.Empty;
                string TELEFONECELULAR = dgvCliente.SelectedRows[0].Cells[5].Value + string.Empty;
                string EMAIL = dgvCliente.SelectedRows[0].Cells[6].Value + string.Empty;

                txtID.Text = ID;
                txtNome.Text = NOME;
                txtCPF.Text = CPF;
                txtRG.Text = RG;
                txtTelefoneF.Text = TELEFONEFIXO;
                txtTelefoneC.Text = TELEFONECELULAR;
                txtEmail.Text = EMAIL;
            }
        }

        // Fecha o formulário
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Adiciona um cliente
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPF.Text;
                cliente.RG = txtRG.Text;
                cliente.TelefoneFixo = txtTelefoneF.Text;
                cliente.TelefoneCelular = txtTelefoneC.Text;
                cliente.Email = txtEmail.Text;

                Response response = clienteBLL.Insert(cliente);
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

        // Atualiza um cliente
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.ID = int.Parse(txtID.Text);
                cliente.Nome = txtNome.Text;
                cliente.CPF = txtCPF.Text;
                cliente.RG = txtRG.Text;
                cliente.TelefoneFixo = txtTelefoneF.Text;
                cliente.TelefoneCelular = txtTelefoneC.Text;
                cliente.Email = txtEmail.Text;
                cliente.Ativo = true; //pensar em algo!

                Response response = clienteBLL.Update(cliente);
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

        // Deleta um cliente
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.ID = int.Parse(txtID.Text);

                Response response = clienteBLL.Delete(cliente);
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
    }
}
