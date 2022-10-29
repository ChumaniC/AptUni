using AptUni.logicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AptUni.presentationLayer
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private DatabaseConnection DatabaseConnection = new DatabaseConnection();
        private logicLayer.Dashboard myDashboard = new logicLayer.Dashboard();

        protected string welcome = "";

        protected string bestTestScore = "";

        protected string bestTestScoreName = "";

        protected string averageTestScore = "";

        protected string numberOfTest = "";

        protected string universityChoice = "";

        protected string undergraduateChoice = "";

        protected string careerChoice = "";

        protected string universityURL = "";

        protected string undergraduateURL = "";

        protected string careerURL = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            welcome = "Welcome to your dashboard, " + Session["Active_User"].ToString();
            // Initialize auto-properties

            myDashboard.BestTestScore = "";

            myDashboard.BestTestName = "";

            myDashboard.AverageTestScore = "";

            myDashboard.APS_Score = "";

            myDashboard.BestUniversityChoice = "";

            myDashboard.UndergraduateChoice = "";

            myDashboard.CareerChoice = "";

            myDashboard.UniversityChoiceWebsiteURL = "";

            myDashboard.CareerChoiceReadMoreURL = "";

            myDashboard.UndergraduateChoiceReadMoreURL = "";

            myDashboard.BestTestScoreList = new List<int>();

            myDashboard.BestTestScoreNamesList = new List<string>();

            myDashboard.Page = Page;

            myDashboard.CurrentAPS_Score = hfCurrent;

            try
            {
                myDashboard.UserBestTestScore();
                bestTestScore = myDashboard.BestTestScore;
                bestTestScoreName = myDashboard.BestTestName;
                averageTestScore = myDashboard.AverageTestScore;
                numberOfTest = myDashboard.BestTestScoreList.Count.ToString() + " test(s) have been written so far.";
                myDashboard.UserUniverstiyChoice();
                universityChoice = myDashboard.BestUniversityChoice;
                universityURL = myDashboard.UniversityChoiceWebsiteURL;
                undergraduateChoice = myDashboard.UndergraduateChoice;
                undergraduateURL = myDashboard.UndergraduateChoiceReadMoreURL;
                careerChoice = myDashboard.CareerChoice;
                careerURL = myDashboard.CareerChoiceReadMoreURL;

                string selectUnionQuery = "SELECT Test_ID, Test_Type, Test_Average, Test_Score, Test_Accuracy, Time_Taken, Test_Date FROM Diagrammatic_Test_Result WHERE User_ID = " + Convert.ToInt32(Session["User_ID"].ToString()) + " UNION " +
                                           "SELECT Test_ID, Test_Type, Test_Average, Test_Score, Test_Accuracy, Time_Taken, Test_Date FROM Numerical_Test_Result WHERE User_ID = " + Convert.ToInt32(Session["User_ID"].ToString()) + " UNION " +
                                          "SELECT Test_ID, Test_Type, Test_Average, Test_Score, Test_Accuracy, Time_Taken, Test_Date FROM Situational_Test_Result WHERE User_ID = " + Convert.ToInt32(Session["User_ID"].ToString()) + " UNION " +
                                          "SELECT Test_ID, Test_Type, Test_Average, Test_Score, Test_Accuracy, Time_Taken, Test_Date FROM Verbal_Test_Result WHERE User_ID = " + Convert.ToInt32(Session["User_ID"].ToString());

                if (!this.IsPostBack)
                {
                    SqlConnection conn = DatabaseConnection.SQL_Connnection();
                    using (SqlDataAdapter sda = new SqlDataAdapter(selectUnionQuery, conn))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvTests.DataSource = dt;
                        gvTests.DataBind();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}