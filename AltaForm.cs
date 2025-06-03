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
    public partial class AltaForm: Form
    {
        public AltaForm()
        {
            InitializeComponent();
            cmbCategoria.Items.AddRange(new string[] {
                "Alimentos Secos",
                "Alimentos Humedos",
                "Shampoo y Enjuagues",
                "Paseo",
                "Comprimidos",
                "Pipetas",
                "Venenos",
                "Cuidado Oral",
                "Huesos y Orejas",
                "Snacks",
                "Antidesparasitarios",
                "Educadores",
                "Sanitarios",
                "Comederos",
                "Ropa",
                "Camas",
                "Higiene",
            });
            cmbProovedor.Items.AddRange(new string[] {
                "MaxiPets",
                "Traverso",
                "HyM Balanceados",
                "Animal Brothes",
                "Copito",
                "Deleita",
                "Vital Crops",
            });
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "";

            if (categoria == "Alimentos secos")
            {
                txtPrecioVenta.Text = "–";
            }
            else
            {
                // Si hay precio de costo y % a agregar, se puede calcular
                if (decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) &&
                    decimal.TryParse(txtPorcentajeAgregar.Text, out decimal porcentaje))
                {
                    decimal precioVenta = precioCosto + (precioCosto * (porcentaje / 100));
                    txtPrecioVenta.Text = precioVenta.ToString("0.00");
                }
                else
                {
                    txtPrecioVenta.Text = "";
                }
            }
        }

        private void AltaForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
