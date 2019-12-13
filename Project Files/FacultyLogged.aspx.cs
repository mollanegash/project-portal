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

namespace TestForm.ProjectsCS
{
    public partial class FacultyLogged : System.Web.UI.Page
    {
        private String name;
        private String Text;
        private int U_ID;
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
            DBm.CloseDB();
            Text = "Select USERTABLE.Fname,USERTABLE.Lname, PROJECT2.P_Name,PROJECT2.Descrip, PROJECT2.Link, STUDENT.U_ID from PROJECT2 INNER JOIN USERTABLE ON USERTABLE.U_ID = PROJECT2.UserID INNER JOIN STUDENT ON USERTABLE.U_ID = STUDENT.U_ID;";
            DBm.GetCommend(Text);
            DBm.ExeQuery();
            EmpGridView.DataSource = DBm.QueryEX();
            EmpGridView.DataBind();
            DBm.CloseDB();
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
            
            Text = "SELECT S_UID FROM SUPERVISER WHERE S_UID = " + Label6.Text;
            DBm.GetCommend(Text);
            SqlDataReader reader;
            reader = DBm.ExeReader();
            DBm.ConnectDB();
            
           if (reader.HasRows && reader.Read())
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>\n");
                System.Web.HttpContext.Current.Response.Write("alert(\"" + "Already had a Superviser" + "\")\n");
                System.Web.HttpContext.Current.Response.Write("</SCRIPT>");
                DBm.CloseDB();
            }
            else
            {
                //close data reader to execute another command
                DBm.CloseDB();
                //open new command to execute a next statement
                DBm.ConnectDB();

                Text = "insert into SUPERVISER(Superviser_ID, S_UID) VALUES(@Superviser_ID, @S_UID)";
                DBm.GetCommend(Text);

                U_ID = (int)Session["U_ID"];

                DBm.AddInt("@Superviser_ID",U_ID );
                DBm.AddVal("@S_UID", Label6.Text);
                DBm.ExeQuery();

                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>\n");
                System.Web.HttpContext.Current.Response.Write("alert(\"" + "Add supervisees Successfully" + "\")\n");
                System.Web.HttpContext.Current.Response.Write("</SCRIPT>");
                DBm.CloseDB();
            }

        }

       protected void FacProfile_click(object sender, EventArgs e)
        {
           Response.Redirect("FacultyProfile.aspx");
        }
        
    }

}