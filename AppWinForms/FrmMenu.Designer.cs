namespace AppWinForms
{
    partial class FrmMenu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnProfesionales;
        private System.Windows.Forms.Button btnEspecialidades;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnReportes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();

            btnPacientes = new System.Windows.Forms.Button();
            btnProfesionales = new System.Windows.Forms.Button();
            btnEspecialidades = new System.Windows.Forms.Button();
            btnTurnos = new System.Windows.Forms.Button();
            btnReportes = new System.Windows.Forms.Button();

            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.Font = new System.Drawing.Font(
                "Segoe UI", 17F, System.Drawing.FontStyle.Bold);

            lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            lblTitulo.Location = new System.Drawing.Point(25, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(450, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Sistema de Gestión de Turnos";
            lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            lblSubtitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            lblSubtitulo.Location = new System.Drawing.Point(40, 80);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(420, 25);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Seleccione una opción:";
            lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnPacientes
            // 
            btnPacientes.BackColor = System.Drawing.Color.SteelBlue;
            btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPacientes.FlatAppearance.BorderSize = 0;
            btnPacientes.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            btnPacientes.ForeColor = System.Drawing.Color.White;
            btnPacientes.Location = new System.Drawing.Point(100, 120);
            btnPacientes.Name = "btnPacientes";
            btnPacientes.Size = new System.Drawing.Size(300, 40);
            btnPacientes.TabIndex = 2;
            btnPacientes.Text = "Gestionar Pacientes";
            btnPacientes.UseVisualStyleBackColor = false;
            btnPacientes.Click += new System.EventHandler(btnPacientes_Click);

            // 
            // btnProfesionales
            // 
            btnProfesionales.BackColor = System.Drawing.Color.SteelBlue;
            btnProfesionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProfesionales.FlatAppearance.BorderSize = 0;
            btnProfesionales.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            btnProfesionales.ForeColor = System.Drawing.Color.White;
            btnProfesionales.Location = new System.Drawing.Point(100, 175);
            btnProfesionales.Name = "btnProfesionales";
            btnProfesionales.Size = new System.Drawing.Size(300, 40);
            btnProfesionales.TabIndex = 3;
            btnProfesionales.Text = "Gestionar Profesionales";
            btnProfesionales.UseVisualStyleBackColor = false;
            btnProfesionales.Click += new System.EventHandler(btnProfesionales_Click);

            // 
            // btnEspecialidades
            // 
            btnEspecialidades.BackColor = System.Drawing.Color.SteelBlue;
            btnEspecialidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEspecialidades.FlatAppearance.BorderSize = 0;
            btnEspecialidades.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            btnEspecialidades.ForeColor = System.Drawing.Color.White;
            btnEspecialidades.Location = new System.Drawing.Point(100, 230);
            btnEspecialidades.Name = "btnEspecialidades";
            btnEspecialidades.Size = new System.Drawing.Size(300, 40);
            btnEspecialidades.TabIndex = 4;
            btnEspecialidades.Text = "Gestionar Especialidades";
            btnEspecialidades.UseVisualStyleBackColor = false;
            btnEspecialidades.Click += new System.EventHandler(btnEspecialidades_Click);

            // 
            // btnTurnos
            // 
            btnTurnos.BackColor = System.Drawing.Color.SteelBlue;
            btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTurnos.FlatAppearance.BorderSize = 0;
            btnTurnos.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            btnTurnos.ForeColor = System.Drawing.Color.White;
            btnTurnos.Location = new System.Drawing.Point(100, 285);
            btnTurnos.Name = "btnTurnos";
            btnTurnos.Size = new System.Drawing.Size(300, 40);
            btnTurnos.TabIndex = 5;
            btnTurnos.Text = "Gestionar Turnos";
            btnTurnos.UseVisualStyleBackColor = false;
            btnTurnos.Click += new System.EventHandler(btnTurnos_Click);

            // 
            // btnReportes
            // 
            btnReportes.BackColor = System.Drawing.Color.SteelBlue;
            btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.Font = new System.Drawing.Font(
                "Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            btnReportes.ForeColor = System.Drawing.Color.White;
            btnReportes.Location = new System.Drawing.Point(100, 340);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new System.Drawing.Size(300, 40);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "Consultar Reportes";
            btnReportes.UseVisualStyleBackColor = false;
            btnReportes.Click += new System.EventHandler(btnReportes_Click);

            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            ClientSize = new System.Drawing.Size(500, 410);

            Controls.Add(lblTitulo);
            Controls.Add(lblSubtitulo);
            Controls.Add(btnPacientes);
            Controls.Add(btnProfesionales);
            Controls.Add(btnEspecialidades);
            Controls.Add(btnTurnos);
            Controls.Add(btnReportes);

            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMenu";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sistema de Gestión de Turnos";

            ResumeLayout(false);
        }

        #endregion
    }
}

