﻿using System;
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

        public void LlenarPapelera(DataGridView tab)
        {
            conectar = new OleDbConnection(cadena);
            try
            {
                conectar.Open();
                string consulta = "SELECT * FROM Papelera order by Nombre";

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

        //Ingresar Contactos nuevos a la lista   ---- Listo
        public void CargarContacto(string nom, string ape, string correo, string numero, string categ, string tipo)
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
                    if(tipo == "Contactos")
                    {
                        MessageBox.Show("¡Contacto agregado con éxito!");
                        conectar.Close();
                    }

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

        public void Modificar(string nom, string ape, string correo, string numero, string categ, string aux)
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

        public void CargarPapelera(string nom, string ape, string correo, string numero, string categ)
        {
            string consulta = $"insert into Papelera values('{nom}','{ape}','{numero}','{correo}','{categ}')";
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
                string consulta = $"SELECT * from Contactos where Categoria = '{item}'";

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
