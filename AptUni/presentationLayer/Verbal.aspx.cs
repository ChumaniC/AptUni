using System;
using System.Web;

namespace AptUni.presentationLayer
{
    public partial class Verbal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Session["Test_Type_Selection"] = "Verbal";
            Session["Current_Page"] = HttpContext.Current.Request.Url.AbsolutePath;
            Session["Header_Title"] = "Verbal Reasoning Tests";
            Session["Header_Content"] = "Verbal reasoning tests assess your understanding and comprehension skills." +
                "You will be presented with a short passage of text, which you’ll be required to" +
                "interpret and then answer questions on. These are typically in the ‘True, False," +
                "Cannot Say’ multiple - choice format, although there are a range of alternatives too.";

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