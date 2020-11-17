using Common;
using Entities;
using Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class FormPrincipal : Form
    {
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblNome.Text = Environments.FuncionarioLogado.Nome;
            lblCargo.Text = Convert.ToString(Environments.FuncionarioLogado.Cargo);
        }

        FormCheckIn formCheckIn = new FormCheckIn();
        FormCheckOut formCheckOut = new FormCheckOut();
        FormCliente formCliente = new FormCliente();
        FormFornecedor formFornecedor = new FormFornecedor();
        FormFuncionario formFuncionario = new FormFuncionario();
        FormProduto formProduto = new FormProduto();
        FormQuarto formQuarto = new FormQuarto();
        FormRegistroProdutos formRegistroProdutos = new FormRegistroProdutos();
        FormVendaItens formVendaItens = new FormVendaItens();

        public FormPrincipal()
        {
            InitializeComponent();
            if (!Environments.FuncionarioLogado.IsADM)
            {
                btnFornecedores.Hide();
                btnFuncionarios.Hide();
                btnQuartos.Hide();
                btnEntradaProdutos.Hide();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnClientes.Height;
            pnlNav.Top = btnClientes.Top;
            this.Hide();
            formCliente.ShowDialog();
            this.Show();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnFuncionarios.Height;
            pnlNav.Top = btnFuncionarios.Top;
            this.Hide();
            formFuncionario.ShowDialog();
            this.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnFornecedores.Height;
            pnlNav.Top = btnFornecedores.Top;
            this.Hide();
            formFornecedor.ShowDialog();
            this.Show();
        }

        private void btnQuartos_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnQuartos.Height;
            pnlNav.Top = btnQuartos.Top;
            this.Hide();
            formQuarto.ShowDialog();
            this.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formProduto.ShowDialog();
            this.Show();
        }

        private void btnEntradaProdutos_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formRegistroProdutos.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVendaProdutos_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formVendaItens.ShowDialog();
            this.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formCheckIn.ShowDialog();
            this.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formCheckOut.ShowDialog();
            this.Show();
        }
    }
}
