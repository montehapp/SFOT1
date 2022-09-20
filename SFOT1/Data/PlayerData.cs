using System.Data;
using Microsoft.Data.SqlClient;

namespace SFOT1.Data
{
    public class PlayerData
    {
        public static DataTable GetPlayer(int clubId)
        {
            DataTable dt = new DataTable();

            using SqlConnection cn = new SqlConnection(Globals.ConnectionString);
            using SqlCommand cmd = new SqlCommand();
            cn.Open();
            cmd.CommandTimeout = 1200;
            cmd.Connection = cn;
            cmd.CommandText = "ap_PlayerFlatStats_Get"; //Add sproc that returns five fields matching the PlayerProp.cs class
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@inClubID", clubId));

            using SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;

        }
    }
}
