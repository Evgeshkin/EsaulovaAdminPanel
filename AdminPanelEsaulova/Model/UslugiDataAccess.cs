using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdminPanelEsaulova.Model
{
    public class UslugiDataAccess
    {
        string ConnectionString = Helpers.ConnectionString;// "Data source=ms-sql-9.in-solve.ru;Initial catalog=1gb_x_jesau20d;User ID=1gb_torov-lab;Password=zd5b59c84yzx";

        public IEnumerable<UslugiDT> GetUslugiDTs()
        {
            List<UslugiDT> listUslug = new List<UslugiDT>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand comm = new SqlCommand("adv_UslugiSelectALL", conn);
                comm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    UslugiDT uslugiDT = new UslugiDT();
                    uslugiDT.ID = Convert.ToInt32(rdr["id"]);
                    uslugiDT.Name = rdr["name"].ToString();
                    uslugiDT.Opisanie = rdr["opisanie"].ToString();
                    uslugiDT.DataGroup = rdr["datagrups"].ToString();
                    uslugiDT.TopUsl = Convert.ToBoolean(rdr["top_usl"]);

                    listUslug.Add(uslugiDT);
                }
                conn.Close();
            }
            return listUslug;
        }

        public void AddUslugu(UslugiDT usluga)
        {
            string datagrupp = "";
            if (usluga.GrajdanDela == true)
                datagrupp += "\"gragdel\"";
            if (usluga.UgolovDela == true)
                datagrupp += ", \"ugldel\"";
            if (usluga.EkonomDela == true)
                datagrupp += ", \"ekonomdel\"";
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("dt_Uslugi_Insert", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.NVarChar).Value = usluga.ID;
                comm.Parameters.Add("@name", SqlDbType.NVarChar).Value = usluga.Name;
                comm.Parameters.Add("@opisanie", SqlDbType.NVarChar).Value = usluga.Opisanie;
                comm.Parameters.Add("@datagrups", SqlDbType.NVarChar).Value = datagrupp;
                comm.Parameters.Add("@top_usl", SqlDbType.Bit).Value = usluga.TopUsl;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void UpdateUslugu(UslugiDT usluga)
        {
            string datagrupp = "";
            if (usluga.GrajdanDela == true)
                datagrupp += "\"gragdel\"";
            if (usluga.UgolovDela == true)
                datagrupp += ", \"ugldel\"";
            if (usluga.EkonomDela == true)
                datagrupp += ", \"ekonomdel\"";
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("dt_Uslugi_Update", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.Int).Value = usluga.ID;
                comm.Parameters.Add("@name", SqlDbType.NVarChar).Value = usluga.Name;
                comm.Parameters.Add("@opisanie", SqlDbType.NVarChar).Value = usluga.Opisanie;
                comm.Parameters.Add("@datagrups", SqlDbType.NVarChar).Value = datagrupp;
                comm.Parameters.Add("@top_usl", SqlDbType.Bit).Value = usluga.TopUsl;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public UslugiDT GetUslugaByID(int? id)
        {
            UslugiDT uslugiDT = new UslugiDT();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand comm = new SqlCommand("adv_UslugiSelectByID", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    uslugiDT.ID = Convert.ToInt32(rdr["id"]);
                    uslugiDT.Name = rdr["name"].ToString();
                    uslugiDT.Opisanie = rdr["opisanie"].ToString();
                    uslugiDT.DataGroup = rdr["datagrups"].ToString();//переопределить
                    uslugiDT.TopUsl = Convert.ToBoolean(rdr["top_usl"]);
                    uslugiDT.UgolovDela = UslGrupp("\"ugldel\"", rdr["datagrups"].ToString());
                    uslugiDT.GrajdanDela = UslGrupp("\"gragdel\"", rdr["datagrups"].ToString());
                    uslugiDT.EkonomDela = UslGrupp("\"ekonomdel\"", rdr["datagrups"].ToString());
                }
                conn.Close();
            }
            return uslugiDT;
        }

        public void DeleteUslugu(int? id)
        {
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("dt_Uslugi_Delete", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        private bool UslGrupp(string seprtext, string dtdecl)
        {
            string[] sepr = dtdecl.Split(",");
            for (int i = 0; i < sepr.Length; i++)
            {
                if (sepr[i].Trim(' ') == seprtext)
                    return true;
            }
            return false;
        }
    }
}
