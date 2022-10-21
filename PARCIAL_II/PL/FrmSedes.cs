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
    public partial class FrmSedes : Form
    {
        FarmaciaSedDAL sedDAL;
        public FrmSedes()
        {
            InitializeComponent();
            this.sedDAL = new FarmaciaSedDAL();
        }

        private void FrmSedes_Load(object sender, EventArgs e)
        {
            fillDgvSedes();
        }

        private void fillDgvSedes()
        {
            dgvSedes.DataSource = sedDAL.getAllFarmaciaSedes();
        }

        private void clearTextBox()
        {
            txtId.Clear();
            txtSede.Clear();
            txtUbicacion.Clear();
            txtEmail.Clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSede.Text) || string.IsNullOrEmpty(txtUbicacion.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                string nombre_sede = txtSede.Text;
                string ubicacion_sede = txtUbicacion.Text;
                string email_sede = txtEmail.Text;
                FarmaciaSedBLL Sedes = new FarmaciaSedBLL(0, nombre_sede, ubicacion_sede, email_sede);
                if(sedDAL.createfarmacia_sedes(Sedes))
                {
                    MessageBox.Show("La nueva sede se creó con éxito");
                    fillDgvSedes();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("No se ha podido crear la nueva sede");
                }
            }
        }

        private void dgvSedes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtId.Text = dgvSedes.Rows[index].Cells[0].Value.ToString();
                txtSede.Text = dgvSedes.Rows[index].Cells[1].Value.ToString();
                txtUbicacion.Text = dgvSedes.Rows[index].Cells[2].Value.ToString();
                txtEmail.Text = dgvSedes.Rows[index].Cells[3].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSede.Text) || string.IsNullOrEmpty(txtUbicacion.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe completar todos los parametros");
            }
            else
            {
                int id_sedes = Convert.ToInt32(txtId.Text);
                string Sedes = txtSede.Text;
                string Ubicacion_sedes = txtUbicacion.Text;
                string Emil_sedes = txtEmail.Text;
                FarmaciaSedBLL farmaciaSedBLL = new FarmaciaSedBLL(id_sedes, Sedes, Ubicacion_sedes, Emil_sedes);
                FarmaciaSedDAL CreateSedes = new FarmaciaSedDAL();
                if(CreateSedes.updatefarmacia_sedes(farmaciaSedBLL))
                {
                    MessageBox.Show("La sede se ha actualizado con exito");
                    fillDgvSedes();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("L sede no se ha podido actualizar");
                }
            }
        }

        private void dgvSedes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar una sede");
            }
            else
            {
                int id = int.Parse(txtId.Text);
                FarmaciaSedBLL farmaciaSedBLL = new FarmaciaSedBLL(id);
                var confirmar = MessageBox.Show("¿Seguro de que desea eliminar esta sede?", "Confirmar", MessageBoxButtons.YesNo);
                if(confirmar == DialogResult.Yes)
                {
                    if(sedDAL.deletefarmacia_sedes(farmaciaSedBLL))
                    {
                        MessageBox.Show("Sede eliminada con éxito");
                        fillDgvSedes();
                        clearTextBox();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la sede");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
