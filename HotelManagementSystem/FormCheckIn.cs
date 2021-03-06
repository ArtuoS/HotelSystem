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
        }

        QuartoBLL quartoBLL = new QuartoBLL();
        ClienteBLL clienteBLL = new ClienteBLL();
        CheckInBLL checkInBLL = new CheckInBLL();
        CheckOutBLL checkOutBLL = new CheckOutBLL();

        // Chamado ao carregar o formulário
        private void FormCheckIn_Load(object sender, EventArgs e)
        {
            UpdateGridViewQuartos();
            UpdateGridViewClientes();
            UpdateGridViewCheckIn();
        }

        // Atualiza o datagridview com os quartos não ocupados
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

        // Atualiza o datagridview com os clientes
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

        // Atualiza o datagridview com os checkins
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

        // Preenche os campos com os valores do datagridview
        private void dgvQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuartos.SelectedRows.Count > 0)
            {
                string ID = dgvQuartos.SelectedRows[0].Cells[0].Value + string.Empty;

                txtQuartoID.Text = ID;
            }
        }

        // Preenche os campos com os valores do datagridview
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

        // Fecha o formulário
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Adiciona um checkin
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            try
            {
                CheckIn checkIn = new CheckIn();
                checkIn.QuartoID = int.Parse(txtQuartoID.Text);
                checkIn.ClienteID = int.Parse(txtClienteID.Text);
                checkIn.DataEntrada = DateTime.Now;
                checkIn.DataSaidaPrevista = dtpDataSaidaPrevista.Value;

                Response response = checkInBLL.Insert(checkIn);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridViewQuartos();
                    UpdateGridViewCheckIn();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }

        }
    }
}