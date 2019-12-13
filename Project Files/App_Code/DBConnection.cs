using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TestForm.App_Code
{
    public class DBConnection
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        private DataTable dt;
        private SqlDataAdapter da;

        public SqlConnection ConnectDB()
        {          
            con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
            con.Open();
            return con;
        }

        public void CloseDB()
        {
            if(con != null && con.State == System.Data.ConnectionState.Open)
            {
                this.con.Close();
            }
        }

        public SqlCommand GetCommend(String qur)
        {
            cmd = new SqlCommand(qur);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.ConnectDB();

            return cmd;
        }

        public void AddVal(String prm, String input)
        {
            cmd.Parameters.AddWithValue(prm, input);
        }

        public void AddDate(String prm, DateTime date)
        {
            cmd.Parameters.AddWithValue(prm, date);
        }

        public void AddInt(String prm, int val)
        {
            cmd.Parameters.AddWithValue(prm, val);
        }

        public SqlCommand ExeQuery()
        {
            cmd.ExecuteNonQuery();
            return cmd;
        }

        public DataTable QueryEX()
        {
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public SqlDataReader ExeReader()
        {
            reader = cmd.ExecuteReader();
            return reader;
        }
       
    }
}