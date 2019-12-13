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
using TestForm.App_Code;

namespace TestForm
{
    public partial class StudentList : System.Web.UI.Page
    {
        private String name;
        private String Text;
        DBConnection Dbm = new DBConnection();
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
           int u_id = (int)Session["U_ID"];
           
           Text = "Select USERTABLE.Fname, USERTABLE.Lname, USERTABLE.School, USERTABLE.email, SUPERVISER.S_UID, PROJECT2.P_Name"
                                + " from SUPERVISER " 
                                + " INNER JOIN FACULTY ON FACULTY.U_ID = SUPERVISER.Superviser_ID "
                                + " INNER JOIN STUDENT ON STUDENT.U_ID = SUPERVISER.S_UID "
                                + " INNER JOIN USERTABLE ON USERTABLE.U_ID = STUDENT.U_ID "
                                + " INNER JOIN PROJECT2 ON PROJECT2.UserID = STUDENT.U_ID "
                                + "WHERE Superviser_ID = " + u_id;
            Dbm.ConnectDB();
            Dbm.GetCommend(Text);
            Dbm.ExeQuery();

            EmpGridView.DataSource = Dbm.QueryEX();
            EmpGridView.DataBind();
            Dbm.CloseDB();
        }

        protected void ButtonClick1_Click(object sender, EventArgs e)
        {

            Button btnDel = (Button)sender;
            GridViewRow grv = (GridViewRow)btnDel.NamingContainer;
            int stu_int = Int32.Parse(grv.Cells[4].Text);

            Text = "DELETE FROM SUPERVISER WHERE S_UID= " + stu_int;
            Dbm.ConnectDB();
            Dbm.GetCommend(Text);
            Dbm.ExeQuery();
            Dbm.CloseDB();

            //refresh page to show th actual result
            Response.Redirect("StudentList.aspx");

        }

        protected void UserLabel1_Click(object sender, EventArgs e)
        {

        }
    }

}