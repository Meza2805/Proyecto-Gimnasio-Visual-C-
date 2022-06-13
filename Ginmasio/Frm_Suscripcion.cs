using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Ginmasio
{
    public partial class Frm_Suscripcion : Form
    {
        public Frm_Suscripcion(String Cedula)
        {
            InitializeComponent();
            cargar_membresia();
            Cedula_empleado = Cedula;
          
        }
        Membresia Memb = new Membresia();
        Mensaje_Suscripcion caja;
        public static String Nombre_empleado;
        public static String Cedula_empleado;
        public static String Cedula_cliente;
        public static char codigo_membresia;
        public static DateTime fecha;
        public List<string> Membresia_codigo = new List<string>();
        
        public void cargar_membresia()
        {
            Membresia_codigo = Memb.Lista_Membresia();
            foreach(var item in Membresia_codigo)
            {
                cbMembresia.Items.Add(item.ToString());
            }

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Nombre_empleado = txtNombre_Busqueda.Text;
            dgvClientes.DataSource= Memb.Cargar_Clientes(Nombre_empleado);
        }

        private void dgvClientes_Click(object sender, EventArgs e)
        {
            txtCedula.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            txtPrimerNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtSegundoNombre.Text =  dgvClientes.CurrentRow.Cells[2].Value.ToString();
            txtPrimerApellido.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            txtSegundoApellido.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
            Cedula_cliente = dgvClientes.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //fecha = Convert.ToString(Memb.Registrar_Suscripcion(Cedula_cliente, Cedula_empleado, codigo_membresia).fecha);
            //MessageBox.Show(" la fecha es "+fecha);
            //caja = new Mensaje_Suscripcion(cbMembresia.Text,fecha);
            codigo_membresia = Memb.busqueda_membresia(cbMembresia.Text);
            if (Memb.Registrar_Suscripcion(Cedula_cliente, Cedula_empleado, codigo_membresia).valor == 0)
            {
                //MessageBox.Show("SUSCRIPCION REALIZADA CORRECTAMENTE");
                fecha = Memb.Registrar_Suscripcion(Cedula_cliente, Cedula_empleado, codigo_membresia).fecha;
                caja = new Mensaje_Suscripcion(cbMembresia.Text, fecha);
               // MessageBox.Show(" la fecha es " + fecha);
                caja.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR");
            }



        }
    }
}
