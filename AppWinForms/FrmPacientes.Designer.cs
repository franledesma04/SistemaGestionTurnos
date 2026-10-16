namespace AppWinForms
{
    partial class FrmPacientes
    {
        private System.ComponentModel.IContainer components = null;

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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellido = new Label();
            txtApellido = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblFechaNacimiento = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvPacientes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).BeginInit();
            SuspendLayout();
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 23);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(130, 20);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(210, 23);
            //
            // lblApellido
            //
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(380, 23);
            lblApellido.Name = "lblApellido";
            lblApellido.Text = "Apellido";
            //
            // txtApellido
            //
            txtApellido.Location = new Point(490, 20);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(210, 23);
            //
            // lblDni
            //
            lblDni.AutoSize = true;
            lblDni.Location = new Point(20, 63);
            lblDni.Name = "lblDni";
            lblDni.Text = "DNI";
            //
            // txtDni
            //
            txtDni.Location = new Point(130, 60);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(210, 23);
            //
            // lblTelefono
            //
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(380, 63);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Text = "Teléfono";
            //
            // txtTelefono
            //
            txtTelefono.Location = new Point(490, 60);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(210, 23);
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 103);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(130, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(210, 23);
            //
            // lblFechaNacimiento
            //
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(380, 103);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Text = "Fecha de nac.";
            //
            // dtpFechaNacimiento
            //
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(490, 100);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(210, 23);
            //
            // btnNuevo
            //
            btnNuevo.Location = new Point(20, 145);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(100, 32);
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            //
            // btnGuardar
            //
            btnGuardar.Location = new Point(130, 145);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 32);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnEliminar
            //
            btnEliminar.Location = new Point(240, 145);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 32);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            //
            // lblBuscar
            //
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(380, 153);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Text = "Buscar";
            //
            // txtBuscar
            //
            txtBuscar.Location = new Point(490, 150);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Nombre, apellido o DNI";
            txtBuscar.Size = new Size(210, 23);
            //
            // btnBuscar
            //
            btnBuscar.Location = new Point(710, 145);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 32);
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            //
            // dgvPacientes
            //
            dgvPacientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPacientes.Location = new Point(20, 195);
            dgvPacientes.Name = "dgvPacientes";
            dgvPacientes.Size = new Size(860, 345);
            dgvPacientes.SelectionChanged += dgvPacientes_SelectionChanged;
            //
            // FrmPacientes
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 560);
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblApellido);
            Controls.Add(txtApellido);
            Controls.Add(lblDni);
            Controls.Add(txtDni);
            Controls.Add(lblTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(dgvPacientes);
            Name = "FrmPacientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Pacientes";
            Load += FrmPacientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPacientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellido;
        private TextBox txtApellido;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblFechaNacimiento;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvPacientes;
    }
}
