using AptUni.logicLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace AptUni.presentationLayer
{
    public partial class Test : System.Web.UI.Page
    {
        // Line chart data values

        public int _lineA_2018 = 20, _lineA_2019 = 25, _lineA_2020 = 30, _lineA_2021 = 15, _lineA_2022 = 10;

        public int _lineB_2018 = 40, _lineB_2019 = 50, _lineB_2020 = 35, _lineB_2021 = 30, _lineB_2022 = 20;

        public int _lineC_2018 = 75, _lineC_2019 = 80, _lineC_2020 = 70, _lineC_2021 = 50, _lineC_2022 = 30;

        // Bar chart data values

        public int _Tirana_Jan = 135, _Tirana_Feb = 150, _Tirana_Mar = 130, _Tirana_Apr = 115, _Tirana_May = 120;

        public int _Algiers_Jan = 80, _Algiers_Feb = 75, _Algiers_Mar = 55, _Algiers_Apr = 60, _Algiers_May = 40;

        public int _Stockholm_Jan = 40, _Stockholm_Feb = 25, _Stockholm_Mar = 30, _Stockholm_Apr = 30, _Stockholm_May = 30;

        // Pie chart data values

        public int _Balcom_plc_2021 = 21, _Antlyn_plc_2021 = 12, _Graaf_inc_2021 = 30, _Trade_ltd_2021 = 11, _Royer_inc_2021 = 26;

        public int _Balcom_plc_2022 = 25, _Antlyn_plc_2022 = 18, _Graaf_inc_2022 = 24, _Trade_ltd_2022 = 13, _Royer_inc_2022 = 20;

        // Horizontal Bar chart data values

        public int _Les_Arcs_Jan = 10, _Les_Arcs_Feb = 20, _Les_Arcs_Nov = 25, _Les_Arcs_Dec = 30;

        public int _Tignes_Jan = 15, _Tignes_Feb = 25, _Tignes_Nov = 30, _Tignes_Dec = 20;

        public int _Whistler_Jan = 10, _Whistler_Feb = 20, _Whistler_Nov = 20, _Whistler_Dec = 30;

        public int _Val_Thorens_Jan = 5, _Val_Thorens_Feb = 20, _Val_Thorens_Nov = 40, _Val_Thorens_Dec = 35;

        // Chart type

        public string chartType;

        public string chartTypeFunction;

        protected int questionCounter;

        protected string myTimerVar = "";

        protected string myCaseContent;

        private int counter;

        private TheTest test = new TheTest();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize Auto-Properties

            test.HasEntry = false;
            test.HasScore = false;
            test.ResultHasEntry = false;
            test.Counter = counter;
            test.MyTimer = myTimerVar;
            test.QuestionCounter = questionCounter;
            test.CorrectAnswers = new List<string>();
            test.UserAnswers = new List<string>();
            test.DatabaseEntries = new List<string>();
            test.BackButton = btnBack;
            test.NextButton = btnNext;
            test.SubmitButton = btnSubmit;
            test.EndButton = btnEnd;
            test.TestForm = form1;
            test.HasEntryHiddenField = hfHasEntry;
            test.ResultHasEntryHiddenField = hfResultHasEntry;
            test.TimerHiddenInput = myTimer;
            test.CounterHiddenField = hfCounter;
            test.TotalQuestionsHiddenField = hfTotalQuestions;
            test.CurrentQuestionHiddenField = hfCurrentQuestion;
            test.SelectedRadioButtonHiddenField = hfSelectedRadioButton;
            test.PagerCounterHiddenField = hfPagerCounter;
            test.PaginationTotalPagesHiddenField = hfPaginationTotalPages;
            test.FinalMarkHiddenField = hfFinalMark;
            test.AccuracyHiddenField = hfAccuracy;
            test.TestScoreHiddenField = hfTestScore;
            test.QuestionTitleLabel = lblQuestionHeading;
            test.QuestionContentLabel = lblQuestionContent;
            test.OptionOneRadioButton = rdAns1;
            test.OptionTwoRadioButton = rdAns2;
            test.OptionThreeRadioButton = rdAns3;
            test.OptionFourRadioButton = rdAns4;
            test.Page = Page;
            test.ListCounter = hfListCounter;
            test.NumberOfTests = hfNumberOfTests;
            test.LastTestWritten = hfLastTest;
            test.HasScoreHiddenField = hfHasScore;

            test.AverageTestScore = "";
            test.AverageScores = hfAverageScores;

            lblTestName.Text = Session["Test_Name"].ToString() + " " + Session["Test_ID"].ToString();
            lblQuestionHeading.Text = "Question " + hfCounter.Value;
            questionCounter = Convert.ToInt32(hfCounter.Value);
            test.IsQuestionOne();
            test.IsLastQuestion(questionCounter);

            // Call appropriate chart function based on numerical test

            if (Session["Test_Type"].ToString() == "Numerical_Test_Questions" && Session["Test_ID"].ToString() == "Test 1")
            {
                chartTypeFunction = "TestOneNumerical();";
                chartType = "chart-line";
            }
            else if (Session["Test_Type"].ToString() == "Numerical_Test_Questions" && Session["Test_ID"].ToString() == "Test 2")
            {
                chartTypeFunction = "TestTwoNumerical();";
                chartType = "chart-bars";
            }
            else if (Session["Test_Type"].ToString() == "Numerical_Test_Questions" && Session["Test_ID"].ToString() == "Test 3")
            {
                chartTypeFunction = "TestThreeNumerical();";
                chartType = "chart-pie";
            }
            else if (Session["Test_Type"].ToString() == "Numerical_Test_Questions" && Session["Test_ID"].ToString() == "Test 4")
            {
                chartTypeFunction = "TestFourNumerical();";
                chartType = "chart-bars-hor";
            }
            else if (Session["Test_Type"].ToString() == "Verbal_Test_Questions")
            {
                GetCase();
                chartTypeFunction = "showCase();";
            }
            else if (Session["Test_Type"].ToString() == "Situational_Test_Questions")
            {
                chartTypeFunction = "showCase();";
            }
            else if (Session["Test_Type"].ToString() == "Diagrammatic_Test_Questions")
            {
                Session["Image_ID"] = lblQuestionHeading.Text;
                HttpCookie Test_ID_cookie = new HttpCookie("Test_ID");
                Test_ID_cookie.Value = Session["Test_ID"].ToString();
                Response.Cookies.Add(Test_ID_cookie);

                HttpCookie Image_ID_cookie = new HttpCookie("Image_ID");
                Image_ID_cookie.Value = Session["Image_ID"].ToString();
                Response.Cookies.Add(Image_ID_cookie);

                rdAns5.Visible = true;
                test.OptionFiveRadioButton = rdAns5;
                chartTypeFunction = "showImage();";

                myDiagram.Visible = true;
                myDiagram.ImageUrl = "../imageHandler/diagrammaticQuestionHandler.ashx?";
            }

            // Call Pagination

            Pager pager = new Pager();

            pager.TotalPagesHF = hfPaginationTotalPages;
            pager.CurrentPage = questionCounter;
            pager.Counter = Convert.ToInt32(hfPagerCounter.Value);
            pager.Pages = new List<int>();
            pager.PaginationLabel = lblPagination;

            try
            {
                test.RetrieveQuestion(Session["Test_Type"].ToString(), Session["Test_Options_Type"].ToString());
                if (Session["Test_Type"].ToString() == "Situational_Test_Questions")
                {
                    myCaseContent = lblQuestionContent.Text;
                    lblQuestionContent.Visible = false;
                }

                // Call Pagination and Timer once
                if (Convert.ToInt32(hfPagerCounter.Value) == 0)
                {
                    pager.Pagination();
                    counter = Convert.ToInt32(hfPagerCounter.Value);
                    counter++;
                    hfPagerCounter.Value = counter.ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        public void GetCase()
        {
            int caseID = Convert.ToInt32(Session["Test Row Index"].ToString());
            // Establish database connection

            DatabaseConnection DatabaseConn = new DatabaseConnection();
            var con = DatabaseConn.SQL_Connnection();

            // SQL Queries

            string selectCaseQuery = "SELECT [Case] FROM [AptUni].[dbo].[Verbal_Test_Cases] WHERE Case_Study_ID = " + caseID;

            // SQL Command

            SqlCommand selectCMD = new SqlCommand(selectCaseQuery, con);

            // Retrieve case

            using (var reader = selectCMD.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        hfCase.Value = reader.GetString(0);
                    }
                }
            }
            con.Close();

            myCaseContent = hfCase.Value;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                test.CheckEntry(Session["User_Answer_Type"].ToString(), test.HasEntry, test.HasEntryHiddenField);
                // Save the user's answer

                if (test.HasEntryHiddenField.Value == true.ToString())
                {
                    test.UpdateAnswer(Session["User_Answer_Type"].ToString());
                }
                else if (test.HasEntryHiddenField.Value != true.ToString())
                {
                    test.InsertAnswer(Session["User_Answer_Type"].ToString());
                }

                // Display the following question

                questionCounter = Convert.ToInt32(hfCounter.Value);
                questionCounter++;
                hfCounter.Value = questionCounter.ToString();
                test.IsQuestionOne();

                lblQuestionHeading.Text = "Question " + hfCounter.Value;
                questionCounter = Convert.ToInt32(hfCounter.Value);
                test.IsLastQuestion(questionCounter);

                // Retrieve Question & Multiple choice answers

                test.RetrieveQuestion(Session["Test_Type"].ToString(), Session["Test_Options_Type"].ToString());
                this.myTimerVar = Request.Form["MyTimer"];
                if (Session["Test_Type"].ToString() == "Situational_Test_Questions")
                {
                    myCaseContent = lblQuestionContent.Text;
                    lblQuestionContent.Visible = false;
                }

                if (Session["Test_Type"].ToString() == "Diagrammatic_Test_Questions")
                {
                    Session["Image_ID"] = lblQuestionHeading.Text;
                    HttpCookie Test_ID_cookie = new HttpCookie("Test_ID");
                    Test_ID_cookie.Value = Session["Test_ID"].ToString();
                    Response.Cookies.Add(Test_ID_cookie);

                    HttpCookie Image_ID_cookie = new HttpCookie("Image_ID");
                    Image_ID_cookie.Value = Session["Image_ID"].ToString();
                    Response.Cookies.Add(Image_ID_cookie);

                    rdAns5.Visible = true;
                    test.OptionFiveRadioButton = rdAns5;
                    chartTypeFunction = "showImage();";

                    myDiagram.Visible = true;
                    myDiagram.ImageUrl = "../imageHandler/diagrammaticQuestionHandler.ashx?";
                }
                Response.Write(questionCounter.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                // Save the user's answer

                test.UpdateAnswer(Session["User_Answer_Type"].ToString());

                // Display the following question

                questionCounter = Convert.ToInt32(hfCounter.Value);
                questionCounter--;
                hfCounter.Value = questionCounter.ToString();
                test.IsQuestionOne();

                lblQuestionHeading.Text = "Question " + hfCounter.Value;
                questionCounter = Convert.ToInt32(hfCounter.Value);
                test.IsLastQuestion(questionCounter);

                // Retrieve Question & Multiple choice answers

                test.RetrieveQuestion(Session["Test_Type"].ToString(), Session["Test_Options_Type"].ToString());
                this.myTimerVar = Request.Form["MyTimer"];
                if (Session["Test_Type"].ToString() == "Situational_Test_Questions")
                {
                    myCaseContent = lblQuestionContent.Text;
                    lblQuestionContent.Visible = false;
                }

                if (Session["Test_Type"].ToString() == "Diagrammatic_Test_Questions")
                {
                    Session["Image_ID"] = lblQuestionHeading.Text;
                    HttpCookie Test_ID_cookie = new HttpCookie("Test_ID");
                    Test_ID_cookie.Value = Session["Test_ID"].ToString();
                    Response.Cookies.Add(Test_ID_cookie);

                    HttpCookie Image_ID_cookie = new HttpCookie("Image_ID");
                    Image_ID_cookie.Value = Session["Image_ID"].ToString();
                    Response.Cookies.Add(Image_ID_cookie);

                    rdAns5.Visible = true;
                    test.OptionFiveRadioButton = rdAns5;
                    chartTypeFunction = "showImage();";

                    myDiagram.Visible = true;
                    myDiagram.ImageUrl = "../imageHandler/diagrammaticQuestionHandler.ashx?";
                }
                Response.Write(questionCounter.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "end test", "end_test();", true);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AptUni.logicLayer.Login login = new logicLayer.Login();
            try
            {
                // Save the user's answer
                test.UpdateAnswer(Session["User_Answer_Type"].ToString());

                // Submit the saved answer and check against correct answers in database

                test.PopulateAnswerList(Session["Test_Answers_Type"].ToString(), Session["User_Answer_Type"].ToString());

                test.SaveTestScore(Session["User_Answer_Type"].ToString(), Session["Test_Result_Type"].ToString());

                login.CheckScores();

                ClientScript.RegisterStartupScript(this.GetType(), "submit answer", "submit_answer();", true);
                System.Threading.Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}