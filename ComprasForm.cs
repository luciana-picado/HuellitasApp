using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuellitasAppLocal
{
    public partial class ComprasForm: Form
    {
        private DataTable tablaProductos;
        private decimal subtotal = 0;

        public ComprasForm()
        {
            InitializeComponent();
        }
        private void ComprasForm_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=huellitas.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nombre, proveedor, precioCosto FROM productos";

                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    tablaProductos = new DataTable();
                    adapter.Fill(tablaProductos);
                    dgvProductos.DataSource = tablaProductos;
                }
            }

            // Columnas del dgvListaCompra
            dgvListaCompra.Columns.Clear();
            dgvListaCompra.Columns.Add("Nombre", "Nombre");
            dgvListaCompra.Columns.Add("Proveedor", "Proveedor");
            dgvListaCompra.Columns.Add("Cantidad", "Cantidad");
            dgvListaCompra.Columns.Add("PrecioCosto", "Precio Costo");
            dgvListaCompra.Columns.Add("Total", "Total");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            (dgvProductos.DataSource as DataTable).DefaultView.RowFilter =
                $"nombre LIKE '%{txtBuscar.Text}%'"; // Filtra por nombre
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
                    return;

                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Cantidad inválida.");
                    return;
                }

                string nombre = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
                string proveedor = dgvProductos.CurrentRow.Cells["proveedor"].Value.ToString();
                decimal precioCosto = Convert.ToDecimal(dgvProductos.CurrentRow.Cells["precioCosto"].Value);
                decimal total = precioCosto * cantidad;

                dgvListaCompra.Rows.Add(nombre, proveedor, cantidad, precioCosto.ToString("0.00"), total.ToString("0.00"));

                // Actualizar subtotal
                decimal subtotal = 0;
                foreach (DataGridViewRow row in dgvListaCompra.Rows)
                {
                    if (!row.IsNewRow)
                        subtotal += Convert.ToDecimal(row.Cells["Total"].Value);
                }

                txtSubtotal.Text = subtotal.ToString("0.00");
                txtCantidad.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar producto: " + ex.Message);
            }
        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea finalizar la compra?", "Confirmación", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            string connectionString = "Data Source=huellitas.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                foreach (DataGridViewRow row in dgvListaCompra.Rows)
                {
                    string nombre = row.Cells["Nombre"].Value.ToString();
                    string proveedor = row.Cells["Proveedor"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precioCosto = Convert.ToDecimal(row.Cells["PrecioCosto"].Value);
                    decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string query = @"INSERT INTO Compras (nombre, proveedor, cantidad, precioCosto, total, fecha)
                             VALUES (@nombre, @proveedor, @cantidad, @precioCosto, @total, @fecha)";
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@proveedor", proveedor);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@precioCosto", precioCosto);
                        cmd.Parameters.AddWithValue("@total", total);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Compra registrada exitosamente.");
            dgvListaCompra.Enabled = false;
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close(); // o volver al formulario principal
            InicioForm inicio = new InicioForm();
            inicio.Show();
        }
    }
}
