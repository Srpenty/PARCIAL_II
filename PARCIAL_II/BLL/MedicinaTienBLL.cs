using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_II.BLL
{
    class MedicinaTienBLL
    {
        private int id_producto;
        private string nombre_producto;
        private string fecha_vencimiento;
        private int cantidad;
        private int precio;

        public MedicinaTienBLL(int id_producto)
        {
            this.id_producto = id_producto;
        }

        public MedicinaTienBLL(int id_producto, string nombre_producto, string fecha_vencimiento, int cantidad, int precio)
        {
            this.Id_producto = id_producto;
            this.Nombre_producto = nombre_producto;
            this.Fecha_vencimiento = fecha_vencimiento;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public string Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Precio { get => precio; set => precio = value; }
    }
}
