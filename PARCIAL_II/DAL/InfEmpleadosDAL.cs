using PARCIAL_II.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL_II.DAL
{
    class InfEmpleadosDAL
    {
        private Database db;
        public InfEmpleadosDAL()

        {
            db = new Database();
        }

        public DataTable getAllInfoEmpleados()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM info_empleados";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    con.Close();
                    return dt;
                }
            }
            catch
            {
                return dt;
            }
        }

        public bool createinfo_empleados(InfEmpleadosBLL emp, FarmaciaSedBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "INSERT INTO info_empleados ( id_sede, nombre_empleado, cargo_empleado, num_telefonico) VALUES (@ids, @nom, @ce, @tel);";
                    cmd.Parameters.AddWithValue("@ids", sede.Id_sedes);
                    cmd.Parameters.AddWithValue("@nom", emp.Nombre_empleado);
                    cmd.Parameters.AddWithValue("@ce", emp.Cargo_empleado);
                    cmd.Parameters.AddWithValue("@tel", emp.Num_telefonico);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool updateInf_Empleado(InfEmpleadosBLL emp, FarmaciaSedBLL sede)
        {
            SqlConnection Con = db.GetConnection();
            using (SqlCommand cmd = Con.CreateCommand())
            {
                Con.Open();
                cmd.CommandText = "UPDATE info_empleados SET id_sede = @ids ,nombre_empleado = @nom, cargo_empleado = @ce, num_telefonico = @tel WHERE id_empleado = @id;";
                cmd.Parameters.AddWithValue("@id", emp.Id_empleado);
                cmd.Parameters.AddWithValue("@ids", sede.Id_sedes);
                cmd.Parameters.AddWithValue("@nom", emp.Nombre_empleado);
                cmd.Parameters.AddWithValue("@ce", emp.Cargo_empleado);
                cmd.Parameters.AddWithValue("@tel", emp.Num_telefonico);
                cmd.ExecuteNonQuery();
                Con.Close();

                return true;
            }
        }

        public bool deleteInf_Empleado(InfEmpleadosBLL emp)
        {
            try
            {
                SqlConnection Con = db.GetConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "DELETE FROM info_empleados WHERE id_empleado = @id;";
                    cmd.Parameters.AddWithValue("@id", emp.Id_empleado);
                    cmd.ExecuteNonQuery();
                    Con.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
    

