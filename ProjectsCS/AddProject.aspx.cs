using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace TestForm.ProjectsCS
{
    public partial class AddProject : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        private String name;
        private int userID;

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
        }

        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        protected void SubmitEventMethod(object sender, EventArgs e)
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            userID = (int)Session["U_ID"];
            con.Open();
            cmd.CommandText = "insert into PROJECT2 VALUES (@P_Name,@UploadDate,@Link,@Tag,@Descrip,@UserID)";

            cmd.Parameters.AddWithValue("@P_Name", ProjectNameBox.Text);
            cmd.Parameters.AddWithValue("@UploadDate", uploadBox.Text);
            cmd.Parameters.AddWithValue("@Link", LinkBox.Text);
            cmd.Parameters.AddWithValue("@Tag", projectTagBox.Text);
            cmd.Parameters.AddWithValue("@Descrip", projectDesBox.Text);
            cmd.Parameters.AddWithValue("@UserID", userID);

            cmd.ExecuteNonQuery();

            //clear text
            ProjectNameBox.Text = "";
            uploadBox.Text = "";
            LinkBox.Text = "";
            projectDesBox.Text = "";
            projectTagBox.Text = "";

            // to notify the add project is success
            Dis_data();

        }
        public void Dis_data()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PROJECT2 where UserID = " + userID;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
}
