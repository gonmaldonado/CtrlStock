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
    public partial class Codigos : Form
    {
        Procesando pro = new Procesando();
        DataTable dt1, dt2;

        public Codigos()
        {
            InitializeComponent();
        }

        private void Codigos_Load(object sender, EventArgs e)
        {
            pro.Show();
            pro.Visible = false;
            Form1.f1.Enabled = false;
            pro.Visible = true;
            Enabled = false;
            TopMost = false;
            BackgroundWorker tarea = new BackgroundWorker();
            tarea.DoWork += CargarformStock;
            tarea.RunWorkerCompleted += abrirformStock;
            tarea.RunWorkerAsync();
          

        }

        private void txtBuscarx_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscarx.Text != "")
            {
                DataTable dt;
            dt = Logica.Consultas.TraerGeneral();
            DataView dv = dt.DefaultView;
           
                try
                {
                    dv.RowFilter = cboBuscarx.Text + " like '%" + txtBuscarx.Text.Trim() + "%'";
                }
                catch { }
                dgvGeneral.DataSource = dv;
            }
        }

        private void cboBuscarx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscarx.Text.Trim() == "")
            {
                dgvGeneral.DataSource = Logica.Consultas.TraerGeneral();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbo1.Text != "")
            {
                DataTable dt;
                dt = Logica.Consultas.TraerDoor();
                DataView dv = dt.DefaultView;

                try
                {
                    dv.RowFilter = cbo1.Text + " like '%" + textBox1.Text.Trim() + "%'";
                }
                catch { }
                dgvDoor.DataSource = dv;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo1.Text.Trim() == "")
            {
                dgvDoor.DataSource = Logica.Consultas.TraerDoor();
            }
        }

        private void Codigos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.f1.Enabled = true;
            
        }
        public void CargarformStock(object o, DoWorkEventArgs e)
        {

            dt2 = Logica.Consultas.TraerGeneral();
           dt1 = Logica.Consultas.TraerDoor();
            


        }

        public void abrirformStock(object o, RunWorkerCompletedEventArgs e)
        {
            dgvGeneral.DataSource =dt2;
            dgvDoor.DataSource =dt1;
           
            pro.Close();
            Enabled = true;
            TopMost = true;


        }

    }
}
