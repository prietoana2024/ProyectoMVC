using AppMvc.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace AppMvc.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Lista()
        {
            var contactos = new List<ContactoModel>();


            //en la siguiente linea creare un instancia para conectarme con mi bd

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //Voy a llamar a mi procedimieno almacenado
                SqlCommand cmd = new SqlCommand("Sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    //Con el while voy a hacer de todo el reultado de la ejecucion
                    while (dr.Read())
                    {
                        contactos.Add(new ContactoModel()
                        {
                            //columna que tiene que leer
                            idContacto = Convert.ToInt32(dr["idContacto"]),
                            nombre = Convert.ToString(dr["nombre"]),
                            telefono = Convert.ToString(dr["telefono"]),
                            correo = Convert.ToString(dr["correo"])

                        });
                    }
                }
            }

            return contactos;
        }

        //SEGUNDO METODO

        public ContactoModel Obtener(int idContacto)
        {
            var contacto = new ContactoModel();
            //en la siguiente linea creare un instancia para conectarme con mi bd
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                //Voy a llamar a mi procedimieno almacenado
                SqlCommand cmd = new SqlCommand("Sp_Obtener", conexion);

                cmd.Parameters.AddWithValue("idContacto",idContacto);

                cmd.CommandType = CommandType.StoredProcedure;

                //creamos otro using para leer el resultado

                using (var dr = cmd.ExecuteReader())
                {
                    //Con el while voy a hacer de todo el reultado de la ejecucion
                    while (dr.Read())
                    {
                        contacto.idContacto = Convert.ToInt32(dr["idContacto"]);
                        contacto.nombre =dr["nombre"].ToString();
                        contacto.telefono =dr["telefono"].ToString();
                        contacto.correo = dr["correo"].ToString();
                    }
                }
            }
            return contacto;
        }

        //TERCER METODO GUARDAR

        public bool Guardar(ContactoModel contactoNuevo)
        {
            bool rsp;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //Voy a llamar a mi procedimieno almacenado
                    SqlCommand cmd = new SqlCommand("Sp_Guardar", conexion);

                    cmd.Parameters.AddWithValue("nombre", contactoNuevo.nombre);
                    cmd.Parameters.AddWithValue("telefono", contactoNuevo.telefono);
                    cmd.Parameters.AddWithValue("correo", contactoNuevo.correo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    //creamos otro using para leer el resultado

                }
                rsp = true;
            }
            catch(Exception e)
            {
                string error=e.Message;
                rsp = false;
            }
            return rsp;
        }
        //CUARTO METODO DE EDITAR
        public bool Editar(ContactoModel contactoEditar)
        {
            bool rsp;
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //Voy a llamar a mi procedimieno almacenado
                    SqlCommand cmd = new SqlCommand("Sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("idContacto", contactoEditar.idContacto);
                    cmd.Parameters.AddWithValue("nombre", contactoEditar.nombre);
                    cmd.Parameters.AddWithValue("telefono", contactoEditar.telefono);
                    cmd.Parameters.AddWithValue("correo", contactoEditar.correo);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    //creamos otro using para leer el resultado

                }
                rsp = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rsp = false;
            }
            return rsp;
        }

        //QUINTO  METODO ELIMINAR

        public bool Eliminar(int idContacto) 
        { 
            bool rsp;

            try{
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    //Voy a llamar a mi procedimieno almacenado

                   
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar", conexion);

                    cmd.Parameters.AddWithValue("idContacto", idContacto);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rsp = true;

            }
            catch (Exception e)
            {
                string error = e.Message;
                rsp = false;
            }

            return rsp;
        }

    }

}