using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace AptUni.logicLayer
{
    public class Login
    {
        DatabaseConnection DatabaseConnection = new DatabaseConnection();
        public List<int> UserScoreList { get; set; }
        public SqlCommand Select_Command { get; set; }

        public Page Page { get; set; }

        public TextBox LoginID { get; set; }

        public TextBox LoginPassword { get; set; }

        public bool HasTestScore { get; set; }

        public int ColumnIndex { get; set; }

        public int UserNameIndex { get; set; }

        public int UserSurnameIndex { get; set; }
        public string BestTestScore { get; set; }


        public string WebPageURL { get; set; }

        public void User_Login()
        {
            using (var reader_Login = Select_Command.ExecuteReader())
            {
                if (reader_Login.HasRows)
                {
                    while (reader_Login.Read())
                    {
                        if (LoginPassword.Text == reader_Login.GetString(ColumnIndex))
                        {
                            FormsAuthentication.RedirectFromLoginPage(LoginID.Text, false);
                            // Create session object to store active user details
                            Page.Session["Active_User"] = reader_Login.GetString(UserNameIndex).ToString() + "  " + reader_Login.GetString(UserSurnameIndex).ToString();
                            // Create session object to store user login ID
                            Page.Session["User_ID"] = reader_Login.GetInt32(0).ToString();
                            // Create cookie object to store user login ID
                            HttpCookie User_ID_cookie = new HttpCookie("User_ID");
                            User_ID_cookie.Value = Page.Session["User_ID"].ToString();
                            Page.Response.Cookies.Add(User_ID_cookie);
                            CheckScores();

                            reader_Login.Close();
                            Page.Response.Redirect(WebPageURL);
                            break;
                        }
                    }
                }
            }
        }

        public bool CheckScores()
        {
            UserScoreList = new List<int>();
            HasTestScore = true;
            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();


            // SQL Queries


            // Test Scores

            string selectNumericScoreQuery = "SELECT [Test_Score] FROM [Numerical_Test_Result] WHERE User_ID = @User_ID";

            string selectDiagrammaticScoreQuery = "SELECT [Test_Score] FROM [Diagrammatic_Test_Result] WHERE User_ID = @User_ID";

            string selectSituationalScoreQuery = "SELECT [Test_Score] FROM [Situational_Test_Result] WHERE User_ID = @User_ID";

            string selectVerbalScoreQuery = "SELECT [Test_Score] FROM [Verbal_Test_Result] WHERE User_ID = @User_ID";

            // SQL Commands

            // Test Scores

            SqlCommand selectNumericScoreCMD = new SqlCommand(selectNumericScoreQuery, con);

            SqlCommand selectDiagrammaticScoreCMD = new SqlCommand(selectDiagrammaticScoreQuery, con);

            SqlCommand selectSituationalScoreCMD = new SqlCommand(selectSituationalScoreQuery, con);

            SqlCommand selectVerbalScoreCMD = new SqlCommand(selectVerbalScoreQuery, con);

            // SQL Parameters

            // Test Scores

            selectNumericScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString()); //

            selectDiagrammaticScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            selectSituationalScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            selectVerbalScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            // Determine the best score from the list of test scores for a user

            using (var reader = selectNumericScoreCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int scoreLen = reader.GetString(0).Length;
                        int score = Convert.ToInt32(reader.GetString(0).Remove(scoreLen - 1));
                        UserScoreList.Add(score);
                    }
                }
                else
                {
                    HasTestScore = false;
                    Page.Session["HasTestScore"] = HasTestScore.ToString();
                }
            }

            using (var reader = selectDiagrammaticScoreCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int scoreLen = reader.GetString(0).Length;
                        int score = Convert.ToInt32(reader.GetString(0).Remove(scoreLen - 1));
                        UserScoreList.Add(score);
                    }
                }
                else
                {
                    HasTestScore = false;
                    Page.Session["HasTestScore"] = HasTestScore.ToString();
                }
            }

            using (var reader = selectSituationalScoreCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int scoreLen = reader.GetString(0).Length;
                        int score = Convert.ToInt32(reader.GetString(0).Remove(scoreLen - 1));
                        UserScoreList.Add(score);
                    }
                }
                else
                {
                    HasTestScore = false;
                    Page.Session["HasTestScore"] = HasTestScore.ToString();
                }
            }

            using (var reader = selectVerbalScoreCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int scoreLen = reader.GetString(0).Length;
                        int score = Convert.ToInt32(reader.GetString(0).Remove(scoreLen - 1));
                        UserScoreList.Add(score);
                    }
                }
                else
                {
                    HasTestScore = false;
                    Page.Session["HasTestScore"] = HasTestScore.ToString();
                }
            }
            selectNumericScoreCMD.ExecuteNonQuery();
            selectDiagrammaticScoreCMD.ExecuteNonQuery();
            selectSituationalScoreCMD.ExecuteNonQuery();
            selectVerbalScoreCMD.ExecuteNonQuery();

            con.Close();

            if (UserScoreList.Count == 0)
            {
                HasTestScore = false;
                Page.Session["HasTestScore"] = HasTestScore.ToString();
            }
            else
            {
                HasTestScore = true;
                Page.Session["HasTestScore"] = HasTestScore.ToString();
            }

            return HasTestScore;
        }


        public void Active_User(string adminID, Label userNameLabel, string sqlTableName, string sqlCondition)
        {
            DatabaseConnection databaseConn = new DatabaseConnection();

            SqlConnection conn = databaseConn.SQL_Connnection();

            // Create SQL query

            string selectQuery = "SELECT [Name], [Surname] FROM [" + sqlTableName + "] WHERE " + sqlCondition + " = @" + sqlCondition + "";

            // Create SQL Command

            SqlCommand select_Command = new SqlCommand(selectQuery, conn);

            // Create SQL Parameters

            select_Command.Parameters.AddWithValue("@" + sqlCondition, adminID);

            using (var reader = select_Command.ExecuteReader())
            {
                // Check whether table has data

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userNameLabel.Text = reader.GetString(0) + " " + reader.GetString(1);
                    }
                }
            }

            conn.Close();
        }
    }
}