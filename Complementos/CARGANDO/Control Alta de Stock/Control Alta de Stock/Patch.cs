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
    public partial class Patch : Form
    {
        public Patch()
        {
            InitializeComponent();
           
        }

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (cboModelo.Text == "")
            {

                
            }
            else
            {
                Logica.Consultas.Armado(cboModelo.Text);
                Logica.Consultas.CargarRegistro(cboModelo.Text);
                Close();
            }
           
        }

        private void Patch_Load(object sender, EventArgs e)
        {
            Form1.f1.Enabled = false;
            LlenarComboModelos();
         
        }
        public void LlenarComboModelos()
        {
            DataTable df = Logica.Consultas.ListarPatch();
            cboModelo.DataSource = df;
            cboModelo.DisplayMember = "Modelo";
            cboModelo.ValueMember = "ID";
            DataRow dr = df.NewRow();
            dr["ID"] = "";
            df.Rows.InsertAt(dr, 0);
            this.cboModelo.SelectedValue = 0;
            this.cboModelo.SelectedIndexChanged += new System.EventHandler(this.cboModelo_SelectedIndexChanged);


        }

        private void Patch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.f1.Enabled = true;
        }
    }
}
