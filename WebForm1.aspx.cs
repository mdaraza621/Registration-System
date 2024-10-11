using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace webformCRUD
{
    public partial class WebForm1 : System.Web.UI.Page

    {
        SqlConnection con = new SqlConnection("data source = DESKTOP-3278F0B\\SQLEXPRESS; initial catalog =ddgproc; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindState();
                BindCity();
                BindGender();
                Show();
            }


        }

       public void Clear()

        {
            txtname.Text = "";
            ddlstate.SelectedValue = "0";
            ddlcity.SelectedValue = "0";
            rblgender.ClearSelection();
            btnsubmit.Text = "Submit";
        }
        
        public void Show()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("register_proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "select");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            
            gvregister.DataSource = dt;
            gvregister.DataBind();
           
            
        }

        public void BindState()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("state_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlstate.DataValueField = "sid";
            ddlstate.DataTextField = "sname";
            ddlstate.DataSource = dt;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--select--","0"));
            
        }

        public void BindCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("city_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
          
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "cid";
            ddlcity.DataTextField = "cname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--select--","0"));
                
        }
        public void BindGender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("gender_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblgender.DataValueField = "gid";
            rblgender.DataTextField = "gname";
            rblgender.DataSource = dt;
            rblgender.DataBind();
            

        }




        protected void btnsubmit_Click(object sender, EventArgs e)
        {


            if (btnsubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("register_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);


                cmd.ExecuteNonQuery();
                con.Close();
                Show();
                Clear();


            }

            else if (btnsubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("register_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "update");
                cmd.Parameters.AddWithValue("@name",txtname.Text);
                cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
                cmd.Parameters.AddWithValue("@city",ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@id", ViewState["abc"]);
                cmd.ExecuteNonQuery();
                con.Close();
                Show();
                Clear();



            }
        }

        protected void gvregister_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "D")
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("register_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Show();

            }
            else if (e.CommandName == "E")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("register_proc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Edit");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                ddlstate.SelectedValue = dt.Rows[0]["state"].ToString();
                ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                btnsubmit.Text = "Update";
                ViewState["abc"] = e.CommandArgument;
            }

        }
    }
}