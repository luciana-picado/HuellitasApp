namespace HuellitasAppLocal
{
    partial class AltaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblSubCategoria = new System.Windows.Forms.Label();
            this.lblPVenta = new System.Windows.Forms.Label();
            this.lblPaAgregar = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblItemxPack = new System.Windows.Forms.Label();
            this.lblProovedor = new System.Windows.Forms.Label();
            this.lblPxKilo = new System.Windows.Forms.Label();
            this.lblPBolsa = new System.Windows.Forms.Label();
            this.lblPCosto = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtPorcentajeAgregar = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txtPrecioCosto = new System.Windows.Forms.TextBox();
            this.cmbProovedor = new System.Windows.Forms.ComboBox();
            this.lblKgBolsa = new System.Windows.Forms.Label();
            this.txtKgBolsa = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alta de Producto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(27, 82);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(157, 30);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(191, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 30);
            this.textBox1.TabIndex = 2;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(192, 113);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(158, 28);
            this.cmbCategoria.TabIndex = 3;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // lblSubCategoria
            // 
            this.lblSubCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategoria.Location = new System.Drawing.Point(457, 118);
            this.lblSubCategoria.Name = "lblSubCategoria";
            this.lblSubCategoria.Size = new System.Drawing.Size(145, 30);
            this.lblSubCategoria.TabIndex = 14;
            this.lblSubCategoria.Text = "SubCategoria";
            // 
            // lblPVenta
            // 
            this.lblPVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPVenta.Location = new System.Drawing.Point(457, 82);
            this.lblPVenta.Name = "lblPVenta";
            this.lblPVenta.Size = new System.Drawing.Size(145, 30);
            this.lblPVenta.TabIndex = 15;
            this.lblPVenta.Text = "$ de Venta";
            this.lblPVenta.Click += new System.EventHandler(this.label14_Click);
            // 
            // lblPaAgregar
            // 
            this.lblPaAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaAgregar.Location = new System.Drawing.Point(27, 352);
            this.lblPaAgregar.Name = "lblPaAgregar";
            this.lblPaAgregar.Size = new System.Drawing.Size(157, 30);
            this.lblPaAgregar.TabIndex = 16;
            this.lblPaAgregar.Text = "% a Agregar";
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(27, 319);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(157, 30);
            this.lblStock.TabIndex = 17;
            this.lblStock.Text = "Stock";
            // 
            // lblItemxPack
            // 
            this.lblItemxPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemxPack.Location = new System.Drawing.Point(27, 286);
            this.lblItemxPack.Name = "lblItemxPack";
            this.lblItemxPack.Size = new System.Drawing.Size(157, 30);
            this.lblItemxPack.TabIndex = 18;
            this.lblItemxPack.Text = "Item x Pack";
            // 
            // lblProovedor
            // 
            this.lblProovedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProovedor.Location = new System.Drawing.Point(27, 253);
            this.lblProovedor.Name = "lblProovedor";
            this.lblProovedor.Size = new System.Drawing.Size(157, 30);
            this.lblProovedor.TabIndex = 19;
            this.lblProovedor.Text = "Proovedor";
            // 
            // lblPxKilo
            // 
            this.lblPxKilo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPxKilo.Location = new System.Drawing.Point(27, 218);
            this.lblPxKilo.Name = "lblPxKilo";
            this.lblPxKilo.Size = new System.Drawing.Size(157, 30);
            this.lblPxKilo.TabIndex = 20;
            this.lblPxKilo.Text = "$ por Kilo";
            this.lblPxKilo.Click += new System.EventHandler(this.label19_Click);
            // 
            // lblPBolsa
            // 
            this.lblPBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPBolsa.Location = new System.Drawing.Point(27, 184);
            this.lblPBolsa.Name = "lblPBolsa";
            this.lblPBolsa.Size = new System.Drawing.Size(157, 30);
            this.lblPBolsa.TabIndex = 21;
            this.lblPBolsa.Text = "$ Bolsa";
            this.lblPBolsa.Click += new System.EventHandler(this.label20_Click);
            // 
            // lblPCosto
            // 
            this.lblPCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCosto.Location = new System.Drawing.Point(27, 148);
            this.lblPCosto.Name = "lblPCosto";
            this.lblPCosto.Size = new System.Drawing.Size(157, 30);
            this.lblPCosto.TabIndex = 22;
            this.lblPCosto.Text = "$ Costo";
            this.lblPCosto.Click += new System.EventHandler(this.label21_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(27, 115);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(157, 30);
            this.lblCategoria.TabIndex = 23;
            this.lblCategoria.Text = "Categoria";
            this.lblCategoria.Click += new System.EventHandler(this.label22_Click);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(608, 115);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(159, 30);
            this.textBox6.TabIndex = 28;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioVenta.Location = new System.Drawing.Point(608, 82);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(159, 30);
            this.txtPrecioVenta.TabIndex = 29;
            // 
            // txtPorcentajeAgregar
            // 
            this.txtPorcentajeAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeAgregar.Location = new System.Drawing.Point(190, 347);
            this.txtPorcentajeAgregar.Name = "txtPorcentajeAgregar";
            this.txtPorcentajeAgregar.Size = new System.Drawing.Size(159, 30);
            this.txtPorcentajeAgregar.TabIndex = 30;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(191, 314);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(159, 30);
            this.textBox9.TabIndex = 31;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(191, 281);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(159, 30);
            this.textBox10.TabIndex = 32;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(191, 215);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(159, 30);
            this.textBox12.TabIndex = 34;
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(190, 179);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(159, 30);
            this.textBox13.TabIndex = 35;
            // 
            // txtPrecioCosto
            // 
            this.txtPrecioCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioCosto.Location = new System.Drawing.Point(190, 143);
            this.txtPrecioCosto.Name = "txtPrecioCosto";
            this.txtPrecioCosto.Size = new System.Drawing.Size(159, 30);
            this.txtPrecioCosto.TabIndex = 36;
            // 
            // cmbProovedor
            // 
            this.cmbProovedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProovedor.FormattingEnabled = true;
            this.cmbProovedor.Location = new System.Drawing.Point(190, 251);
            this.cmbProovedor.Name = "cmbProovedor";
            this.cmbProovedor.Size = new System.Drawing.Size(158, 28);
            this.cmbProovedor.TabIndex = 37;
            // 
            // lblKgBolsa
            // 
            this.lblKgBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKgBolsa.Location = new System.Drawing.Point(459, 154);
            this.lblKgBolsa.Name = "lblKgBolsa";
            this.lblKgBolsa.Size = new System.Drawing.Size(145, 30);
            this.lblKgBolsa.TabIndex = 38;
            this.lblKgBolsa.Text = "Kg por Bolsa";
            // 
            // txtKgBolsa
            // 
            this.txtKgBolsa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKgBolsa.Location = new System.Drawing.Point(608, 151);
            this.txtKgBolsa.Name = "txtKgBolsa";
            this.txtKgBolsa.Size = new System.Drawing.Size(159, 30);
            this.txtKgBolsa.TabIndex = 39;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(464, 215);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(181, 64);
            this.btnGuardar.TabIndex = 40;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(659, 335);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(108, 43);
            this.btnAtras.TabIndex = 41;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            // 
            // AltaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtKgBolsa);
            this.Controls.Add(this.lblKgBolsa);
            this.Controls.Add(this.cmbProovedor);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.txtPorcentajeAgregar);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPaAgregar);
            this.Controls.Add(this.lblPVenta);
            this.Controls.Add(this.lblSubCategoria);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrecioCosto);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblPCosto);
            this.Controls.Add(this.lblPBolsa);
            this.Controls.Add(this.lblPxKilo);
            this.Controls.Add(this.lblProovedor);
            this.Controls.Add(this.lblItemxPack);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblNombre);
            this.Name = "AltaForm";
            this.Text = "AltaForm";
            this.Load += new System.EventHandler(this.AltaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblSubCategoria;
        private System.Windows.Forms.Label lblPVenta;
        private System.Windows.Forms.Label lblPaAgregar;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblItemxPack;
        private System.Windows.Forms.Label lblProovedor;
        private System.Windows.Forms.Label lblPxKilo;
        private System.Windows.Forms.Label lblPBolsa;
        private System.Windows.Forms.Label lblPCosto;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtPorcentajeAgregar;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox txtPrecioCosto;
        private System.Windows.Forms.ComboBox cmbProovedor;
        private System.Windows.Forms.Label lblKgBolsa;
        private System.Windows.Forms.TextBox txtKgBolsa;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAtras;
    }
}