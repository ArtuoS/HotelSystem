﻿using BusinessLogicalLayer;
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
    public partial class FormCheckIn : Form
    {
        public FormCheckIn()
        {
            InitializeComponent();
            txtDataAtual.Text = DateTime.Now.ToString();
        }

        QuartoBLL quartoBLL = new QuartoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        CheckInBLL checkInBLL = new CheckInBLL();
        CheckOutBLL checkOutBLL = new CheckOutBLL();

        System.Threading.Thread t;
        string QUARTOID;

        private void FormCheckIn_Load(object sender, EventArgs e)
        {
            UpdateGridViewQuartos();
            UpdateGridViewClientes();
            UpdateGridViewCheckIn();
            t = new System.Threading.Thread(GetHoraAtual);
            t.Start();
        }

        private void UpdateGridViewQuartos()
        {
            QueryResponse<Quarto> response = quartoBLL.GetNotOccupied();
            if (response.Success)
            {
                dgvQuartos.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void UpdateGridViewClientes()
        {
            QueryResponse<Cliente> response = clienteBLL.GetAll();
            if (response.Success)
            {
                dgvClientes.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void UpdateGridViewCheckIn()
        {
            QueryResponse<CheckIn> response = checkInBLL.GetAll();
            if (response.Success)
            {
                dgvCheckIn.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void dgvQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuartos.SelectedRows.Count > 0)
            {
                string ID = dgvQuartos.SelectedRows[0].Cells[0].Value + string.Empty;

                txtQuartoID.Text = ID;
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                string ID = dgvClientes.SelectedRows[0].Cells[0].Value + string.Empty;
                string NOME = dgvClientes.SelectedRows[0].Cells[1].Value + string.Empty;


                txtClienteNome.Text = NOME;
                txtClienteID.Text = ID;
            }
        }
        private void dgvCheckIn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCheckIn.SelectedRows.Count > 0)
            {
                string ID = dgvCheckIn.SelectedRows[0].Cells[0].Value + string.Empty;
                QUARTOID = dgvCheckIn.SelectedRows[0].Cells[1].Value + string.Empty;

                txtCheckInID.Text = ID;
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
            t.Abort();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            CheckIn checkIn = new CheckIn();
            checkIn.QuartoID = int.Parse(txtQuartoID.Text);
            checkIn.ClienteID = int.Parse(txtClienteID.Text);
            checkIn.DataEntrada = DateTime.Now;
            checkIn.DataSaidaPrevista = dtpDataSaidaPrevista.Value;

            Response response = checkInBLL.Insert(checkIn);
            MessageBox.Show(response.Message);
            
            if(response.Success)
            {
                UpdateGridViewQuartos();
                UpdateGridViewCheckIn();
                FerramentasTextBox.LimpaTextBoxes(this);
            }
        }

        public void GetHoraAtual()
        {
            while (true)
            {
                txtDataAtual.Invoke((MethodInvoker)(() => txtDataAtual.Text = DateTime.Now.ToString()));
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            CheckIn checkIn = new CheckIn();
            checkIn.ID = int.Parse(txtCheckInID.Text);
            checkIn.QuartoID = int.Parse(QUARTOID);

            Response response = checkInBLL.Delete(checkIn);
            MessageBox.Show(response.Message);

            if(response.Success)
            {
                UpdateGridViewCheckIn();
                UpdateGridViewQuartos();
                FerramentasTextBox.LimpaTextBoxes(this);
            }
        }
    }
}