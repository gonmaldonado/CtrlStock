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
    public partial class Procesando : Form
    {
        public Procesando()
        {
            InitializeComponent();
            textBox1.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            timer2.Start();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = true;
           
            timer3.Start();
            timer2.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            lbl1.Visible = false;
            lbl2.Visible = true;
            lbl3.Visible = false;
            timer1.Start();
            timer3.Stop();
        }

        private void Procesando_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            timer4.Start();
            timer1.Start();
           
            
           label1.Visible = false;
            label1.Visible = true;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "WQW")
            {
                Close();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("WQW");//con esto cierro la ventana caragando
        }
    }
}
