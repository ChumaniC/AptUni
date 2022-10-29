using System;

namespace AptUni.presentationLayer
{
    public partial class TestInstruction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTestTitle.Text = Session["Header_Title"].ToString() + " " + Session["Test_ID"].ToString();
        }

        protected void btnBegin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/Test.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/TestSelection.aspx");
        }
    }
}