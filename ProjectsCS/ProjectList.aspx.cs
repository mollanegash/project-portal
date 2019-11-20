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
    public partial class ProjectList : System.Web.UI.Page
    { 
        private SqlConnection con = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dis_data();
            }
            
        }

        public void Dis_data()
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.CommandText = "SELECT * from PROJECT2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmpGridView.DataSource = dt;
            EmpGridView.DataBind();

        }

        protected void hyperlinkRedireced_Click(object sender, EventArgs e)
        {
            if (Session["Fname"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                String fac = Session["RoleType"].ToString();
                if ( fac == "Faculty")
                {
                    Response.Redirect("FacultyLogged.aspx");
                }
                else if (Session["RoleType"].ToString() == "Student")
                {
                    Response.Redirect("studentLogged.aspx");
                }
            }
        }    
        
        protected void View_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow grv = (GridViewRow)imgbtn.NamingContainer;
            lbl1.Text = grv.Cells[1].Text;
            lbl2.Text = grv.Cells[2].Text;
            lbl3.Text = grv.Cells[3].Text;
            lbl4.Text = grv.Cells[4].Text;
            lbl5.Text = grv.Cells[5].Text;

            ModalPopupExtender1.Show();
        }

        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}