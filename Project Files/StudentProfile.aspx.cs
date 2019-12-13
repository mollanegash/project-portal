using System.Web.UI;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using TestForm.ProjectsCS;
using System;
using TestForm.App_Code;

namespace TestForm.ProjectsCS
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        private String name;
        private String Text;
        DBConnection DBm = new DBConnection();
       
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

        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DataBlinding()
        {
           int u_id = (int)Session["U_ID"];
            DBm.ConnectDB();

            Text = "Select USERTABLE.Fname, USERTABLE.Lname, USERTABLE.School, STUDENT.Major, STUDENT.Grad_Date "
                                + "from USERTABLE "
                                + "LEFT JOIN STUDENT ON STUDENT.U_ID = USERTABLE.U_ID"
                                + " WHERE USERTABLE.U_ID =" + u_id;
           
            DBm.GetCommend(Text);
            DBm.ExeQuery();

            EmpGridView.DataSource = DBm.QueryEX();
            EmpGridView.DataBind();
            EmpGridView.RowStyle.VerticalAlign = VerticalAlign.Middle;
            DBm.CloseDB();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            TextBox1.Text = grv.Cells[0].Text;
            TextBox2.Text = grv.Cells[1].Text;
            TextBox3.Text = grv.Cells[2].Text;
            TextBox4.Text = grv.Cells[3].Text;
            TextBox5.Text = grv.Cells[4].Text;

            ModalPopupExtender1.Show();
        }

        
        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        public void EnterClick(object sender, EventArgs e)
        {
            int stu_int = (int)(Session["U_ID"]);

            //connecting to the database
            DBm.ConnectDB();
            
            Text = "BEGIN TRANSACTION; " +
                              "UPDATE USERTABLE " +
                              "SET Fname = @Fname" +
                              ", Lname = @Lname " +
                              ", School = @School" +
                              " FROM USERTABLE WHERE USERTABLE.U_ID = " + stu_int +
                              " UPDATE STUDENT " +
                              "SET Major = @Major" +
                              ", Grad_Date = @Grad_Date" +
                              " FROM STUDENT WHERE STUDENT.U_ID = " + stu_int +
                              " COMMIT;" ;

            DBm.GetCommend(Text);

            DBm.AddVal("@Fname", TextBox1.Text);
            DBm.AddVal("@Lname", TextBox2.Text);
            DBm.AddVal("@School", TextBox3.Text);
            DBm.AddVal("@Major", TextBox4.Text);
            DBm.AddVal("@Grad_Date", TextBox5.Text);

            DBm.ExeQuery();

            //refresh page to show th actual result
            Response.Redirect("StudentProfile.aspx");

            DBm.CloseDB();
        }
    }
}