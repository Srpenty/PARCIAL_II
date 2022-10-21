using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_II.BLL
{
    class FarmaciaSedBLL
    {
        private int id_sedes;
        private string nombre_sede;
        private string ubicacion_sede;
        private string email_sede;

        public FarmaciaSedBLL(int id_sedes)
        {
            this.Id_sedes = id_sedes;
        }

        public FarmaciaSedBLL(int id_sedes, string nombre_sede, string ubicacion_sede, string email_sede)
        {
            this.Id_sedes = id_sedes;
            this.Nombre_sede = nombre_sede;
            this.Ubicacion_sede = ubicacion_sede;
            this.Email_sede = email_sede;
        }

        public int Id_sedes { get => id_sedes; set => id_sedes = value; }
        public string Nombre_sede { get => nombre_sede; set => nombre_sede = value; }
        public string Ubicacion_sede { get => ubicacion_sede; set => ubicacion_sede = value; }
        public string Email_sede { get => email_sede; set => email_sede = value; }
    }
}
