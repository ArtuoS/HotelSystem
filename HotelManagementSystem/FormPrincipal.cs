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

        public FormPrincipal()
        {
            InitializeComponent();
            btmLimpezaQuatos.Hide();
            if (!Environments.FuncionarioLogado.IsADM)
            {
                btnFuncionarios.Hide();
                btnFornecedores.Hide();
            }
            if (Environments.FuncionarioLogado.Cargo == CargosFuncionarios.Governanta)
            {
                btmLimpezaQuatos.Show();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormCliente formCliente = new FormCliente();
            pnlNav.Height = btnClientes.Height;
            pnlNav.Top = btnClientes.Top;
            this.Hide();
            formCliente.ShowDialog();
            this.Show();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            FormFuncionario formFuncionario = new FormFuncionario();
            pnlNav.Height = btnFuncionarios.Height;
            pnlNav.Top = btnFuncionarios.Top;
            this.Hide();
            formFuncionario.ShowDialog();
            this.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            FormFornecedor formFornecedor = new FormFornecedor();
            pnlNav.Height = btnFornecedores.Height;
            pnlNav.Top = btnFornecedores.Top;
            this.Hide();
            formFornecedor.ShowDialog();
            this.Show();
        }

        private void btnQuartos_Click(object sender, EventArgs e)
        {
            FormQuarto formQuarto = new FormQuarto();
            pnlNav.Height = btnQuartos.Height;
            pnlNav.Top = btnQuartos.Top;
            this.Hide();
            formQuarto.ShowDialog();
            this.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            FormProduto formProduto = new FormProduto();
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formProduto.ShowDialog();
            this.Show();
        }

        private void btnEntradaProdutos_Click(object sender, EventArgs e)
        {
            FormRegistroProdutos formRegistroProdutos = new FormRegistroProdutos();
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
            FormVendaItens formVendaItens = new FormVendaItens();
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formVendaItens.ShowDialog();
            this.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            FormCheckIn formCheckIn = new FormCheckIn();
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formCheckIn.ShowDialog();
            this.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            FormCheckOut formCheckOut = new FormCheckOut();
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            this.Hide();
            formCheckOut.ShowDialog();
            this.Show();
        }

        private void btmLimpezaQuatos_Click(object sender, EventArgs e)
        {
            FormLimpeza formLimpeza = new FormLimpeza();
            pnlNav.Height = btmLimpezaQuatos.Height;
            pnlNav.Top = btmLimpezaQuatos.Top;
            this.Hide();
            formLimpeza.ShowDialog();
            this.Show();
        }
    }
}
