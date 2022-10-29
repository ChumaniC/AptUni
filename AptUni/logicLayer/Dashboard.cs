using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AptUni.logicLayer
{
    public class Dashboard
    {
        private DatabaseConnection DatabaseConnection = new DatabaseConnection();

        public bool HasTestScore { get; set; }

        public List<int> BestTestScoreList { get; set; }

        public List<string> BestTestScoreNamesList { get; set; }

        public string APS_Score { get; set; }

        public string BestTestScore { get; set; }

        public string BestTestName { get; set; }

        public string AverageTestScore { get; set; }

        public string LatestTestScore { get; set; }

        public string LatestTestName { get; set; }

        public string BestUniversityChoice { get; set; }

        public string UniversityChoiceWebsiteURL { get; set; }

        public string UndergraduateChoice { get; set; }

        public string UndergraduateChoiceReadMoreURL { get; set; }

        public string CareerChoice { get; set; }

        public string CareerChoiceReadMoreURL { get; set; }

        public HiddenField CurrentAPS_Score { get; set; }

        public Page Page { get; set; }

        // Method to determine the best test score

        public void UserBestTestScore()
        {
            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            // Test Scores

            string selectNumericScoreQuery = "SELECT [Test_Score] FROM [Numerical_Test_Result] WHERE User_ID = @User_ID";

            string selectDiagrammaticScoreQuery = "SELECT [Test_Score] FROM [Diagrammatic_Test_Result] WHERE User_ID = @User_ID";

            string selectSituationalScoreQuery = "SELECT [Test_Score] FROM [Situational_Test_Result] WHERE User_ID = @User_ID";

            string selectVerbalScoreQuery = "SELECT [Test_Score] FROM [Verbal_Test_Result] WHERE User_ID = @User_ID";

            // Test Names

            string selectNumericNameQuery = "SELECT [Test_ID] FROM [Numerical_Test_Result] WHERE User_ID = @User_ID";

            string selectDiagrammaticNameQuery = "SELECT [Test_ID] FROM [Diagrammatic_Test_Result] WHERE User_ID = @User_ID";

            string selectSituationalNameQuery = "SELECT [Test_ID] FROM [Situational_Test_Result] WHERE User_ID = @User_ID";

            string selectVerbalNameQuery = "SELECT [Test_ID] FROM [Verbal_Test_Result] WHERE User_ID = @User_ID";

            // SQL Commands

            // Test Scores

            SqlCommand selectNumericScoreCMD = new SqlCommand(selectNumericScoreQuery, con);

            SqlCommand selectDiagrammaticScoreCMD = new SqlCommand(selectDiagrammaticScoreQuery, con);

            SqlCommand selectSituationalScoreCMD = new SqlCommand(selectSituationalScoreQuery, con);

            SqlCommand selectVerbalScoreCMD = new SqlCommand(selectVerbalScoreQuery, con);

            // Test Names

            SqlCommand selectNumericNameCMD = new SqlCommand(selectNumericNameQuery, con);

            SqlCommand selectDiagrammaticNameCMD = new SqlCommand(selectDiagrammaticNameQuery, con);

            SqlCommand selectSituationalNameCMD = new SqlCommand(selectSituationalNameQuery, con);

            SqlCommand selectVerbalNameCMD = new SqlCommand(selectVerbalNameQuery, con);

            // SQL Parameters

            // Test Scores

            selectNumericScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString()); //

            selectDiagrammaticScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            selectSituationalScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            selectVerbalScoreCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            // Test Names

            selectNumericNameCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString()); //Page.Session["Test_ID"].ToString()

            selectDiagrammaticNameCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            selectSituationalNameCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            selectVerbalNameCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            // Determine the best score from the list of test scores for a user

            using (var reader = selectNumericScoreCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int scoreLen = reader.GetString(0).Length;
                        int score = Convert.ToInt32(reader.GetString(0).Remove(scoreLen - 1));
                        BestTestScoreList.Add(score);
                    }
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
                        BestTestScoreList.Add(score);
                    }
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
                        BestTestScoreList.Add(score);
                    }
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
                        BestTestScoreList.Add(score);
                    }
                }
            }
            selectNumericScoreCMD.ExecuteNonQuery();
            selectDiagrammaticScoreCMD.ExecuteNonQuery();
            selectSituationalScoreCMD.ExecuteNonQuery();
            selectVerbalScoreCMD.ExecuteNonQuery();

            // Determine best score test name

            using (var reader = selectNumericNameCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BestTestScoreNamesList.Add("Numerical Reasoning " + reader.GetString(0));
                    }
                }
            }

            using (var reader = selectDiagrammaticNameCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BestTestScoreNamesList.Add("Diagrammatic Reasoning " + reader.GetString(0));
                    }
                }
            }

            using (var reader = selectSituationalNameCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BestTestScoreNamesList.Add("Situational Reasoning " + reader.GetString(0));
                    }
                }
            }

            using (var reader = selectVerbalNameCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BestTestScoreNamesList.Add("Verbal Reasoning " + reader.GetString(0));
                    }
                }
            }
            selectNumericNameCMD.ExecuteNonQuery();
            selectDiagrammaticNameCMD.ExecuteNonQuery();
            selectSituationalNameCMD.ExecuteNonQuery();
            selectVerbalNameCMD.ExecuteNonQuery();
            con.Close();

            // From the BestScoreList extract the highest integer value

            BestTestScore = BestTestScoreList.Max().ToString() + "%";

            int bestScoreIndex = BestTestScoreList.IndexOf(BestTestScoreList.Max());

            // From the  BestTestScoreNamesList extract the name of the test corresponding to the best score

            BestTestName = BestTestScoreNamesList[bestScoreIndex];

            int myScore = 0;
            foreach (var score in BestTestScoreList)
            {
                myScore += score;
            }

            // Determine the user's average score

            int average = myScore / BestTestScoreList.Count;
            AverageTestScore = average.ToString() + "%";
        }

        // Method to determine user's best university choice
        public void UserUniverstiyChoice()
        {
            // Calculate user's APS based on matric results

            List<int> userMarks = new List<int>();

            List<int> universityAPS = new List<int>();

            List<string> universityName = new List<string>();

            List<string> universityUrl = new List<string>();

            List<string> careerChoice = new List<string>();

            List<string> undergradURL = new List<string>();

            List<string> careerURL = new List<string>();

            List<string> universityUndergrad_Choice = new List<string>();

            List<int> userAPS = new List<int>();

            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string selectMatricResult = "SELECT [Subject_1], [Subject_2], [Subject_3], [Subject_5], [Subject_6], [Subject_7] FROM [User_Matric_Results] WHERE User_ID = @User_ID";

            string selectAPS = "SELECT [APS] FROM [University]";

            string selectUniversity = "SELECT [Uni_Name] FROM [University]";

            string selectUrl = "SELECT [Uni_URL] FROM [University]";

            string selectUndergrad_Choice = "SELECT [Undergrad_Choice] FROM [University]";

            string selectCareer = "SELECT [Career_Option] FROM [University]";

            string selectUndergradURL = "SELECT [Undergrad_URL] FROM [University]";

            string selectCareerURL = "SELECT [Career_URL] FROM [University]";

            // SQL Command

            SqlCommand selectMatricResultCMD = new SqlCommand(selectMatricResult, con);

            SqlCommand selectAPSCMD = new SqlCommand(selectAPS, con);

            SqlCommand selectUniCMD = new SqlCommand(selectUniversity, con);

            SqlCommand selectUrlCMD = new SqlCommand(selectUrl, con);

            SqlCommand selectUndergrad_ChoiceCMD = new SqlCommand(selectUndergrad_Choice, con);

            SqlCommand selectCareerCMD = new SqlCommand(selectCareer, con);

            SqlCommand selectUndergradURLCMD = new SqlCommand(selectUndergradURL, con);

            SqlCommand selectCareerURLCMD = new SqlCommand(selectCareerURL, con);

            // SQL Parameters

            selectMatricResultCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            // User marks

            using (var reader = selectMatricResultCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userMarks.Add(reader.GetInt32(0));
                        userMarks.Add(reader.GetInt32(1));
                        userMarks.Add(reader.GetInt32(2));
                        userMarks.Add(reader.GetInt32(3));
                        userMarks.Add(reader.GetInt32(4));
                        userMarks.Add(reader.GetInt32(5));
                    }
                }
            }

            // University APS

            using (var reader = selectAPSCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        universityAPS.Add(reader.GetInt32(0));
                    }
                }
            }

            //  University name

            using (var reader = selectUniCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        universityName.Add(reader.GetString(0));
                    }
                }
            }

            // Undergrad_Choice
            using (var reader = selectUndergrad_ChoiceCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        universityUndergrad_Choice.Add(reader.GetString(0));
                    }
                }
            }

            // University Url

            using (var reader = selectUrlCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        universityUrl.Add(reader.GetString(0));
                    }
                }
            }

            // Career

            using (var reader = selectCareerCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        careerChoice.Add(reader.GetString(0));
                    }
                }
            }

            // Undergrad url

            using (var reader = selectUndergradURLCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        undergradURL.Add(reader.GetString(0));
                    }
                }
            }

            // Career url

            using (var reader = selectCareerURLCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        careerURL.Add(reader.GetString(0));
                    }
                }
            }
            selectMatricResultCMD.ExecuteNonQuery();
            selectUniCMD.ExecuteNonQuery();
            selectAPSCMD.ExecuteNonQuery();
            selectUndergrad_ChoiceCMD.ExecuteNonQuery();
            selectUrlCMD.ExecuteNonQuery();
            selectCareerCMD.ExecuteNonQuery();
            selectUndergradURLCMD.ExecuteNonQuery();
            selectCareerURLCMD.ExecuteNonQuery();
            con.Close();

            foreach (var mark in userMarks)
            {
                if (mark >= 80 && mark <= 100)
                {
                    userAPS.Add(7);
                }
                else if (mark >= 70 && mark <= 79)
                {
                    userAPS.Add(6);
                }
                else if (mark >= 60 && mark <= 69)
                {
                    userAPS.Add(5);
                }
                else if (mark >= 50 && mark <= 59)
                {
                    userAPS.Add(4);
                }
                else if (mark >= 40 && mark <= 49)
                {
                    userAPS.Add(3);
                }
                else if (mark >= 30 && mark <= 39)
                {
                    userAPS.Add(2);
                }
                else if (mark >= 0 && mark <= 29)
                {
                    userAPS.Add(1);
                }
            }

            int _apsScore = 0;
            foreach (var apsScore in userAPS)
            {
                _apsScore += apsScore;
            }
            APS_Score = _apsScore.ToString();

            // Determine university choice by comparing the user's APS Score
            // with the APS scores of all universities

            int universityScoreAPS_Index = 0;

            int currentAPS = 0;

            List<int> apsScoreDifference = new List<int>();

            List<int> positiveAPS = new List<int>();

            CurrentAPS_Score.Value = currentAPS.ToString();

            foreach (var uniAPSScore in universityAPS)
            {
                currentAPS = Convert.ToInt32(APS_Score) - uniAPSScore;
                apsScoreDifference.Add(currentAPS);
            }

            foreach (var diff in apsScoreDifference)
            {
                if (diff >= 0)
                {
                    positiveAPS.Add(diff);
                }
            }

            int smallestDifference = positiveAPS.Min();

            universityScoreAPS_Index = apsScoreDifference.IndexOf(smallestDifference);
            BestUniversityChoice = universityName[universityScoreAPS_Index];
            UniversityChoiceWebsiteURL = universityUrl[universityScoreAPS_Index];
            UndergraduateChoice = universityUndergrad_Choice[universityScoreAPS_Index];
            UndergraduateChoiceReadMoreURL = undergradURL[universityScoreAPS_Index]; ;
            CareerChoice = careerChoice[universityScoreAPS_Index];
            CareerChoiceReadMoreURL = careerURL[universityScoreAPS_Index];
        }
    }
}
