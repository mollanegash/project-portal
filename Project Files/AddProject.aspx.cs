using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using TestForm.App_Code;

namespace TestForm.ProjectsCS
{
    public partial class AddProject : System.Web.UI.Page
    {
        //create an instant for data connection class
        DBConnection DBm = new DBConnection();

        //declare all private variable 
        private String Text;
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
            userID = (int)Session["U_ID"];
            DBm.ConnectDB();
            Text= "insert into PROJECT2 VALUES (@P_Name,@UploadDate,@Link,@Tag,@Descrip,@UserID)";
            DBm.GetCommend(Text);

            DBm.AddVal("@P_Name", ProjectNameBox.Text);
            DBm.AddVal("@UploadDate", uploadBox.Text);
            DBm.AddVal("@Link", LinkBox.Text);
            DBm.AddVal("@Tag", projectTagBox.Text);
            DBm.AddVal("@Descrip", projectDesBox.Text);
            DBm.AddInt("@UserID", userID);

            DBm.ExeQuery();

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
            Text = "select * from PROJECT2 where UserID = " + userID;
            DBm.GetCommend(Text);
            DBm.ExeQuery();
            //Display data in gridview
            GridView1.DataSource = DBm.QueryEX();
            GridView1.DataBind();
        }

    }
}
