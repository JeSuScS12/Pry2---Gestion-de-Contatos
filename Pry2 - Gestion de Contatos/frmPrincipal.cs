using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pry2___Gestion_de_Contatos
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            nuevo.CargarCombo(cmbRelacion);
            nuevo.LlenarTabla(dgvTabla);
        }

        //Instancair conexion
        clsConexion nuevo = new clsConexion();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            nuevo.LlenarNombre(dgvTabla);
        }


        private void cmbRelacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cmbRelacion.SelectedItem.ToString();
            nuevo.LlenarTabla2(dgvTabla,item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbRelacion.Text = "";
            nuevo.LlenarTabla(dgvTabla);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar frm = new frmAgregar();
            frm.ShowDialog();
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

                aux= aux = fila.Cells["Numero"].Value.ToString();

                // Mostrar los valores en la consola o utilizarlos según sea necesario
                lblNombre.Text = nombre;
                lblApellido.Text = apellido;
                lblNumero.Text = numero;
                lblCorreo.Text = correo;
                lblRelacion.Text = cat;
            }
        }

        string aux;

        private void button1_Click(object sender, EventArgs e)
        {
            frmModificar frm = new frmModificar();
            frm.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //-----
            string nom = lblNombre.Text;
            string apel = lblApellido.Text;
            string correo = lblCorreo.Text;
            string numero = lblNumero.Text;
            int cat = cmbRelacion.SelectedIndex;
            //---

            nuevo.Eliminar(aux, "Contactos");
            nuevo.CargarPapelera(nom,apel,correo,numero,cat);
            nuevo.LlenarTabla(dgvTabla);

            //Limpiar aux
            aux = "";

            lblNombre.Text = "";
            lblApellido.Text = "";
            lblNumero.Text = "";
            lblCorreo.Text = "";
            lblRelacion.Text = "";
        }

        private void btnPapelera_Click(object sender, EventArgs e)
        {
            frmPapelera frm = new frmPapelera();
            frm.ShowDialog();
        }
    }
}
