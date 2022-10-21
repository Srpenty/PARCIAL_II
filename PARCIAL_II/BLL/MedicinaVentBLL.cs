using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_II.BLL
{
    class MedicinaVentBLL
    {
        private int id_venta;
        private int id_producto;
        private int id_empleado;
        private int cantidad;
        private int precio;

        public MedicinaVentBLL(int id_venta)
        {
            this.id_venta = id_venta;
        }

        public MedicinaVentBLL(int id_venta, int id_producto, int id_empleado)
        {
            this.Id_venta = id_venta;

        }

        public MedicinaVentBLL(int id_venta, int id_producto, int id_empleado, int cantidad, int precio)
        {
            this.Id_venta = id_venta;
            this.Id_producto = id_producto;
            this.Id_empleado = id_empleado;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public int Id_venta { get => id_venta; set => id_venta = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public int Precio { get => precio; set => precio = value; }
    }
}
