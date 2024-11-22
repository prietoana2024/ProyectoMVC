using System.Data.SqlClient;

namespace AppMvc.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        //Nuestro constructor es lo primero que se ejecuta 
        public Conexion()
        {

            // si nosotros usamos una variable var, es porque no sabemos de que tipo es

            //builder va a ser es obtener la cadena de conexion, en la estructura en comilla
            //agregamos el archivo donde se encuentra nuestra ruta

            var builder = new ConfigurationBuilder().SetBasePath
            (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:cadenaSQL").Value;


        }
        //Metodo para devolver nuestra cadena
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
