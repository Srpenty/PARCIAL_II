using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PARCIAL_II
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnfarmaciasedes_Click(object sender, EventArgs e)
        {
            FrmSedes form = new FrmSedes();
            form.Show();
        }

        private void btnInfoEmpleados_Click(object sender, EventArgs e)
        {
            Empleadoscs emp = new Empleadoscs();
            emp.Show();
        }

        private void btnventamedicamento_Click(object sender, EventArgs e)
        {
            FrmVentascs vent = new FrmVentascs();
            vent.Show();
        }

        private void btnmedicinatienda_Click(object sender, EventArgs e)
        {
            FrmTienda2 tien = new FrmTienda2();
            tien.Show();
        }

        private void btncompramedicinas_Click(object sender, EventArgs e)
        {
            FrmCompra compra = new FrmCompra();
            compra.Show();
        }
    }
}
