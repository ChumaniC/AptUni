using AptUni.logicLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AptUni.presentationLayer
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private string IsValidText(ITextControl textInput, int inputLenLimit, HiddenField hiddenField, string javaScriptFunction)
        {
            if (textInput.Text.Length <= inputLenLimit && textInput.Text.Length > 0)
            {
                hiddenField.Value = true.ToString();
            }
            else
            {
                hiddenField.Value = false.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", javaScriptFunction, true);
            }
            return hiddenField.Value;
        }

        private string IsValidNumeric(ITextControl textInput, int inputLenLimit, HiddenField hiddenField, string javaScriptFunction)
        {
            if (textInput.Text.Length <= inputLenLimit && textInput.Text.Length > 0 && Convert.ToInt32(textInput.Text) >= 0)
            {
                hiddenField.Value = true.ToString();
            }
            else
            {
                hiddenField.Value = false.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup_Err", javaScriptFunction, true);
            }
            return hiddenField.Value;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                // Establish database connection

                DatabaseConnection databaseConn = new DatabaseConnection();
                SqlConnection con = databaseConn.SQL_Connnection();

                // Create SQL queries

                string insertUserTableQuery = "INSERT INTO [User] ([Name] ,[Surname], [Email], [Password])" +
                                    "VALUES (@Name, @Surname, @Email, @Password)";

                string insertMatricResultTableQuery = "INSERT INTO [User_Matric_Results] ([User_ID] ,[Subject_1], [Subject_2], [Subject_3], [Subject_4], [Subject_5], [Subject_6], [Subject_7])" +
                                    "VALUES (@User_ID, @Subject_1, @Subject_2, @Subject_3, @Subject_4, @Subject_5, @Subject_6, @Subject_7)";

                string selectQuery = "SELECT User_ID FROM [User]";

                // Create SQL command

                var insertUserTableCMD = new SqlCommand(insertUserTableQuery, con);

                var insertMatricResultTableCMD = new SqlCommand(insertMatricResultTableQuery, con);

                var selectCMD = new SqlCommand(selectQuery, con);

                List<int> userIDs = new List<int>();

                // Determine the user ID for the new user

                using (var reader = selectCMD.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userIDs.Add(reader.GetInt32(0));
                        }
                    }
                }
                selectCMD.ExecuteNonQuery();

                //Create SQL parameters

                insertUserTableCMD.Parameters.AddWithValue("@Name", txtName.Text);
                insertUserTableCMD.Parameters.AddWithValue("@Surname", txtSurname.Text);
                insertUserTableCMD.Parameters.AddWithValue("@Email", txtEmail.Text);
                insertUserTableCMD.Parameters.AddWithValue("@Password", txtPassword.Text);

                insertMatricResultTableCMD.Parameters.AddWithValue("@User_ID", (userIDs.Count + 1));
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_1", txtSubject1.Text);
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_2", txtSubject2.Text);
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_3", txtSubject3.Text);
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_4", txtSubject4.Text);
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_5", txtSubject5.Text);
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_6", txtSubject6.Text);
                insertMatricResultTableCMD.Parameters.AddWithValue("@Subject_7", txtSubject7.Text);

                // Validation checks

                IsValidText(txtName, 25, hfName, "Name_Length();");
                IsValidText(txtSurname, 25, hfSurname, "Surname_Length();");
                IsValidText(txtEmail, 25, hfEmail, "Email_Length();");
                IsValidText(txtPassword, 25, hfPassword, "Password_Length();");

                IsValidNumeric(txtSubject1, 3, hfSub1, "Subject_Length();");
                IsValidNumeric(txtSubject2, 3, hfSub2, "Subject_Length();");
                IsValidNumeric(txtSubject3, 3, hfSub3, "Subject_Length();");
                IsValidNumeric(txtSubject4, 3, hfSub4, "Subject_Length();");
                IsValidNumeric(txtSubject5, 3, hfSub5, "Subject_Length();");
                IsValidNumeric(txtSubject6, 3, hfSub6, "Subject_Length();");
                IsValidNumeric(txtSubject7, 3, hfSub7, "Subject_Length();");

                if (hfName.Value == true.ToString() && hfSurname.Value == true.ToString() && hfEmail.Value == true.ToString() && hfPassword.Value == true.ToString() &&
                    hfSub1.Value == true.ToString() && hfSub2.Value == true.ToString() && hfSub3.Value == true.ToString() && hfSub4.Value == true.ToString() && hfSub5.Value == true.ToString() &&
                    hfSub6.Value == true.ToString() && hfSub7.Value == true.ToString())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup_info", "info_submitted();", true);
                    System.Threading.Thread.Sleep(3000);
                    insertUserTableCMD.ExecuteNonQuery();
                    insertMatricResultTableCMD.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../presentationLayer/LandingPage.aspx");
        }
    }
}