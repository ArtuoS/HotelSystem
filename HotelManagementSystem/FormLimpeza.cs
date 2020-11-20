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
    public partial class FormLimpeza : Form
    {
        public FormLimpeza()
        {
            InitializeComponent();
        }

        LimpezaQuartoBLL limpezaQuartoBLL = new LimpezaQuartoBLL();
        QuartoBLL quartoBLL = new QuartoBLL();

        // Insere uma limpeza de quarto
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateGridView()
        {
            QueryResponse<Quarto> response = quartoBLL.GetAll();
            if (response.Success)
            {
                dgvQuartos.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void FormLimpeza_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void dgvQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuartos.SelectedRows.Count > 0)
            {
                string ID = dgvQuartos.SelectedRows[0].Cells[0].Value + string.Empty;

                txtIDQuarto.Text = ID;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            try
            {

                LimpezaQuarto limpeza = new LimpezaQuarto();
                limpeza.DataLimpeza = DateTime.Now;
                limpeza.FuncionarioID = Environments.FuncionarioLogado.ID;
                limpeza.QuartoID = int.Parse(txtIDQuarto.Text);

                Response response = limpezaQuartoBLL.Insert(limpeza);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridView();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }
    }
}
