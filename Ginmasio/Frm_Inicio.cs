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
        public static string n, a,Cedula_Empleado;
        Frm_Login ventana_login = new Frm_Login();

        public Frm_Inicio(string cedula,string nombre, string apellido)
        {
            InitializeComponent();
            Cedula_Empleado = cedula;
            n = nombre;
            a = apellido;
            mostrar_usuario_activo();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            abrirFormHijo(new Frm_LogoReloj());
        }


        /*Metodos*/
        public void mostrar_usuario_activo() //Metodo para mostrar el nombre del usuario activo en le panel superior
         {
            LbUsuario.Text = n + " " + a;
         }


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

        private void abrirFormHijo(object frmhijo) //Metodo para cargar los formularios hijos dentro del panel contenedor
        {
            if (this.Panel_Contenedor.Controls.Count > 0)
                this.Panel_Contenedor.Controls.RemoveAt(0);
            Form fh = frmhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.Panel_Contenedor.Controls.Add(fh);
            this.Panel_Contenedor.Tag = fh;
            fh.Show();
        }

        /*FIN METODOS*/


        //-----------BOTONES DE MINIMIZAR, MAXIMIZAR Y CERRAR---------------//
        private void btn_Minimizar_Todo_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_maximizar_todo_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btn_maximizar_todo.Visible = false;
            btn_normalizar_todo.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Normal;
            btn_maximizar_todo.Visible = true;

            btn_normalizar_todo.Visible = false;
        }


        private void bnt_Cerrar_todo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ESTA SEGURO QUE DESEA SALIR", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (System.Windows.Forms.DialogResult.Yes))
            {
                Environment.Exit(0);
            }
        }
        //-----------BOTONES DE MINIMIZAR, MAXIMIZAR Y CERRAR-------FIN--------//




        ///--------------------OPCIONES DE MENU-------------///
        private void button2_Click(object sender, EventArgs e) ///Menu Facturacion
        {
            contraer_menu_productos();
            abrirFormHijo(new Frm_Facturacion());
        }
        private void button1_Click(object sender, EventArgs e)//Menu Clientes
        {
            // sonido_boton();
            contraer_menu_productos();
            abrirFormHijo(new Frm_Cliente());
        }
        private void bntSuscripcion_Click(object sender, EventArgs e) //Menu suscripcion
        {
            contraer_menu_productos();
            abrirFormHijo(new Frm_Suscripcion(Cedula_Empleado)); //pasamos la cedula del empleado para establecer el empleado que atiende
        }

        private void bntAsistencia_Click(object sender, EventArgs e) //Menu Asistencia
        {
            contraer_menu_productos();
            abrirFormHijo(new Frm_Asistencia());
        }

        private void bntCompras_Click(object sender, EventArgs e)//Menu Compras
        {
            contraer_menu_productos();

        }

        private void button10_Click(object sender, EventArgs e)//Menu Reportes
        {
            contraer_menu_productos();
        }

    
        private void button9_Click(object sender, EventArgs e) //Menu Servicios Admin
        {
            contraer_menu_productos();
            Panel_Ser_Admin.Visible = true;

        }

        public static bool band_producto = true;
       
        private void btnProductos_Click(object sender, EventArgs e)//menu Productos
        {

            desplazar_menu_productos();
        }
        private void bntEmpleados_Click(object sender, EventArgs e) //Menu Empleados
        {
            contraer_menu_productos();
        }

        private void bntProovedores_Click(object sender, EventArgs e) //Menu Proovedores
        {
            contraer_menu_productos();

        }

        private void btnPro_Registro_Click(object sender, EventArgs e) //SubMenu Registro-Productos
        {
            Panel_Producto.Visible = false;
            abrirFormHijo(new Frm_P_Registro());
            contraer_menu_productos();
        }

        private void btnPro_Marcas_Click(object sender, EventArgs e)//SubMenu Marcas-Productos
        {
            Panel_Producto.Visible = false;
            contraer_menu_productos();
            abrirFormHijo(new Frm_P_Marca());
        }

        private void btnPro_Categoria_Click(object sender, EventArgs e) //SubMenu Marcas-Categoria
        {
            Panel_Producto.Visible = false;
            contraer_menu_productos();
            abrirFormHijo(new Frm_P_Categoria());
        }

        ///--------------------OPCIONES DE MENU--------FIN-----///

        private void button3_Click(object sender, EventArgs e)
        {
            Panel_Ser_Admin.Visible = false;
            Panel_Producto.Visible = false;

        }
        //private void Panel_Contenedor_Click(object sender, EventArgs e)
        //{
        //    Panel_Producto.Visible = true;
        //}


        private void panel5_Click(object sender, EventArgs e)
        {
           
        }

        private void Btn_Cambiar_Usuario_Click(object sender, EventArgs e)
        {
            ventana_login.Show();
            this.Close();
        }


        ////////////////////////////////////////////METODOS PARA CONFIGURACION DE PANELES////////////////////////////////////////




        //-Evento para mostrar formulario de reloj cuando se presiona la imagen del logo en le menu-//
        private void pcLogo_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Frm_LogoReloj());
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


        /// <summary>
        /// METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        /// </summary>
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











    }
}
