using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AptUni.logicLayer
{
    public class TheTest
    {
        private DatabaseConnection DatabaseConnection = new DatabaseConnection();

        // Auto-Properties

        public bool HasEntry { get; set; }

        public bool HasScore { get; set; }

        public bool ResultHasEntry { get; set; }

        public int Counter { get; set; }

        public string MyTimer { get; set; }

        public string AverageTestScore { get; set; }

        public int QuestionCounter { get; set; }

        public List<string> CorrectAnswers { get; set; }

        public List<string> UserAnswers { get; set; }

        public List<string> DatabaseEntries { get; set; }

        public Button BackButton { get; set; }

        public Button NextButton { get; set; }

        public Button SubmitButton { get; set; }

        public Button EndButton { get; set; }

        public HtmlForm TestForm { get; set; }

        public HiddenField ListCounter { get; set; }

        public HiddenField AverageScores { get; set; }

        public HtmlInputHidden TimerHiddenInput { get; set; }

        public HiddenField HasEntryHiddenField { get; set; }

        public HiddenField ResultHasEntryHiddenField { get; set; }

        public HiddenField CounterHiddenField { get; set; }

        public HiddenField TotalQuestionsHiddenField { get; set; }

        public HiddenField CurrentQuestionHiddenField { get; set; }

        public HiddenField SelectedRadioButtonHiddenField { get; set; }

        public HiddenField PagerCounterHiddenField { get; set; }

        public HiddenField PaginationTotalPagesHiddenField { get; set; }

        public HiddenField FinalMarkHiddenField { get; set; }

        public HiddenField AccuracyHiddenField { get; set; }

        public HiddenField TestScoreHiddenField { get; set; }

        public HiddenField NumberOfTests { get; set; }

        public HiddenField LastTestWritten { get; set; }

        public HiddenField TestStatus { get; set; }

        public HiddenField HasScoreHiddenField { get; set; }

        public Label QuestionTitleLabel { get; set; }

        public Label QuestionContentLabel { get; set; }

        public RadioButton OptionOneRadioButton { get; set; }

        public RadioButton OptionTwoRadioButton { get; set; }

        public RadioButton OptionThreeRadioButton { get; set; }

        public RadioButton OptionFourRadioButton { get; set; }

        public RadioButton OptionFiveRadioButton { get; set; }

        public Page Page { get; set; }

        // Class methods

        // Method to disable Back button if on question 1

        public bool IsQuestionOne()
        {
            if (Convert.ToInt32(CounterHiddenField.Value) == 1)
            {
                BackButton.Enabled = false;
            }
            else if (Convert.ToInt32(CounterHiddenField.Value) > 1)
            {
                BackButton.Enabled = true;
            }
            return true;
        }

        // Method to disable Next button if on last question

        public bool IsLastQuestion(int questionNumber)
        {
            if (questionNumber == Convert.ToInt32(TotalQuestionsHiddenField.Value))
            {
                NextButton.Enabled = false;
                EndButton.Visible = false;
                SubmitButton.Visible = true;
            }
            else if (questionNumber < Convert.ToInt32(TotalQuestionsHiddenField.Value) && QuestionTitleLabel.Text != "Question 4")
            {
                NextButton.Enabled = true;
                EndButton.Visible = true;
                SubmitButton.Visible = false;
            }
            return true;
        }

        // Method to retrieve list of question for a test
        public void RetrieveQuestion(string sqlQuestionTableName, string sqlQuestionAnswerTableName)
        {
            
            // Establish database connection
            var con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string selectQuestionQuery = "SELECT [Question_1], [Question_2], [Question_3], [Question_4] FROM " + sqlQuestionTableName + " WHERE Test_ID = @Test_ID"; //

            string selectAnsOptQuery = "SELECT [Ans_1], [Ans_2], [Ans_3], [Ans_4] FROM " + sqlQuestionAnswerTableName + " WHERE Test_ID = @Test_ID AND Question_ID = @Question_ID";//

            string selectAnsOptQuery_Diagrammatic = "SELECT [Ans_1], [Ans_2], [Ans_3], [Ans_4], [Ans_5] FROM " + sqlQuestionAnswerTableName + " WHERE Test_ID = @Test_ID AND Question_ID = @Question_ID";//

            // SQL Commands

            SqlCommand selectQuestionCMD = new SqlCommand(selectQuestionQuery, con);

            SqlCommand selectAnsOptCMD = new SqlCommand(selectAnsOptQuery, con);

            SqlCommand selectAnsOptCMD_Diagrammatic = new SqlCommand(selectAnsOptQuery_Diagrammatic, con);

            // SQL Parameters

            selectQuestionCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

            selectAnsOptCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

            selectAnsOptCMD.Parameters.AddWithValue("@Question_ID", Convert.ToInt32(CounterHiddenField.Value));

            selectAnsOptCMD_Diagrammatic.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

            selectAnsOptCMD_Diagrammatic.Parameters.AddWithValue("@Question_ID", Convert.ToInt32(CounterHiddenField.Value));

            // Retrieve question

            using (var reader = selectQuestionCMD.ExecuteReader())
            {
                int currentQIndex;

                currentQIndex = Convert.ToInt32(CounterHiddenField.Value);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        QuestionContentLabel.Text = reader.GetString(currentQIndex - 1);
                    }
                }
            }

            // Retrieve and populate possible answer options

            if (Page.Session["Test_Type"].ToString() == "Diagrammatic_Test_Questions")
            {
                using (var reader = selectAnsOptCMD_Diagrammatic.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OptionOneRadioButton.Text = reader.GetString(0);
                            OptionTwoRadioButton.Text = reader.GetString(1);
                            OptionThreeRadioButton.Text = reader.GetString(2);
                            OptionFourRadioButton.Text = reader.GetString(3);
                            OptionFiveRadioButton.Text = reader.GetString(4);
                        }
                    }
                }
                selectQuestionCMD.ExecuteNonQuery();
                selectAnsOptCMD_Diagrammatic.ExecuteNonQuery();
            }
            else
            {
                using (var reader = selectAnsOptCMD.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OptionOneRadioButton.Text = reader.GetString(0);
                            OptionTwoRadioButton.Text = reader.GetString(1);
                            OptionThreeRadioButton.Text = reader.GetString(2);
                            OptionFourRadioButton.Text = reader.GetString(3);
                        }
                    }
                }
                selectQuestionCMD.ExecuteNonQuery();
                selectAnsOptCMD.ExecuteNonQuery();
            }
            con.Close();
        }

        // Method to select and store the value of the checked/ selected radio button
        public void GetCheckedRadioButtonValue()
        {
            RadioButton selectedRadioButton = TestForm.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked && rb.GroupName == "answers");

            if (selectedRadioButton != null)
            {
                SelectedRadioButtonHiddenField.Value = selectedRadioButton.Text;
                foreach (RadioButton radioButton in TestForm.Controls.OfType<RadioButton>())
                {
                    radioButton.Checked = false;
                }
            }
            else
            {
                SelectedRadioButtonHiddenField.Value = "(empty)";
                foreach (RadioButton radioButton in TestForm.Controls.OfType<RadioButton>())
                {
                    radioButton.Checked = false;
                }
            }
        }

        // Method to update the user's answer
        public void UpdateAnswer(string sqlUserAnswerTable)
        {
            GetCheckedRadioButtonValue();

            // Establish database connection
            var con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string updateQuery = "UPDATE [" + sqlUserAnswerTable + "] Set Question_" + CounterHiddenField.Value + " = @Question_" + CounterHiddenField.Value + " WHERE User_ID = @User_ID";//

            // SQL Commands

            SqlCommand updateCMD = new SqlCommand(updateQuery, con);

            // SQL Parameters

            updateCMD.Parameters.AddWithValue("@Question_" + CounterHiddenField.Value, SelectedRadioButtonHiddenField.Value);

            updateCMD.Parameters.AddWithValue("@User_ID", Convert.ToInt32(Page.Session["User_ID"].ToString()));

            updateCMD.ExecuteNonQuery();
            con.Close();
        }

        // Method to match user's answers to the database answers
        public bool CheckEntry(string sqlUserAnswerTable, bool tableHasEntry, HiddenField entryHiddenField)
        {
            // Establish database connection
            var con = DatabaseConnection.SQL_Connnection();

            // SQL Query

            string selectQuery = "SELECT Test_ID, User_ID FROM " + sqlUserAnswerTable;

            // SQL Command

            SqlCommand selectCMD = new SqlCommand(selectQuery, con);

            // Check whether the SQL table containing the answers for all users for a specific category
            // of test contains an entry for the current user and current test written.
            // If there is no entry found, insert a new entry,
            // if there is an entry found, update the existing entry

            using (var reader = selectCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DatabaseEntries.Add(reader.GetString(0) + "_" + reader.GetInt32(1).ToString());
                    }
                }
            }

            foreach (var item in DatabaseEntries)
            {
                if (item == Page.Session["Test_ID"].ToString() + "_" + Page.Session["User_ID"])
                {
                    tableHasEntry = true;
                    entryHiddenField.Value = tableHasEntry.ToString();
                    break;
                }
            }
            return tableHasEntry;
        }

        // Method to insert the user's answer
        public void InsertAnswer(string sqlUserAnswerTable)
        {
            GetCheckedRadioButtonValue();

            // Establish database connection
            var con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string insertQueryUserAnswers = "INSERT INTO " + sqlUserAnswerTable + " (User_ID, Test_ID, Question_" + CounterHiddenField.Value + ") " +
                   "VALUES (@User_ID, @Test_ID, @Question_" + CounterHiddenField.Value + ")";

            // SQL Commands

            SqlCommand insertCMD = new SqlCommand(insertQueryUserAnswers, con);

            // SQL Parameters

            insertCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());
            insertCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());
            insertCMD.Parameters.AddWithValue("@Question_" + CounterHiddenField.Value, SelectedRadioButtonHiddenField.Value);

            insertCMD.ExecuteNonQuery();
            con.Close();
        }

        // Method to store user's answers in a list 
        public void PopulateAnswerList(string sqlCorrectTestAnswerTable, string sqlUserAnswerTable)
        {
            // Establish database connection
            var con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string selectCorrectAnswerQuery = "SELECT Question_1, Question_2, Question_3, Question_4 FROM " + sqlCorrectTestAnswerTable + " WHERE Test_ID = @Test_ID";

            string selectUserAnswerQuery = "SELECT Question_1, Question_2, Question_3, Question_4 FROM " + sqlUserAnswerTable + " WHERE Test_ID = @Test_ID AND User_ID = @User_ID";//

            // SQL Commands

            SqlCommand correctAnsCMD = new SqlCommand(selectCorrectAnswerQuery, con);
            SqlCommand userAnsCMD = new SqlCommand(selectUserAnswerQuery, con);

            // SQL Parameters

            correctAnsCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());
            userAnsCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());
            userAnsCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

            // Correct Answers Reader

            using (var reader = correctAnsCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CorrectAnswers.Add(reader.GetString(0));
                        CorrectAnswers.Add(reader.GetString(1));
                        CorrectAnswers.Add(reader.GetString(2));
                        CorrectAnswers.Add(reader.GetString(3));
                    }
                }
            }
            correctAnsCMD.ExecuteNonQuery();
            // User Answers Reader

            using (var reader = userAnsCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserAnswers.Add(reader.GetString(0));
                        UserAnswers.Add(reader.GetString(1));
                        UserAnswers.Add(reader.GetString(2));
                        UserAnswers.Add(reader.GetString(3));
                    }
                }
            }
            userAnsCMD.ExecuteNonQuery();
            con.Close();

            // Compare user's answers to the correct answers

            int correctAnsIndex = 0;
            int userMark;

            FinalMarkHiddenField.Value = "0";
            foreach (var item in UserAnswers)
            {
                if (CorrectAnswers.Contains(item))
                {
                    userMark = Convert.ToInt32(FinalMarkHiddenField.Value);
                    userMark++;
                    FinalMarkHiddenField.Value = userMark.ToString();
                }
                correctAnsIndex++;
            }
        }

        // Method to calculate the average of all users for a specific test
        public void UsersTestAverages()
        {
            List<int> testScores = new List<int>();

            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string selectTestScoreQuery = "SELECT [Test_Score] FROM " + Page.Session["Test_Result_Type"].ToString() + " WHERE Test_ID = @Test_ID";

            // SQL Commands

            SqlCommand selectTestScoreCMD = new SqlCommand(selectTestScoreQuery, con);

            // SQL Parameters

            selectTestScoreCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

            using (var reader = selectTestScoreCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    HasScore = true;
                    HasScoreHiddenField.Value = HasScore.ToString();
                    while (reader.Read())
                    {
                        int scoreLen = reader.GetString(0).Length;
                        testScores.Add(Convert.ToInt32(reader.GetString(0).Remove(scoreLen - 1)));
                    }
                }
                else
                {
                    HasScore = false;
                    HasScoreHiddenField.Value = HasScore.ToString();
                }
            }
            ListCounter.Value = testScores.Count.ToString();

            selectTestScoreCMD.ExecuteNonQuery();
            con.Close();

            int myScore = 0;
            foreach (var score in testScores)
            {
                myScore += score;
            }

            // Determine the user's average score

            if (testScores.Count > 0)
            {
                int average = myScore / testScores.Count;
                AverageTestScore = average.ToString() + "%";
            }
            else
            {
                AverageTestScore = "0%";
            }

            AverageScores.Value = AverageTestScore;
        }

        // Method to save the user's test score
        public void SaveTestScore(string sqlUserAnswerTable, string sqlTestResultTable)
        {
            UsersTestAverages();    
            // Local variables

            DateTime currentDateTime = DateTime.Now;

            AccuracyHiddenField.Value = FinalMarkHiddenField.Value + "/" + TotalQuestionsHiddenField.Value;

            double a = Convert.ToInt32(FinalMarkHiddenField.Value);
            double b = Convert.ToInt32(TotalQuestionsHiddenField.Value);
            double score = Math.Floor((a / b) * 100);

            // Set MyTimer

            this.MyTimer = Page.Request.Form[MyTimer];

            MyTimer = TimerHiddenInput.Value;

            // Establish database connection
            var con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string insertQuery = "INSERT INTO " + sqlUserAnswerTable + " (User_ID, Test_ID, Time_Taken, Test_Date, Test_Score) " +
                                "VALUES (@User_ID, @Test_ID, @Time_Taken, @Test_Date, @Test_Score)";

            string insertQueryTestResult = "INSERT INTO " + sqlTestResultTable + " (User_ID, Test_ID, Test_Accuracy, Time_Taken, Test_Date, Test_Score, Test_Type, Test_Status) " +
                                "VALUES (@User_ID, @Test_ID, @Test_Accuracy, @Time_Taken, @Test_Date, @Test_Score, @Test_Type, @Test_Status)";

            string insertAverage = "INSERT INTO " + Page.Session["Test_Result_Type"].ToString() + " (Test_Average) " +
                   "VALUES (@Test_Average)";

            string updateQuery = "UPDATE [" + sqlUserAnswerTable + "] Set Time_Taken = @Time_Taken , Test_Date = @Test_Date, Test_Score = @Test_Score" +
                                "  WHERE User_ID = @User_ID AND Test_ID = @Test_ID";

            string updateQueryTestResult = "UPDATE [" + sqlTestResultTable + "] Set Test_Accuracy = @Test_Accuracy , Time_Taken = @Time_Taken, Test_Date = @Test_Date, Test_Score = @Test_Score,Test_Type = @Test_Type, Test_Status = @Test_Status" +//
                                "  WHERE User_ID = @User_ID AND Test_ID = @Test_ID";

            string updateAverageQuery = "UPDATE [" + Page.Session["Test_Result_Type"].ToString() + "] Set Test_Average = @Test_Average" +
                                "  WHERE Test_ID = @Test_ID";

            // SQL Commands

            SqlCommand insertCMD = new SqlCommand(insertQuery, con);

            SqlCommand insertCMD_TestR = new SqlCommand(insertQueryTestResult, con);

            SqlCommand insertCMD_Average = new SqlCommand(insertAverage, con);

            SqlCommand updateCMD = new SqlCommand(updateQuery, con);

            SqlCommand updateCMD_TestR = new SqlCommand(updateQueryTestResult, con);

            SqlCommand updateCMD_Average = new SqlCommand(updateAverageQuery, con);

            if (HasEntryHiddenField.Value != true.ToString())
            {
                // Insert data into database

                // SQL Parameters
                insertCMD.Parameters.AddWithValue("@Time_Taken", MyTimer);

                insertCMD.Parameters.AddWithValue("@Test_Date", currentDateTime.ToString());

                insertCMD.Parameters.AddWithValue("@Test_Score", score.ToString() + "%");

                insertCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

                
                insertCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString()); 


                // Execute Commands
                insertCMD.ExecuteNonQuery();
            }
            else
            {
                // update database

                // SQL Parameters
                updateCMD.Parameters.AddWithValue("@Time_Taken", MyTimer);

                updateCMD.Parameters.AddWithValue("@Test_Date", currentDateTime.ToString());

                updateCMD.Parameters.AddWithValue("@Test_Score", score.ToString() + "%");

                updateCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

                updateCMD.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

                // Execute Commands
                updateCMD.ExecuteNonQuery();
            }

            CheckEntry(Page.Session["Test_Result_Type"].ToString(), ResultHasEntry, ResultHasEntryHiddenField);

            if (ResultHasEntryHiddenField.Value != true.ToString())
            {
                insertCMD_TestR.Parameters.AddWithValue("@Test_Accuracy", AccuracyHiddenField.Value);

                insertCMD_TestR.Parameters.AddWithValue("@Time_Taken", MyTimer);

                insertCMD_TestR.Parameters.AddWithValue("@Test_Date", currentDateTime.ToString());

                insertCMD_TestR.Parameters.AddWithValue("@Test_Score", score.ToString() + "%");

                insertCMD_TestR.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

                insertCMD_TestR.Parameters.AddWithValue("@Test_Type", Page.Session["Test_Name"].ToString());

                insertCMD_TestR.Parameters.AddWithValue("@Test_Status", "Written");

                insertCMD_TestR.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString()); 

                // Execute Commands
                insertCMD_TestR.ExecuteNonQuery();
            }
            else
            {
                updateCMD_TestR.Parameters.AddWithValue("@Test_Accuracy", AccuracyHiddenField.Value);

                updateCMD_TestR.Parameters.AddWithValue("@Time_Taken", MyTimer);

                updateCMD_TestR.Parameters.AddWithValue("@Test_Date", currentDateTime.ToString());

                updateCMD_TestR.Parameters.AddWithValue("@Test_Score", score.ToString() + "%");

                updateCMD_TestR.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

                updateCMD_TestR.Parameters.AddWithValue("@Test_Status", "Written");

                updateCMD_TestR.Parameters.AddWithValue("@Test_Type", Page.Session["Test_Name"].ToString());

                updateCMD_TestR.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

                // Execute Commands
                updateCMD_TestR.ExecuteNonQuery();
            }

            if (HasEntryHiddenField.Value != true.ToString())
            {
                // Insert data into database

                // SQL Parameters
                insertCMD_Average.Parameters.AddWithValue("@Test_Average", AverageScores.Value);

                // Execute Commands
                insertCMD_Average.ExecuteNonQuery();
            }
            else
            {
                // update database

                // SQL Parameters
                updateCMD_Average.Parameters.AddWithValue("@Test_Average", AverageScores.Value);
                updateCMD_Average.Parameters.AddWithValue("@Test_ID", Page.Session["Test_ID"].ToString());

                // Execute Commands
                updateCMD_Average.ExecuteNonQuery();
            }
            con.Close();

            Page.Response.Redirect("../presentationLayer/TestSelection.aspx");
        }

        // Method to determine the number of tests

        public void TotalTests(string sqlQuestionsTableName)
        {
            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            string selectCountQuery = "SELECT COUNT (Test_ID) FROM " + sqlQuestionsTableName;

            // SQL Command

            var cmd_count = new SqlCommand(selectCountQuery, con);

            int count = (int)cmd_count.ExecuteScalar();

             NumberOfTests.Value = count.ToString();
        }

        // Method to select and return a list of tests written by a specific user 

        public void RetrieveWrittenTests(string sqlResultsTableName)
        {
            List<string> writtenTestsList = new List<string>();
            List<string> testStatusList = new List<string>();

            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();

            // SQL Query

            string selectTestQuery = "SELECT [Test_ID], [Test_Status] FROM " + sqlResultsTableName + " WHERE User_ID = @User_ID";

            // SQL Command

            SqlCommand selectCMD = new SqlCommand(selectTestQuery, con);

            selectCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());

            using (var reader = selectCMD.ExecuteReader())
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        writtenTestsList.Add(reader.GetString(0));
                        testStatusList.Add(reader.GetString(1));
                    }
                }
                else
                {
                    writtenTestsList.Add("Test 0");
                    testStatusList.Add("Not Written");
                }
            }

            selectCMD.ExecuteNonQuery();
            con.Close();
            // Get the last test written

            int lastTestIndex = writtenTestsList.Count - 1;
            int lastTest = Convert.ToInt32(writtenTestsList[lastTestIndex].Substring(5));

            LastTestWritten.Value = lastTest.ToString();

            int lastStatusIndex = testStatusList.Count - 1;
            TestStatus.Value = testStatusList[lastStatusIndex];
        }

        // Method to display the next available test for a user

        public void DisplayAvailableTest(string sqlResultsTableName)
        {

            // Establish database connection

            SqlConnection con = DatabaseConnection.SQL_Connnection();

            // SQL Queries

            
            string insertUserDetailsQuery = "INSERT INTO " + sqlResultsTableName + " (User_ID, Test_ID, Test_Average, Test_Score, Test_Date, Test_Type, Test_Status) " +
                   "VALUES (@User_ID, @Test_ID, @Test_Average, @Test_Score, @Test_Date, @Test_Type, @Test_Status)";

            // SQL Commands


            SqlCommand insertCMD = new SqlCommand(insertUserDetailsQuery, con);

            // SQL Parameters

            insertCMD.Parameters.AddWithValue("@Test_ID", "Test "+ (Convert.ToInt32(LastTestWritten.Value) + 1).ToString());
            insertCMD.Parameters.AddWithValue("@User_ID", Page.Session["User_ID"].ToString());
            insertCMD.Parameters.AddWithValue("@Test_Average", "-");
            insertCMD.Parameters.AddWithValue("@Test_Score", "0%");
            insertCMD.Parameters.AddWithValue("@Test_Date", "-");
            insertCMD.Parameters.AddWithValue("@Test_Type", "-");
            insertCMD.Parameters.AddWithValue("@Test_Status", "Not Written");

            insertCMD.ExecuteNonQuery();
            con.Close();
        }
    }
}