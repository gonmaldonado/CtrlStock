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
    public partial class Stock : Form
    {
        Procesando pro = new Procesando();
        public static List<Entidades.Linea> lista = new List<Entidades.Linea>();
        public static List<Entidades.Linea> lista2 = new List<Entidades.Linea>();
        DataView dv;
        public Stock()
        {
            InitializeComponent();
           
          

        }

        private void Stock_Load(object sender, EventArgs e)
        {
            Form1.f1.Enabled = false;
            Enabled = false;
            lista.Clear();
            lista2.Clear();
            dgvGeneral.DataSource = null;
            BackgroundWorker tarea = new BackgroundWorker();
            tarea.DoWork += CargarformStock;
            tarea.RunWorkerCompleted += abrirformStock;
            tarea.RunWorkerAsync();
            pro.Show();
        


            //dgvGeneral.DataSource = Logica.Consultas.BDStock();




        }
        public  void ArmarStock()
        {
            for (int i = 0; i < Logica.Consultas.BDStock().Rows.Count; i++)
            {
                int Pendiente = 0;
                int Ajuste = 0;
                int Tango = 0;
                Entidades.Linea L = new Entidades.Linea();
                L.MODELO= Logica.Consultas.BDStock().Rows[i]["MODELO"].ToString().Trim();
              L.CODIGO =Logica.Consultas.BDStock().Rows[i]["CODIGO"].ToString().Trim();
              L.DESCRIPCION= Logica.Consultas.BDStock().Rows[i]["DESCRIPCION"].ToString().Trim();
                Pendiente = Logica.Consultas.Pendiente(L.CODIGO);
                Ajuste = Logica.Consultas.Ajuste(L.CODIGO); 
                Tango = Logica.Consultas.Tango(L.CODIGO);
                L.TANGO = Tango;
                L.PENDIENTE = Pendiente;
                L.AJUSTE = Ajuste*-1;
                L.STOCK = L.TANGO+L.PENDIENTE+L.AJUSTE;
              lista.Add(L);
            if(L.STOCK<0)
                { lista2.Add(L); }

            }
        }

        private void cboBuscarx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBuscarx.Text.Trim() == "")
            {
                if (checkBox1.Checked)
                {
                    dgvGeneral.DataSource = null;
                    dgvGeneral.DataSource = ConvertToDataTable(lista2);

                }
                else
                {
                    dgvGeneral.DataSource = null;
                    dgvGeneral.DataSource = ConvertToDataTable(lista);
                }

                
            }
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private void txtBuscarx_TextChanged(object sender, EventArgs e)
        {
            if (cboBuscarx.Text != "")
            {
                DataTable dt;

                if (checkBox1.Checked)
                {
                    dt = ConvertToDataTable(lista2);

                }
                else
                {
                    dt = ConvertToDataTable(lista);
                }

                DataView dv = dt.DefaultView;

                try { dv.RowFilter = cboBuscarx.Text + " like '%" + txtBuscarx.Text.Trim() + "%'"; }
                catch { }
                dgvGeneral.DataSource = dv;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
            dgvGeneral.DataSource = null;
            if (checkBox1.Checked)
            {
               dv = ConvertToDataTable(lista2).DefaultView;
                
            }
            else
            {
                dv = ConvertToDataTable(lista).DefaultView;
            }
            dgvGeneral.DataSource = dv;
        }
        public void CargarformStock(object o, DoWorkEventArgs e)
        {
            
            ArmarStock();


        }
   
        public  void abrirformStock(object o, RunWorkerCompletedEventArgs e)
        {
            dgvGeneral.DataSource = lista;
            pro.Close();
            TopMost = true;
            Enabled = true;

        }

        private void Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.f1.Enabled = true;
        }
    }
}
