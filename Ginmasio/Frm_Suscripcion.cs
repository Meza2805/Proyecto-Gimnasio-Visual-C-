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
        public Frm_Suscripcion()
        {
            InitializeComponent();
        }
        Membresia Memb = new Membresia();
        static String Nombre;
        
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Nombre = txtNombre.Text;
            dgvClientes.DataSource= Memb.Cargar_Clientes(Nombre);
        }
    }
}
