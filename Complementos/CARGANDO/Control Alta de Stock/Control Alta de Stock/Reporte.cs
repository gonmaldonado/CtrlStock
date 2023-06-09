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
    public partial class Reporte : Form
    {
        DataTable dt;

        public Reporte()
        {
           
            InitializeComponent();
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
           
        }

        private void btnReporte_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void btnReporte_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void btnReporte_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpDesde.Format = DateTimePickerFormat.Custom;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            dtpHasta.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dtpDesde.Text) > Convert.ToDateTime(dtpHasta.Text))
            {
                MessageBox.Show("DATOS INCORECTOS", "ERROR", MessageBoxButtons.OK);
                dtpHasta.Text = DateTime.Now.ToString();
                dtpDesde.Text = DateTime.Now.ToString();
            }
            else
            {
                if (radioButton1.Checked)
                {
                    dgvReporte.DataSource = Logica.Consultas.Reporte3(dtpDesde.Text, dtpHasta.Text);
                    dt = Logica.Consultas.Reporte3(dtpDesde.Text, dtpHasta.Text);
                }
                else
                { dgvReporte.DataSource = Logica.Consultas.Reporte4(dtpDesde.Text, dtpHasta.Text);
                dt= Logica.Consultas.Reporte4(dtpDesde.Text, dtpHasta.Text);
                }
                dgvReporte.ClearSelection();
                LlenarComboModelos();
                cboModelo.Enabled = true;
                btnDeshacer.Enabled = true;

            }
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
            this.cboModelo.SelectedIndexChanged += new System.EventHandler(this.cboModelo_SelectedIndexChanged);


        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            Form1.f1.Enabled = false;
            
            cboModelo.Enabled = false;
            btnDeshacer.Enabled = false;

            radioButton1.Select();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            dgvReporte.DataSource = "";
            cboModelo.Enabled = false;
            btnDeshacer.Enabled = false;
            dtpHasta.Text = hoy.ToShortDateString();
            dtpDesde.Text = hoy.ToShortDateString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModelo.Text.Trim() == "")
            {
                if (radioButton1.Checked)
                {
                    dgvReporte.DataSource = Logica.Consultas.Reporte3(dtpDesde.Text, dtpHasta.Text);
                    dt = Logica.Consultas.Reporte3(dtpDesde.Text, dtpHasta.Text);
                }
                else
                {
                    dgvReporte.DataSource = Logica.Consultas.Reporte4(dtpDesde.Text, dtpHasta.Text);
                    dt = Logica.Consultas.Reporte4(dtpDesde.Text, dtpHasta.Text);
                }
                dgvReporte.ClearSelection();
            }
            else
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dgvReporte.DataSource = dv;
            }

        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            cboModelo.Text = "";
            if (radioButton1.Checked)
            {
                dgvReporte.DataSource = Logica.Consultas.Reporte3(dtpDesde.Text, dtpHasta.Text);
                dt = Logica.Consultas.Reporte3(dtpDesde.Text, dtpHasta.Text);
            }
            else
            {
                dgvReporte.DataSource = Logica.Consultas.Reporte4(dtpDesde.Text, dtpHasta.Text);
                dt = Logica.Consultas.Reporte4(dtpDesde.Text, dtpHasta.Text);
            }
            dgvReporte.ClearSelection();
        }

        private void Reporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.f1.Enabled = true;
        }
    }
}
