using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Pry2___Gestion_de_Contatos
{
    internal class clsConexion
    {
        OleDbCommand comando;
        OleDbConnection conectar;
        OleDbDataAdapter adaptador;

        string cadena;

        public clsConexion()
        {
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./BD/Contactos.accdb";
        }

        public void Conect()
        {
            try
            {
                conectar = new OleDbConnection(cadena);
                conectar.Open();
                MessageBox.Show("Se conecto a BD");
            }
            catch (Exception x)
            {
                MessageBox.Show("Error" + x, "😒");
            }
        }

        //Llena la tabla con todos los datos de la BD
        public void LlenarTabla(DataGridView tab)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT * FROM Contactos order by Nombre";

                adaptador = new OleDbDataAdapter(consulta, conectar);
                DataTable dataTable = new DataTable();

                adaptador.Fill(dataTable);
                tab.DataSource = dataTable;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        //Llenar Combo

        public void CargarCombo(ComboBox comboBox)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT DISTINCT Categoria FROM Contactos";

                comando = new OleDbCommand(consulta, conectar);
                OleDbDataReader reader = comando.ExecuteReader();

                // Limpia los items del ComboBox antes de agregar nuevos datos
                comboBox.Items.Clear();

                // Agrega los datos al ComboBox
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["Categoria"].ToString());
                }

                reader.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }


        }
        //Ingresar Productos nuevos a la lista   ---- Por hacer
        public void CargarContacto(string nom, string ape, string correo, string numero, string categ)
        {
            string consulta = $"insert into Contactos values('{nom}','{ape}','{numero}','{correo}','{categ}')";
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    MessageBox.Show("¡Contacto agregado con éxito!");
                }
                else
                {
                    MessageBox.Show("No se agregó el Contacto.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }

        }
    }
}
