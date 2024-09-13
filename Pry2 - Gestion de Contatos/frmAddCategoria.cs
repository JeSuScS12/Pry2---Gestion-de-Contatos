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
    public partial class frmAddCategoria : Form
    {
        public frmAddCategoria()
        {
            InitializeComponent();
            nuevo.LlenarCat(tvNombres);
        }

        //Instancair conexion
        clsConexion nuevo = new clsConexion();

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            string item = txtCat.Text;
            nuevo.CargarCat(item);
            nuevo.LlenarCat(tvNombres);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
