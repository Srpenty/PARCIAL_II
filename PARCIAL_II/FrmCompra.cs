using System;
using PARCIAL_II.BLL;
using PARCIAL_II.DAL;
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
    public partial class FrmCompra : Form
    {
        MedicinaCompDAL compra;
        public FrmCompra()
        {
            InitializeComponent();
            compra = new MedicinaCompDAL();
        }
        private void filldgvTienda()
        {
            dgvTienda.DataSource = compra.getAllCompras();

        }

        private void limpiartxt()
        {
            txtcantidad.Clear();
            txtFechaVencimiento.Clear();
            txtNombreProducto.Clear();
            txtPrecio.Clear();
            txtIdventa.Clear();
        }



        private void FrmCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
