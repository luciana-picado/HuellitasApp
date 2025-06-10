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
    public partial class ProductosForm : Form
    {
        private DataTable productosTable;

        public ProductosForm()
        {
            InitializeComponent();
        }
        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar producto...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.Black;
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar producto...";
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (productosTable == null) return;

            string texto = txtBuscar.Text.Trim().Replace("'", "''");
            if (texto == "" || texto == "Buscar producto...")
            {
                (dgvProductos.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            else
            {
                string filtro = $"nombre LIKE '%{texto}%' OR categoria LIKE '%{texto}%'";
                (dgvProductos.DataSource as DataTable).DefaultView.RowFilter = filtro;
            }
        }

        private void CargarProductos()
        {
            string connectionString = "Data Source=huellitas.db;Version=3;";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT * FROM Productos", connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        productosTable = new DataTable();
                        adapter.Fill(productosTable);
                        dgvProductos.AutoGenerateColumns = false;
                        dgvProductos.DataSource = productosTable;

                        // Esperamos que se dibuje, luego limpiamos selección
                        this.BeginInvoke(new Action(() =>
                        {
                            dgvProductos.ClearSelection();
                            dgvProductos.CurrentCell = null;
                            btnDarDeBaja.Enabled = false;
                            btnModificar.Enabled = false;
                        }));
                    }
                }
            }
        }

        private void ConfigurarColumnas()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "id",
                HeaderText = "ID",
                Name = "id",
                Visible = false // así no se muestra en pantalla
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "nombre",
                HeaderText = "Nombre",
                Name = "nombre"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "categoria",
                HeaderText = "Categoría",
                Name = "categoria"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioCosto",
                HeaderText = "Costo",
                Name = "PrecioCosto"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioPorBolsa",
                HeaderText = "Precio Bolsa",
                Name = "PrecioPorBolsa"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioPorKilo",
                HeaderText = "Precio/Kilo",
                Name = "PrecioPorKilo"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "proveedor",
                HeaderText = "Proveedor",
                Name = "proveedor"
            });

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stock",
                HeaderText = "Stock",
                Name = "stock"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "stock",
                HeaderText = "Stock",
                Name = "stock"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PorcentajeAgregar",
                HeaderText = "% a Agregar",
                Name = "PorcentajeAgregar"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioVenta",
                HeaderText = "$ de Venta",
                Name = "PrecioVenta"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "KgPorBolsa",
                HeaderText = "Kg x Bolsa",
                Name = "KgPorBolsa"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subcategoria",
                HeaderText = "Subcategoria",
                Name = "Subcategoria"
            });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ItemPorPack",
                HeaderText = "Item x Pack",
                Name = "ItemPorPack"
            });
        }
        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un producto para dar de baja.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id"].Value);

            var resultado = MessageBox.Show($"¿Estás seguro de que querés eliminar el producto '{nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                string connectionString = "Data Source=huellitas.db;Version=3;";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand("DELETE FROM Productos WHERE id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
            }
        }


        private void ProductosForm_Load(object sender, EventArgs e)
        {
            // Desactivar botones por defecto
            btnDarDeBaja.Enabled = false;
            btnModificar.Enabled = false;

            ConfigurarColumnas();
            CargarProductos();

            // Mejoras visuales
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            txtBuscar.Text = "Buscar producto...";
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Enter += TxtBuscar_Enter;
            txtBuscar.Leave += TxtBuscar_Leave;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            dgvProductos.CellMouseDown += DgvProductos_CellMouseDown;
            dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;


        }
        private void DgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            bool haySeleccion = dgvProductos.CurrentRow != null;

            btnDarDeBaja.Enabled = haySeleccion;
            btnModificar.Enabled = haySeleccion;
        }

        private void DgvProductos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                dgvProductos.ClearSelection();
                dgvProductos.CurrentCell = null;
            }
            else
            {
                dgvProductos.CurrentCell = dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        private void ProductosForm_Click(object sender, EventArgs e)
        {
            dgvProductos.ClearSelection();
            dgvProductos.CurrentCell = null;
        }


        private void DgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProductos.CurrentRow != null)
            {
                string nombre = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
                string id = ""; // si querés, agregamos columna oculta de ID para usarla acá

                MessageBox.Show($"Modificar o dar de baja el producto: {nombre}");
                // Lógica de modificación o baja
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var altaForm = new AltaForm();
            altaForm.ShowDialog();
            CargarProductos(); // actualizar después del alta
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            InicioForm inicio = new InicioForm();
            inicio.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                var formModificar = new ModificarProductoForm(dgvProductos.CurrentRow);
                formModificar.ShowDialog();
                CargarProductos(); // Recarga los datos actualizados
            }
        }
    }
}
