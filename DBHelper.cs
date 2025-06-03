using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace HuellitasAppLocal
{
    class DBHelper
    {
     private const string nombreArchivo = "huellitas.db";
        private const string conexionString = "Data Source=huellitas.db;Version=3;";

        public static void CrearBaseSiNoExiste()
        {
            if (!File.Exists(nombreArchivo))
            {
                SQLiteConnection.CreateFile(nombreArchivo);

                using (var conexion = new SQLiteConnection(conexionString))
                {
                    conexion.Open();

                    string sql = @"
                CREATE TABLE Productos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Categoria TEXT NOT NULL,
                    PrecioCosto REAL,
                    PrecioBolsa REAL,
                    PrecioPorKilo REAL,
                    Proveedor TEXT,
                    ItemPorPack INTEGER,
                    Stock INTEGER,
                    PorcentajeAgregar REAL,
                    PrecioVenta REAL,
                    Subcategoria TEXT
                );";

                    using (var comando = new SQLiteCommand(sql, conexion))
                    {
                        comando.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
