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
    public partial class FacultyProfile : System.Web.UI.Page
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
            int u_id = (int)Session["U_ID"];
            DBm.ConnectDB();
            Text = "Select USERTABLE.Fname, USERTABLE.Lname, USERTABLE.School, FACULTY.Field_Exp "
                                + "from USERTABLE "
                                + "LEFT JOIN FACULTY ON FACULTY.U_ID = USERTABLE.U_ID"
                                + " WHERE USERTABLE.U_ID =" + u_id;
            DBm.GetCommend(Text);
            DBm.ExeQuery();
            EmpGridView.DataSource = DBm.QueryEX();
            EmpGridView.DataBind();
            DBm.ConnectDB();
        }

        protected void logoutEventMethod(object sender, EventArgs e)
        {
            Session["Fname"] = null;
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

        protected void EnterClick(object sender, EventArgs e)
        {
            int stu_int = (int)(Session["U_ID"]);
            Text = "BEGIN TRANSACTION; " +
                              "UPDATE USERTABLE " +
                              "SET Fname = @Fname" +
                              ", Lname = @Lname " +
                              ", School = @School" +
                              " FROM USERTABLE WHERE USERTABLE.U_ID = " + stu_int +
                              " UPDATE FACULTY " +
                              "SET Field_Exp = @Field_Exp" +
                              " FROM FACULTY WHERE FACULTY.U_ID = " + stu_int +
                              " COMMIT;";
            DBm.GetCommend(Text);
            DBm.AddVal("@Fname", TextBox1.Text);
            DBm.AddVal("@Lname", TextBox2.Text);
            DBm.AddVal("@School", TextBox3.Text);
            DBm.AddVal("@Field_Exp", TextBox4.Text);

            DBm.ExeQuery();

            //refresh page to show th actual result
            Response.Redirect("FacultyProfile.aspx");

            DBm.CloseDB();
        }

       
    }
}