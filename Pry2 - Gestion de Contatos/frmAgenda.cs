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
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        clsConexion nuevo = new clsConexion();

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            nuevo.Conect();
            nuevo.CargarCombo(cmbCateFiltro);
            nuevo.CargarCombo(cmbCategoria);
            nuevo.LlenarTabla(dgvTabla);
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void frm_close(object sender, FormClosingEventArgs e)
        {
            nuevo.CargarCombo(cmbCategoria);
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar ventana = new frmAgregar();
            ventana.ShowDialog();
        }

        //string nom = txtNom.Text;
        //string apel = txtApellido.Text;
        //string correo = txtCorreo.Text;
        //string numero = txtNumero.Text;
        //string cat = cmbCategoria.Text;

        //nuevo.CargarContacto(nom, apel, correo, numero, cat,"Contactos");
        //    nuevo.LlenarTabla(dgvTabla);
        //    LimpiarTXT();
    

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string apel = txtApellido.Text;
            string correo = txtCorreo.Text;
            string numero = txtNumero.Text;
            int cat = cmbCategoria.SelectedIndex;

            nuevo.Modificar(nom, apel, correo, numero, cat+1,aux);
            nuevo.LlenarTabla(dgvTabla);

            //Limpiar aux
            aux = "";           

            //Btns falsos
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            LimpiarTXT();

        }
        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //-----
            string nom = txtNom.Text;
            string apel = txtApellido.Text;
            string correo = txtCorreo.Text;
            string numero = txtNumero.Text;
            int cat = cmbCategoria.SelectedIndex;
            //---
            nuevo.CargarPapelera(nom, apel, correo, numero, cat);

            nuevo.Eliminar(aux,"Contactos");
            nuevo.LlenarTabla(dgvTabla);

            //Limpiar aux
            aux = "";

            //Btns falsos
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            LimpiarTXT();
        }


        //Funciones

        
        public void LimpiarTXT()
        {
            txtNom.Text = "";
            txtApellido.Text = "";
            txtNumero.Text = "";
            txtCorreo.Text = "";
            cmbCategoria.Text = "";
            cmbCateFiltro.Text = "";

            nuevo.LlenarTabla(dgvTabla);
        }

        //AUX --> Global para guardar el numero que es una llave
        string aux;

        private void dgvTabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;

            btnAgregar.Enabled = false;

            if (dgvTabla.CurrentRow != null) // Verifica si hay una fila seleccionada
            {
                // Obtener la fila seleccionada actualmente
                DataGridViewRow fila = dgvTabla.CurrentRow;

                // Obtener los valores de las celdas de la fila seleccionada
                string nombre = fila.Cells["Nombre"].Value.ToString(); // Cambia "Nombre" por el nombre de tu columna
                string apellido = fila.Cells["Apellido"].Value.ToString();
                string num = fila.Cells["Numero"].Value.ToString();
                string correo = fila.Cells["Correo"].Value.ToString();
                string cat = fila.Cells["Relacion"].Value.ToString();

                aux = fila.Cells["Numero"].Value.ToString();

                // Mostrar los valores en la consola o utilizarlos según sea necesario
                txtNom.Text = nombre;
                txtApellido.Text = apellido;
                txtNumero.Text = num;
                txtCorreo.Text = correo;
                cmbCategoria.Text = cat;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTXT();
            //Limpiar aux
            aux = "";

            //Btns False - True
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }

        private void cmbCateFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item;

            item = cmbCateFiltro.Text;
            nuevo.FiltrarCat(dgvTabla, item);
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            nuevo.LlenarPapelera(dgvPapelera);
        }

        private void dgvPapelera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPapelera.CurrentRow != null) // Verifica si hay una fila seleccionada
            {
                // Obtener la fila seleccionada actualmente
                DataGridViewRow fila = dgvPapelera.CurrentRow;

                // Obtener los valores de las celdas de la fila seleccionada
                string nombre = fila.Cells["Nombre"].Value.ToString(); 
                string apellido = fila.Cells["Apellido"].Value.ToString();
                string num = fila.Cells["Numero"].Value.ToString();
                string correo = fila.Cells["Correo"].Value.ToString();
                string cat = fila.Cells["Relacion"].Value.ToString();

                aux = fila.Cells["Numero"].Value.ToString();

                // Mostrar los valores en la consola o utilizarlos según sea necesario
                lblNombre.Text = nombre;
                lblApellido.Text = apellido;
                lblNumero.Text = num;
                lblCorreo.Text = correo;
                lblCategoria.Text = cat;
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            string nom = lblNombre.Text;
            string apel = lblApellido.Text;
            string correo = lblCorreo.Text;
            string numero = lblNumero.Text;
            string cat = lblCategoria.Text;

            aux = numero;

            
            nuevo.Eliminar(aux,"Papelera");
            nuevo.LlenarPapelera(dgvPapelera);
            nuevo.LlenarTabla(dgvTabla);

            //Limpiar aux
            aux = "";

            lblNombre.Text = "";
            lblApellido.Text = "";
            lblNumero.Text = "";
            lblCorreo.Text = "";
            lblCategoria.Text = "";



        }

        private void btnAgregarCat_Click(object sender, EventArgs e)
        {
            frmAddCategoria catAdd = new frmAddCategoria();
            catAdd.ShowDialog();
            catAdd.FormClosing += frm_close;
        }

        private void dgvPapelera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
