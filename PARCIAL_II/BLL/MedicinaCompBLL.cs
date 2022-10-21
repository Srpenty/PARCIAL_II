using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_II.BLL
{
    class MedicinaCompBLL
    {
        private int id_compra;
        private int producto;
        private string fecha_vencimiento;
        private int cantidad;
        private int precio;

        public MedicinaCompBLL(int id_compra, int producto, string nombre_producto, string fecha_vencimiento, int cantidad, int precio)
        {
            this.Id_compra = id_compra;
            this.Producto = producto;

            this.Fecha_vencimiento = fecha_vencimiento;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public int Id_compra { get => id_compra; set => id_compra = value; }
        public int Producto { get => producto; set => producto = value; }

        public string Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Precio { get => precio; set => precio = value; }
    }
}
