using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdminPanelEsaulova.Model.BlogDT
{
    public class ThemaDataAccess
    {
        string ConnectionString = Helpers.ConnectionString;


        public IEnumerable<ThemaBloga> GetThemaBlog()
        {
            List<ThemaBloga> listThemaBloga = new List<ThemaBloga>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand comm = new SqlCommand("adv_BlogThema_Select", conn);
                comm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    ThemaBloga uslugiDT = new ThemaBloga();
                    uslugiDT.ID = Convert.ToInt32(rdr["id"]);
                    uslugiDT.Name = rdr["name"].ToString();
                    listThemaBloga.Add(uslugiDT);
                }
                conn.Close();
            }
            return listThemaBloga;
        }
    }
}