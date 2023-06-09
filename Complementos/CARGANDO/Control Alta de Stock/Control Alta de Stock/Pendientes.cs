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
    public partial class Pendientes : Form
    {
        public Pendientes()
        {
            InitializeComponent();
        }

        private void Pendientes_Load(object sender, EventArgs e)
        {
            Form1.f1.Enabled = false;
            dgvPendientes.DataSource = Logica.Consultas.TraerPendientesDeArmados();
            dgvPendientes.ClearSelection();
        }

        private void Pendientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.f1.Enabled = true;
        }
    }
}
