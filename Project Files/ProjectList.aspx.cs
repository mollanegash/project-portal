using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using TestForm.App_Code;

namespace TestForm.ProjectsCS
{
    public partial class ProjectList : System.Web.UI.Page
    {
        DBConnection Dbm = new DBConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dis_data();

            }

        }

        public void Dis_data()
        {
            String qry = "select * " +
                        " from PROJECT2 " +
                        " INNER JOIN STUDENT ON STUDENT.U_ID = PROJECT2.UserID " +
                        " INNER JOIN USERTABLE ON STUDENT.U_ID = USERTABLE.U_ID ";

            Dbm.GetCommend(qry);
            Dbm.ExeQuery();

            EmpGridView.DataSource = Dbm.QueryEX();
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
                if (fac == "Faculty")
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
            lbl0.Text = grv.Cells[0].Text;
            lbl1.Text = grv.Cells[1].Text;
            lbl2.Text = grv.Cells[2].Text;
            lbl3.Text = grv.Cells[3].Text;
            lbl4.Text = grv.Cells[4].Text;
            lbl5.Text = grv.Cells[5].Text;

            ShowComment();
            ModalPopupExtender1.Show();
        }

        protected void EmpGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void EmpGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmpGridView.PageIndex = e.NewPageIndex;
            Dis_data();
        }

        protected void EmpGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            String query = "";
            String textInput = "";

            if (DropDownList1.Text == "Project Name")
            {
                query = "select * " +
                        " from PROJECT2 " +
                        " INNER JOIN STUDENT ON STUDENT.U_ID = PROJECT2.UserID " +
                        " INNER JOIN USERTABLE ON STUDENT.U_ID = USERTABLE.U_ID " +
                        " WHERE P_Name like '";
                textInput = TextBox1.Text + "%'";
                SearchData(query, textInput);
            }
            else if (DropDownList1.Text == "Author Name")
            {
                query = "select * " +
                        " from PROJECT2 " +
                        " INNER JOIN STUDENT ON STUDENT.U_ID = PROJECT2.UserID " +
                        " INNER JOIN USERTABLE ON STUDENT.U_ID = USERTABLE.U_ID " +
                        " WHERE USERTABLE.FName like '";
                textInput = TextBox1.Text + "%'";
                SearchData(query, textInput);
            }
            else if (DropDownList1.Text == "Project ID")
            {
                query = "select * " +
                        " from PROJECT2 " +
                        " INNER JOIN STUDENT ON STUDENT.U_ID = PROJECT2.UserID " +
                        " INNER JOIN USERTABLE ON STUDENT.U_ID = USERTABLE.U_ID " +
                        " WHERE PROJECT2.P_ID like '";
                textInput = TextBox1.Text + "%'";
                SearchData(query, textInput);
            }
            else if (DropDownList1.Text == "Project Tag")
            {
                query = "select * " +
                        " from PROJECT2 " +
                        " INNER JOIN STUDENT ON STUDENT.U_ID = PROJECT2.UserID " +
                        " INNER JOIN USERTABLE ON STUDENT.U_ID = USERTABLE.U_ID " +
                        " WHERE Tag like '";
                textInput = TextBox1.Text + "%'";
                SearchData(query, textInput);
            }
            else
            {
                TextBox1.Text = " The search not found !";
            }


        }

        private void SearchData(String query, String TextInput)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query + TextInput, Dbm.ConnectDB());
            DataSet data = new DataSet();
            sda.Fill(data);
            EmpGridView.DataSource = data;
            EmpGridView.DataBind();
            Dbm.CloseDB();
        }

        protected void Comment_Click1(object sender, EventArgs e)
        {
            String text;

            text = "insert into COMMENT(ProjectID, ComName, CommentText, DateComment) values(@ProjectID, @Name, @CommentText, @DateComment)";
            Dbm.GetCommend(text);

            Dbm.ConnectDB();

            Dbm.AddVal("@Name", TextName.Text);
            Dbm.AddDate("@DateComment", DateTime.Now.ToLocalTime());
            Dbm.AddVal("@CommentText", TextComment.Text);
            Dbm.AddVal("@ProjectID", lbl0.Text);
            Dbm.ExeQuery();

            TextName.Text = "";
            TextComment.Text = "";

        }
        protected void ShowComment()
        {
            String text = "Select ComName, DateComment, CommentText from COMMENT WHERE ProjectID = " + lbl0.Text;
            Dbm.GetCommend(text);
            Repeater1.DataSource = Dbm.QueryEX();
            Repeater1.DataBind();
            Dbm.CloseDB();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}