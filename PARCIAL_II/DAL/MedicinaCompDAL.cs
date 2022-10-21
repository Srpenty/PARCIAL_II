using PARCIAL_II.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PARCIAL_II.DAL
{
    class MedicinaCompDAL
    {
        private Database db;
        public MedicinaCompDAL()
        {
            db = new Database();
        }
        public DataTable getAllCompras()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM compra_medicina";
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
        public bool insertarcompra(MedicinaCompBLL compra, MedicinaTienBLL stock)
        {
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO compra_medicina (id_compra, id_producto, fecha_vencimiento, cantidad, precio) VALUES (@idc, @idp, @fech, @cant, @prec)";
                    cmd.Parameters.AddWithValue("idc", compra.Id_compra);
                    cmd.Parameters.AddWithValue("@idp", stock.Id_producto);
                    cmd.Parameters.AddWithValue("@fech", compra.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@cant", compra.Cantidad);
                    cmd.Parameters.AddWithValue("@prec", compra.Precio);
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
        public bool actualizarcompra(MedicinaCompBLL Actucompra, MedicinaTienBLL stock)
        {
            try
            {

                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "UPDATE compra_medicina SET id_producto = @idp, fecha_vencimiento = @fech, cantidad = @cant, precio = @prec WHERE id_compra = @idc";
                    cmd.Parameters.AddWithValue("@idc",Actucompra.Id_compra);
                    cmd.Parameters.AddWithValue("@idp", stock.Id_producto);
                    cmd.Parameters.AddWithValue("@fech", Actucompra.Fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@cant", Actucompra.Cantidad);
                    cmd.Parameters.AddWithValue("@prec", Actucompra.Precio);
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

        public bool eliminarcompra(MedicinaCompBLL CompraDel)
        {
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM compra_medicina WHERE id_compra =@idc";
                    cmd.Parameters.AddWithValue("@idc", CompraDel.Id_compra);
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
