using BusinessLogicalLayer;
using Common;
using Entities;
using Entities.Enumeradores;
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
    public partial class FormQuarto : Form
    {
        public FormQuarto()
        {
            InitializeComponent();
        }

        QuartoBLL quartoBLL = new QuartoBLL();

        // Chamado ao carregar o form
        private void FormQuarto_Load(object sender, EventArgs e)
        {
            cbTipoQuarto.DataSource = Enum.GetValues(typeof(TipoQuartos));
            UpdateGridView();
        }

        // Adiciona um quarto
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Quarto quarto = new Quarto();
            try
            {
                quarto.TipoQuarto = (TipoQuartos)cbTipoQuarto.SelectedIndex;
                quarto.ValorNoite = Convert.ToDouble(txtValor.Text);
                quarto.PessoasMaximas = int.Parse(txtPessoasMax.Text);
                quarto.Ocupado = false;

                Response response = quartoBLL.Insert(quarto);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        // Atualiza um quarto
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Quarto quarto = new Quarto();
            try
            {
                quarto.ID = int.Parse(txtID.Text);
                quarto.TipoQuarto = (TipoQuartos)cbTipoQuarto.SelectedIndex;
                quarto.ValorNoite = double.Parse(txtValor.Text);
                quarto.PessoasMaximas = int.Parse(txtPessoasMax.Text);
                quarto.Ocupado = false;

                Response response = quartoBLL.Update(quarto);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");
            }
        }

        // Deleta um quarto
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Quarto quarto = new Quarto();
            try
            {
                quarto.ID = int.Parse(txtID.Text);

                Response response = quartoBLL.Delete(quarto);
                MessageBox.Show(response.Message);

                if (response.Success)
                {
                    UpdateGridView();
                    FerramentasTextBox.LimpaTextBoxes(this);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Existem valores inválidos!");

            }

        }

        // Atualiza o datagridview com os quartos
        private void UpdateGridView()
        {
            QueryResponse<Quarto> response = quartoBLL.GetAll();
            if (response.Success)
            {
                dgvQuarto.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        // Fecha o formulário
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Preenche os campos com os valor do datagridview
        private void dgvQuarto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvQuarto.SelectedRows.Count > 0)
            {
                string ID = dgvQuarto.SelectedRows[0].Cells[0].Value + string.Empty;
                string TIPOQUARTO = dgvQuarto.SelectedRows[0].Cells[1].Value + string.Empty;
                string VALORNOITE = dgvQuarto.SelectedRows[0].Cells[2].Value + string.Empty;
                string PESSOASMAXIMAS = dgvQuarto.SelectedRows[0].Cells[3].Value + string.Empty;


                txtID.Text = ID;
                cbTipoQuarto.SelectedIndex = RetornaTipoQuarto(TIPOQUARTO);
                txtValor.Text = VALORNOITE;
                txtPessoasMax.Text = PESSOASMAXIMAS;
            }
        }

        // Converte os quartos de string para int para passar ao banco
        public int RetornaTipoQuarto(string cargo)
        {
            if (cargo == "Econômico")
            {
                return 0;
            }
            else if (cargo == "Executivo")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        // Atualiza a imagem do quarto ao mudar o index do combobox
        private void cbTipoQuarto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoQuarto.SelectedIndex == 0)
            {
                pbImgQuarto.ImageLocation = @"HotelManagementSystem\Imagens\economico.jpg";
            }
            else if (cbTipoQuarto.SelectedIndex == 1)
            {
                pbImgQuarto.ImageLocation = @"HotelSys\HotelManagementSystem\Imagens\executivo.jpg";
            }
            else
            {
                pbImgQuarto.ImageLocation = @"C:\Users\arthu\source\repos\HotelSys\HotelManagementSystem\Imagens\suite.jpg";

            }
        }
    }
}
