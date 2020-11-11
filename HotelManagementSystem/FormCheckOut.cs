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

        System.Threading.Thread t;

        string QUARTOID;
        private void dgvCheckOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheckOut.SelectedRows.Count > 0)
            {
                string ID = dgvCheckOut.SelectedRows[0].Cells[0].Value + string.Empty;
                string CLIENTEID = dgvCheckOut.SelectedRows[0].Cells[2].Value + string.Empty;
                QUARTOID = dgvCheckOut.SelectedRows[0].Cells[1].Value + string.Empty;

                txtID.Text = ID;
                txtIDCliente.Text = CLIENTEID;


                Cliente cliente = new Cliente();
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

        public void GetHoraAtual()
        {
            while (true)
            {
                txtDataAtual.Invoke((MethodInvoker)(() => txtDataAtual.Text = DateTime.Now.ToString()));
            }
        }

        private void FormCheckOut_Load(object sender, EventArgs e)
        {
            UpdateGridView();
            t = new System.Threading.Thread(GetHoraAtual);
            t.Start();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            CheckOut checkOut = new CheckOut();
            checkOut.ID = int.Parse(txtID.Text);
            checkOut.QuartoID = int.Parse(QUARTOID);
            checkOut.ClienteID = int.Parse(txtIDCliente.Text);
            checkOut.DataSaida = DateTime.Parse(txtDataAtual.Text);
            checkOut.Valor = 10; //ISSO É UM TESTE! MUDA ISSO DOIDO!

            Response response = checkOutBLL.Insert(checkOut);
            MessageBox.Show(response.Message);
            if(response.Success)
            {
                FerramentasTextBox.LimpaTextBoxes(this);
                UpdateGridView();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
