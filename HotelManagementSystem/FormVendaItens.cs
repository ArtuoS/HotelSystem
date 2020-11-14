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
    public partial class FormVendaItens : Form
    {
        public FormVendaItens()
        {
            InitializeComponent();
        }

        private void FormVendaItens_Load(object sender, EventArgs e)
        {
            UpdateGridView();
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            cbCliente.DataSource = response.Data;
            cbCliente.ValueMember = "NOME";
        }

        ProdutoBLL produtoBLL = new ProdutoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();

        private void btnVender_Click(object sender, EventArgs e)
        {

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

        private void cbCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            foreach (Cliente cliente in response.Data)
            {
                if (cbCliente.GetItemText(cbCliente.SelectedItem) == cliente.Nome)
                {
                    txtCPF.Text = cliente.CPF;
                }
            }
        }
    }
}
