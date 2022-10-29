using System;
using System.Web;

namespace AptUni.presentationLayer
{
    public partial class Logical : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Session["Test_Type_Selection"] = "Diagrammatic";
            Session["Current_Page"] = HttpContext.Current.Request.Url.AbsolutePath;
            Session["Header_Title"] = "Diagrammatic Reasoning Test";
            Session["Header_Content"] = "Diagrammatic reasoning tests assess your logical reasoning ability." +
                "The questions measure your ability to infer a set of rules from a flowchart" +
                "or sequence of diagrams and then to apply those rules to a new situation.";

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