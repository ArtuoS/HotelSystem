namespace HotelManagementSystem
{
    partial class FormCheckIn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDataAtual = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClienteNome = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvQuartos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuartoID = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataSaidaPrevista = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.txtCheckInID = new System.Windows.Forms.TextBox();
            this.dgvCheckIn = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuartos)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckIn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(96)))), ((int)(((byte)(206)))));
            this.panel1.Controls.Add(this.txtDataAtual);
            this.panel1.Controls.Add(this.btnCheckIn);
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 681);
            this.panel1.TabIndex = 0;
            // 
            // txtDataAtual
            // 
            this.txtDataAtual.Location = new System.Drawing.Point(972, 391);
            this.txtDataAtual.Margin = new System.Windows.Forms.Padding(4);
            this.txtDataAtual.Name = "txtDataAtual";
            this.txtDataAtual.ReadOnly = true;
            this.txtDataAtual.Size = new System.Drawing.Size(199, 25);
            this.txtDataAtual.TabIndex = 9;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.ForeColor = System.Drawing.Color.White;
            this.btnCheckIn.Location = new System.Drawing.Point(12, 449);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(198, 50);
            this.btnCheckIn.TabIndex = 79;
            this.btnCheckIn.Text = "Registrar Check-in";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1159, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(25, 28);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.Text = "X";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtClienteID);
            this.panel3.Controls.Add(this.dgvClientes);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtClienteNome);
            this.panel3.Location = new System.Drawing.Point(12, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1160, 170);
            this.panel3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(70, 92);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "ID";
            // 
            // txtClienteID
            // 
            this.txtClienteID.Location = new System.Drawing.Point(59, 116);
            this.txtClienteID.Margin = new System.Windows.Forms.Padding(4);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.ReadOnly = true;
            this.txtClienteID.Size = new System.Drawing.Size(46, 25);
            this.txtClienteID.TabIndex = 7;
            this.txtClienteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToDeleteRows = false;
            this.dgvClientes.AllowUserToResizeRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(154, 28);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.Size = new System.Drawing.Size(979, 116);
            this.dgvClientes.TabIndex = 6;
            this.dgvClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome do Cliente";
            // 
            // txtClienteNome
            // 
            this.txtClienteNome.Location = new System.Drawing.Point(24, 63);
            this.txtClienteNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtClienteNome.Name = "txtClienteNome";
            this.txtClienteNome.ReadOnly = true;
            this.txtClienteNome.Size = new System.Drawing.Size(112, 25);
            this.txtClienteNome.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel2.Controls.Add(this.dgvQuartos);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtQuartoID);
            this.panel2.Location = new System.Drawing.Point(12, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1160, 170);
            this.panel2.TabIndex = 7;
            // 
            // dgvQuartos
            // 
            this.dgvQuartos.AllowUserToDeleteRows = false;
            this.dgvQuartos.AllowUserToResizeRows = false;
            this.dgvQuartos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvQuartos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuartos.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvQuartos.Location = new System.Drawing.Point(154, 28);
            this.dgvQuartos.Name = "dgvQuartos";
            this.dgvQuartos.ReadOnly = true;
            this.dgvQuartos.Size = new System.Drawing.Size(979, 116);
            this.dgvQuartos.TabIndex = 6;
            this.dgvQuartos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuartos_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Número do Quarto";
            // 
            // txtQuartoID
            // 
            this.txtQuartoID.Location = new System.Drawing.Point(59, 83);
            this.txtQuartoID.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuartoID.Name = "txtQuartoID";
            this.txtQuartoID.ReadOnly = true;
            this.txtQuartoID.Size = new System.Drawing.Size(46, 25);
            this.txtQuartoID.TabIndex = 2;
            this.txtQuartoID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpDataSaidaPrevista);
            this.panel4.Location = new System.Drawing.Point(12, 390);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 52);
            this.panel4.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data de Saída Prevista";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDataSaidaPrevista
            // 
            this.dtpDataSaidaPrevista.Location = new System.Drawing.Point(154, 13);
            this.dtpDataSaidaPrevista.Name = "dtpDataSaidaPrevista";
            this.dtpDataSaidaPrevista.Size = new System.Drawing.Size(202, 25);
            this.dtpDataSaidaPrevista.TabIndex = 82;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.btnDeletar);
            this.panel5.Controls.Add(this.txtCheckInID);
            this.panel5.Controls.Add(this.dgvCheckIn);
            this.panel5.Location = new System.Drawing.Point(12, 506);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1014, 163);
            this.panel5.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(48)))), ((int)(((byte)(195)))));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(837, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "ID do Check-in";
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(144)))), ((int)(((byte)(217)))));
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(786, 90);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(198, 50);
            this.btnDeletar.TabIndex = 82;
            this.btnDeletar.Text = "Realizar Check-out";
            this.btnDeletar.UseVisualStyleBackColor = false;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // txtCheckInID
            // 
            this.txtCheckInID.Location = new System.Drawing.Point(866, 57);
            this.txtCheckInID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCheckInID.Name = "txtCheckInID";
            this.txtCheckInID.ReadOnly = true;
            this.txtCheckInID.Size = new System.Drawing.Size(46, 25);
            this.txtCheckInID.TabIndex = 9;
            this.txtCheckInID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvCheckIn
            // 
            this.dgvCheckIn.AllowUserToDeleteRows = false;
            this.dgvCheckIn.AllowUserToResizeRows = false;
            this.dgvCheckIn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCheckIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckIn.Location = new System.Drawing.Point(25, 24);
            this.dgvCheckIn.Name = "dgvCheckIn";
            this.dgvCheckIn.ReadOnly = true;
            this.dgvCheckIn.Size = new System.Drawing.Size(754, 116);
            this.dgvCheckIn.TabIndex = 9;
            this.dgvCheckIn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckIn_CellClick);
            // 
            // FormCheckIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormCheckIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCheckIn";
            this.Load += new System.EventHandler(this.FormCheckIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuartos)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuartoID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvQuartos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClienteNome;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.TextBox txtDataAtual;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvCheckIn;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCheckInID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataSaidaPrevista;
    }
}