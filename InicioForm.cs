using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuellitasAppLocal
{
    public partial class InicioForm: Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonProducto_Click(object sender, EventArgs e)
        {
            var formProductos = new ProductosForm(); // O el nombre que le pusiste
            formProductos.Show();
            this.Hide(); // Si querés ocultar el formulario principal
        }

        private void InicioForm_Load(object sender, EventArgs e)
        {
            DBHelper.CrearBaseSiNoExiste();
        }
    }
}
