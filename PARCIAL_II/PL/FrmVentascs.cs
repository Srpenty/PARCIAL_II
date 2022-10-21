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
    public partial class FrmVentascs : Form
    {
        InfEmpleadosDAL empleadosDAL;
        MedicinaVentDAL ventaDAL;
        public FrmVentascs()
        {
            InitializeComponent();
            empleadosDAL = new InfEmpleadosDAL();
            ventaDAL = new MedicinaVentDAL();
        }

        private void listarEmpleados()
        {
            cmbIdEmpleado.DataSource = empleadosDAL.getAllInfoEmpleados();
            cmbIdEmpleado.DisplayMember = "nombre_empleado";
            cmbIdEmpleado.ValueMember = "id_empleado";
        }

        private void listarVenta()
        {
            cmbIdProducto.DataSource = ventaDAL.getAllMedicinaVentDAL();
            cmbIdProducto.DisplayMember = "nombre_producto";
            cmbIdProducto.ValueMember = "id_producto";
        }
        
        private void filldgvVentas()
        {
            dgvVentas.DataSource = ventaDAL.getAllMedicinaVentDAL();
        }

        private void limpiarText()
        {
            txtNombreProducto.Clear();
            txtcantidad.Clear();
            txtIdVentas.Clear();
            txtcantidad.Clear();
        }

        private void FrmVentascs_Load(object sender, EventArgs e)
        {
            filldgvVentas();
            listarEmpleados();
            listarVenta();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtNombreProducto.Text))
            {
                MessageBox.Show("Por favor complete todos los parametros");
            }
            else
            {
                string nombre = txtNombreProducto.Text;
                int cantidad = Convert.ToInt32(txtcantidad.Text);
                int precio = Convert.ToInt32(txtPrecio.Text);
                int idEmpleado = Convert.ToInt32(cmbIdEmpleado.SelectedValue);
                int idProducto = Convert.ToInt32(cmbIdProducto.SelectedValue);
                InfEmpleadosBLL empleado = new InfEmpleadosBLL(idEmpleado, null, null, null);
                MedicinaTienBLL stock = new MedicinaTienBLL(idProducto,nombre, null, cantidad, precio);
                MedicinaVentBLL venta = new MedicinaVentBLL(0,idProducto, idEmpleado, cantidad,precio );
                if (ventaDAL.insertarventa(venta, stock, empleado))
                {
                    MessageBox.Show("La venta se ha registrado con exito");
                    filldgvVentas();
                    limpiarText();
                }
                else
                {
                    MessageBox.Show("La venta no se pudo registrar");
                }
            }
        }
        private void dgvVentasCellMouse_Clic(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                txtIdVentas.Text = dgvVentas.Rows[index].Cells[0].Value.ToString();
                cmbIdProducto.SelectedValue = Convert.ToInt32(dgvVentas.Rows[index].Cells[1].Value);
                cmbIdEmpleado.SelectedValue = Convert.ToInt32(dgvVentas.Rows[index].Cells[2].Value);
                txtcantidad.Text = dgvVentas.Rows[index].Cells[3].Value.ToString();
                txtPrecio.Text = dgvVentas.Rows[index].Cells[4].Value.ToString();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtcantidad.Text) || string.IsNullOrEmpty(txtNombreProducto.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Debe completar todos los parametros");
            }
            else
            {
                string nombre = txtNombreProducto.Text;
                int cantidad = Convert.ToInt32(txtcantidad.Text);
                int precio = Convert.ToInt32(txtPrecio.Text);
                int idEmpleado = Convert.ToInt32(cmbIdEmpleado.SelectedValue);
                int idProducto = Convert.ToInt32(cmbIdProducto.SelectedValue);
                InfEmpleadosBLL empleado = new InfEmpleadosBLL(idEmpleado, null, null, null);
                MedicinaTienBLL stock = new MedicinaTienBLL(idProducto, null, null, 0, 0);
                MedicinaVentBLL venta = new MedicinaVentBLL(0, idProducto, idEmpleado, cantidad, precio);
                if (ventaDAL.actualizarventa(venta, stock, empleado))
                {
                    MessageBox.Show("La venta se ha actualizado con exito");
                    filldgvVentas();
                    limpiarText();
                }
                else
                {
                    MessageBox.Show("La venta no se ha podido actualizar");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtIdVentas.Text))
            {
                MessageBox.Show("Debe seleccionar una venta para poder eliminarla");
            }
            else
            {
                int id = Convert.ToInt32(txtIdVentas.Text);
                MedicinaVentBLL venta = new MedicinaVentBLL(id);
                var confirmar = MessageBox.Show("¿Esta seguro de que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.Yes)
                {
                    if (ventaDAL.eliminarVenta(venta))
                    {
                        MessageBox.Show("La venta se ha eliminado con exito");
                        filldgvVentas();
                        limpiarText();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminar la venta");
                }
            }
        }
    }
}
