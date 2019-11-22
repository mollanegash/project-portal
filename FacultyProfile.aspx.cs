using System.Web.UI;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using TestForm.ProjectsCS;
using System;


namespace TestForm.ProjectsCS
{
    public partial class FacultyProfile : System.Web.UI.Page
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
                labelText.Text = name;
            }

            if (!IsPostBack)
            {
                DataBlinding();
            }
        }

        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            TextBox1.Text = grv.Cells[0].Text;
            TextBox2.Text = grv.Cells[1].Text;
            TextBox3.Text = grv.Cells[2].Text;
            TextBox4.Text = grv.Cells[3].Text;
            
            ModalPopupExtender1.Show();
        }

        public void DataBlinding()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int u_id = (int)Session["U_ID"];
            con.Open();
            cmd.CommandText = "Select USERTABLE.Fname, USERTABLE.Lname, USERTABLE.School, FACULTY.Field_Exp "
                                + "from USERTABLE "
                                + "LEFT JOIN FACULTY ON FACULTY.U_ID = USERTABLE.U_ID"
                                + " WHERE USERTABLE.U_ID =" + u_id;

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmpGridView.DataSource = dt;
            EmpGridView.DataBind();
            con.Close();
        }

        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        protected void EnterClick(object sender, EventArgs e)
        {
            SqlCommand std = con.CreateCommand();
            std.CommandType = CommandType.Text;

            int stu_int = (int)(Session["U_ID"]);

            con.Open();

            std.CommandText = "BEGIN TRANSACTION; " +
                              "UPDATE USERTABLE " +
                              "SET Fname = @Fname" +
                              ", Lname = @Lname " +
                              ", School = @School" +
                              " FROM USERTABLE WHERE USERTABLE.U_ID = " + stu_int +
                              " UPDATE FACULTY " +
                              "SET Field_Exp = @Field_Exp" +
                              " FROM FACULTY WHERE FACULTY.U_ID = " + stu_int +
                              " COMMIT;";
            std.Parameters.AddWithValue("@Fname", TextBox1.Text);
            std.Parameters.AddWithValue("@Lname", TextBox2.Text);
            std.Parameters.AddWithValue("@School", TextBox3.Text);
            std.Parameters.AddWithValue("@Field_Exp", TextBox4.Text);
           
            std.ExecuteNonQuery();

            //refresh page to show th actual result
            Response.Redirect("FacultyProfile.aspx");

            con.Close();
        }

       
    }
}