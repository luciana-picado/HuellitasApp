namespace HuellitasAppLocal
{
    partial class InicioForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.buttonProducto = new System.Windows.Forms.Button();
            this.buttonCompras = new System.Windows.Forms.Button();
            this.buttonVentas = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 82);
            this.label1.TabIndex = 0;
            this.label1.Text = "Huellitas Pet Shop";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonProducto
            // 
            this.buttonProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProducto.Location = new System.Drawing.Point(312, 143);
            this.buttonProducto.Name = "buttonProducto";
            this.buttonProducto.Size = new System.Drawing.Size(154, 75);
            this.buttonProducto.TabIndex = 1;
            this.buttonProducto.Text = "Productos";
            this.buttonProducto.UseVisualStyleBackColor = true;
            this.buttonProducto.Click += new System.EventHandler(this.buttonProducto_Click);
            // 
            // buttonCompras
            // 
            this.buttonCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCompras.Location = new System.Drawing.Point(163, 224);
            this.buttonCompras.Name = "buttonCompras";
            this.buttonCompras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonCompras.Size = new System.Drawing.Size(154, 75);
            this.buttonCompras.TabIndex = 2;
            this.buttonCompras.Text = "Compras";
            this.buttonCompras.UseVisualStyleBackColor = true;
            // 
            // buttonVentas
            // 
            this.buttonVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVentas.Location = new System.Drawing.Point(464, 224);
            this.buttonVentas.Name = "buttonVentas";
            this.buttonVentas.Size = new System.Drawing.Size(154, 75);
            this.buttonVentas.TabIndex = 3;
            this.buttonVentas.Text = "Ventas";
            this.buttonVentas.UseVisualStyleBackColor = true;
            // 
            // buttonSalir
            // 
            this.buttonSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSalir.Location = new System.Drawing.Point(615, 356);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(124, 49);
            this.buttonSalir.TabIndex = 4;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            // 
            // InicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 450);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonVentas);
            this.Controls.Add(this.buttonCompras);
            this.Controls.Add(this.buttonProducto);
            this.Controls.Add(this.label1);
            this.Name = "InicioForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.InicioForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonProducto;
        private System.Windows.Forms.Button buttonCompras;
        private System.Windows.Forms.Button buttonVentas;
        private System.Windows.Forms.Button buttonSalir;
    }
}

