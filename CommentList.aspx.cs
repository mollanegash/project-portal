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

namespace TestForm
{
    public partial class CommentList : System.Web.UI.Page
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
                DataBlinding();
            }
        }

        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataBlinding()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int u_id = (int)Session["U_ID"];
            //int p_id = (int)Session["P_ID"];
            con.Open();
            cmd.CommandText = "Select COMMENT.ProjectID, COMMENT.UserID, COMMENT.CommentText, COMMENT.DateComment"
                                + "from COMMENT"
                                //+ "WHERE COMMENT.ProjectID =" + p_id

            /*cmd.CommandText = "Select USERTABLE.Fname, USERTABLE.Lname, USERTABLE.School, USERTABLE.email, SUPERVISER.S_UID, PROJECT2.P_Name"
                                + " from SUPERVISER "
                                + " INNER JOIN FACULTY ON FACULTY.U_ID = SUPERVISER.Superviser_ID "
                                + " INNER JOIN STUDENT ON STUDENT.U_ID = SUPERVISER.S_UID "
                                + " INNER JOIN USERTABLE ON USERTABLE.U_ID = STUDENT.U_ID "
                                + " INNER JOIN PROJECT2 ON PROJECT2.UserID = STUDENT.U_ID "
                                + "WHERE Superviser_ID = " + u_id;*/

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmpGridView.DataSource = dt;
            EmpGridView.DataBind();
            con.Close();
        }

        protected void ButtonClick1_Click(object sender, EventArgs e)
        {
            /*SqlCommand std = con.CreateCommand();
            std.CommandType = CommandType.Text;
            Button btnDel = (Button)sender;
            GridViewRow grv = (GridViewRow)btnDel.NamingContainer;
            int stu_int = Int32.Parse(grv.Cells[4].Text);

            con.Open();

            std.CommandText = "DELETE FROM SUPERVISER WHERE S_UID= " + stu_int;
            std.ExecuteNonQuery();

           //refresh page to show th actual result
            Response.Redirect("StudentList.aspx");

            con.Close();*/
        }
    }

}
