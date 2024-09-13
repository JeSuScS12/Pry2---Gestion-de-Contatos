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
            cadena = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../BD/Contactos.accdb";
        }

        public void Conect()
        {
            try
            {
                conectar = new OleDbConnection(cadena);
                conectar.Open();
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
                string consulta = "SELECT Contactos.Nombre as Nombre , Contactos.Apellido as Apellido, Contactos.Numero, Contactos.Correo, Categoria.NombreCat as Relacion  " +
                                  "FROM Contactos INNER JOIN Categoria ON Categoria.IdCategoria = Contactos.Categoria order by Nombre;";

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

        public void LlenarTabla2(DataGridView tab, string item)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = $"SELECT Contactos.Nombre as Nombre , Contactos.Apellido as Apellido, Contactos.Numero, Contactos.Correo, Categoria.NombreCat as Relacion    FROM Contactos INNER JOIN Categoria ON Categoria.IdCategoria = Contactos.Categoria  where Categoria.NombreCat = '{item}'";

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

        public void LlenarNombre(DataGridView tabla)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT  Nombre,  Apellido, numero, correo,Categoria  FROM Contactos";

                comando = new OleDbCommand(consulta, conectar);
                OleDbDataReader reader = comando.ExecuteReader();


                // Agrega los datos al ComboBox
                while (reader.Read())
                {
                }

                reader.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }

        }


        public void LlenarCat(TreeView arbol)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT  NombreCat  FROM Categoria";

                comando = new OleDbCommand(consulta, conectar);
                OleDbDataReader reader = comando.ExecuteReader();

                // Limpia los items del ComboBox antes de agregar nuevos datos
                arbol.Nodes.Clear();

                // Agrega los datos al ComboBox
                while (reader.Read())
                {
                    string nombre = reader.GetString(0);

                    arbol.Nodes.Add(nombre);
                }

                reader.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }

        }

        public void CargarCat(string categ)
        {
            string consulta = $"insert into Categoria (NombreCat) values('{categ}')";
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    conectar.Close();
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


        public void LlenarPapelera(DataGridView tab)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT Papelera.Nombre as Nombre , Papelera.Apellido as Apellido, Papelera.Numero, Papelera.Correo, Papelera.Categoria as Relacion  " +
                                  "FROM Papelera INNER JOIN Categoria ON Categoria.IdCategoria = Papelera.Categoria order by Nombre;";

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
                string consulta = "SELECT  NombreCat FROM Categoria";

                comando = new OleDbCommand(consulta, conectar);
                OleDbDataReader reader = comando.ExecuteReader();

                // Limpia los items del ComboBox antes de agregar nuevos datos
                comboBox.Items.Clear();

                // Agrega los datos al ComboBox
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["NombreCat"].ToString());
                }

                reader.Close();

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }

        }

        //Agregar Categoria y Llenar tabla
        public void LlenarTabCat(DataGridView tabla)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "select IdCategoria as Id, NombreCat as Relacion from Categoria";

                adaptador = new OleDbDataAdapter(consulta, conectar);
                DataTable dataTable = new DataTable();

                adaptador.Fill(dataTable);
                tabla.DataSource = dataTable;

            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }
        public void CargarCats(string item)
        {
            string consulta = $"insert into Categoria(NombreCat) values('{item}')";
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    MessageBox.Show("¡Categoria agregada con éxito!");
                    conectar.Close();
                }
                else
                {
                    MessageBox.Show("No se agregó la Categoria.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }


        //Ingresar Contactos nuevos a la lista   ---- Listo
        public void CargarContacto(string nom, string ape, string correo, string numero, int tipo)
        {
            string consulta = $"insert into Contactos values('{nom}','{ape}','{numero}','{correo}', {tipo})";
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
                    conectar.Close();
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

        public void Modificar(string nom, string ape, string correo, string numero, int categ, string aux)
        {


            string consulta = $"update Contactos set Nombre = '{nom}' , Apellido ='{ape}' ,numero='{numero}' , correo ='{correo}' ,Categoria='{categ}'  where numero = '{aux}'";  // <--- Cambiar numero
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    MessageBox.Show("¡Contacto modificado con éxito!", "Notificacion");
                    conectar.Close();
                }
                else
                {
                    MessageBox.Show("No se modifico el Contacto.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        public void Eliminar(string aux, string tipo)
        {
            string consulta = $"delete from {tipo}  where numero = '{aux}'";  // <--- Cambiar numero
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {

                    if(tipo == "Contactos")
                    {
                        MessageBox.Show("¡Contacto Eliminado con éxito!", "Notificacion");
                        conectar.Close();
                    }
                    else 
                    {
                        MessageBox.Show("¡Contacto Restaurado con éxito!", "Notificacion");
                        conectar.Close();
                    }
                }
                
                else
                {
                    MessageBox.Show("No se Elimino el Contacto.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }

        public void CargarPapelera(string nom, string ape, string correo, string numero, int categ)
        {
            string consulta = $"insert into Papelera values('{nom}','{ape}','{numero}','{correo}',{categ})";
            conectar = new OleDbConnection(cadena);

            comando = new OleDbCommand(consulta, conectar);
            try
            {
                conectar.Open();

                int result = comando.ExecuteNonQuery();
                // Comprobar si se Agrego
                if (result > 0)
                {
                    conectar.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error" + error);
            }
        }


        public void FiltrarCat(DataGridView tab, string item)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT Contactos.Nombre, Contactos.Apellido, Contactos.Numero, Contactos.Correo, Categoria.NombreCat as Relacion  " +
                                  $"FROM Contactos INNER JOIN Categoria ON Categoria.IdCategoria = Contactos.Categoria WHERE Relacion = '{item}';";

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
    }
}   
