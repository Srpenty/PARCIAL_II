using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_II.BLL
{
    class InfEmpleadosBLL
    {
        private int id_empleado;
        private string nombre_empleado;
        private string cargo_empleado;
        private string num_telefonico;

        public InfEmpleadosBLL(int id_empleado)
        {
            this.id_empleado = id_empleado;
        }

        public InfEmpleadosBLL(int id_empleado, string nombre_empleado, string cargo_empleado, string num_telefonico)
        {
            this.id_empleado = id_empleado;
            this.nombre_empleado = nombre_empleado;
            this.cargo_empleado = cargo_empleado;
            this.num_telefonico = num_telefonico;
        }

        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public string Nombre_empleado { get => nombre_empleado; set => nombre_empleado = value; }
        public string Cargo_empleado { get => cargo_empleado; set => cargo_empleado = value; }
        public string Num_telefonico { get => num_telefonico; set => num_telefonico = value; }
    }
}
