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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );

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

        public FormPrincipal()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            if(!Environments.FuncionarioLogado.IsADM)
            {
                btnFornecedores.Hide();
                btnFuncionarios.Hide();
                btnQuartos.Hide();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnClientes.Height;
            pnlNav.Top = btnClientes.Top;
            btnClientes.BackColor = Color.FromArgb(94, 96, 206);
            this.Hide();
            formCliente.ShowDialog();
            this.Show();
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnFuncionarios.Height;
            pnlNav.Top = btnFuncionarios.Top;
            btnFuncionarios.BackColor = Color.FromArgb(94, 96, 206);
            this.Hide();
            formFuncionario.ShowDialog();
            this.Show();
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnFornecedores.Height;
            pnlNav.Top = btnFornecedores.Top;
            btnFornecedores.BackColor = Color.FromArgb(94, 96, 206);
            this.Hide();
            formFornecedor.ShowDialog();
            this.Show();
        }

        private void btnQuartos_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnQuartos.Height;
            pnlNav.Top = btnQuartos.Top;
            btnQuartos.BackColor = Color.FromArgb(94, 96, 206);
            this.Hide();
            formQuarto.ShowDialog();
            this.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnProdutos.Height;
            pnlNav.Top = btnProdutos.Top;
            btnProdutos.BackColor = Color.FromArgb(94, 96, 206);
            this.Hide();
            formProduto.ShowDialog();
            this.Show();
        }

        private void btnClientes_Leave(object sender, EventArgs e)
        {
            btnProdutos.BackColor = Color.FromArgb(83, 144, 217);
        }

        private void btnFuncionarios_Leave(object sender, EventArgs e)
        {
            btnProdutos.BackColor = Color.FromArgb(83, 144, 217);
        }

        private void btnFornecedores_Leave(object sender, EventArgs e)
        {
            btnProdutos.BackColor = Color.FromArgb(83, 144, 217);
        }

        private void btnQuartos_Leave(object sender, EventArgs e)
        {
            btnProdutos.BackColor = Color.FromArgb(83, 144, 217);
        }

        private void btnProdutos_Leave(object sender, EventArgs e)
        {
            btnProdutos.BackColor = Color.FromArgb(83, 144, 217);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
