using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace HuellitasAppLocal
{
    public partial class ModificarProductoForm : Form
    {
        private int productoId;
        private string categoria;

        public ModificarProductoForm(DataGridViewRow row)
        {
            InitializeComponent();

            productoId = Convert.ToInt32(row.Cells["id"].Value);
            categoria = row.Cells["categoria"].Value.ToString();

            txtNombre.Text = row.Cells["nombre"].Value.ToString();
            txtPrecioCosto.Text = row.Cells["precioCosto"].Value.ToString();
            txtPrecioPorBolsa.Text = row.Cells["PrecioPorBolsa"].Value.ToString();
            txtPrecioPorKilo.Text = row.Cells["PrecioPorKilo"].Value.ToString();
            txtStock.Text = row.Cells["stock"].Value.ToString();
            txtKgPorBolsa.Text = row.Cells["KgPorBolsa"].Value.ToString();

            // Asignar proveedor
            List<string> proveedores = new List<string> { "HyM Balanceados", "Traverso", "Copito", "Deleita", "Vital Crops", "Animal Brothes", "Maxi Pet" };
            cmbProveedor.DataSource = proveedores;

            string proveedorActual = row.Cells["proveedor"].Value.ToString();
            if (cmbProveedor.Items.Contains(proveedorActual))
                cmbProveedor.SelectedItem = proveedorActual;
            else
                cmbProveedor.Items.Insert(0, proveedorActual);

            // Activar campos según categoría
            if (categoria == "Alimentos Secos")
            {
                // Habilitados
                txtNombre.Enabled = true;
                txtPrecioCosto.Enabled = true;
                cmbProveedor.Enabled = true;
                txtStock.Enabled = true;
                txtKgPorBolsa.Enabled = true;

                // Calculados y bloqueados
                txtPrecioPorBolsa.ReadOnly = true;
                txtPrecioPorKilo.ReadOnly = true;

                // Deshabilitar campos que no aplican
                txtPrecioVenta.Enabled = false;
                txtItemPorPack.Enabled = false;
                //txtSubcategoria.Enabled = false;
                txtPorcentajeAgregar.Enabled = false;

                // Cálculo automático
                txtPrecioCosto.TextChanged += (s, e) => CalcularPrecios();
                txtKgPorBolsa.TextChanged += (s, e) => CalcularPrecios();
                CalcularPrecios();
            }
            else
            {
                // Habilitados
                txtNombre.Enabled = true;
                txtPrecioCosto.Enabled = true;
                cmbProveedor.Enabled = true;
                txtStock.Enabled = true;
                txtItemPorPack.Enabled = true;
                //txtSubcategoria.Enabled = true;
                txtPorcentajeAgregar.Enabled = true;

                // Calculado y bloqueado
                txtPrecioVenta.ReadOnly = true;

                // Deshabilitar campos de alimentos
                txtPrecioPorBolsa.Enabled = false;
                txtPrecioPorKilo.Enabled = false;
                txtKgPorBolsa.Enabled = false;

                // Cálculo automático
                txtPrecioCosto.TextChanged += (s, e) => CalcularPrecioVenta();
                txtPorcentajeAgregar.TextChanged += (s, e) => CalcularPrecioVenta();
                CalcularPrecioVenta();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string connectionString = "Data Source=huellitas.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query;
                using (var cmd = new SQLiteCommand(connection))
                {
                    if (categoria == "Alimentos Secos")
                    {
                        query = @"UPDATE productos SET 
                                    nombre = @nombre,
                                    precioCosto = @precioCosto,
                                    PrecioPorBolsa = @precioPorBolsa,
                                    PrecioPorKilo = @precioPorKilo,
                                    proveedor = @proveedor,
                                    stock = @stock,
                                    KgPorBolsa = @kgPorBolsa
                                  WHERE id = @id";

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@precioPorBolsa", Convert.ToDecimal(txtPrecioPorBolsa.Text));
                        cmd.Parameters.AddWithValue("@precioPorKilo", Convert.ToDecimal(txtPrecioPorKilo.Text));
                        cmd.Parameters.AddWithValue("@kgPorBolsa", Convert.ToDecimal(txtKgPorBolsa.Text));
                    }
                    else
                    {
                        query = @"UPDATE productos SET 
                                    nombre = @nombre,
                                    precioCosto = @precioCosto,
                                    proveedor = @proveedor,
                                    stock = @stock,
                                    ItemPorPack = @itemPorPack,
                                    PorcentajeAgregar = @porcentajeAgregar,
                                    PrecioVentaKgPorBolsa = @precioVenta
                                  WHERE id = @id";

                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@itemPorPack", txtItemPorPack.Text);
                        cmd.Parameters.AddWithValue("@porcentajeAgregar", txtPorcentajeAgregar.Text);
                        cmd.Parameters.AddWithValue("@precioVenta", txtPrecioVenta.Text);
                    }

                    // Comunes
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@precioCosto", Convert.ToDecimal(txtPrecioCosto.Text));
                    cmd.Parameters.AddWithValue("@proveedor", cmbProveedor.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));
                    cmd.Parameters.AddWithValue("@id", productoId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CalcularPrecios()
        {
            if (decimal.TryParse(txtPrecioCosto.Text, out decimal costo) &&
                decimal.TryParse(txtKgPorBolsa.Text, out decimal kilos) &&
                kilos > 0)
            {
                decimal precioBolsa = costo * 1.19m;
                decimal precioKilo = (costo / kilos) * 1.35m;

                txtPrecioPorBolsa.Text = precioBolsa.ToString("0.00");
                txtPrecioPorKilo.Text = precioKilo.ToString("0.00");
            }
        }

        private void CalcularPrecioVenta()
        {
            if (decimal.TryParse(txtPrecioCosto.Text, out decimal costo) &&
                decimal.TryParse(txtPorcentajeAgregar.Text, out decimal porcentaje))
            {
                decimal precioVenta = costo + (costo * (porcentaje / 100));
                txtPrecioVenta.Text = precioVenta.ToString("0.00");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioCosto.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Todos los campos obligatorios deben estar completos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) || precioCosto < 0 ||
                !int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Revisá que los campos numéricos sean válidos y mayores a cero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (categoria == "Alimentos Secos")
            {
                if (!decimal.TryParse(txtKgPorBolsa.Text, out decimal kg) || kg <= 0)
                {
                    MessageBox.Show("Kg por bolsa debe ser mayor a cero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                if (!decimal.TryParse(txtPorcentajeAgregar.Text, out decimal porcentaje) || porcentaje < 0)
                {
                    MessageBox.Show("Porcentaje debe ser un número positivo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
    }
}
