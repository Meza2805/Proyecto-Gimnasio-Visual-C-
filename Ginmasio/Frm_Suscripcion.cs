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
            Cargar_membresia_precio();
            Cargar_registro_sus();

            Cedula_empleado = Cedula;
          
        }
        Membresia Memb = new Membresia();
        Mensaje_Suscripcion caja;
        public static String Nombre_empleado;
        public static String Cedula_empleado;
        public static String Cedula_cliente;
        public static char codigo_membresia;
        public static string fecha;
        public List<string> Membresia_codigo = new List<string>();
        
        public void cargar_membresia() //Metodo para cargar las membresias al ComboBox
        {
            Membresia_codigo = Memb.Lista_Membresia();
            foreach(var item in Membresia_codigo)
            {
                cbMembresia.Items.Add(item.ToString());
            }

        }


        public void Cargar_membresia_precio() //Metodo para cargar los precios de las membresia en el DataGridView
        {
            dgvPrecio_Membresia.DataSource = Memb.Mostrar_Precio_Membresia();
        }


        public void Cargar_registro_sus() //Metodo para mostrar el registro de membresias activas
        {
            dgv_Registro_Membresia.DataSource = Memb.Mostrar_susc();
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Nombre_empleado = txtNombre_Busqueda.Text;
            dgvClientes.DataSource= Memb.Cargar_Clientes(Nombre_empleado);
        }

        public bool validar_membresia()
        {
            bool band= true;
            if(txtCedula.Text.Length == 0 )
            {
               
                band= false;
            }
            return band;
        }


        private void dgvClientes_Click(object sender, EventArgs e)
        {
            try
            {
                txtCedula.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                txtPrimerNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtSegundoNombre.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtPrimerApellido.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtSegundoApellido.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                Cedula_cliente = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            }
            catch(NullReferenceException)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codigo_membresia= Memb.busqueda_membresia(cbMembresia.Text);
  
            Memb.Registrar_Suscripcion(Cedula_cliente, Cedula_empleado, codigo_membresia); //Instancia del objeto para registrar la suscripcion
            caja = new Mensaje_Suscripcion();//Instanciamos el formulario con el parametro
            AddOwnedForm(caja); //asignamos este formulario como propietario
            caja.ShowDialog(); //mostramos la vent
         
           

            /*
           
            if (validar_membresia() == false)
            {
                MessageBox.Show("DEBE BUSCAR UN CLIENTE ANTES DE SUSCRIPCION", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                errorProvider1.SetError(txtNombre_Busqueda,"ERROR");
            }
            else
            {
                
            }*/


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
