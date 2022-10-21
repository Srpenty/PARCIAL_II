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
    class FarmaciaSedDAL
    {
        Database db;
        public FarmaciaSedDAL()
        {
            db = new Database();
        }

        public DataTable getAllFarmaciaSedes()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = db.GetConnection();
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM farmacia_sedes";
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

        public bool createfarmacia_sedes( FarmaciaSedBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "INSERT INTO farmacia_sedes (nombre_sede ,ubicacion_sede ,email_sede ) VALUES (@nom, @ub, @em);";
                    cmd.Parameters.AddWithValue("@nom", sede.Nombre_sede);
                    cmd.Parameters.AddWithValue("@ub", sede.Ubicacion_sede);
                    cmd.Parameters.AddWithValue("@em", sede.Email_sede);
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

        public bool updatefarmacia_sedes( FarmaciaSedBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "UPDATE farmacia_sedes SET nombre_sede =  @nom, ubicacion_sede = @ub, email_sede = @em WHERE id_sedes = @ids;";
                    cmd.Parameters.AddWithValue("@ids", sede.Id_sedes);
                    cmd.Parameters.AddWithValue("@nom", sede.Nombre_sede);
                    cmd.Parameters.AddWithValue("@ub", sede.Ubicacion_sede);
                    cmd.Parameters.AddWithValue("@em", sede.Email_sede);

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

        public bool deletefarmacia_sedes(FarmaciaSedBLL sede)
        {
            try
            {
                SqlConnection Con = db.GetConnection();
                using (SqlCommand cmd = Con.CreateCommand())
                {
                    Con.Open();
                    cmd.CommandText = "DELETE FROM farmacia_sedes WHERE id_sedes = @ids;";
                    cmd.Parameters.AddWithValue("@ids", sede.Id_sedes);
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

   
