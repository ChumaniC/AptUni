using System;
using System.Web;

namespace AptUni.presentationLayer
{
    public partial class Situational : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Session["Test_Type_Selection"] = "Situational";
            Session["Current_Page"] = HttpContext.Current.Request.Url.AbsolutePath;
            Session["Header_Title"] = "Situational Judgement Test";
            Session["Header_Content"] = "Situational judgement tests allow employers to assess how you approach" +
                "scenarios encountered in the workplace. The tests are built around hypothetical" +
                "work situations, to which you are expected to react accordingly." +
                "Your answers will indicate your alignment with the values and behaviours of that particular company.";

            if (Session["User_ID"] == null)
            {
                Response.Redirect("../presentationLayer/SignIn.aspx");
            }
            else
            {
                Response.Redirect("../presentationLayer/TestSelection.aspx");
            }
        }
    }
}