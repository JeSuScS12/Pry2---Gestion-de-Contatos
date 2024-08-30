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
            nuevo.LlenarTabla(dgvTabla);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string apel = txtApellido.Text;
            string correo = txtCorreo.Text;
            string numero = txtNumero.Text;
            string cat = cmbCategoria.Text;

            nuevo.CargarContacto(nom, apel,correo,numero,cat);
            nuevo.LlenarTabla(dgvTabla);
        }
    }
}
