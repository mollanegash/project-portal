using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class FacultyLogged : System.Web.UI.Page
    {
        String name;
        SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
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
                UserLabel1.Text = name;
            }

            if (!IsPostBack)
            {
                dataBlinding();
            }

        }

        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        protected void dataBlinding()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandText = "Select USERTABLE.Fname,USERTABLE.Lname, PROJECT2.P_Name,PROJECT2.Descrip, PROJECT2.Link, STUDENT.U_ID from PROJECT2 INNER JOIN USERTABLE ON USERTABLE.U_ID = PROJECT2.UserID INNER JOIN STUDENT ON USERTABLE.U_ID = STUDENT.U_ID;";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmpGridView.DataSource = dt;
            EmpGridView.DataBind();
            con.Close();
        }
        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void ButtonClick1_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            Label1.Text = grv.Cells[0].Text;
            Label2.Text = grv.Cells[1].Text;
            Label3.Text = grv.Cells[2].Text;
            Label4.Text = grv.Cells[3].Text;
            Label5.Text = grv.Cells[4].Text;
            Label6.Text = grv.Cells[5].Text;

            ModalPopupExtender1.Show();
        }

        protected void AddClick(object sender, EventArgs e)
        {
            SqlCommand std = con.CreateCommand();
            std.CommandType = CommandType.Text;
            SqlDataReader reader;
            std.CommandText = "SELECT S_UID FROM SUPERVISER WHERE S_UID = " + Label6.Text;
            con.Open();
            reader = std.ExecuteReader();

            if (reader.HasRows && reader.Read())
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>\n");
                System.Web.HttpContext.Current.Response.Write("alert(\"" + "Already had a Superviser" + "\")\n");
                System.Web.HttpContext.Current.Response.Write("</SCRIPT>");
                con.Close();
            }
            else
            {
                //close data reader to execute another command
                con.Close();
                //open new command to execute a next statement
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into SUPERVISER(Superviser_ID, S_UID) VALUES(@Superviser_ID, @S_UID)";

                cmd.Parameters.AddWithValue("@Superviser_ID", Session["U_ID"]);
                cmd.Parameters.AddWithValue("@S_UID", Label6.Text);
                cmd.ExecuteNonQuery();

                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>\n");
                System.Web.HttpContext.Current.Response.Write("alert(\"" + "Add supervisees Successfully" + "\")\n");
                System.Web.HttpContext.Current.Response.Write("</SCRIPT>");
                con.Close();
            }

        }

       protected void FacProfile_click(object sender, EventArgs e)
        {
           Response.Redirect("FacultyProfile.aspx");
        }
        
    }

}