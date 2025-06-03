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
    public partial class ProductosForm: Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            var altaForm = new AltaForm();
            altaForm.ShowDialog(); // Para que se abra como ventana modal
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
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvProductos.DataSource = dataTable;
                    }
                }
            }
        }
    }
    
    }
