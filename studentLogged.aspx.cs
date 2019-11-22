using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using TestForm.ProjectsCS;

namespace TestForm.ProjectsCS
{
    public partial class LoggedIn : System.Web.UI.Page
    {

        private SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        private String name;
        private int userID;
        static int projectID;

        protected void Page_Load(object sender, EventArgs e)
        {
            name = (String)(Session["Fname"]);
            if (name == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("index.aspx", false);
            }
            else
            {
                lbluser.Text = name;

                if (!IsPostBack)
                {
                    Dis_data();
                }

            }
           
        }

        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        
        public void Dis_data()
        {
            userID = (int)Session["U_ID"];

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.CommandText = "select * from PROJECT2 where UserID = " + userID ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmpGridView.DataSource = dt;
            EmpGridView.DataBind();

            con.Close();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            TextBox1.Text = grv.Cells[1].Text;
            TextBox2.Text = grv.Cells[2].Text;
            TextBox3.Text = grv.Cells[3].Text;
            TextBox4.Text = grv.Cells[4].Text;
            TextBox5.Text = grv.Cells[5].Text;

            projectID = Int32.Parse(grv.Cells[0].Text);

            ModalPopupExtender1.Show();
        }

        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        protected void DeleteProject_Click(object sender, EventArgs e)
        {
            SqlCommand std = con.CreateCommand();
            std.CommandType = CommandType.Text;
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            projectID = Int32.Parse(grv.Cells[0].Text);

            con.Open();

            std.CommandText = "DELETE FROM PROJECT2 WHERE P_ID= " + projectID;
            std.ExecuteNonQuery();

            //refresh page to show th actual result
            Response.Redirect("StudentLogged.aspx");

            con.Close();
        }

        protected void EnterClick(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            con.Open();
            cmd.CommandText = "UPDATE PROJECT2 SET "
                                   + "P_Name = @P_Name, "
                                   + "UploadDate = @UploadDate, "
                                   + "Link = @Link, "
                                   + "Tag = @Tag, "
                                   + "Descrip = @Descript "
                                   + " WHERE P_ID = " + projectID;

            cmd.Parameters.AddWithValue("@P_Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@UploadDate", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Link", TextBox3.Text);
            cmd.Parameters.AddWithValue("@Tag", TextBox4.Text);
            cmd.Parameters.AddWithValue("@Descript", TextBox5.Text);

            cmd.ExecuteNonQuery();

            //refresh page to show th actual result
            Response.Redirect("studentLogged.aspx");

            con.Close();
        }

        public void EditUser_click(object sender, EventArgs e)
        {
            Response.Redirect("StudentProfile.aspx");
                
        }
    }
}
