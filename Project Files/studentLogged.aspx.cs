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
    public partial class studentLogged : System.Web.UI.Page
    {
        private String name;
        private String Text;
        private int userID;
        static int projectID;
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
            
            Text = "select * from PROJECT2 where UserID = " + userID;
            Dbm.ConnectDB();
            Dbm.GetCommend(Text);
            Dbm.ExeQuery();

            EmpGridView.DataSource = Dbm.QueryEX();
            EmpGridView.DataBind();

            Dbm.CloseDB();
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
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            projectID = Int32.Parse(grv.Cells[0].Text);

            Text = "DELETE FROM PROJECT2 WHERE P_ID= " + projectID;
            Dbm.ConnectDB();
            Dbm.GetCommend(Text);
            Dbm.ExeQuery();
            Dbm.CloseDB();
            

            //refresh page to show th actual result
            Response.Redirect("StudentLogged.aspx");

           
        }

        protected void EnterClick(object sender, EventArgs e)
        {
            Text = "UPDATE PROJECT2 SET "
                                   + "P_Name = @P_Name, "
                                   + "UploadDate = @UploadDate, "
                                   + "Link = @Link, "
                                   + "Tag = @Tag, "
                                   + "Descrip = @Descript "
                                   + " WHERE P_ID = " + projectID;

            Dbm.ConnectDB();
            Dbm.GetCommend(Text);
            
            Dbm.AddVal("@P_Name", TextBox1.Text);
            Dbm.AddVal("@UploadDate", TextBox2.Text);
            Dbm.AddVal("@Link", TextBox3.Text);
            Dbm.AddVal("@Tag", TextBox4.Text);
            Dbm.AddVal("@Descript", TextBox5.Text);

            Dbm.ExeQuery();

            //refresh page to show th actual result
            Response.Redirect("studentLogged.aspx");
            

            Dbm.CloseDB();
        }

        public void EditUser_click(object sender, EventArgs e)
        {
            Response.Redirect("StudentProfile.aspx");

        }


    }
}