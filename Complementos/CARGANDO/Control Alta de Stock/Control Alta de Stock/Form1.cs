using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Control_Alta_de_Stock
{

    public partial class Form1 : Form
    {
       
        public static Form1 f1;
        

        public Form1()
        {
            InitializeComponent();
            Enabled = false;
          



        }
        public void Cargarforminicio(object o, DoWorkEventArgs e)
        {
            
        }

        public void abrirforminicio(object o, RunWorkerCompletedEventArgs e)
        {
            TopMost = true;
            Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1.f1 = this;
            DateTime hoy = DateTime.Today;
            dtpDia.Text = hoy.ToShortDateString();
            LlenarComboModelos();
            LlenarTablas(dtpDia.Text);
            BackgroundWorker tarea = new BackgroundWorker();
            tarea.DoWork += Cargarforminicio;
            tarea.RunWorkerCompleted += abrirforminicio;
            tarea.RunWorkerAsync();
        }
        public void LlenarComboModelos()
        {
            DataTable df = Logica.Consultas.ListarModelos();
            cboModelo.DataSource = df;
            cboModelo.DisplayMember = "Modelo";
            cboModelo.ValueMember = "NOMBRE";
            DataRow dr = df.NewRow();
            dr["NOMBRE"] = "";
            df.Rows.InsertAt(dr, 0);
            this.cboModelo.SelectedValue = 0;
            this.cboModelo.SelectedIndexChanged += new System.EventHandler(this.cboModelo_SelectedIndexChanged_1);


        }
        public void LlenarTablas(string dia)
        {
            Cursor.Current = Cursors.WaitCursor;
            dgvMañana.DataSource = Logica.Consultas.TraerContadorM(dia);
            dgvMañana.ClearSelection();
            dgvDtarde.DataSource = Logica.Consultas.TraerDolliesT(dia);
            dgvDtarde.ClearSelection();
            dgvDmañana.DataSource = Logica.Consultas.TraerDolliesM(dia);
            dgvDmañana.ClearSelection();
            dgvDtotal.DataSource = Logica.Consultas.TraerDollies(dia);
            dgvDtotal.ClearSelection();
            dgvTarde.DataSource = Logica.Consultas.TraerContadorT(dia);
            dgvTarde.ClearSelection();
            dgvTotal.DataSource = Logica.Consultas.TraerContador(dia);
            dgvTotal.ClearSelection();
            dgvSet.DataSource = Logica.Consultas.TraerSetXModelo(dia);
            dgvSet.ClearSelection();
            dgvMovimientos.DataSource = Logica.Consultas.TraerRegistros(dia);
            lblUltumo.Text = Logica.Consultas.TraerUltimoArmado();
            Cursor.Current = Cursors.Arrow;
        }

        private void dtpDia_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime hoy = DateTime.Today;
                dtpDia.Format = DateTimePickerFormat.Custom;
                if (Convert.ToDateTime(dtpDia.Value.ToShortDateString()) == hoy)
                {
                    timer1.Start();
                    LlenarTablas(dtpDia.Text);
                }
                else
                {
                    timer1.Stop();
                    LlenarTablas(dtpDia.Text);
                }
            }
            catch { }

        }

        private void dgvMañana_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ptbFecha_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LlenarTablas(dtpDia.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblReporte_Click(object sender, EventArgs e)
        {
            Reporte report = new Reporte();
            report.Show();
        }

        private void lblReporte_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblReporte_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Reporte report = new Reporte();
            report.Show();
        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarTablas(dtpDia.Text);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void dgvSet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            cboModelo.Text = "";
            LlenarTablas(dtpDia.Text);
            Cursor.Current = Cursors.Arrow;
        }

        private void txtBuscarx_TextChanged(object sender, EventArgs e)
        {

            if (cboBuscarx.Text != "")
            {
                DataTable dt;

                dt = Logica.Consultas.TraerSetXModelo(dtpDia.Text);
                DataView dv = dt.DefaultView;

                try { dv.RowFilter = cboBuscarx.Text + " like '%" + txtBuscarx.Text.Trim() + "%'"; }
                catch { }
                dgvSet.DataSource = dv;
            }
        }

        private void cboBuscarx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscarx.Text.Trim() == "")
            {
                dgvSet.DataSource = Logica.Consultas.TraerSetXModelo(dtpDia.Text);
            }
        }
    


        private void cboModelo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;


            if (cboModelo.Text.Trim() == "")
            {
                LlenarTablas(dtpDia.Text);
            }
            else
            {
                CargarTablasBuscar();

            }
            Cursor.Current = Cursors.Arrow;
        }
        public void CargarTablasBuscar ()
        {
            DataTable dt1, dt2, dt3, dt4, dt5, dt6, dt7;
            dt1 = Logica.Consultas.TraerContadorM(dtpDia.Text);
            dt2 = Logica.Consultas.TraerDolliesT(dtpDia.Text);
            dt3 = Logica.Consultas.TraerDolliesM(dtpDia.Text);
            dt4 = Logica.Consultas.TraerDollies(dtpDia.Text);
            dt5 = Logica.Consultas.TraerContadorT(dtpDia.Text);
            dt6 = Logica.Consultas.TraerContador(dtpDia.Text);
            dt7 = Logica.Consultas.TraerRegistros(dtpDia.Text);
           
                DataView dv1 = dt1.DefaultView;
                DataView dv2 = dt2.DefaultView;
                DataView dv3 = dt3.DefaultView;
                DataView dv4 = dt4.DefaultView;
                DataView dv5 = dt5.DefaultView;
                DataView dv6 = dt6.DefaultView;
                DataView dv7 = dt7.DefaultView;
                dv1.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv2.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv3.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv4.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv5.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv6.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv7.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dgvMañana.DataSource = dv1;
                dgvDtarde.DataSource = dv2;
                dgvDmañana.DataSource = dv3;
                dgvDtotal.DataSource = dv4;
                dgvTarde.DataSource = dv5;
                dgvTotal.DataSource = dv6;
                dgvMovimientos.DataSource = dv7;


            

        }
      

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime hoy = DateTime.Today;
            txtBuscarx.Clear();
            cboBuscarx.Text = "";
            cboModelo.Text = "";
            dtpDia.Text = hoy.ToShortDateString();
            LlenarTablas(dtpDia.Text);
            Cursor.Current = Cursors.Arrow;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {

            Pendientes report = new Pendientes();
            report.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Codigos report = new Codigos();
            report.Show();

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form patch = new Patch();
            patch.Show();
        }
      

        public void button3_Click(object sender, EventArgs e)
        {
   
            Stock st = new Stock();
            st.Show();
        
         
          







        }
    }
}
