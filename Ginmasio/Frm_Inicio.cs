using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;

namespace Ginmasio
{
    public partial class Frm_Inicio : Form
    {
        public Frm_Inicio()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
       
        }

        public void sonido_boton()
        {
            SoundPlayer boton = new SoundPlayer(@"C:\BD\Repositorio para Base de Datos Sql Server\Gimnasio\Base-de-Datos-Gimnasio\Proyecto de Visual Studio C#\Ginmasio\Resources\Sonido_boton.wav");
            boton.Play();
        }
        public void sonido_menu()
        {
            SoundPlayer boton = new SoundPlayer(@"C:\BD\Repositorio para Base de Datos Sql Server\Gimnasio\Base-de-Datos-Gimnasio\Proyecto de Visual Studio C#\Ginmasio\Resources\Sonido_menu.wav");
            boton.Play();
        }


        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

       
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.Panel_superior.Region = region;
            this.Invalidate();
        }

        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void bnt_Cerrar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
           // btnMaximizar.Visible = false;
           // btnMaximizar02.Visible = true;
        }

        private void btnMaximizar02_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
           // btnMaximizar02.Visible = false;
           // btnMaximizar.Visible = true;
        }
          private void btnMinimizar_Click(object sender, EventArgs e)
        {
            sonido_boton();
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();
            abrirFormHijo(new Frm_Facturacion());
        }


        /// <summary>
        /// / CODIGO PARA PODER MOVER EL FORMULARIO PRINCIPAL EN LA PANTALLA
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel_superior_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();
            Panel_Ser_Admin.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sonido_boton();
            contraer_menu_productos();
            abrirFormHijo(new Frm_Cliente());
        }
        public static bool band_producto = true;
        public void desplazar_menu_productos()
        {
            if (band_producto == true)
            {
                Panel_Producto.Visible = true;
                btnCompras.Location = new Point(3, (270 + 110));
                panel_compra.Location = new Point(0, (270 + 110));

                btnEmpleados.Location = new Point(3, (305 + 110));
                panel_empelados.Location = new Point(0, (305 + 110));

                btnProovedores.Location = new Point(3, (340 + 110));
                panel_proovedores.Location = new Point(0, (340 + 110));

                btnReportes.Location = new Point(3, (375 + 110));
                panel_reportes.Location = new Point(0, (375 + 110));

                btnServicios.Location = new Point(3, (409 + 110));
                Panel_Ser_Admin.Location = new Point(0, (409 + 110));

                band_producto = false;
            }
            else
            {
                Panel_Producto.Visible = false;
                btnCompras.Location = new Point(3, 270);
                panel_compra.Location = new Point(0, 270);

                btnEmpleados.Location = new Point(3, 305);
                panel_empelados.Location = new Point(0, 305);

                btnProovedores.Location = new Point(3, 340);
                panel_proovedores.Location = new Point(0, 340);

                btnReportes.Location = new Point(3, 375);
                panel_reportes.Location = new Point(0, 375);

                btnServicios.Location = new Point(3, 409);
                Panel_Ser_Admin.Location = new Point(0, 409);

                band_producto = true;
            }
        }
        public void contraer_menu_productos()
        {
            if (band_producto == false)
            {
                Panel_Producto.Visible = false;
                btnCompras.Location = new Point(3, 270);
                panel_compra.Location = new Point(0, 270);

                btnEmpleados.Location = new Point(3, 305);
                panel_empelados.Location = new Point(0, 305);

                btnProovedores.Location = new Point(3, 340);
                panel_proovedores.Location = new Point(0, 340);

                btnReportes.Location = new Point(3, 375);
                panel_reportes.Location = new Point(0, 375);

                btnServicios.Location = new Point(3, 409);
                Panel_Ser_Admin.Location = new Point(0, 409);

                band_producto = true;
            }
            Panel_Producto.Visible = false;
        }
        private void btnProductos_Click(object sender, EventArgs e)
        {

            desplazar_menu_productos();
        }

        private void btnPro_Registro_Click(object sender, EventArgs e)
        {
            Panel_Producto.Visible = false;
            abrirFormHijo(new Frm_P_Registro());
            contraer_menu_productos();
        }

        private void btnPro_Marcas_Click(object sender, EventArgs e)
        {
            Panel_Producto.Visible = false;
            contraer_menu_productos();
            abrirFormHijo(new Frm_P_Marca());
        }

        private void btnPro_Categoria_Click(object sender, EventArgs e)
        {
            Panel_Producto.Visible = false;
            contraer_menu_productos();
            abrirFormHijo(new Frm_P_Categoria());
        }

        private void bntSuscripcion_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();
            abrirFormHijo(new Frm_Suscripcion());
        }

        private void bntAsistencia_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();
            abrirFormHijo(new Frm_Asistencia());

        }

        private void bntCompras_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();

        }

        private void bntEmpleados_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();

        }

        private void bntProovedores_Click(object sender, EventArgs e)
        {
            contraer_menu_productos();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Panel_Ser_Admin.Visible = false;
            Panel_Producto.Visible = false;

        }

        private void Panel_Contenedor_Paint(object sender, PaintEventArgs e)
        {

        }


        private void abrirFormHijo(object frmhijo)
        {
            if (this.Panel_Contenedor.Controls.Count >0)
                this.Panel_Contenedor.Controls.RemoveAt(0);
            Form fh = frmhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panel_Contenedor.Controls.Add(fh);
            this.Panel_Contenedor.Tag = fh;
            fh.Show();
        }

        private void Panel_Contenedor_Click(object sender, EventArgs e)
        {
            Panel_Producto.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_LogoReloj());
        }

        private void Prueba_Load(object sender, EventArgs e)
        {
            pictureBox1_Click(null, e);
        }

        private void Panel_superior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sonido_boton();
            this.WindowState = FormWindowState.Normal;
            btn_maximizar_todo.Visible = true;
           // btnMaximizar.Visible = true;
           // btnNormalizar.Visible = false;
            btn_normalizar_todo.Visible = false;
        }

        private void bnt_Cerrar_todo_Click(object sender, EventArgs e)
        {
            sonido_boton();
            if (MessageBox.Show("¿ESTA SEGURO QUE DESEA SALIR", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (System.Windows.Forms.DialogResult.Yes))
            {
                this.Close();
            }
        }

        private void btn_maximizar_todo_Click(object sender, EventArgs e)
        {
            sonido_boton();
            this.WindowState = FormWindowState.Maximized;
           // btnMaximizar.Visible = false;
            btn_maximizar_todo.Visible = false;
           // btnNormalizar.Visible = true;
            btn_normalizar_todo.Visible = true;
        }

        private void btn_Minimizar_Todo_Click(object sender, EventArgs e)
        {
            sonido_boton();
            this.WindowState = FormWindowState.Minimized;
        }

        private void bntFacturacion_MouseMove(object sender, MouseEventArgs e)
        {
      
        }

        private void bntFacturacion_MouseEnter(object sender, EventArgs e)
        {
            sonido_menu();
        }

        private void bntSuscripcion_MouseEnter(object sender, EventArgs e)
        {
            sonido_menu();
        }

        private void Panel_Ser_Admin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
