using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;

namespace TiempodeUnaCervezaDef
{

    class LlenadoCB
    {
        private string connectionString = "//";

        public List<Cervezas> Get()
        {
            
            List<Cervezas> cervezasList = new List<Cervezas>();
            string query = "select Id, Nombre, Mililitros, GradosAlcohol from cervezacont";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    int mililitros = reader.GetInt32(2);
                    double gradosalcohol = reader.GetDouble(3);

                    Cervezas cervezas = new Cervezas(id, nombre, mililitros, gradosalcohol);
                    cervezasList.Add(cervezas);
                }
                reader.Close();
                conn.Close();
            }
                
            return cervezasList;
        }
    }
}
