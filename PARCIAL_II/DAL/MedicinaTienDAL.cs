using System;
using PARCIAL_II.BLL;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace PARCIAL_II.DAL
{
    class MedicinaTienDAL
    {
        private Database db;
        public MedicinaTienDAL()
        {
            db = new Database();
        }
        
        public DataTable getAllMedicinaTienDAL()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM medicina_tienda";
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

        public List<MedicinaTienBLL> GetMedicinaTienBLLs()
        {
            List<MedicinaTienBLL> tienBLLs = new List<MedicinaTienBLL>();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT FROM medicina_tienda";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            tienBLLs.Add(new MedicinaTienBLL(
                                Convert.ToInt32(reader["id_producto"]),
                                Convert.ToString(reader["nombre_producto"]),
                                Convert.ToString(reader["fecha_vencimiento"]),
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
                    return tienBLLs;
                }
            }
            catch
            {
                return tienBLLs;
            }
        }

        public bool insertarstock(MedicinaTienBLL Stocks)
        {
           try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO medicina_tienda (nombre_producto, fecha_vencimiento, cantidad, precio) VALUES (@nomp, @fech, @cant, @prec)";
                    cmd.Parameters.AddWithValue("@nomp", Stocks.Nombre_producto);
                    cmd.Parameters.AddWithValue("@fech", Stocks.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@cant", Stocks.Cantidad);
                    cmd.Parameters.AddWithValue("@prec", Stocks.Precio);
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
        public bool actualizacionstock(MedicinaTienBLL StocksActu)
        {
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE medicina_tienda SET nombre_producto = @nomp, fecha_vencimiento = @fech, cantidad = @cant, precio = @prec WHERE id_producto = @idp";
                    cmd.Parameters.AddWithValue("@idp", StocksActu.Id_producto);
                    cmd.Parameters.AddWithValue("@nomp", StocksActu.Nombre_producto);
                    cmd.Parameters.AddWithValue("@fech", StocksActu.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@cant", StocksActu.Cantidad);
                    cmd.Parameters.AddWithValue("@prec", StocksActu.Precio);
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

        public bool deletestock(MedicinaTienBLL StocksDel)
        {
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM medicina_tienda WHERE id_producto = @idp";
                    cmd.Parameters.AddWithValue("@idp", StocksDel.Id_producto);
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
