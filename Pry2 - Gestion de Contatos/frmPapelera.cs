using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pry2___Gestion_de_Contatos
{
    public partial class frmPapelera : Form
    {
        public frmPapelera()
        {
            InitializeComponent();
            conexion.CargarCombo(cmbRelacion);
            conexion.LlenarPapelera(dgvTabla);
        }

        //Instanciar
        clsConexion conexion = new clsConexion();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvTabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTabla.CurrentRow != null) // Verifica si hay una fila seleccionada
            {
                // Obtener la fila seleccionada actualmente
                DataGridViewRow fila = dgvTabla.CurrentRow;

                // Obtener los valores de las celdas de la fila seleccionada
                string nombre = fila.Cells["Nombre"].Value.ToString();
                string apellido = fila.Cells["Apellido"].Value.ToString();
                string numero = fila.Cells["Numero"].Value.ToString();
                string correo = fila.Cells["Correo"].Value.ToString();
                string cat = fila.Cells["Relacion"].Value.ToString();

                aux = aux = fila.Cells["Numero"].Value.ToString();

                // Mostrar los valores en la consola o utilizarlos según sea necesario
                txtNombre.Text = nombre;
                txtApellido.Text = apellido;
                txtNumero.Text = numero;
                txtCorreo.Text = correo;
                cmbRelacion.Text = cat;
            }
        }

        string aux;

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            string nom = txtNombre.Text;
            string apel = txtApellido.Text;
            string correo = txtCorreo.Text;
            string numero = txtNumero.Text;
            int cat = cmbRelacion.SelectedIndex;

            aux = numero;


            conexion.Eliminar(aux, "Papelera");
            conexion.LlenarPapelera(dgvTabla);

            //Limpiar aux
            aux = "";

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNumero.Text = "";
            txtCorreo.Text = "";
            cmbRelacion.Text = "";
        }

        public void LimpiarTXT()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNumero.Text = "";
            txtCorreo.Text = "";
            cmbRelacion.Text = "";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            conexion.LlenarPapelera(dgvTabla);
        }
    }
}
