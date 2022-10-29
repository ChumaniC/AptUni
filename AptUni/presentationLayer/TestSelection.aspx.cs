using AptUni.logicLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AptUni.presentationLayer
{
    public partial class TestSelection : System.Web.UI.Page
    {
        private DatabaseConnection DatabaseConnection = new DatabaseConnection();

        private TheTest test = new TheTest();

        public string HeaderTitle = "";

        public string HeaderContent = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            HeaderTitle = Session["Header_Title"].ToString();

            HeaderContent = Session["Header_Content"].ToString();

            test.Page = Page;
            test.NumberOfTests = hfNumberOfTests;
            test.LastTestWritten = hfLastTest;
            test.TestStatus = hfTestStatus;
            test.HasScoreHiddenField = hfHasScore;
            test.ListCounter = hfListCounter;
            test.AverageScores = hfAverageScore;

            // Populate Gridview

            try
            {
                DeclareSessionVariables(Session["Test_Type_Selection"].ToString());
                test.TotalTests(Session["Test_Type"].ToString());
                test.RetrieveWrittenTests(Session["Test_Result_Type"].ToString());

                int numberOfTests = Convert.ToInt32(test.NumberOfTests.Value);
                int lastTest = Convert.ToInt32(test.LastTestWritten.Value);

                if (lastTest < numberOfTests && test.TestStatus.Value == "Written")
                {
                    test.DisplayAvailableTest(Session["Test_Result_Type"].ToString());
                }
                else if (lastTest == 0 && test.TestStatus.Value == "Not Written")
                {
                    test.DisplayAvailableTest(Session["Test_Result_Type"].ToString());
                }
                if (Session["Test_ID"] != null)
                {
                    test.UsersTestAverages();
                }
                GetData();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        private void DeclareSessionVariables(string testType)
        {
            switch (testType)
            {
                case "Numerical":
                    Session["Test_Type"] = "Numerical_Test_Questions";
                    Session["Test_Result_Type"] = "Numerical_Test_Result";
                    Session["User_Answer_Type"] = "User_Numerical_Answers";
                    Session["Test_Options_Type"] = "Numerical_Test_Options";
                    Session["Test_Answers_Type"] = "Numerical_Answers";
                    Session["Test_Name"] = "Numerical Test";
                    break;

                case "Diagrammatic":
                    Session["Test_Type"] = "Diagrammatic_Test_Questions";
                    Session["Test_Result_Type"] = "Diagrammatic_Test_Result";
                    Session["User_Answer_Type"] = "User_Diagrammatic_Answers";
                    Session["Test_Options_Type"] = "Diagrammatic_Test_Options";
                    Session["Test_Answers_Type"] = "Diagrammatic_Answers";
                    Session["Test_Name"] = "Diagrammatic Test";
                    break;

                case "Situational":
                    Session["Test_Type"] = "Situational_Test_Questions";
                    Session["Test_Result_Type"] = "Situational_Test_Result";
                    Session["User_Answer_Type"] = "User_Situational_Answers";
                    Session["Test_Options_Type"] = "Situational_Test_Options";
                    Session["Test_Answers_Type"] = "Situational_Answers";
                    Session["Test_Name"] = "Situational Test";
                    break;

                case "Verbal":
                    Session["Test_Type"] = "Verbal_Test_Questions";
                    Session["Test_Result_Type"] = "Verbal_Test_Result";
                    Session["User_Answer_Type"] = "User_Verbal_Answers";
                    Session["Test_Options_Type"] = "Verbal_Test_Options";
                    Session["Test_Answers_Type"] = "Verbal_Answers";
                    Session["Test_Name"] = "Verbal Test";
                    break;
            }
        }

        private void GetData()
        {
            if (!this.IsPostBack)
            {
                SqlConnection conn = DatabaseConnection.SQL_Connnection();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Test_ID, Test_Average, Test_Score, Test_Accuracy, Time_Taken, Test_Date FROM " + Session["Test_Result_Type"].ToString() +
                                            " WHERE User_ID = " + Convert.ToInt32(Session["User_ID"].ToString()), conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvTests.DataSource = dt;
                    gvTests.DataBind();
                    conn.Close();
                }
            }
        }

        // Method to determine the index of the row of clicked button

        public void RowIndex(object sender)
        {
            int rowIndex;
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            rowIndex = gvRow.RowIndex + 1;
            Session["Test Row Index"] = rowIndex.ToString();
            Session["Test_ID"] = "Test " + rowIndex.ToString();
        }

        protected void btnBegin_Click(object sender, EventArgs e)
        {
            RowIndex(sender);
            Response.Redirect("../presentationLayer/TestInstruction.aspx");
        }
    }
}