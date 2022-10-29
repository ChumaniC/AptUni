<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="Numerical.aspx.cs" Inherits="AptUni.presentationLayer.Numerical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="topnav" id="myTopnav" style="background-color: white;">
        <header style="height: 10vh; min-height: 430px; background-image: url('../images/numeric.jpg'); background-size: cover; background-position: center; background-repeat: no-repeat; opacity: 0.8;">
            <h1 style="color: white;">Numerical Reasoning Tests</h1>
            <h4 style="color: whitesmoke;">Numerical reasoning tests demonstrate your
                ability to deal with numbers quickly and accurately.
                These tests contain questions that assess your knowledge of ratios,
                percentages, number sequences, data interpretation,
                financial analysis and currency conversion.</h4>
            <div style="top: 50%; left: 50%; transform: translateX(45%) translateY(200%);">
                <asp:Button ID="btnSignUp" runat="server" Text="Write Test"
                    CssClass="btn btn-danger btn-lg" OnClick="btnSignUp_Click" />
            </div>
        </header>
    </div>

    <div class="bg-light">
        <div class="container py-5">
            <div class="row h-100 align-items-center py-5">
                <div class="col-lg-6">
                    <h2 class="display-4">What is a numerical reasoning test?</h2>
                    <p class="lead text-muted mb-0">
                        A numerical reasoning test is a psychometric assessment that measures
                        a candidate’s numerical aptitude and their ability to interpret,
                        analyse and draw conclusions from data sets. The test is usually
                        timed with multiple-choice questions based on charts, tables or graphs.
                        They’re often used in conjunction with other psychometric tests, including
                        verbal reasoning tests, personality tests and situational judgement tests.
                    </p>

                    <p class="lead text-muted mb-0">
                        Unlike standardised maths tests, which demonstrate a student’s ability to
    learn and apply mathematical techniques based on a set syllabus, numerical
    reasoning tests reflect how successfully a candidate can apply numerical
    understanding in a realistic context.
                    </p>

                    <p class="lead text-muted mb-0">
                        General arithmetic, percentages, fractions and averages are all common
    elements of a numerical reasoning test, but its main focus is statistical
    information. Candidates are required to work with graphs, tables and charts
    to identify key facts and figures, and apply the correct logic to form an
    answer in response to a worded question.
                    </p>

                    <p class="lead text-muted mb-0">
                        You may be required to sit a numerical reasoning test if you’re applying
    for a job in a numeracy-based sector, such as finance or insurance.
    That said, they are increasingly common for any role that involves a
    level of data interpretation or numerical analysis, including marketing and HR.
                    </p>
                </div>
                <div class="col-lg-6 d-none d-lg-block">
                    <img src="../images/pie-chart.png" alt="" class="img-fluid">
                </div>
            </div>
        </div>
    </div>
</asp:Content>