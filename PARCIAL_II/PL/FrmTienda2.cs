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
    public partial class FrmTienda2 : Form
    {
        MedicinaTienDAL tienda;
        public FrmTienda2()
        {
            InitializeComponent();
            tienda = new MedicinaTienDAL();
        }

        private void fillDgvTienda()
        {
            dgvTienda.DataSource = tienda.getAllMedicinaTienDAL();
        }

        private void limpiarText()
        {
            txtNombreProducto.Clear();
            txtcantidad.Clear();
            txtPrecio.Clear();
        }
        private void dgvTiendaCellMouse_Clic(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtcantidad.Text = dgvTienda.Rows[index].Cells[3].Value.ToString();
                txtFechaVencimiento.Text = dgvTienda.Rows[index].Cells[2].Value.ToString();
                txtIdPtoducto.Text = dgvTienda.Rows[index].Cells[0].Value.ToString();
                txtNombreProducto.Text = dgvTienda.Rows[index].Cells[1].Value.ToString();
                txtPrecio.Text = dgvTienda.Rows[index].Cells[4].Value.ToString();
            }
        }
        private void FrmTienda2_Load(object sender, EventArgs e)
        {
            fillDgvTienda();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtNombreProducto.Text))
            {
                MessageBox.Show("Por favor complete todos los parametros");
            }
            else
            {

                string nombre = txtNombreProducto.Text;
                string fecha = txtFechaVencimiento.Text;
                int cantidad = int.Parse(txtcantidad.Text);
                int precio = int.Parse(txtPrecio.Text);
                MedicinaTienBLL tien = new MedicinaTienBLL(0, nombre, fecha, cantidad, precio);
                MedicinaTienDAL create = new MedicinaTienDAL();
                if(create.actualizacionstock(tien))
                {
                    MessageBox.Show("La informacion del producto se ha actualizado con exito");
                    fillDgvTienda();
                    limpiarText();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la informacion del producto");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdPtoducto.Text))
            {
                MessageBox.Show("Debe seleccionar un producto para poder eliminarlo");
            }
            else
            {
                int idp = int.Parse(txtIdPtoducto.Text);
                MedicinaTienBLL stcokdel = new MedicinaTienBLL(idp);
                var confirmar = MessageBox.Show("¿Esta seguro de que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
                if(confirmar == DialogResult.Yes)
                {
                    if (tienda.deletestock(stcokdel))
                    {
                        MessageBox.Show("Producto eliminado con exito");
                        fillDgvTienda();
                        limpiarText();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el producto");
                    }
                }
            }
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtNombreProducto.Text))
            {
                MessageBox.Show("Por favor complete todos los parametros");
            }
            else
            {
                string nombre = txtNombreProducto.Text;
                string fecha = txtFechaVencimiento.Text;
                int cantidad = int.Parse(txtcantidad.Text);
                int precio = int.Parse(txtPrecio.Text);
                MedicinaTienBLL tien = new MedicinaTienBLL(0, nombre, fecha, cantidad, precio);
                if (tienda.insertarstock(tien))
                {
                    MessageBox.Show("El producto se ha registrado con exito");
                    fillDgvTienda();
                    limpiarText();
                }
                else
                {
                    MessageBox.Show("El producto no pudo ser registrado");
                }

            }
        }
    }
}
