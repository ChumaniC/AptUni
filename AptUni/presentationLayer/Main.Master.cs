using System;
using System.Web.UI;

namespace AptUni.presentationLayer
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private logicLayer.Dashboard dashboard = new logicLayer.Dashboard();
        private logicLayer.Login login = new logicLayer.Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            login.Page = Page;
            login.HasTestScore = false;

            if (Session["Active_User"] != null)
            {
                login.CheckScores();
                lblOnlineUSername.Text = "Hello " + Session["Active_User"].ToString();
                if (Session["HasTestScore"].ToString() != false.ToString())
                {
                    btnDashboard.Visible = true;
                }

                btnSignIn.Visible = false;
                btnSignUp.Text = "SignOut";
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/SignIn.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (Session["Active_User"] != null)
            {
                Session.Abandon();
                lblOnlineUSername.Visible = false;
                btnSignIn.Visible = true;
                btnSignUp.Visible = true;
                btnSignUp.Text = "Sign In";
                Response.AddHeader("REFRESH", "1;URL=../presentationLayer/LandingPage.aspx");
            }
            else
            {
                if (Session["Active_User"] == null)
                {
                    btnSignUp.Visible = false;
                    Response.Redirect("../presentationLayer/SignUp.aspx");
                }
            }
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            if (Session["Active_User"] != null)
            {
                lblOnlineUSername.Text = "Hello " + Session["Active_User"].ToString();
                btnSignIn.Visible = false;
                btnSignUp.Text = "SignOut";

                if (Session["HasTestScore"].ToString() != false.ToString())
                {
                    Response.AddHeader("REFRESH", "1;URL=../presentationLayer/Dashboard.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_dash", "dashboard();", true);
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }
    }
}