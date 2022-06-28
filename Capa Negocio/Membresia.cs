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
        SqlDataReader reader;

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
            comando.ExecuteNonQuery();
            Adaptador.Fill(Clientes);
            Conexion.conexion_datos.Close();
            return Clientes;
        }

        public List<string> Lista_Membresia()
        {
            List<string> lista = new List<string>();
            Conexion.conexion_datos.Open();
            comando = new SqlCommand();
            comando.CommandText = "select Descripcion from Membresia";
            comando.Connection = Conexion.conexion_datos;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(reader["Descripcion"].ToString());
            }
            Conexion.conexion_datos.Close();
            return lista;
        }

        public char busqueda_membresia(string descripcion)
        {
            char id_membresia;
            Conexion.conexion_datos.Open();
            comando = new SqlCommand();
            comando.CommandText = "Buscar_ID_Membresia";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@descripcion", System.Data.SqlDbType.VarChar)).Value=descripcion;
            comando.Parameters.Add("@id_membresia", SqlDbType.Char, 1).Direction = ParameterDirection.Output;
            comando.Connection = Conexion.conexion_datos;
            comando.ExecuteNonQuery();
            id_membresia = Convert.ToChar(comando.Parameters["@id_membresia"].Value);
            Conexion.conexion_datos.Close();
            return id_membresia;
        }

        public struct salida_sus
        {
            public int valor;
            public string fecha;
        }
        public void Registrar_Suscripcion(String cedula_cliente, String cedula_empleado,char id_membresia)
        {
            Conexion.conexion_datos.Open();
            salida_sus salida;
            comando = new SqlCommand();
            comando.CommandText = "SP_Insertar_Suscripcion";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@id_cliente", System.Data.SqlDbType.VarChar)).Value = cedula_cliente;
            comando.Parameters.Add(new SqlParameter("@id_empleado",System.Data.SqlDbType.VarChar)).Value = cedula_empleado;
            comando.Parameters.Add(new SqlParameter("@id_membresia", System.Data.SqlDbType.VarChar)).Value = id_membresia;
            comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            comando.Parameters.Add("@fecha_convertida", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
            comando.Connection = Conexion.conexion_datos;
            comando.ExecuteNonQuery();
            salida.valor = Convert.ToInt32(comando.Parameters["@salida"].Value);
            salida.fecha = Convert.ToString(comando.Parameters["@fecha_convertida"].Value);
            Conexion.conexion_datos.Close();
            //return salida;
        }

        public DataTable Buscar_Membresia_cliente(string cedula_cliente)
        {

            DataTable cliente = new DataTable();
            Conexion.conexion_datos.Open();
            comando = new SqlCommand();
            comando.CommandText = "SP_Sus_Cliente";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add(new SqlParameter("@ID_Cliente",System.Data.SqlDbType.VarChar)).Value =cedula_cliente;
            comando.Connection = Conexion.conexion_datos;
            comando.ExecuteNonQuery();
            Adaptador = new SqlDataAdapter(comando);
            Adaptador.Fill(cliente);
            Conexion.conexion_datos.Close();
            return cliente;

        }


        public DataTable Mostrar_Precio_Membresia()
        {
            DataTable tabla = new DataTable();
            Conexion.conexion_datos.Open();
            comando = new SqlCommand();
            comando.CommandText = "SP_Membresia_Precio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = Conexion.conexion_datos;
            comando.ExecuteNonQuery();
            Adaptador = new SqlDataAdapter(comando);
            Adaptador.Fill(tabla);
            Conexion.conexion_datos.Close();
            return tabla;
        }


        public DataTable Mostrar_susc ()
        {
            DataTable tabla = new DataTable();
            Conexion.conexion_datos.Open();
            comando = new SqlCommand();
            comando.CommandText = "SP_Registro_Membresias";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection = Conexion.conexion_datos;
            comando.ExecuteNonQuery();
            Adaptador = new SqlDataAdapter(comando);
            Adaptador.Fill(tabla);
            Conexion.conexion_datos.Close();
            return tabla;
        }

    }
}
