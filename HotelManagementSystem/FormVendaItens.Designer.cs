namespace HotelManagementSystem
{
    partial class FormVendaItens
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtProdutoID = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSelecionaCliente = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtQuantidadeItens = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddNoCarrinho = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvCarrinho = new System.Windows.Forms.DataGridView();
            this.cbCPF = new System.Windows.Forms.ComboBox();
            this.btnVender = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 21);
            this.label6.TabIndex = 87;
            this.label6.Text = "Cliente";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(96)))), ((int)(((byte)(206)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtValor);
            this.panel1.Controls.Add(this.txtProdutoID);
            this.panel1.Controls.Add(this.txtQuantidade);
            this.panel1.Controls.Add(this.txtValorUnitario);
            this.panel1.Controls.Add(this.txtProduto);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cbCPF);
            this.panel1.Controls.Add(this.btnVender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 818);
            this.panel1.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(96)))), ((int)(((byte)(206)))));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(698, 505);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 97;
            this.label7.Text = "Valor Total";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(702, 529);
            this.txtValor.Name = "txtValor";
            this.txtValor.ReadOnly = true;
            this.txtValor.Size = new System.Drawing.Size(156, 26);
            this.txtValor.TabIndex = 105;
            // 
            // txtProdutoID
            // 
            this.txtProdutoID.Location = new System.Drawing.Point(69, 577);
            this.txtProdutoID.Name = "txtProdutoID";
            this.txtProdutoID.Size = new System.Drawing.Size(10, 26);
            this.txtProdutoID.TabIndex = 104;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Location = new System.Drawing.Point(101, 577);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(10, 26);
            this.txtQuantidade.TabIndex = 102;
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(117, 577);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(10, 26);
            this.txtValorUnitario.TabIndex = 101;
            this.txtValorUnitario.Text = "d";
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(85, 577);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(10, 26);
            this.txtProduto.TabIndex = 100;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel5.Controls.Add(this.btnSelecionaCliente);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.cbCliente);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtID);
            this.panel5.Controls.Add(this.txtCPF);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(12, 32);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(243, 284);
            this.panel5.TabIndex = 99;
            // 
            // btnSelecionaCliente
            // 
            this.btnSelecionaCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.btnSelecionaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionaCliente.ForeColor = System.Drawing.Color.White;
            this.btnSelecionaCliente.Location = new System.Drawing.Point(15, 206);
            this.btnSelecionaCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecionaCliente.Name = "btnSelecionaCliente";
            this.btnSelecionaCliente.Size = new System.Drawing.Size(207, 62);
            this.btnSelecionaCliente.TabIndex = 105;
            this.btnSelecionaCliente.Text = "Selecionar Cliente";
            this.btnSelecionaCliente.UseVisualStyleBackColor = false;
            this.btnSelecionaCliente.Click += new System.EventHandler(this.btnSelecionaCliente_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(243, 26);
            this.panel7.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Informações do Cliente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(15, 61);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(207, 29);
            this.cbCliente.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 96;
            this.label2.Text = "ID do Cliente";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(15, 173);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(48, 26);
            this.txtID.TabIndex = 90;
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(15, 117);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.ReadOnly = true;
            this.txtCPF.Size = new System.Drawing.Size(207, 26);
            this.txtCPF.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 21);
            this.label1.TabIndex = 93;
            this.label1.Text = "CPF";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel2.Controls.Add(this.txtQuantidadeItens);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnAddNoCarrinho);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvProdutos);
            this.panel2.Location = new System.Drawing.Point(308, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 261);
            this.panel2.TabIndex = 98;
            // 
            // txtQuantidadeItens
            // 
            this.txtQuantidadeItens.Location = new System.Drawing.Point(19, 217);
            this.txtQuantidadeItens.Name = "txtQuantidadeItens";
            this.txtQuantidadeItens.Size = new System.Drawing.Size(50, 26);
            this.txtQuantidadeItens.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 193);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 21);
            this.label5.TabIndex = 97;
            this.label5.Text = "Quantidade de Itens";
            // 
            // btnAddNoCarrinho
            // 
            this.btnAddNoCarrinho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.btnAddNoCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNoCarrinho.ForeColor = System.Drawing.Color.White;
            this.btnAddNoCarrinho.Location = new System.Drawing.Point(556, 187);
            this.btnAddNoCarrinho.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddNoCarrinho.Name = "btnAddNoCarrinho";
            this.btnAddNoCarrinho.Size = new System.Drawing.Size(197, 56);
            this.btnAddNoCarrinho.TabIndex = 100;
            this.btnAddNoCarrinho.Text = "Adicionar ao Carrinho de Compras";
            this.btnAddNoCarrinho.UseVisualStyleBackColor = false;
            this.btnAddNoCarrinho.Click += new System.EventHandler(this.btnAddNoCarrinho_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(775, 26);
            this.panel3.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(775, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Produtos a Venda";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(17, 34);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.RowHeadersWidth = 51;
            this.dgvProdutos.RowTemplate.Height = 24;
            this.dgvProdutos.Size = new System.Drawing.Size(736, 145);
            this.dgvProdutos.TabIndex = 95;
            this.dgvProdutos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.dgvCarrinho);
            this.panel4.Location = new System.Drawing.Point(308, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(775, 193);
            this.panel4.TabIndex = 97;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Controls.Add(this.label8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(775, 26);
            this.panel6.TabIndex = 87;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(775, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Carrinho";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCarrinho
            // 
            this.dgvCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrinho.Location = new System.Drawing.Point(19, 35);
            this.dgvCarrinho.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvCarrinho.Name = "dgvCarrinho";
            this.dgvCarrinho.RowHeadersWidth = 51;
            this.dgvCarrinho.RowTemplate.Height = 24;
            this.dgvCarrinho.Size = new System.Drawing.Size(736, 145);
            this.dgvCarrinho.TabIndex = 95;
            this.dgvCarrinho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCarrinho_CellClick);
            // 
            // cbCPF
            // 
            this.cbCPF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCPF.FormattingEnabled = true;
            this.cbCPF.Location = new System.Drawing.Point(12, 322);
            this.cbCPF.Name = "cbCPF";
            this.cbCPF.Size = new System.Drawing.Size(243, 29);
            this.cbCPF.TabIndex = 94;
            this.cbCPF.SelectedIndexChanged += new System.EventHandler(this.cbCPF_SelectedIndexChanged);
            // 
            // btnVender
            // 
            this.btnVender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.btnVender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVender.ForeColor = System.Drawing.Color.White;
            this.btnVender.Location = new System.Drawing.Point(866, 499);
            this.btnVender.Margin = new System.Windows.Forms.Padding(5);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(197, 56);
            this.btnVender.TabIndex = 60;
            this.btnVender.Text = "Vender ao Cliente";
            this.btnVender.UseVisualStyleBackColor = false;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // FormVendaItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 818);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormVendaItens";
            this.Text = "FormVendaItens";
            this.Load += new System.EventHandler(this.FormVendaItens_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrinho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.ComboBox cbCPF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCarrinho;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddNoCarrinho;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.TextBox txtProdutoID;
        private System.Windows.Forms.MaskedTextBox txtQuantidadeItens;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelecionaCliente;
    }
}