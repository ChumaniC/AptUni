using AptUni.logicLayer;
using System;
using System.Data.SqlClient;

namespace AptUni.presentationLayer
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish database connection

                DatabaseConnection databaseConn = new DatabaseConnection();
                SqlConnection con = databaseConn.SQL_Connnection();

                logicLayer.Login login = new logicLayer.Login();
                login.Page = Page;
                login.LoginID = txtIDLogin;
                login.LoginPassword = txtPasswordLogin;

                // Create SQL query

                string selectQuery_Login = "SELECT * FROM [User] WHERE Email = @Email AND Password = @Password";

                // Create SQL command

                var select_Command = new SqlCommand(selectQuery_Login, con);

                // Initialize properties

                login.ColumnIndex = 4;
                login.UserNameIndex = 1;
                login.UserSurnameIndex = 2;

                if (Session["Current_Page"] != null)
                {
                    login.WebPageURL = Session["Current_Page"].ToString();
                }
                else
                {
                    login.WebPageURL = "../presentationLayer/LandingPage.aspx";
                }

                //Create SQL parameters

                login.Select_Command = select_Command;
                login.Select_Command.Parameters.AddWithValue("@Email", login.LoginID.Text);
                login.Select_Command.Parameters.AddWithValue("@Password", login.LoginPassword.Text);

                login.User_Login();
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}