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
        private SqlConnection con2 = new SqlConnection(@"Data Source=parsley.arvixe.com;Initial Catalog=computerscienceprojectportal;Persist Security Info=True;User ID=computerscienceprojectportal;Password=team4CS673");
		
		protected string mProjectNameContainsString = string.Empty;
    	protected string mProjectDescriptionContainsString = string.Empty;
   		protected string mProjectTag1ContainsString = string.Empty;
    	protected string selectQueryString = string.Empty;
		protected string begginingQueryString = string.Empty;
		protected string ProjectNameQueryString = string.Empty;
		protected string ProjectDescriptionQueryString = string.Empty;
		protected string ProjectTag1QueryString = string.Empty;
		
		protected int NotNullVariableCount = 0;
		
		
		
        protected void Page_Load(object sender, EventArgs e)
        {
			
			mProjectNameContainsString = Request.QueryString.Get("projectname");
    		mProjectDescriptionContainsString = Request.QueryString.Get("projectdescription");
    		mProjectTag1ContainsString = Request.QueryString.Get("projecttag1");
			
            if (!IsPostBack)
            {
                Dis_data();
            }
            
        }

        public void Dis_data()
        {
			

    		begginingQueryString = "select * from PROJECT2 ";
			
			if (mProjectNameContainsString != "") {
		
				if (NotNullVariableCount == 0) {
					ProjectNameQueryString = " WHERE ProjectName like '%" + mProjectNameContainsString + "%'";
				}
				else {
					ProjectNameQueryString = " AND ProjectName like '%" + mProjectNameContainsString + "%'";
				}
				NotNullVariableCount++;
			}
		
			if (mProjectDescriptionContainsString != "") {
		
				if (NotNullVariableCount == 0) {
					ProjectDescriptionQueryString = " WHERE  ProjectDescription like '%" + mProjectDescriptionContainsString + "%'";
				}
				else {
					ProjectDescriptionQueryString = " AND ProjectDescription like '%" + mProjectDescriptionContainsString + "%'";
				}
		
				this.NotNullVariableCount = NotNullVariableCount+1;
			}
		
		
			if (mAuthorsContainsString != "") {
		
				if (NotNullVariableCount == 0) {
					AuthorsQueryString = " WHERE  Authors like '%" + mAuthorsContainsString + "%'";
				}
				else {
					AuthorsQueryString = " AND Authors like '%" + mAuthorsContainsString + "%'";
				}
		
				this.NotNullVariableCount = NotNullVariableCount+1;
			}
		
		
			if (mProjectTag1ContainsString != "") {
		
				if (NotNullVariableCount == 0) {
					ProjectTag1QueryString = " WHERE  ProjectTag1 like '%" + mProjectTag1ContainsString + "%'";
				}
				else {
					ProjectTag1QueryString = " AND ProjectTag1 like '%" + mProjectTag1ContainsString + "%'";
				}
		
				this.NotNullVariableCount = NotNullVariableCount+1;
			}
		
		
		
			selectQueryString = begginingQueryString + ProjectNameQueryString + ProjectDescriptionQueryString + AuthorsQueryString + ProjectTag1QueryString;
			
			
			
			
			SqlCommand cmd = con2.CreateCommand();
            cmd.CommandType = CommandType.Text;
            con2.Open();
			cmd.CommandText = "Select PROJECT2.P_Name from Project2"; //I cannot get this sting to do anything, no matter waht I change it to, it always displays all projects?  
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EmpGridView.DataSource = dt;
            EmpGridView.DataBind();
			con2.Close();

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