using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ginmasio
{
    public partial class Mensaje_Suscripcion : Form
    {
        public Mensaje_Suscripcion(String membresia,DateTime f)
        {
            InitializeComponent();
            txtMembresia.Text = Convert.ToString(membresia);
            fecha = f;
            txtFecha.Text = f.ToShortDateString();          
        }
        public static DateTime fecha;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
