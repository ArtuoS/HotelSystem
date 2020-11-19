using BusinessLogicalLayer;
using Common;
using Entities;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class FormLogin : Form
    {
        // Chamado ao carregar o formulário
        public FormLogin()
        {
            InitializeComponent();
            txtEmail.Text = "arthureduardomolinari@gmail.com";
            txtSenha.Text = "123";
        }

        FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
        FormPrincipal formPrincipal;

        // Loga no sistema
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Email = txtEmail.Text;
                funcionario.Senha = txtSenha.Text;

                Response response = funcionarioBLL.GetByLogin(funcionario);
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    this.Hide();
                    formPrincipal = new FormPrincipal();
                    formPrincipal.Show();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        // Fecha o formulário
        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


