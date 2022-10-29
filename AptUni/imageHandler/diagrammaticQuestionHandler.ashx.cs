using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AptUni.imageHandler
{
    /// <summary>
    /// Summary description for diagrammaticQuestionHandler
    /// </summary>
    public class diagrammaticQuestionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string test_ID = context.Request.Cookies["Test_ID"].Value.ToString();
                string image_ID = context.Request.Cookies["Image_ID"].Value.ToString();
                string sConn = System.Configuration.ConfigurationManager.ConnectionStrings["AptUniConnectionString"].ToString();
                SqlConnection objConn = new SqlConnection(sConn);
                objConn.Open();
                string sTSQL = "SELECT Test_Image FROM [Diagrammatic_Test_Image] WHERE Test_ID = @Test_ID AND Image_ID = @Image_ID";
                SqlCommand objCmd = new SqlCommand(sTSQL, objConn);
                objCmd.CommandType = CommandType.Text;
                objCmd.Parameters.AddWithValue("@Test_ID", test_ID);
                objCmd.Parameters.AddWithValue("@Image_ID", image_ID);
                object data = objCmd.ExecuteScalar();
                objConn.Close();
                objCmd.Dispose();
                context.Response.BinaryWrite((byte[])data);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}