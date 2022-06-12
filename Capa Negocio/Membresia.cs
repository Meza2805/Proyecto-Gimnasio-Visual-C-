using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Negocio;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Negocio
{
    public class Membresia
    {
        Capa_Datos.Acceso Conexion = new Capa_Datos.Acceso();
        private SqlCommand comando;
        SqlDataAdapter Adaptador;


        public DataTable Cargar_Clientes(String nombre)
        {
            DataTable Clientes = new DataTable();
            Conexion.conexion_datos.Open();
            comando = new SqlCommand();
            comando.CommandText = "SP_Cargar_Clientes";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = Conexion.conexion_datos;
            Adaptador = new SqlDataAdapter(comando);
            comando.Parameters.Add(new SqlParameter("@Nombre",System.Data.SqlDbType.VarChar)).Value = nombre;
            Adaptador.Fill(Clientes);
            Conexion.conexion_datos.Close();
            return Clientes;
        }

    }
}
