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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
            nuevo.CargarCombo(cmbCategoria);
        }

        //Instancair conexion
        clsConexion nuevo = new clsConexion();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string apel = txtApellido.Text;
            string correo = txtCorreo.Text;
            string numero = txtNumero.Text;
            int cat = cmbCategoria.SelectedIndex;

            nuevo.CargarContacto(nom, apel, correo, numero, cat+1);
            LimpiarTXT();
        }

        public void LimpiarTXT()
        {
            txtNom.Text = "";
            txtApellido.Text = "";
            txtNumero.Text = "";
            txtCorreo.Text = "";
            cmbCategoria.Text = "";
            cmbCategoria.Text = "";

        }

        private void btnAgregarCat_Click(object sender, EventArgs e)
        {
            frmAddCategoria frm = new frmAddCategoria();
            frm.ShowDialog();
        }
    }
}
