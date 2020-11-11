using BusinessLogicalLayer;
using Common;
using Entities;
using System;
using System.Windows.Forms;

namespace HotelManagementSystem 
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
        FormPrincipal formPrincipal;
        FormFuncionario formFuncionario;


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            funcionario.Email = txtEmail.Text;
            funcionario.Senha = txtSenha.Text;

            Response response = funcionarioBLL.GetByLogin(funcionario);
            MessageBox.Show(response.Message);
            if(response.Success)
            {
                this.Hide();
                formPrincipal = new FormPrincipal();
                formPrincipal.Show();

            }
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            formFuncionario = new FormFuncionario();
            formFuncionario.Show();
        }
    }
}


