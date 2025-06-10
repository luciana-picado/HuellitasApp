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
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            txtPrecioCosto.TextChanged += Campos_TextChanged;
            txtKgBolsa.TextChanged += Campos_TextChanged;
            txtPorcentajeAgregar.TextChanged += Campos_TextChanged;

        }
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "";

            // Verificamos si el precio de costo es válido
            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) || precioCosto <= 0)
            {
                txtPrecioPorBolsa.Text = "";
                txtPrecioPorKilo.Text = "";
                txtPrecioVenta.Text = "";
                return;
            }

            if (categoria == "Alimentos Secos")
            {
                // Solo calcula si los kilos están bien cargados
                if (decimal.TryParse(txtKgBolsa.Text, out decimal kgBolsa) && kgBolsa > 0)
                {
                    decimal precioBolsa = precioCosto * 1.19m;
                    decimal precioKilo = (precioCosto / kgBolsa) * 1.35m;

                    txtPrecioPorBolsa.Text = precioBolsa.ToString("0.00");
                    txtPrecioPorKilo.Text = precioKilo.ToString("0.00");
                }
                else
                {
                    txtPrecioPorBolsa.Text = "";
                    txtPrecioPorKilo.Text = "";
                }

                txtPrecioVenta.Text = ""; // no se usa
            }
            else
            {
                // Calcula el precio de venta si hay un porcentaje válido
                if (decimal.TryParse(txtPorcentajeAgregar.Text, out decimal porcentaje) && porcentaje >= 0)
                {
                    decimal precioVenta = precioCosto + (precioCosto * (porcentaje / 100));
                    txtPrecioVenta.Text = precioVenta.ToString("0.00");
                }
                else
                {
                    txtPrecioVenta.Text = "";
                }

                txtPrecioPorBolsa.Text = "";
                txtPrecioPorKilo.Text = "";
            }
        }



        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "";

            if (categoria == "Alimentos Secos")
            {
                // Desactivar campos innecesarios
                txtItemPorPack.Text = "";
                txtItemPorPack.Enabled = true; // asumimos que es "kilos por bolsa"

                txtPorcentajeAgregar.Text = "";
                txtPorcentajeAgregar.Enabled = false;

                txtSubcategoria.Text = "";
                txtSubcategoria.Enabled = false;

                txtPrecioVenta.Text = "";
                txtPrecioVenta.Enabled = false;

                txtItemPorPack.Text = "";
                txtItemPorPack.Enabled = false;

                txtPrecioPorBolsa.Enabled = false;
                txtPrecioPorKilo.Enabled = false;
            }
            else
            {
                // Activar campos estándar
                txtItemPorPack.Text = "";
                txtItemPorPack.Enabled = false;

                txtPorcentajeAgregar.Enabled = true;
                txtSubcategoria.Enabled = true;
                txtPrecioVenta.Enabled = true;

                txtPrecioPorBolsa.Text = "";
                txtPrecioPorBolsa.Enabled = false;
                txtPrecioPorKilo.Text = "";
                txtPrecioPorKilo.Enabled = false;
            }
        }


        private void AltaForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "";
            string proveedor = cmbProovedor.SelectedItem?.ToString() ?? "";
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(proveedor))
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto) || precioCosto <= 0)
            {
                MessageBox.Show("Precio de costo inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Stock inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si es Alimentos Secos
            if (categoria == "Alimentos Secos")
            {
                if (!decimal.TryParse(txtKgBolsa.Text, out decimal kgPorBolsa) || kgPorBolsa <= 0)
                {
                    MessageBox.Show("Kg por bolsa inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal precioPorBolsa = precioCosto * 1.19m;
                decimal precioPorKilo = (precioCosto / kgPorBolsa) * 1.35m;

                txtPrecioPorBolsa.Text = precioPorBolsa.ToString("0.00");
                txtPrecioPorKilo.Text = precioPorKilo.ToString("0.00");

                // Guardar en base de datos
                try
                {
                    using (var conn = new System.Data.SQLite.SQLiteConnection("Data Source=huellitas.db"))
                    {
                        conn.Open();
                        using (var cmd = new System.Data.SQLite.SQLiteCommand(conn))
                        {
                            cmd.CommandText = @"INSERT INTO Productos 
                            (Nombre, Categoria, Proveedor, PrecioCosto, Stock, KgPorBolsa, PrecioPorBolsa, PrecioPorKilo)
                            VALUES 
                            (@nombre, @categoria, @proveedor, @precioCosto, @stock, @kgPorBolsa, @precioPorBolsa, @precioPorKilo)";
                            cmd.Parameters.AddWithValue("@nombre", nombre + $" {kgPorBolsa}kg");
                            cmd.Parameters.AddWithValue("@categoria", categoria);
                            cmd.Parameters.AddWithValue("@proveedor", proveedor);
                            cmd.Parameters.AddWithValue("@precioCosto", precioCosto);
                            cmd.Parameters.AddWithValue("@stock", stock);
                            cmd.Parameters.AddWithValue("@kgPorBolsa", kgPorBolsa);
                            cmd.Parameters.AddWithValue("@precioPorBolsa", precioPorBolsa);
                            cmd.Parameters.AddWithValue("@precioPorKilo", precioPorKilo);
                            cmd.ExecuteNonQuery();

                        }
                    }

                    MessageBox.Show("Producto de alimento seco guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Todo lo demás
            {
                if (!decimal.TryParse(txtItemPorPack.Text, out decimal itemPorPack) || itemPorPack <= 0)
                {
                    MessageBox.Show("Item por pack inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPorcentajeAgregar.Text, out decimal porcentajeAgregar) || porcentajeAgregar < 0)
                {
                    MessageBox.Show("Porcentaje a agregar inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSubcategoria.Text))
                {
                    MessageBox.Show("La subcategoría es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal precioVenta = precioCosto + (precioCosto * (porcentajeAgregar / 100));
                txtPrecioVenta.Text = precioVenta.ToString("0.00");

                // Guardar en base de datos
                try
                {
                    using (var conn = new System.Data.SQLite.SQLiteConnection("Data Source=huellitas.db"))
                    {
                        conn.Open();
                        using (var cmd = new System.Data.SQLite.SQLiteCommand(conn))
                        {
                            cmd.CommandText = @"INSERT INTO productos (nombre, categoria, proveedor, precioCosto, stock, itemPorPack, porcentajeAgregar, precioVenta, subcategoria)
                                        VALUES (@nombre, @categoria, @proveedor, @precioCosto, @stock, @itemPorPack, @porcentajeAgregar, @precioVenta, @subcategoria)";
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@categoria", categoria);
                            cmd.Parameters.AddWithValue("@proveedor", proveedor);
                            cmd.Parameters.AddWithValue("@precioCosto", precioCosto);
                            cmd.Parameters.AddWithValue("@stock", stock);
                            cmd.Parameters.AddWithValue("@itemPorPack", itemPorPack);
                            cmd.Parameters.AddWithValue("@porcentajeAgregar", porcentajeAgregar);
                            cmd.Parameters.AddWithValue("@precioVenta", precioVenta);
                            cmd.Parameters.AddWithValue("@subcategoria", txtSubcategoria.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtPrecioCosto.Clear();
            txtItemPorPack.Clear();
            txtPorcentajeAgregar.Clear();
            txtPrecioVenta.Clear();
            txtPrecioPorBolsa.Clear();
            txtPrecioPorKilo.Clear();
            txtStock.Clear();
            txtSubcategoria.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbProovedor.SelectedIndex = -1;
        }
        private void txtPrecioCosto_TextChanged(object sender, EventArgs e)
        {
            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "";

            if (decimal.TryParse(txtPrecioCosto.Text, out decimal precioCosto))
            {
                if (categoria == "Alimentos Secos")
                {
                    if (decimal.TryParse(txtItemPorPack.Text, out decimal kilosBolsa) && kilosBolsa > 0)
                    {
                        decimal precioPorBolsa = precioCosto * 1.19m;
                        decimal precioPorKilo = (precioCosto / kilosBolsa) * 1.35m;

                        txtPrecioPorBolsa.Text = precioPorBolsa.ToString("0.00");
                        txtPrecioPorKilo.Text = precioPorKilo.ToString("0.00");
                    }
                    else
                    {
                        txtPrecioPorBolsa.Text = "";
                        txtPrecioPorKilo.Text = "";
                    }
                }
                else
                {
                    if (decimal.TryParse(txtPorcentajeAgregar.Text, out decimal porcentaje))
                    {
                        decimal precioFinal = precioCosto + (precioCosto * (porcentaje / 100));
                        txtPrecioVenta.Text = precioFinal.ToString("0.00");
                    }
                    else
                    {
                        txtPrecioVenta.Text = "";
                    }
                }
            }
            else
            {
                txtPrecioPorBolsa.Text = "";
                txtPrecioPorKilo.Text = "";
                txtPrecioVenta.Text = "";
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
