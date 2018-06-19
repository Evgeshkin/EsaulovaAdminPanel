using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelEsaulova.Model.BlogDT
{
    public class BlogDataAccess : HelperDataAccess
    {
        public IEnumerable<Blog> GetBlog()
        {
            listBloga = new List<Blog>();
            using (SqlConnection conn = new SqlConnection(Helpers.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("adv_Blog_SelectAll", conn);
                comm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    Blog blog = new Blog();
                    blog.ID = Convert.ToInt32(rdr["id"]);
                    blog.HederText = rdr["hedertext"].ToString();
                    blog.FillText = rdr["filltext"].ToString();
                    blog.FullText = rdr["fulltext"].ToString();
                    blog.DataPublick = Convert.ToDateTime(rdr["date_publick"].ToString());
                    blog.ImgDir = rdr["img_dir"].ToString();
                    blog.NewsArhiv = (bool)rdr["news_arhif"];
                    blog.TopNews = (bool)rdr["glav"];
                    blog.RazdelID = (int)rdr["id_razdel"];
                    blog.ThemaID = (int)rdr["id_tema"];
                    listBloga.Add(blog);
                }
                conn.Close();
            }
            return listBloga;
        }

        public IEnumerable<Blog> GetBlogByThema(int? temaid)
        {
            listBloga = new List<Blog>();
            using (SqlConnection conn = new SqlConnection(Helpers.ConnectionString))
            {
                SqlCommand comm = new SqlCommand(CmdText, conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                comm.Parameters.Add("@themaID", SqlDbType.Int).Value = temaid;
                conn.Open();
                SqlDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    Blog blog = new Blog();
                    blog.ID = Convert.ToInt32(rdr["id"]);
                    blog.HederText = rdr["hedertext"].ToString();
                    blog.FillText = rdr["filltext"].ToString();
                    blog.FullText = rdr["fulltext"].ToString();
                    blog.DataPublick = Convert.ToDateTime(rdr["date_publick"].ToString());
                    blog.ImgDir = rdr["img_dir"].ToString();
                    blog.NewsArhiv = (bool)rdr["news_arhif"];
                    blog.TopNews = (bool)rdr["glav"];
                    blog.RazdelID = (int)rdr["id_razdel"];
                    blog.ThemaID = (int)rdr["id_tema"];
                    listBloga.Add(blog);
                }
                conn.Close();
            }
            return listBloga;
        }


        public Blog GetBlogByID(int? id)
        {
            using (SqlConnection conn = new SqlConnection(Helpers.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("adv_Blog_SelectByID", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                SqlDataReader rdr = comm.ExecuteReader();
                    Blog blog = new Blog();
                    blog.ID = Convert.ToInt32(rdr["id"]);
                    blog.HederText = rdr["hedertext"].ToString();
                    blog.FillText = rdr["filltext"].ToString();
                    blog.FullText = rdr["fulltext"].ToString();
                    blog.DataPublick = Convert.ToDateTime(rdr["date_publick"].ToString());
                    blog.ImgDir = rdr["img_dir"].ToString();
                    blog.NewsArhiv = (bool)rdr["news_arhif"];
                    blog.TopNews = (bool)rdr["glav"];
                    blog.RazdelID = (int)rdr["id_razdel"];
                    blog.ThemaID = (int)rdr["id_tema"];
                conn.Close();
                return blog;
            }
        }

        public void EditBlogNews(Blog blog)
        {
            using (SqlConnection conn = new SqlConnection(Helpers.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("dt_Uslugi_Update", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.NVarChar).Value = blog.ID;
                comm.Parameters.Add("@hedertext", SqlDbType.NVarChar).Value = blog.HederText;
                comm.Parameters.Add("@filltext", SqlDbType.NVarChar).Value = blog.FillText;
                comm.Parameters.Add("@fulltext", SqlDbType.NVarChar).Value = blog.FullText;
                comm.Parameters.Add("@date_publick", SqlDbType.DateTime).Value = blog.DataPublick;
                comm.Parameters.Add("@img_dir", SqlDbType.NVarChar).Value = blog.ImgDir;
                comm.Parameters.Add("@news_arhif", SqlDbType.Bit).Value = blog.NewsArhiv;
                comm.Parameters.Add("@glav", SqlDbType.Bit).Value = blog.RazdelID;
                comm.Parameters.Add("@id_razdel", SqlDbType.Int).Value = blog.ThemaID;
                comm.Parameters.Add("@id_tema", SqlDbType.Int).Value = blog.TopNews;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void AddBlogNews(Blog blog)
        {
            using (SqlConnection conn = new SqlConnection(Helpers.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("dt_Uslugi_Insert", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.NVarChar).Value = blog.ID;
                comm.Parameters.Add("@hedertext", SqlDbType.NVarChar).Value = blog.HederText;
                comm.Parameters.Add("@filltext", SqlDbType.NVarChar).Value = blog.FillText;
                comm.Parameters.Add("@fulltext", SqlDbType.NVarChar).Value = blog.FullText;
                comm.Parameters.Add("@date_publick", SqlDbType.DateTime).Value = blog.DataPublick;
                comm.Parameters.Add("@img_dir", SqlDbType.NVarChar).Value = blog.ImgDir;
                comm.Parameters.Add("@news_arhif", SqlDbType.Bit).Value = blog.NewsArhiv;
                comm.Parameters.Add("@glav", SqlDbType.Bit).Value = blog.RazdelID;
                comm.Parameters.Add("@id_razdel", SqlDbType.Int).Value = blog.ThemaID;
                comm.Parameters.Add("@id_tema", SqlDbType.Int).Value = blog.TopNews;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void DeleteBlogNews(int? id)
        {
            using (SqlConnection conn = new SqlConnection(Helpers.ConnectionString))
            {
                SqlCommand comm = new SqlCommand("dt_Uslugi_Delete", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
