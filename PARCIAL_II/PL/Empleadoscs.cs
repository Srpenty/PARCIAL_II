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
    public partial class Empleadoscs : Form
    {
        FarmaciaSedDAL sedDAL;
        InfEmpleadosDAL empleadosDAL;
        public Empleadoscs()
        {
            InitializeComponent();
            this.sedDAL = new FarmaciaSedDAL();
            this.empleadosDAL = new InfEmpleadosDAL();
        }

        private void listarSedes()
        {
            cmbSedes.DataSource = sedDAL.getAllFarmaciaSedes();
            cmbSedes.DisplayMember = "nombre_sede";
            cmbSedes.ValueMember = "id_sedes";
        }

        private void fillDgvEmpleados()
        {
            dgvEmpleados.DataSource = empleadosDAL.getAllInfoEmpleados();
        }

        private void clearText()
        {
            txtNombreEmpleado.Clear();
            txtNumCelular.Clear();
            txtCargo.Clear();
        }

        private void Empleadoscs_Load(object sender, EventArgs e)
        {
            listarSedes();
            fillDgvEmpleados();
        }

        private void btnAgregaar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCargo.Text) || string.IsNullOrEmpty(txtNombreEmpleado.Text) || string.IsNullOrEmpty(txtNumCelular.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                int id_sedes = Convert.ToInt32(cmbSedes.SelectedValue);
                string nombre_empleado = txtNombreEmpleado.Text;
                string cargo_empleado = txtCargo.Text;
                string num_celular = txtNumCelular.Text;
                FarmaciaSedBLL sedes = new FarmaciaSedBLL(id_sedes, null, null, null);
                InfEmpleadosBLL empleados = new InfEmpleadosBLL(0, nombre_empleado, cargo_empleado, num_celular);
                if (empleadosDAL.createinfo_empleados(empleados, sedes))
                {
                    MessageBox.Show("Empleado agregado con éxito");
                    fillDgvEmpleados();
                    clearText();
                }
                else
                {
                    MessageBox.Show("No se ha podido agreegar al empleadp");
                }
            }
        }

        private void dgvEmpleados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtId.Text = dgvEmpleados.Rows[index].Cells[0].Value.ToString();
                cmbSedes.SelectedValue = Convert.ToUInt32(dgvEmpleados.Rows[index].Cells[1].Value);
                txtNombreEmpleado.Text = dgvEmpleados.Rows[index].Cells[2].Value.ToString();
                txtCargo.Text = dgvEmpleados.Rows[index].Cells[3].Value.ToString();
                txtNumCelular.Text = dgvEmpleados.Rows[index].Cells[4].Value.ToString();
            
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtCargo.Text) || string.IsNullOrEmpty(txtNombreEmpleado.Text) || string.IsNullOrEmpty(txtNumCelular.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                int id_empleado = Convert.ToInt32(txtId.Text);
                string nombre_empleado = txtNombreEmpleado.Text;
                string cargo_empleado = txtCargo.Text;
                string num_celular = txtNumCelular.Text;
                int id_sedes = Convert.ToInt32(cmbSedes.SelectedValue);
                FarmaciaSedBLL sedes = new FarmaciaSedBLL(id_sedes, null, null, null);
                InfEmpleadosBLL empleados = new InfEmpleadosBLL(id_empleado, nombre_empleado, cargo_empleado, num_celular);
                if (empleadosDAL.updateInf_Empleado(empleados, sedes))
                {
                    MessageBox.Show("Informacion del empleada actualizada con éxito");
                    fillDgvEmpleados();
                    clearText();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar la informacion del empleado");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar una sede");
            }
            else
            {
                int id = int.Parse(txtId.Text);
                InfEmpleadosBLL delete = new InfEmpleadosBLL(id);
                var confirmar = MessageBox.Show("¿Seguro de que desea eliminar esta sede?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirmar == DialogResult.Yes)
                {
                    if (empleadosDAL.deleteInf_Empleado(delete))
                    {
                        MessageBox.Show("Sede eliminada con éxito");
                        fillDgvEmpleados();
                        clearText();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la sede");
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
