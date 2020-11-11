using BusinessLogicalLayer;
using Common;
using Entities;
using Entities.Enumeradores;
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
    public partial class FormFuncionario : Form
    {
        public FormFuncionario()
        {
            InitializeComponent();
        }

        private void FormFuncionario_Load(object sender, EventArgs e)
        {
            cbCargo.DataSource = Enum.GetValues(typeof(CargosFuncionarios));
            UpdateGridView();
        }

        FuncionarioBLL funcionarioBLL = new FuncionarioBLL();

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            try
            {
                funcionario.ID = Convert.ToInt32(txtID.Text);
                funcionario.Nome = txtNome.Text;
                funcionario.CPF = txtCPF.Text;
                funcionario.RG = txtRG.Text;
                funcionario.Email = txtEmail.Text;
                funcionario.Senha = txtSenha.Text;
                funcionario.Rua = txtRua.Text;
                funcionario.Bairro = txtBairro.Text;
                funcionario.NumeroCasa = int.Parse(txtNumeroCasa.Text);
                funcionario.IsADM = cbAdministrador.Checked;
            }
            finally
            {
                Response response = funcionarioBLL.Update(funcionario);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.ID = int.Parse(txtID.Text);
            Response response = funcionarioBLL.Delete(funcionario);
            MessageBox.Show(response.Message);

            if (response.Success)
            {
                UpdateGridView();
                FerramentasTextBox.LimpaTextBoxes(this);
            }
        }

        private void UpdateGridView()
        {
            QueryResponse<Funcionario> response = funcionarioBLL.GetAll();
            if (response.Success)
            {
                dgvFuncionario.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            try
            {
                funcionario.Nome = txtNome.Text;
                funcionario.CPF = txtCPF.Text;
                funcionario.RG = txtRG.Text;
                funcionario.Email = txtEmail.Text;
                funcionario.Senha = txtSenha.Text;
                funcionario.Cargo = (CargosFuncionarios)cbCargo.SelectedIndex;
                funcionario.Rua = txtRua.Text;
                funcionario.Bairro = txtBairro.Text;
                funcionario.NumeroCasa = int.Parse(txtNumeroCasa.Text);
                funcionario.IsADM = cbAdministrador.Checked;
            }
            finally
            {
                Response response = funcionarioBLL.Insert(funcionario);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
        }

        private void dgvFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFuncionario.SelectedRows.Count > 0)
            {
                string ID = dgvFuncionario.SelectedRows[0].Cells[0].Value + string.Empty;
                string NOME = dgvFuncionario.SelectedRows[0].Cells[1].Value + string.Empty;
                string CPF = dgvFuncionario.SelectedRows[0].Cells[2].Value + string.Empty;
                string RG = dgvFuncionario.SelectedRows[0].Cells[3].Value + string.Empty;
                string EMAIL = dgvFuncionario.SelectedRows[0].Cells[4].Value + string.Empty;
                string SENHA = dgvFuncionario.SelectedRows[0].Cells[5].Value + string.Empty;
                string CARGO = dgvFuncionario.SelectedRows[0].Cells[6].Value + string.Empty;
                string RUA = dgvFuncionario.SelectedRows[0].Cells[7].Value + string.Empty;
                string BAIRRO = dgvFuncionario.SelectedRows[0].Cells[8].Value + string.Empty;
                string NUMEROCASA = dgvFuncionario.SelectedRows[0].Cells[9].Value + string.Empty;
                string ADMINISTRADOR = dgvFuncionario.SelectedRows[0].Cells[11].Value + string.Empty;

                txtID.Text = ID;
                txtNome.Text = NOME;
                txtCPF.Text = CPF;
                txtRG.Text = RG;
                txtEmail.Text = EMAIL;
                txtSenha.Text = SENHA;
                cbCargo.SelectedIndex = RetornaCargo(CARGO);
                txtRua.Text = RUA;
                txtBairro.Text = BAIRRO;
                txtNumeroCasa.Text = NUMEROCASA;
                cbAdministrador.Checked = RetornaAdministrador(ADMINISTRADOR);
            }
        }

        public int RetornaCargo(string cargo)
        {
            if (cargo == "Gerente")
            {
                return 0;
            }
            else if (cargo == "Recepcionista")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public bool RetornaAdministrador(string isAdm)
        {
            if (isAdm == "True")
            {
                return true;
            }
            return false;
        }
    }
}
