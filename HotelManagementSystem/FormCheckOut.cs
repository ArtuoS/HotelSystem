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
    public partial class FormCheckOut : Form
    {
        public FormCheckOut()
        {
            InitializeComponent();
        }

        CheckIn_ClienteBLL checkIn_ClienteBLL = new CheckIn_ClienteBLL();
        CheckOutBLL checkOutBLL = new CheckOutBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        Itens_ConsumidosBLL Itens_ConsumidosBLL = new Itens_ConsumidosBLL();

        string QUARTOID;
        Cliente cliente = new Cliente();

        private void dgvCheckOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheckOut.SelectedRows.Count > 0)
            {
                string ID = dgvCheckOut.SelectedRows[0].Cells[0].Value + string.Empty;
                string CLIENTEID = dgvCheckOut.SelectedRows[0].Cells[2].Value + string.Empty;
                QUARTOID = dgvCheckOut.SelectedRows[0].Cells[1].Value + string.Empty;

                txtID.Text = ID;
                txtIDCliente.Text = CLIENTEID;

                cliente.ID = int.Parse(txtIDCliente.Text);
                SingleResponse<Cliente> response = clienteBLL.GetById(cliente);
                if (response.Success)
                {
                    txtNome.Text = cliente.Nome;
                    txtCPF.Text = cliente.CPF;
                    txtRG.Text = cliente.RG;
                    txtTelefoneF.Text = cliente.TelefoneFixo;
                    txtTelefoneC.Text = cliente.TelefoneCelular;
                    txtEmail.Text = cliente.Email;
                    UpdateGridViewItensConsumidos();
                }
            }
        }

        private void UpdateGridView()
        {
            QueryResponse<CheckIn_Cliente> response = checkIn_ClienteBLL.GetData();
            if (response.Success)
            {
                dgvCheckOut.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void UpdateGridViewItensConsumidos()
        {
            QueryResponse<Itens_Consumidos> response = Itens_ConsumidosBLL.GetItensConsumidosByCliente(int.Parse(txtIDCliente.Text));
            if (response.Success)
            {
                dgvItensConsumidos.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void FormCheckOut_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                CheckOut checkOut = new CheckOut();
                //checkOut.ID = int.Parse(txtID.Text);
                checkOut.QuartoID = int.Parse(QUARTOID);
                checkOut.ClienteID = int.Parse(txtIDCliente.Text);
                checkOut.DataSaida = DateTime.Now;
                checkOut.CheckInID = int.Parse(txtID.Text);

                Response response = checkOutBLL.Insert(checkOut);
                MessageBox.Show(response.Message);
                if (response.Success)
                {
                    FerramentasTextBox.LimpaTextBoxes(this);
                    UpdateGridView();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
