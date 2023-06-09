using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace ControldeStock
{
    public partial class Form1 : Form
    {
        DataTable dtArticulos;
        DataTable dtMovimientos;
        Entidades.Articulo Articulo = new Entidades.Articulo();
       
        public Form1()
        {
            InitializeComponent();
            lblSeccion.Text = "Stock";
            //Oculto Tarjetas
            f3.Visible = false;
            TarjetaStockMin.Visible = false;
            TarjetaMovimiento.Visible = false;
            TarjetaNuevo.Visible = false;
            TarjetaModificar.Visible = false;
            TarjetabtnArticulos.Visible = false;
            TarjetaAjuste.Visible = false;
            TarjetaEliminar.Visible = false;
            //Cargo Tabla Articulos
            dtArticulos = Logica.Articulo.TraerArticulosHabilitados();
            dtMovimientos = null;
            //Cargo Fechas para Movimientos
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
        }
        /// <summary>
        /// Carga Tarjeta Articulo
        /// </summary>
        public void CargarArticulo(Entidades.Articulo pArticulo)
        {
            //Cargo Objeto Articulo 
            if (dgvArticulos.Rows.Count > 0)
            {
                Articulo.ID = dgvArticulos.CurrentRow.Cells["CODIGO"].Value.ToString(); ;
                Articulo.DESCRIPCION = dgvArticulos.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                Articulo.CANTIDAD = Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["STOCK"].Value.ToString());
                Articulo.VAL_CRITICO = Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["STOCK MIN"].Value.ToString());
                Articulo.UM = dgvArticulos.CurrentRow.Cells["U.M"].Value.ToString();
                Articulo.HABILITADO = Convert.ToBoolean(dgvArticulos.CurrentRow.Cells["ACTIVO"].Value.ToString());
                lblCodigo.Text = pArticulo.ID;
                txtDescripcion.Text = pArticulo.DESCRIPCION;
                lblStock.Text = pArticulo.CANTIDAD.ToString().Trim() + " " + pArticulo.UM;
                lblAviso.Text = pArticulo.VAL_CRITICO.ToString().Trim() + " " + pArticulo.UM;
                lblUM.Text = pArticulo.UM;
            }
            else
            {
                lblCodigo.Text = null;
                txtDescripcion.Text = null;
                lblStock.Text = null;
                lblAviso.Text = null;
                lblUM.Text = null;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnArticulos_Click(object sender, EventArgs e)
        {
           
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
            BarraProgreso.Value = 1;
            f3.Visible = false;
            f2.Visible = false;
            TarjetaStockMin.Visible = false;
            txtBuscar.Text = "";
            lblSeccion.Visible = false;
            lblSeccion.Text = "Stock";
            lblSeccion.Visible = true;
            btnEntrada.Enabled = true;
            btnSalida.Enabled = true;
            
            if (f1.Width == 50)
            {
                btnEntrada.Visible = true;
                btnSalida.Visible = true;
                TarjetabtnArticulos.Visible = false;
                dtArticulos = Logica.Articulo.TraerArticulosHabilitados();
                dgvArticulos.DataSource = dtArticulos;
                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["ACTIVO"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = true;
                dgvArticulos.Columns["STOCK"].Visible = true;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 400;
                dgvArticulos.Columns[2].Width = 100;
                dgvArticulos.Columns[3].Width = 100;
                CargarArticulo(Articulo);
                BarraProgreso.Value = 2;
            }
            else
            {
                btnEntrada.Visible = false;
                btnSalida.Visible = false;
                dtArticulos = Logica.Articulo.TraerArticulosHabilitados();
                dgvArticulos.DataSource = dtArticulos;
                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["ACTIVO"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = true;
                dgvArticulos.Columns["STOCK"].Visible = true;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 400;
                dgvArticulos.Columns[2].Width = 100;
                dgvArticulos.Columns[3].Width = 100;
                CargarArticulo(Articulo);
                BarraProgreso.Value = 2;

            }
            BarraProgreso.Value = 3;
            SeccionTransition.ShowSync(f2);
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();
          
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (f1.Width == 50)
            {
                f1.Visible = false;
                f1.Width = 300;
                TarjetaStockMin.Visible = false;
                TarjetaArticulos.Visible = false;
                btnEntrada.Visible = false;
                btnSalida.Visible = false;
                TarjetabtnArticulos.Visible = false;
             /// PARA MOVIMIENTOS
                lblMovimientos.Location = new Point(350, 10);
                pictureBox3.Location = new Point(158, 157);
                pbuscar.Location = new Point(215, 73);
                txtBuscarMovimientos.Location = new Point(198, 157);
               dgvMovimientos.Location = new Point(12, 197);
             /// PARA LAS OTRAS SECCIONES
               lblSeccion.Location = new Point(391, 10);
               txtBuscar.Location = new Point(175, 58);
                pictureBox1.Location = new Point(135, 62);
                dgvArticulos.Location = new Point(131, 98);
                PanelTransition.ShowSync(f1);
            }
            else
            {
                /// PARA LAS OTRAS SECCIONES
                lblSeccion.Location = new Point(301, 10);
                txtBuscar.Location = new Point(85, 58);
                pictureBox1.Location = new Point(45, 62);
                dgvArticulos.Location = new Point(41, 98);


                if (lblSeccion.Text.Trim() == "Stock")
                {
                    TarjetabtnArticulos.Visible = false;
                    TarjetaStockMin.Visible = false;
                    btnEntrada.Visible = true;
                    btnSalida.Visible = true;


                }
                if (lblSeccion.Text.Trim() == "Faltantes")
                {
                    TarjetabtnArticulos.Visible = false;
                    TarjetaStockMin.Visible = true;
                    btnEntrada.Visible = false;
                    btnSalida.Visible = false;

                }

                if (lblSeccion.Text.Trim() == "Articulos")
                {
                    TarjetabtnArticulos.Visible = true;
                    TarjetaStockMin.Visible = false;
                    btnEntrada.Visible = false;
                    btnSalida.Visible = false;

                }
                if (lblSeccion.Text.Trim() == "Movimientos")
                {
                    TarjetabtnArticulos.Visible = false;
                    TarjetaStockMin.Visible = false;
                    btnEntrada.Visible = false;
                    btnSalida.Visible = false;
                    lblMovimientos.Location = new Point(450, 10);
                    pictureBox3.Location = new Point(258, 157);
                    pbuscar.Location = new Point(315, 73);
                    txtBuscarMovimientos.Location = new Point(298, 157);
                    dgvMovimientos.Location = new Point(112, 197);
                }

                TarjetaArticulos.Visible = true;
                f1.Visible = false;
                f1.Width = 50;

                PanelTransition.ShowSync(f1);

            }


        }
        private void SeleccionDeFila(object sender, DataGridViewCellEventArgs e)
        {
            CargarArticulo(Articulo);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            f1.Width = 50;
            PanelTransition.ShowSync(f1);
            dgvArticulos.DataSource = dtArticulos;
            dgvArticulos.Columns["STOCK MIN"].Visible = false;
            dgvArticulos.Columns["ACTIVO"].Visible = false;
            dgvArticulos.Columns["U.M"].Visible = true;
            dgvArticulos.Columns["STOCK"].Visible = true;
            dgvArticulos.Columns[0].Width = 100;
            dgvArticulos.Columns[1].Width = 400;
            dgvArticulos.Columns[2].Width = 100;
            dgvArticulos.Columns[3].Width = 100;
            txtBuscar.Select();
            CargarArticulo(Articulo);

        }

        private void f2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuVTrackbar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_OnValueChanged(object sender, EventArgs e)
        {
            DataView dv = dtArticulos.DefaultView;


            dv.RowFilter = "CODIGO like '" + txtBuscar.Text.Trim() + "%' OR DESCRIPCION like '" + txtBuscar.Text.Trim() + "%'";


            dgvArticulos.DataSource = dv;
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Down:
                    dgvArticulos.Select();
                    break;
                case Keys.Up:
                    dgvArticulos.Select();
                    break;
                case Keys.Enter:
                    txtBuscar.Select();
                    break;
                case Keys.Escape:
                    txtBuscar.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            
            FiltrarStockMin.Checked = false;
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
            BarraProgreso.Value = 1;
            f3.Visible = false;
            f2.Visible = false;
            btnEntrada.Visible = false;
            btnSalida.Visible = false; ;
            txtBuscar.Text = "";
            lblSeccion.Visible = false;
            lblSeccion.Text = "Faltantes";
            TarjetaStockMin.Location = new Point(758, 306);
            lblSeccion.Visible = true;
            if (f1.Width == 50)
            {

                btnEntrada.Visible = false;
                btnSalida.Visible = false;
                TarjetabtnArticulos.Visible = false;
                TarjetaStockMin.Visible = true;
                dtArticulos = Logica.Articulo.TraerFaltantes();
                dgvArticulos.DataSource = dtArticulos;
                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["ACTIVO"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = true;
                dgvArticulos.Columns["STOCK"].Visible = true;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 400;
                dgvArticulos.Columns[2].Width = 100;
                dgvArticulos.Columns[3].Width = 100;
                CargarArticulo(Articulo);

                BarraProgreso.Value = 2;
            }
            else
            {
                TarjetaStockMin.Visible = false;
                dtArticulos = Logica.Articulo.TraerFaltantes();
                dgvArticulos.DataSource = dtArticulos;
                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["ACTIVO"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = true;
                dgvArticulos.Columns["STOCK"].Visible = true;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 400;
                dgvArticulos.Columns[2].Width = 100;
                dgvArticulos.Columns[3].Width = 100;
                CargarArticulo(Articulo);

                BarraProgreso.Value = 2;

            }
            BarraProgreso.Value = 3;
            SeccionTransition.ShowSync(f2);
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
           
            TajetaMovimiento("ENTRADA");

            TarjetaMovimiento.Visible = true;
            dgvArticulos.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            f1.Enabled = false;
            txtBuscar.Enabled = false;
        }
        /// <summary>
        /// Convierte la Tarjeta Movimento en ENTRADA o SALIDA
        /// </summary>
        /// <param name="movimiento"></param>
        public void TajetaMovimiento(string movimiento)
        {
            lbldireccion.Visible = false;
            cboDireccion.Visible = false;
            lblCodigo2.Text = Articulo.ID.Trim();
            txtDescripcion2.Text = Articulo.DESCRIPCION.Trim();
            //LblUM lo cargo en CargarArtuculos()
            if (movimiento.Trim() == "ENTRADA")
            {
                lblMovimiento.Text = "Entrada";
                lblMovimiento.ForeColor = Color.Green;
                TarjetaMovimiento.color = Color.Green;

                lbldireccion.Text = "Origen:";

            }
            if (movimiento.Trim() == "SALIDA")
            {
                lblMovimiento.Text = "Salida";
                lblMovimiento.ForeColor = Color.Red;
                TarjetaMovimiento.color = Color.Red;
                lbldireccion.Text = "Destino:";
            }
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void TarjetaMovimiento_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel8_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            TarjetaMovimiento.Visible = false;
            dgvArticulos.Enabled = true;
            btnEntrada.Enabled = true;
            btnSalida.Enabled = true;
            f1.Enabled = true;
            txtBuscar.Enabled = true;
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            TajetaMovimiento("SALIDA");

            TarjetaMovimiento.Visible = true;
            dgvArticulos.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            f1.Enabled = false;
            txtBuscar.Enabled = false;

        }
        public void RegistrarMovimiento(Entidades.Articulo pArticulo,string Movimiento , string Origen)
        {
            DateTime Hoy = DateTime.Now;
            string fecha_actual = Hoy.ToString("dd-MM-yyyy");
            string hora_actual = Hoy.ToLongTimeString();
            Entidades.Movimiento movimiento = new Entidades.Movimiento();
            movimiento.FECHA = Convert.ToDateTime(fecha_actual);
            movimiento.HORA = Convert.ToDateTime(hora_actual);
            movimiento.ID_ARTICULO = pArticulo.ID.Trim();
            movimiento.MOVIMIENTO = Movimiento.ToUpper().Trim();
            movimiento.DESCRIPCION = pArticulo.DESCRIPCION.Trim();
            movimiento.ORIGEN = Origen.ToUpper().Trim();
            movimiento.CANTIDAD = Convert.ToDecimal(pArticulo.CANTIDAD);
            movimiento.UM = pArticulo.UM.Trim();
            Logica.Movimiento.AltaMovimiento(movimiento);


        }

        private void TarjetaArticulos_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// Hace que el TextBox Cantidad solo acepte ENTERO o DECIMAL segun el tipo de Uninidad de Medida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Logica.UM.TraerTipoUM(lblUM.Text.Trim()) == 1)//SI ES ENTERO
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {

                    e.Handled = true;
                    return;
                }
            }
            if (Logica.UM.TraerTipoUM(lblUM.Text.Trim()) == 2)//SI ES DECIMAL
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtCantidad.Text.Length; i++)
                {
                    if (txtCantidad.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
            BarraProgreso.Value = 1;
            if (lblMovimiento.Text.Trim() == "Entrada")
            {
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {

                    MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (Convert.ToDecimal(txtCantidad.Text) == 0)
                    {
                        MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCantidad.Text = "";
                    }

                    else
                    {
                        if (cboDireccion.Text == "g")
                        {
                            MessageBox.Show("No ha seleccionado una Origen", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboDireccion.Select();
                        }

                        else
                        {
                            f2.Visible = false;
                            Logica.Articulo.EntradaArticulo(lblCodigo2.Text, Convert.ToDecimal(txtCantidad.Text));
                            RegistrarMovimiento(Articulo, "ENTRADA", "STOCK");

                           
                            dtArticulos = Logica.Articulo.TraerArticulosHabilitados();
                            BarraProgreso.Value = 2;
                            dgvArticulos.DataSource = dtArticulos;
                            dgvArticulos.Columns["STOCK MIN"].Visible = false;
                            dgvArticulos.Columns[0].Width = 100;
                            dgvArticulos.Columns[1].Width = 400;
                            dgvArticulos.Columns[2].Width = 100;
                            dgvArticulos.Columns[3].Width = 100;

                            TarjetaMovimiento.Visible = false;
                            btnEntrada.Enabled = true;
                            btnSalida.Enabled = true;
                            f1.Enabled = true;
                            txtBuscar.Enabled = true;
                            BarraProgreso.Value = 3;
                            ActualizacionTransition.ShowSync(f2);
                            txtCantidad.Text = "";
                            dgvArticulos.Enabled = true;
                        }
                    }
                }
                
            }
            if (lblMovimiento.Text.Trim() == "Salida")
            {
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                else
                {
                    if (Convert.ToDecimal(txtCantidad.Text) == 0)
                    {
                        MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCantidad.Text = "";
                    }
                    else
                    {

                        if (cboDireccion.Text == "g")
                        {
                            MessageBox.Show("No ha seleccionado una Destino", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            cboDireccion.Select();
                        }

                        else
                        {


                            if ((Convert.ToDecimal(txtCantidad.Text.Trim()) <= Convert.ToDecimal(Articulo.CANTIDAD)))
                            {
                                f2.Visible = false;
                                Logica.Articulo.SalidaArticulo(lblCodigo2.Text, Convert.ToDecimal(txtCantidad.Text));
                                RegistrarMovimiento(Articulo, "SALIDA", "STOCK");
                                //Logica.Reporte.AgregarReporte(CrearReporte());
                                //Form1.f1.Actualizar();
                                dtArticulos = Logica.Articulo.TraerArticulosHabilitados();
                                dgvArticulos.DataSource = dtArticulos;
                                BarraProgreso.Value = 2;
                                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                                dgvArticulos.Columns[0].Width = 100;
                                dgvArticulos.Columns[1].Width = 400;
                                dgvArticulos.Columns[2].Width = 100;
                                dgvArticulos.Columns[3].Width = 100;
                                //Close();
                                TarjetaMovimiento.Visible = false;
                                btnEntrada.Enabled = true;
                                btnSalida.Enabled = true;
                                f1.Enabled = true;
                                txtBuscar.Enabled = true;
                                BarraProgreso.Value = 3;
                                ActualizacionTransition.ShowSync(f2);
                                txtCantidad.Text = "";
                                dgvArticulos.Enabled = true;
                            }

                            else
                            {
                                MessageBox.Show("Saldo Insuficiente", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtCantidad.Text = "";
                                //cboDireccion.Text = "";
                                //txtCantidad.Clear();
                            }
                        }
                    }
                }
            }
            //f2.Visible = true;
            //dgvArticulos.Enabled = true;
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();

        }

        private void txtCantidad_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void TarjetaArticulos2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {

           
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
            BarraProgreso.Value = 1;
            lblSeccion.Visible = false;
            if (lblSeccion.Text != "Movimientos")
            {
                dtpDesde.Value = DateTime.Now;
                dtpHasta.Value = DateTime.Now;
                dtMovimientos = null;
                dgvMovimientos.DataSource = null;
                txtBuscarMovimientos.Text = "";
                BarraProgreso.Value = 2;

            }
            if (f1.Width == 50)
            {
                lblMovimientos.Location = new Point(450, 10);
                pictureBox3.Location = new Point(258, 157);
                pbuscar.Location = new Point(315, 73);
                txtBuscarMovimientos.Location = new Point(298, 157);
                dgvMovimientos.Location = new Point(112, 197);
                BarraProgreso.Value = 2;

            }

          
            BarraProgreso.Value = 3;
            lblSeccion.Text = "Movimientos";
            f3.Dock = DockStyle.Fill;
            txtBuscar.Text = "";
            TarjetaStockMin.Visible = false;
            btnEntrada.Visible = false;
            btnSalida.Visible = false;
            TarjetabtnArticulos.Visible = false;
            SeccionTransition.ShowSync(f3);
            lblSeccion.Visible = true;
            BarraProgreso.Value = 0;
            txtBuscarMovimientos.Focus();
            txtBuscarMovimientos.Select();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
          
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
            BarraProgreso.Value = 1;
            f3.Visible = false;
            f2.Visible = false;
            TarjetaStockMin.Visible = false;
            btnEntrada.Visible = false;
            btnSalida.Visible = false;
            txtBuscar.Text = "";
            dtArticulos = Logica.Articulo.TraerArticulos();
            dgvArticulos.DataSource = dtArticulos;
            lblSeccion.Visible = false;
            lblSeccion.Text = "Articulos";
            lblSeccion.Visible = true;
            if (f1.Width == 50)
            {

                TarjetabtnArticulos.Visible = true;

                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = false;
                dgvArticulos.Columns["ACTIVO"].Visible = true;
                dgvArticulos.Columns["STOCK"].Visible = false;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 500;
                dgvArticulos.Columns[2].Width = 10;
                CargarArticulo(Articulo);
                BarraProgreso.Value = 2;
            }
            else
            {

                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = false;
                dgvArticulos.Columns["ACTIVO"].Visible = true;
                dgvArticulos.Columns["STOCK"].Visible = false;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 500;
                dgvArticulos.Columns[2].Width = 10;
                CargarArticulo(Articulo);
                BarraProgreso.Value = 2;

            }
            BarraProgreso.Value = 3;
            SeccionTransition.ShowSync(f2);
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();
          
        }

        private void lbldireccion_Click(object sender, EventArgs e)
        {

        }


        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Muestro Tarjeta Modificar y acomodo visual
            HabilitadoModificar.Checked = Convert.ToBoolean(Articulo.HABILITADO);
            TarjetabtnArticulos.Visible = false;
            LlenarComboUM(Logica.UM.TraerTipoUM(Articulo.UM));
            cboUMModificar.Text = Articulo.UM;
           
            TarjetaModificar.Location = new Point(758, 306);
          
            lblCodigoModificar.Text = Articulo.ID;
         
            txtDescripcionModificar.Text = Articulo.DESCRIPCION;
            txtStockModificar.Text = Articulo.CANTIDAD.ToString().Trim();
            if (Logica.UM.TraerTipoUM(Articulo.UM) == 1)
            {
                txtValCriticoModificar.Text = Convert.ToInt32(Articulo.VAL_CRITICO).ToString().Trim();
            }
            if (Logica.UM.TraerTipoUM(Articulo.UM) == 2)
            {
                txtValCriticoModificar.Text = Convert.ToDecimal(Articulo.VAL_CRITICO).ToString().Trim();
            }
         
           
           
            dgvArticulos.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            f1.Enabled = false;
            txtBuscar.Enabled = false;
            TarjetaModificar.Visible = true;

        }

        private void btnCancelarModificar_Click(object sender, EventArgs e)
        {
            //Acomodo Visual cuando Cancelo en Tarjeta Modificar
            dgvArticulos.Enabled = true;
            f1.Enabled = true;
            txtBuscar.Enabled = true;
            TarjetaModificar.Visible = false;
            TarjetabtnArticulos.Visible = true;
            txtBuscar.Focus();
            txtBuscar.Select();


        }

        private void txtValCriticoModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Logica.UM.TraerTipoUM(lblUM.Text.Trim()) == 1)//SI ES ENTERO
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                    return;
                }
            }
            if (Logica.UM.TraerTipoUM(lblUM.Text.Trim()) == 2)//SI ES DECIMAL
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtCantidad.Text.Length; i++)
                {
                    if (txtCantidad.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }
        public void LlenarComboUM(int Tipo)
        {
            DataTable dp = Logica.UM.TraerUMs(Tipo);
            cboUMModificar.DataSource = dp;
            cboUMModificar.DisplayMember = "UNIDAD";
            cboUMModificar.ValueMember = "UNIDAD";
            DataRow dr = dp.NewRow();
            dr["UNIDAD"] = "";
            dp.Rows.InsertAt(dr, 0);
            this.cboUMModificar.SelectedValue = 0;
            this.cboUMModificar.SelectedIndexChanged += new System.EventHandler(this.cboUMModificar_SelectedIndexChanged);
        }
        public void LlenarComboUMNuevo()
        {
            DataTable dp = Logica.UM.TraerTodosUMs();
            cboUMNuevo.DataSource = dp;
            cboUMNuevo.DisplayMember = "UNIDAD";
            cboUMNuevo.ValueMember = "UNIDAD";
            DataRow dr = dp.NewRow();
            dr["UNIDAD"] = "";
            dp.Rows.InsertAt(dr, 0);
            this.cboUMNuevo.SelectedValue = 0;
            this.cboUMNuevo.SelectedIndexChanged += new System.EventHandler(this.cboUMNuevo_SelectedIndexChanged);
        }

        private void TarjetaModificar_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ExportarDataGridViewExcel(DataGridView dgvLog)
        {
            BarraProgreso.Value = 0;
            
            try
            {
                if (dgvLog.DataSource != null)
                {
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xlsx";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {

                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                        Enabled = false;

                       
                        for (int i = 1; i <= dgvLog.Columns.Count; i++)
                        {
                            hoja_trabajo.Cells[1, i] = dgvLog.Columns[i - 1].HeaderText;
                            
                        }

                        //Recorremos el DataGridView rellenando la hoja de trabajo con los datos
                        BarraProgreso.MaximumValue= dgvLog.Rows.Count;
                        for (int i = 0; i < dgvLog.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvLog.Columns.Count; j++)
                            {

                                hoja_trabajo.Cells[i + 2, j + 1] = dgvLog.Rows[i].Cells[j].Value.ToString().Trim();
                                BarraProgreso.Value = i;
                            }
                        }
                        hoja_trabajo.Rows[1].Font.Bold = 1;
                        hoja_trabajo.Rows[1].Font.Color = Color.DimGray;
                        hoja_trabajo.Rows[1].Font.size = 13;
                        hoja_trabajo.Rows[1].HorizontalAlignment = 2;
                        hoja_trabajo.Columns.AutoFit();

                        Enabled = true;
                        BarraProgreso.Value = 0;


                        hoja_trabajo.Application.Visible = true;

                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar ", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            if (lblSeccion.Text == "Movimientos")
            {
                ExportarDataGridViewExcel(dgvMovimientos);
            }
            else
            {
                ExportarDataGridViewExcel(dgvArticulos);
              

            }

        }

        private void btnGuardarModificar_Click(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
    
            if (cboUMModificar.Text == "" | txtValCriticoModificar.Text == "" | txtDescripcionModificar.Text == "" )
            {
                MessageBox.Show("Datos Incompletos", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                f2.Visible = false;
                BarraProgreso.Value = 1;
                Entidades.Articulo objEntidadArticulo = new Entidades.Articulo();
                objEntidadArticulo.ID = Articulo.ID;
                objEntidadArticulo.DESCRIPCION = txtDescripcionModificar.Text.ToUpper().Trim();
                objEntidadArticulo.UM = cboUMModificar.Text;
                objEntidadArticulo.CANTIDAD = Articulo.CANTIDAD;
                objEntidadArticulo.VAL_CRITICO = Convert.ToDecimal(txtValCriticoModificar.Text);
                objEntidadArticulo.HABILITADO = HabilitadoModificar.Checked;
                Logica.Articulo.ModificarArticulo(objEntidadArticulo);
                RegistrarMovimiento(objEntidadArticulo, "MODIFICAR", "ARTICULOS");
                BarraProgreso.Value = 2;
               
                dtArticulos = Logica.Articulo.TraerArticulos();
                dgvArticulos.DataSource = dtArticulos;
                lblSeccion.Visible = false;
                lblSeccion.Text = "Articulos";
                lblSeccion.Visible = true;
                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = false;
                dgvArticulos.Columns["STOCK"].Visible = false;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 500;
                dgvArticulos.Columns[2].Width = 10;
                CargarArticulo(Articulo);

                f1.Enabled = true;
                txtBuscar.Enabled = true;
                TarjetaModificar.Visible = false;
                TarjetabtnArticulos.Visible = true;
                ActualizacionTransition.ShowSync(f2);
                txtBuscar.Text = "";
                dgvArticulos.Enabled = true;
                BarraProgreso.Value = 3;
            }
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();
        }

        private void cboUMModificar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HabilitadoModificar_OnChange(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TarjetaEliminar.Location = new Point(758, 306);
            TarjetaEliminar.Visible = true;
            dgvArticulos.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            f1.Enabled = false;
            txtBuscar.Enabled = false;
            TarjetabtnArticulos.Visible = false;
            HabilitadoEliminar.Checked = Convert.ToBoolean(Articulo.HABILITADO);
            lblCodigoEliminar.Text = Articulo.ID;
            txtDescripcionEliminar.Text = Articulo.DESCRIPCION;
            lblStockEliminar.Text = Articulo.CANTIDAD.ToString();
            lblValcriticoEliminar.Text = Articulo.VAL_CRITICO.ToString();
            lblUMEliminar.Text = Articulo.UM;


        }

        private void TarjetaEliminar_Paint(object sender, PaintEventArgs e)
        {


        }

        private void btnEliminarEliminar_Click(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
          
            string message = "¿Esta seguro que quiere ELIMINAR el articulo?";
            string title = "CtrlStock";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                BarraProgreso.Value = 1;
                f2.Visible = false;
                Logica.Articulo.EliminarArticulo(Articulo.ID);
                BarraProgreso.Value = 2;
                RegistrarMovimiento(Articulo, "ELIMINAR", "ARTICULOS");

                
                dtArticulos = Logica.Articulo.TraerArticulos();
                dgvArticulos.DataSource = dtArticulos;
                lblSeccion.Visible = false;
                lblSeccion.Text = "Articulos";
                lblSeccion.Visible = true;
                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                dgvArticulos.Columns["U.M"].Visible = false;
                dgvArticulos.Columns["STOCK"].Visible = false;
                dgvArticulos.Columns[0].Width = 100;
                dgvArticulos.Columns[1].Width = 500;
                dgvArticulos.Columns[2].Width = 10;

              
                f1.Enabled = true;
                txtBuscar.Enabled = true;
                TarjetaEliminar.Visible = false;
                TarjetabtnArticulos.Visible = true;
                BarraProgreso.Value = 3;
                ActualizacionTransition.ShowSync(f2);
                txtBuscar.Text = "";
                dgvArticulos.Enabled = true;


            }
            else
            {
                // Do something  
                //Close();
                dgvArticulos.Enabled = true;
                f1.Enabled = true;
                txtBuscar.Enabled = true;
                TarjetaEliminar.Visible = false;
                TarjetabtnArticulos.Visible = true;

            }

            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();
            //Close();

        }

        private void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            dgvArticulos.Enabled = true;
            f1.Enabled = true;
            txtBuscar.Enabled = true;
            TarjetaEliminar.Visible = false;
            TarjetabtnArticulos.Visible = true;
            txtBuscar.Focus();
            txtBuscar.Select();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            TarjetaNuevo.Location = new Point(758, 306);
            TarjetaNuevo.Visible = true;
            dgvArticulos.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            f1.Enabled = false;
            txtBuscar.Enabled = false;
            LlenarComboUMNuevo();
            txtCodigoNuevo.Clear();
            txtDescripcionNuevo.Clear();
            txtStockNuevo.Text = "";
            txtValCriticoNuevo.Text = "";
            cboUMNuevo.Text = "";
            TarjetabtnArticulos.Visible = false;


        }

        private void btnCancelarNuevo_Click(object sender, EventArgs e)
        {
            dgvArticulos.Enabled = true;
            f1.Enabled = true;
            txtBuscar.Enabled = true;
            TarjetaNuevo.Visible = false;
            TarjetabtnArticulos.Visible = true;
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
          
            if (Logica.Articulo.ValidarCodigo(txtCodigoNuevo.Text))
            {
                MessageBox.Show("El Codigo ya existe", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigoNuevo.Clear();
                txtCodigoNuevo.Select();
            }
            else
            {
                if (txtCodigoNuevo.Text == "" | txtDescripcionNuevo.Text == "" | txtStockNuevo.Text == "" | txtValCriticoNuevo.Text == "")
                {
                    MessageBox.Show("Datos Incompletos", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    BarraProgreso.Value = 1;
                    f2.Visible = false;
                    Entidades.Articulo objEntidadArticulo = new Entidades.Articulo();
                    objEntidadArticulo.ID = txtCodigoNuevo.Text.Trim();
                    objEntidadArticulo.DESCRIPCION = txtDescripcionNuevo.Text.ToUpper().Trim();
                    objEntidadArticulo.UM = cboUMNuevo.Text.ToUpper();
                    objEntidadArticulo.CANTIDAD = Convert.ToDecimal(txtStockNuevo.Text);
                    objEntidadArticulo.VAL_CRITICO = Convert.ToDecimal(txtValCriticoNuevo.Text);
                    objEntidadArticulo.HABILITADO = habilitarNuevo.Checked;
                    Logica.Articulo.AltadeArticulo(objEntidadArticulo);
                    RegistrarMovimiento(objEntidadArticulo, "NUEVO", "ARTICULOS");
                    BarraProgreso.Value = 2;

                   
                    dtArticulos = Logica.Articulo.TraerArticulos();
                    dgvArticulos.DataSource = dtArticulos;
                    lblSeccion.Visible = false;
                    lblSeccion.Text = "Articulos";
                    lblSeccion.Visible = true;
                    dgvArticulos.Columns["STOCK MIN"].Visible = false;
                    dgvArticulos.Columns["U.M"].Visible = false;
                    dgvArticulos.Columns["STOCK"].Visible = false;
                    dgvArticulos.Columns[0].Width = 100;
                    dgvArticulos.Columns[1].Width = 500;
                    dgvArticulos.Columns[2].Width = 10;
                  
                    f1.Enabled = true;
                    txtBuscar.Enabled = true;
                    TarjetaNuevo.Visible = false;
                    TarjetabtnArticulos.Visible = true;
                 
                    ActualizacionTransition.ShowSync(f2);
                    BarraProgreso.Value = 3;
                    dgvArticulos.Enabled = true;
                    txtBuscar.Text = "";
                   

                }
            }
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();

        }

        private void txtStockNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Logica.UM.TraerTipoUM(cboUMNuevo.Text.Trim()) == 1)//SI ES ENTERO
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                    return;
                }
            }
            if (Logica.UM.TraerTipoUM(cboUMNuevo.Text.Trim()) == 2)//SI ES DECIMAL
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtStockNuevo.Text.Length; i++)
                {
                    if (txtStockNuevo.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        private void txtValCriticoNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Logica.UM.TraerTipoUM(cboUMNuevo.Text.Trim()) == 1)//SI ES ENTERO
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                    return;
                }
            }
            if (Logica.UM.TraerTipoUM(cboUMNuevo.Text.Trim()) == 2)//SI ES DECIMAL
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtValCriticoNuevo.Text.Length; i++)
                {
                    if (txtValCriticoNuevo.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }

        }

        private void cboUMNuevo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValCriticoNuevo.Text = "";
            txtStockNuevo.Text = "";
            if (cboUMNuevo.Text == "")
            {
                txtValCriticoNuevo.Enabled = false;
                txtStockNuevo.Enabled = false;
            } else
            {
                txtValCriticoNuevo.Enabled = true;
                txtStockNuevo.Enabled = true;
            }
        }

        private void btnAjuste_Click(object sender, EventArgs e)
        {

            lblCodigoAjuste.Text = Articulo.ID;
            txtDescripcionAjuste.Text = Articulo.DESCRIPCION.Trim();
            TarjetaAjuste.Location = new Point(758, 306);
            TarjetaAjuste.Visible = true;
            dgvArticulos.Enabled = false;
            btnEntrada.Enabled = false;
            btnSalida.Enabled = false;
            f1.Enabled = false;
            txtBuscar.Enabled = false;
            TarjetabtnArticulos.Visible = false;
        }

        private void btnCancelarAjuste_Click(object sender, EventArgs e)
        {
            dgvArticulos.Enabled = true;
            f1.Enabled = true;
            txtBuscar.Enabled = true;
            cboTipoAjuste.Text = " ";
            txtCantidadAjuste.Text = "";
            TarjetaAjuste.Visible = false;
            TarjetabtnArticulos.Visible = true;
            txtBuscar.Focus();
            txtBuscar.Select();
        }

        private void btnGuardarAjuste_Click(object sender, EventArgs e)
        {
            BarraProgreso.Value = 0;
            BarraProgreso.MaximumValue = 3;
           
            if (cboTipoAjuste.Text == "ENTRADA")
            {
                if (string.IsNullOrEmpty(txtCantidadAjuste.Text))
                {

                    MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (Convert.ToDecimal(txtCantidadAjuste.Text) == 0)
                    {
                        MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCantidad.Text = "";
                    }



                    else
                    {
                        f2.Visible = false;
                        BarraProgreso.Value = 1;
                        Logica.Articulo.EntradaArticulo(lblCodigoAjuste.Text, Convert.ToDecimal(txtCantidadAjuste.Text));
                        RegistrarMovimiento(Articulo, "ENTRADA", "AJUSTE");
                        BarraProgreso.Value = 2;
                       
                        dtArticulos = Logica.Articulo.TraerArticulos();
                        dgvArticulos.DataSource = dtArticulos;
                        lblSeccion.Visible = false;
                        lblSeccion.Text = "Articulos";
                        lblSeccion.Visible = true;
                        dgvArticulos.Columns["STOCK MIN"].Visible = false;
                        dgvArticulos.Columns["U.M"].Visible = false;
                        dgvArticulos.Columns["STOCK"].Visible = false;
                        dgvArticulos.Columns[0].Width = 100;
                        dgvArticulos.Columns[1].Width = 500;
                        dgvArticulos.Columns[2].Width = 10;
                        txtCantidadAjuste.Text = "";
                        TarjetaAjuste.Visible = false;
                        TarjetabtnArticulos.Visible = true;

                        cboTipoAjuste.Text = " ";
                        txtCantidadAjuste.Text = "";
                       
                        btnEntrada.Enabled = true;
                        btnSalida.Enabled = true;
                        f1.Enabled = true;
                        txtBuscar.Enabled = true;
                        BarraProgreso.Value = 3;
                        ActualizacionTransition.ShowSync(f2);
                        txtBuscar.Text = "";
                        dgvArticulos.Enabled = true;

                    }
                }
            }
            else
            {
                if (cboTipoAjuste.Text.Trim() == "SALIDA")
                {
                    if (string.IsNullOrEmpty(txtCantidadAjuste.Text))
                    {
                        MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                    else
                    {
                        if (Convert.ToDecimal(txtCantidadAjuste.Text) == 0)
                        {
                            MessageBox.Show("No ha ingresado una cantidad", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtCantidad.Text = "";
                        }

                        else
                        {


                            if ((Convert.ToDecimal(txtCantidadAjuste.Text.Trim()) <= Convert.ToDecimal(Articulo.CANTIDAD)))
                            {
                                f2.Visible = false;
                                BarraProgreso.Value = 1;
                                Logica.Articulo.SalidaArticulo(lblCodigoAjuste.Text, Convert.ToDecimal(txtCantidadAjuste.Text));
                                RegistrarMovimiento(Articulo, "SALIDA", "AJUSTE");
                                BarraProgreso.Value = 2; 
                                dtArticulos = Logica.Articulo.TraerArticulos();
                                dgvArticulos.DataSource = dtArticulos;
                                lblSeccion.Visible = false;
                                lblSeccion.Text = "Articulos";
                                lblSeccion.Visible = true;
                                dgvArticulos.Columns["STOCK MIN"].Visible = false;
                                dgvArticulos.Columns["U.M"].Visible = false;
                                dgvArticulos.Columns["STOCK"].Visible = false;
                                dgvArticulos.Columns[0].Width = 100;
                                dgvArticulos.Columns[1].Width = 500;
                                dgvArticulos.Columns[2].Width = 10;
                                txtCantidadAjuste.Text = "";
                                TarjetaAjuste.Visible = false;
                                TarjetabtnArticulos.Visible = true;
                                cboTipoAjuste.Text = " ";
                                txtCantidadAjuste.Text = "";
                                btnEntrada.Enabled = true;
                                btnSalida.Enabled = true;
                                f1.Enabled = true;
                                txtBuscar.Enabled = true;
                                BarraProgreso.Value = 3;
                                ActualizacionTransition.ShowSync(f2);
                                txtBuscar.Text = "";
                                dgvArticulos.Enabled = true;
                            }

                            else
                            {
                                MessageBox.Show("Saldo Insuficiente", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtCantidadAjuste.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    if (cboTipoAjuste.Text == "" | cboTipoAjuste.Text == " ")
                    {
                        MessageBox.Show("Datos incompletos", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            BarraProgreso.Value = 0;
            txtBuscar.Focus();
            txtBuscar.Select();

        }

        private void txtCantidadAjuste_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Logica.UM.TraerTipoUM(Articulo.UM.Trim()) == 1)//SI ES ENTERO
            {
                if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                {
                  
                    e.Handled = true;
                    return;
                }
            }
            if (Logica.UM.TraerTipoUM(Articulo.UM.Trim()) == 2)//SI ES DECIMAL
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < txtCantidadAjuste.Text.Length; i++)
                {
                    if (txtCantidadAjuste.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
                    {
                        e.Handled = true;
                        return;
                    }


                }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }

        }

        private void bunifuMetroTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void lblModificar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarMovimientos_OnValueChanged(object sender, EventArgs e)
        {
            if (dtMovimientos != null)
            {
                DataView dv = dtMovimientos.DefaultView;


                dv.RowFilter = "CODIGO like '" + txtBuscarMovimientos.Text.Trim() + "%' OR DESCRIPCION like '" + txtBuscarMovimientos.Text.Trim() + "%'";


                dgvMovimientos.DataSource = dv;
            }
        }

        private void pbuscar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            txtBuscarMovimientos.Focus();
            txtBuscarMovimientos.Select();
            txtBuscarMovimientos.Text= "";
          
            if (Convert.ToDateTime(dtpDesde.Value) > Convert.ToDateTime(dtpHasta.Value))
            {
                MessageBox.Show("Datos Incorrectos", "CtrlStock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtpHasta.Value = DateTime.Now;
                dtpDesde.Value = DateTime.Now;
            }
            else
            {
                dtMovimientos = Logica.Movimiento.TraerMovimientos(dtpDesde.Value.ToString(), dtpHasta.Value.ToString());
                dgvMovimientos.DataSource = dtMovimientos;
                dgvMovimientos.Columns[0].Width = 100;
                dgvMovimientos.Columns[1].Width = 100;
                dgvMovimientos.Columns[2].Width = 100;
                dgvMovimientos.Columns[3].Width = 100;
                dgvMovimientos.Columns[4].Width = 100;
                dgvMovimientos.Columns[5].Width = 300;
                dgvMovimientos.Columns[6].Width = 100;
                dgvMovimientos.Columns[7].Width = 50;

            }

     

        }

        private void bunifuCustomLabel36_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel37_Click(object sender, EventArgs e)
        {

        }

        private void ptdHasta_onValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDesde_onValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpHasta_onValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FiltarStockMin_OnChange(object sender, EventArgs e)
        {
            if (FiltrarStockMin.Checked)
            {

                dtArticulos = Logica.Articulo.TraerFaltantesMin();

            }
            else
            {
                dtArticulos = Logica.Articulo.TraerFaltantes();
            }
            dgvArticulos.DataSource = dtArticulos;
            dgvArticulos.Columns["STOCK MIN"].Visible = false;
            dgvArticulos.Columns["ACTIVO"].Visible = false;
            dgvArticulos.Columns["U.M"].Visible = true;
            dgvArticulos.Columns["STOCK"].Visible = true;
            dgvArticulos.Columns[0].Width = 100;
            dgvArticulos.Columns[1].Width = 400;
            dgvArticulos.Columns[2].Width = 100;
            dgvArticulos.Columns[3].Width = 100;
            CargarArticulo(Articulo);
            txtBuscar.Text = "";
            txtBuscar.Focus();
            txtBuscar.Select();
        }

        private void txtBuscarMovimientos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Down:
                    dgvMovimientos.Select();
                    break;
                case Keys.Up:
                    dgvMovimientos.Select();
                    break;
                case Keys.Enter:
                    txtBuscarMovimientos.Select();
                    break;
                case Keys.Escape:
                    txtBuscarMovimientos.Text = "";
                    break;
                default:
                    break;
            }
        }

        private void TarjetaAjuste_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}  

