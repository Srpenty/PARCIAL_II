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
    class MedicinaVentDAL
    {
        Database db;

        public MedicinaVentDAL()
        {
            db = new Database();
        }

        public DataTable getAllMedicinaVentDAL()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ventas_medicina";
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

        public List<MedicinaVentBLL> GetMedicinaVentBLLs()
        {
            List<MedicinaVentBLL> ventBLLs = new List<MedicinaVentBLL>();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ventas_medicina";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ventBLLs.Add(new MedicinaVentBLL(
                                Convert.ToInt32(reader["id_venta"]),
                                Convert.ToInt32(reader["id_producto"]),
                                Convert.ToInt32(reader["id_empleado"]),
                                Convert.ToInt32(reader["cantidad"]),
                                Convert.ToInt32(reader["precio"])
                                ));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron registros.");
                    }
                    con.Close();
                    return ventBLLs;
                }
            }
            catch
            {
                return ventBLLs;
            }
        }

        public bool insertarventa(MedicinaVentBLL Venta, MedicinaTienBLL Stock, InfEmpleadosBLL empleado)
        {
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO ventas_medicina (id_producto, id_empleado, cantidad, precio) VALUES (@idp, @ide, @cant, @prec)";
                    cmd.Parameters.AddWithValue("@idp", Stock.Id_producto);
                    cmd.Parameters.AddWithValue("@ide", empleado.Id_empleado);
                    cmd.Parameters.AddWithValue("@cant", Venta.Cantidad);
                    cmd.Parameters.AddWithValue("@prec", Venta.Precio);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool actualizarventa(MedicinaVentBLL VentaActu, MedicinaTienBLL Vent, InfEmpleadosBLL empleado)
        {
           try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE ventas_medicina SET id_producto = @idp, id_empleado = @ide ,nombre_producto = @nom, cantidad = @cant, precio = @prec WHERE id_venta = @idv";
                    cmd.Parameters.AddWithValue("@idv", VentaActu.Id_venta);
                    cmd.Parameters.AddWithValue("@idp", Vent.Id_producto);
                    cmd.Parameters.AddWithValue("@ide", empleado.Id_empleado);
                    cmd.Parameters.AddWithValue("@cant", VentaActu.Cantidad);
                    cmd.Parameters.AddWithValue("@prec", VentaActu.Precio);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool eliminarVenta(MedicinaVentBLL VentaDel)
        {
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ventas_medicina WHERE id_venta =@idv";
                    cmd.Parameters.AddWithValue("@idv", VentaDel.Id_venta);
                    cmd.ExecuteNonQuery();
                    con.Close();

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
