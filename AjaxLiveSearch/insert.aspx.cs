using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxLiveSearch
{
    public partial class insert : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        string opr, Ename;
        protected void Page_Load(object sender, EventArgs e)
        {
            opr = Request.QueryString["opr"].ToString();
            if(opr == "search")
            {
                Ename = Request.QueryString["nm"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where Ename like('" + Ename.ToString() + "%')",con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Response.Write("<table style='boader= bold 1'>");
                Response.Write("<tr>");
                Response.Write("<td>"); Response.Write("Name"); Response.Write("</td>");
                Response.Write("<td>"); Response.Write("Email"); Response.Write("</td>");
                Response.Write("<td>"); Response.Write("Number"); Response.Write("</td>");

                Response.Write("</tr>");

                foreach(DataRow dr in  dt.Rows)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr["Ename"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["Eemail"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["Emnumber"].ToString()); Response.Write("</td>");
                   
                    Response.Write("</tr>");
                }
                Response.Write("</table>");
                con.Close();
            }
            if (opr == "ser")
            {
                Ename = Request.QueryString["nm"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where Ename like('" + Ename.ToString() + "%')", con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Response.Write("<table style='boader= bold 1'>");
                Response.Write("<tr>");
                Response.Write("<td>"); Response.Write("Name"); Response.Write("</td>");
                Response.Write("<td>"); Response.Write("Email"); Response.Write("</td>");
                Response.Write("<td>"); Response.Write("Number"); Response.Write("</td>");

                Response.Write("</tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    Response.Write("<tr>");
                    Response.Write("<td>"); Response.Write(dr["Ename"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["Eemail"].ToString()); Response.Write("</td>");
                    Response.Write("<td>"); Response.Write(dr["Emnumber"].ToString()); Response.Write("</td>");

                    Response.Write("</tr>");
                }
                Response.Write("</table>");
                con.Close();
            }

        }
    }
}