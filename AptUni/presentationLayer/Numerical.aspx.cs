using System;
using System.Web;

namespace AptUni.presentationLayer
{
    public partial class Numerical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Session["Test_Type_Selection"] = "Numerical";
            Session["Current_Page"] = HttpContext.Current.Request.Url.AbsolutePath;
            Session["Header_Title"] = "Numerical Reasoning Tests";
            Session["Header_Content"] = "Numerical reasoning tests demonstrate your" +
                "ability to deal with numbers quickly and accurately. " +
                "These tests contain questions that assess your knowledge of ratios," +
                "percentages, number sequences, data interpretation," +
                "financial analysis and currency conversion.";

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