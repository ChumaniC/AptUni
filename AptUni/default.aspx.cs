using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AptUni
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNumerical_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/Numerical.aspx");
        }

        protected void btnVerbal_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/Verbal.aspx");
        }


        protected void btnSituational_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/Situational.aspx");
        }

        protected void btnDiagrammatic_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/Diagrammatic.aspx");
        }
    }
}