﻿using System;
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
    public partial class Bienvenida_Login : Form
    {
        Login acceso = new Login();
        public static string muestra;
        public static int va;
        public Bienvenida_Login(string nombre,int validacion)
        {
            InitializeComponent();
            muestra = nombre;
            va = validacion;
            incializar();
            centrar();
        }

        public void incializar()
            {
            
                switch(va)
                {
                    case 0:
                        lbBienvenida.Text = "EL USUARIO NO EXISTE";
                    break;
                     case 1:
                     lbBienvenida.Text = "HA SUPERADO EL LIMITE DE INTENTOS";
                    
                    break;
                    case 2:
                         lbBienvenida.Text = "CONTRASEÑA INCORRECTA";
                    break;
                    case 3:
                    lbBienvenida.Text = "BIENVENIDO " + muestra;
                    pictureBox1.Image = Image.FromFile("C:\\BD\\Repositorio para Base de Datos Sql Server\\Gimnasio\\Base-de-Datos-Gimnasio\\Proyecto de Visual Studio C#\\Ginmasio\\Resources\\candado.png");
                    break;
            }
            }
        public void centrar()
        {
            int ancho_label, ancho_panel, y;
            // tamaño de panel (350;180)
            ancho_panel = Convert.ToInt32(panel1.Width);
            y = Convert.ToInt32(lbBienvenida.Location.Y);
            ancho_label = Convert.ToInt32(lbBienvenida.Width);
            lbBienvenida.Location = new Point((ancho_panel / 2) - (ancho_label / 2), y);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (va == 1)
            {
                Environment.Exit(0);//cierra toda la aplicacion
            }
        }
    }
}