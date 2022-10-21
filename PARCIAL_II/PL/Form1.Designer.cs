
namespace PARCIAL_II
{
    partial class Form1
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
            this.btnventamedicamento = new System.Windows.Forms.Button();
            this.btnmedicinatienda = new System.Windows.Forms.Button();
            this.btncompramedicinas = new System.Windows.Forms.Button();
            this.btnfarmaciasedes = new System.Windows.Forms.Button();
            this.btnInfoEmpleados = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnventamedicamento
            // 
            this.btnventamedicamento.Location = new System.Drawing.Point(69, 230);
            this.btnventamedicamento.Name = "btnventamedicamento";
            this.btnventamedicamento.Size = new System.Drawing.Size(186, 23);
            this.btnventamedicamento.TabIndex = 10;
            this.btnventamedicamento.Text = "Venta de Medicamentos";
            this.btnventamedicamento.UseVisualStyleBackColor = true;
            this.btnventamedicamento.Click += new System.EventHandler(this.btnventamedicamento_Click);
            // 
            // btnmedicinatienda
            // 
            this.btnmedicinatienda.Location = new System.Drawing.Point(69, 180);
            this.btnmedicinatienda.Name = "btnmedicinatienda";
            this.btnmedicinatienda.Size = new System.Drawing.Size(186, 23);
            this.btnmedicinatienda.TabIndex = 9;
            this.btnmedicinatienda.Text = "Medicamento en Tienda";
            this.btnmedicinatienda.UseVisualStyleBackColor = true;
            this.btnmedicinatienda.Click += new System.EventHandler(this.btnmedicinatienda_Click);
            // 
            // btncompramedicinas
            // 
            this.btncompramedicinas.Location = new System.Drawing.Point(69, 130);
            this.btncompramedicinas.Name = "btncompramedicinas";
            this.btncompramedicinas.Size = new System.Drawing.Size(186, 23);
            this.btncompramedicinas.TabIndex = 8;
            this.btncompramedicinas.Text = "Compra de Medicamentos";
            this.btncompramedicinas.UseVisualStyleBackColor = true;
            this.btncompramedicinas.Click += new System.EventHandler(this.btncompramedicinas_Click);
            // 
            // btnfarmaciasedes
            // 
            this.btnfarmaciasedes.Location = new System.Drawing.Point(69, 78);
            this.btnfarmaciasedes.Name = "btnfarmaciasedes";
            this.btnfarmaciasedes.Size = new System.Drawing.Size(186, 23);
            this.btnfarmaciasedes.TabIndex = 7;
            this.btnfarmaciasedes.Text = "Sedes de la farmacia";
            this.btnfarmaciasedes.UseVisualStyleBackColor = true;
            this.btnfarmaciasedes.Click += new System.EventHandler(this.btnfarmaciasedes_Click);
            // 
            // btnInfoEmpleados
            // 
            this.btnInfoEmpleados.Location = new System.Drawing.Point(69, 36);
            this.btnInfoEmpleados.Name = "btnInfoEmpleados";
            this.btnInfoEmpleados.Size = new System.Drawing.Size(186, 23);
            this.btnInfoEmpleados.TabIndex = 6;
            this.btnInfoEmpleados.Text = "Informacion Empleados";
            this.btnInfoEmpleados.UseVisualStyleBackColor = true;
            this.btnInfoEmpleados.Click += new System.EventHandler(this.btnInfoEmpleados_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnventamedicamento);
            this.Controls.Add(this.btnmedicinatienda);
            this.Controls.Add(this.btncompramedicinas);
            this.Controls.Add(this.btnfarmaciasedes);
            this.Controls.Add(this.btnInfoEmpleados);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnventamedicamento;
        private System.Windows.Forms.Button btnmedicinatienda;
        private System.Windows.Forms.Button btncompramedicinas;
        private System.Windows.Forms.Button btnfarmaciasedes;
        private System.Windows.Forms.Button btnInfoEmpleados;
    }
}

