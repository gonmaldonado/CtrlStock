namespace Control_Alta_de_Stock
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvMañana = new System.Windows.Forms.DataGridView();
            this.dgvTotal = new System.Windows.Forms.DataGridView();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.dtpDia = new System.Windows.Forms.DateTimePicker();
            this.dgvTarde = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvSet = new System.Windows.Forms.DataGridView();
            this.txtBuscarx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDmañana = new System.Windows.Forms.DataGridView();
            this.dgvDtotal = new System.Windows.Forms.DataGridView();
            this.dgvDtarde = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboBuscarx = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboModelo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnPendientes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUltimoArmado = new System.Windows.Forms.Label();
            this.lblUltumo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMañana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmañana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtarde)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMañana
            // 
            this.dgvMañana.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvMañana.AllowUserToAddRows = false;
            this.dgvMañana.AllowUserToDeleteRows = false;
            this.dgvMañana.AllowUserToResizeColumns = false;
            this.dgvMañana.AllowUserToResizeRows = false;
            this.dgvMañana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMañana.Location = new System.Drawing.Point(6, 36);
            this.dgvMañana.Name = "dgvMañana";
            this.dgvMañana.ReadOnly = true;
            this.dgvMañana.RowHeadersVisible = false;
            this.dgvMañana.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvMañana.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMañana.Size = new System.Drawing.Size(232, 289);
            this.dgvMañana.TabIndex = 1;
            this.dgvMañana.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMañana_CellContentClick);
            // 
            // dgvTotal
            // 
            this.dgvTotal.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvTotal.AllowUserToAddRows = false;
            this.dgvTotal.AllowUserToDeleteRows = false;
            this.dgvTotal.AllowUserToResizeColumns = false;
            this.dgvTotal.AllowUserToResizeRows = false;
            this.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotal.Location = new System.Drawing.Point(482, 36);
            this.dgvTotal.Name = "dgvTotal";
            this.dgvTotal.ReadOnly = true;
            this.dgvTotal.RowHeadersVisible = false;
            this.dgvTotal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotal.Size = new System.Drawing.Size(232, 289);
            this.dgvTotal.TabIndex = 3;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AllowUserToResizeColumns = false;
            this.dgvMovimientos.AllowUserToResizeRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(6, 13);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(330, 312);
            this.dgvMovimientos.TabIndex = 4;
            // 
            // dtpDia
            // 
            this.dtpDia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDia.Location = new System.Drawing.Point(327, 12);
            this.dtpDia.MinDate = new System.DateTime(2017, 10, 13, 0, 0, 0, 0);
            this.dtpDia.Name = "dtpDia";
            this.dtpDia.Size = new System.Drawing.Size(105, 20);
            this.dtpDia.TabIndex = 9;
            this.dtpDia.ValueChanged += new System.EventHandler(this.dtpDia_ValueChanged);
            // 
            // dgvTarde
            // 
            this.dgvTarde.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvTarde.AllowUserToAddRows = false;
            this.dgvTarde.AllowUserToDeleteRows = false;
            this.dgvTarde.AllowUserToResizeColumns = false;
            this.dgvTarde.AllowUserToResizeRows = false;
            this.dgvTarde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarde.Location = new System.Drawing.Point(244, 36);
            this.dgvTarde.Name = "dgvTarde";
            this.dgvTarde.ReadOnly = true;
            this.dgvTarde.RowHeadersVisible = false;
            this.dgvTarde.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTarde.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTarde.Size = new System.Drawing.Size(232, 289);
            this.dgvTarde.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(1157, 44);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(89, 42);
            this.btnReporte.TabIndex = 18;
            this.btnReporte.Text = "REPORTE DE CANTIDADES";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 31);
            this.label1.TabIndex = 19;
            this.label1.Text = "FECHA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "TURNO MAÑANA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(295, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "TURNO TARDE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(561, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 22;
            this.label4.Text = "TOTAL";
            // 
            // dgvSet
            // 
            this.dgvSet.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvSet.AllowUserToAddRows = false;
            this.dgvSet.AllowUserToDeleteRows = false;
            this.dgvSet.AllowUserToResizeColumns = false;
            this.dgvSet.AllowUserToResizeRows = false;
            this.dgvSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSet.Location = new System.Drawing.Point(5, 38);
            this.dgvSet.Name = "dgvSet";
            this.dgvSet.ReadOnly = true;
            this.dgvSet.RowHeadersVisible = false;
            this.dgvSet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSet.Size = new System.Drawing.Size(479, 278);
            this.dgvSet.TabIndex = 24;
            this.dgvSet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSet_CellContentClick);
            // 
            // txtBuscarx
            // 
            this.txtBuscarx.Location = new System.Drawing.Point(237, 12);
            this.txtBuscarx.Name = "txtBuscarx";
            this.txtBuscarx.Size = new System.Drawing.Size(199, 20);
            this.txtBuscarx.TabIndex = 37;
            this.txtBuscarx.TextChanged += new System.EventHandler(this.txtBuscarx_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(561, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 43;
            this.label7.Text = "TOTAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(295, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "TURNO TARDE";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(50, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "TURNO MAÑANA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMañana);
            this.groupBox1.Controls.Add(this.dgvTotal);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvTarde);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(52, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 336);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FINISH GOOD";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDmañana);
            this.groupBox2.Controls.Add(this.dgvDtotal);
            this.groupBox2.Controls.Add(this.dgvDtarde);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(52, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 328);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DOLLIES/CAJAS";
            // 
            // dgvDmañana
            // 
            this.dgvDmañana.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvDmañana.AllowUserToAddRows = false;
            this.dgvDmañana.AllowUserToDeleteRows = false;
            this.dgvDmañana.AllowUserToResizeColumns = false;
            this.dgvDmañana.AllowUserToResizeRows = false;
            this.dgvDmañana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDmañana.Location = new System.Drawing.Point(6, 38);
            this.dgvDmañana.Name = "dgvDmañana";
            this.dgvDmañana.ReadOnly = true;
            this.dgvDmañana.RowHeadersVisible = false;
            this.dgvDmañana.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDmañana.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDmañana.Size = new System.Drawing.Size(232, 278);
            this.dgvDmañana.TabIndex = 44;
            // 
            // dgvDtotal
            // 
            this.dgvDtotal.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvDtotal.AllowUserToAddRows = false;
            this.dgvDtotal.AllowUserToDeleteRows = false;
            this.dgvDtotal.AllowUserToResizeColumns = false;
            this.dgvDtotal.AllowUserToResizeRows = false;
            this.dgvDtotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDtotal.Location = new System.Drawing.Point(482, 38);
            this.dgvDtotal.Name = "dgvDtotal";
            this.dgvDtotal.ReadOnly = true;
            this.dgvDtotal.RowHeadersVisible = false;
            this.dgvDtotal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDtotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtotal.Size = new System.Drawing.Size(232, 278);
            this.dgvDtotal.TabIndex = 46;
            // 
            // dgvDtarde
            // 
            this.dgvDtarde.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dgvDtarde.AllowUserToAddRows = false;
            this.dgvDtarde.AllowUserToDeleteRows = false;
            this.dgvDtarde.AllowUserToResizeColumns = false;
            this.dgvDtarde.AllowUserToResizeRows = false;
            this.dgvDtarde.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDtarde.Location = new System.Drawing.Point(244, 38);
            this.dgvDtarde.Name = "dgvDtarde";
            this.dgvDtarde.ReadOnly = true;
            this.dgvDtarde.RowHeadersVisible = false;
            this.dgvDtarde.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDtarde.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDtarde.Size = new System.Drawing.Size(232, 278);
            this.dgvDtarde.TabIndex = 45;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvMovimientos);
            this.groupBox3.Location = new System.Drawing.Point(780, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 336);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "REGISTROS";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboBuscarx);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtBuscarx);
            this.groupBox4.Controls.Add(this.dgvSet);
            this.groupBox4.Location = new System.Drawing.Point(780, 374);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(490, 328);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MODELO";
            // 
            // cboBuscarx
            // 
            this.cboBuscarx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarx.FormattingEnabled = true;
            this.cboBuscarx.Items.AddRange(new object[] {
            "",
            "MODELO",
            "CODIGO",
            "HR",
            "AR"});
            this.cboBuscarx.Location = new System.Drawing.Point(155, 12);
            this.cboBuscarx.Name = "cboBuscarx";
            this.cboBuscarx.Size = new System.Drawing.Size(76, 21);
            this.cboBuscarx.TabIndex = 48;
            this.cboBuscarx.SelectedIndexChanged += new System.EventHandler(this.cboBuscarx_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 16);
            this.label6.TabIndex = 44;
            this.label6.Text = "BUSCAR POR:";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // cboModelo
            // 
            this.cboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.Location = new System.Drawing.Point(593, 11);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(76, 21);
            this.cboModelo.TabIndex = 47;
            this.cboModelo.SelectedIndexChanged += new System.EventHandler(this.cboModelo_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(450, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 31);
            this.label5.TabIndex = 48;
            this.label5.Text = "MODELO";
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(675, 11);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(75, 21);
            this.btnDeshacer.TabIndex = 49;
            this.btnDeshacer.Text = "DESHACER";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(756, 11);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(86, 21);
            this.btnActualizar.TabIndex = 50;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnPendientes
            // 
            this.btnPendientes.Location = new System.Drawing.Point(1157, 92);
            this.btnPendientes.Name = "btnPendientes";
            this.btnPendientes.Size = new System.Drawing.Size(89, 42);
            this.btnPendientes.TabIndex = 51;
            this.btnPendientes.Text = "PENDIENTES DE ARMADO TANGO";
            this.btnPendientes.UseVisualStyleBackColor = true;
            this.btnPendientes.Click += new System.EventHandler(this.btnPendientes_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1157, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 26);
            this.button1.TabIndex = 52;
            this.button1.Text = "CODIGOS SAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(859, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(267, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "ÚLTIMO PROCESO DE ARMADO EN TANGO:";
            // 
            // lblUltimoArmado
            // 
            this.lblUltimoArmado.AutoSize = true;
            this.lblUltimoArmado.ForeColor = System.Drawing.Color.Red;
            this.lblUltimoArmado.Location = new System.Drawing.Point(1132, 14);
            this.lblUltimoArmado.Name = "lblUltimoArmado";
            this.lblUltimoArmado.Size = new System.Drawing.Size(0, 13);
            this.lblUltimoArmado.TabIndex = 54;
            // 
            // lblUltumo
            // 
            this.lblUltumo.AutoSize = true;
            this.lblUltumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltumo.ForeColor = System.Drawing.Color.Red;
            this.lblUltumo.Location = new System.Drawing.Point(1125, 14);
            this.lblUltumo.Name = "lblUltumo";
            this.lblUltumo.Size = new System.Drawing.Size(7, 13);
            this.lblUltumo.TabIndex = 55;
            this.lblUltumo.Text = "\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1157, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 47);
            this.button2.TabIndex = 56;
            this.button2.Text = "ALTA DE PATCH";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1157, 172);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 26);
            this.button3.TabIndex = 57;
            this.button3.Text = "STOCK ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1285, 729);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblUltumo);
            this.Controls.Add(this.lblUltimoArmado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPendientes);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboModelo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Finish Good";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMañana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDmañana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDtarde)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMañana;
        private System.Windows.Forms.DataGridView dgvTotal;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DateTimePicker dtpDia;
        private System.Windows.Forms.DataGridView dgvTarde;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvSet;
        private System.Windows.Forms.TextBox txtBuscarx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDmañana;
        private System.Windows.Forms.DataGridView dgvDtotal;
        private System.Windows.Forms.DataGridView dgvDtarde;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cboModelo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBuscarx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnPendientes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblUltimoArmado;
        private System.Windows.Forms.Label lblUltumo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

