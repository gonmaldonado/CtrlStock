using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Control_Alta_de_Stock
{
    public partial class finish_good_control : Form
    {
        Espere procesando = new Espere();


        public void LlenarTablas(string dia)
        {






            grbFinishgood.Visible = false;
            grbRegistros.Visible = false;


            if (rdbUnidades.Checked)
            {
                dgvMañana.DataSource = Logica.Consultas.TraerContadorM(dia);
                dgvMañana.ClearSelection();
                dgvTarde.DataSource = Logica.Consultas.TraerContadorT(dia);
                dgvTarde.ClearSelection();
                dgvTotal.DataSource = Logica.Consultas.TraerContador(dia);
                dgvTotal.ClearSelection();

            }
            else
            {
                dgvMañana.DataSource = Logica.Consultas.TraerDolliesM(dia);
                dgvMañana.ClearSelection();
                dgvTarde.DataSource = Logica.Consultas.TraerDolliesT(dia);
                dgvTarde.ClearSelection();
                dgvTotal.DataSource = Logica.Consultas.TraerDollies(dia);
                dgvTotal.ClearSelection();

            }

            dgvMovimientos.DataSource = Logica.Consultas.TraerRegistros(dia);
            grbFinishgood.Visible = true;
            grbRegistros.Visible = true;


        }
        public finish_good_control()
        {

            InitializeComponent();
            LlenarComboModelos();

            rdbUnidades.Checked = true;


        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

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

        private void finish_good_control_Load(object sender, EventArgs e)
        {
            //LlenarTablas(dtpDia.Text);


        }

        private void grbFinishgood_Enter(object sender, EventArgs e)
        {

        }

        private void dgvFinisgood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rdbUnidades_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbdollies_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtpDia_ValueChanged(object sender, EventArgs e)
        {


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

            LlenarTablas(dtpDia.Text);

        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1, dt2, dt5, dt6;
            dt1 = Logica.Consultas.TraerContadorM(dtpDia.Text);
            dt2 = Logica.Consultas.TraerRegistros(dtpDia.Text);
            dt5 = Logica.Consultas.TraerContadorT(dtpDia.Text);
            dt6 = Logica.Consultas.TraerContador(dtpDia.Text);

            if (cboModelo.Text.Trim() == "")
            {
                LlenarTablas(dtpDia.Text);
            }
            else
            {
                DataView dv1 = dt1.DefaultView;
                DataView dv2 = dt2.DefaultView;
                DataView dv5 = dt5.DefaultView;
                DataView dv6 = dt6.DefaultView;

                dv1.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv2.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv5.RowFilter = " MODELO = '" + cboModelo.Text + "'";
                dv6.RowFilter = " MODELO = '" + cboModelo.Text + "'";

                dgvMañana.DataSource = dv1;
                dgvTarde.DataSource = dv5;
                dgvTotal.DataSource = dv6;
                dgvMovimientos.DataSource = dv2;



            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbActivar.Checked)
            {
                groupBox1.Enabled = false;

                LlenarTablas(DateTime.Today.ToShortDateString());

                timer1.Start();
            }
            else
            {
                groupBox1.Enabled = true;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LlenarTablas(DateTime.Today.ToShortDateString());
        }

        private void cboModelo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            cboModelo.Text = "";

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            LlenarTablas(dtpDia.Text);
            cboModelo.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dtpDia.Text = DateTime.Today.ToShortDateString();
            cboModelo.Text = "";
            ckbActivar.Checked = false;
            LlenarTablas(dtpDia.Text);
        }
    }
}
