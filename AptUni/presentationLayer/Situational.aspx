<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="Situational.aspx.cs" Inherits="AptUni.presentationLayer.Situational" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="topnav" id="myTopnav" style="background-color: white;">
        <header style="height: 10vh; min-height: 400px; background-image: url('../images/sit.jpg'); background-size: cover; background-position: center; background-repeat: no-repeat; opacity: 0.8;">
            <h1 style="color: whitesmoke;">Situational Judgement Tests</h1>
            <h4 style="color: whitesmoke;">Situational judgement tests allow employers to assess how you approach
                scenarios encountered in the workplace. The tests are built around hypothetical
                work situations, to which you are expected to react accordingly.
                Your answers will indicate your alignment with the values and behaviours of that particular company.</h4>
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
                    <h2 class="display-4">What is a situational reasoning test?</h2>
                    <p class="lead text-muted mb-0">
                        A situational judgement test, also known as an SJT, is a
                       type of psychometric test that often forms part of the assessment process for job applications.

An SJT involves considering a series of hypothetical workplace scenarios that you might encounter
                       in the role for which you are interviewing. You are then invited
                       to select a response that you feel best answers each question.
                       From these, the company extrapolates and assesses your judgement and character traits.
                    </p>

                    <p class="lead text-muted mb-0">
                        Situational judgement tests vary depending on the provider and the employer
    commissioning the test but usually take a similar form, in that you are
    presented with a description of a workplace-based scenario and a number of responses.

After reading the situation you are then asked to select or rank the responses.
    There are no right or wrong answers per se, and indeed none of the responses may include your
    instinctive response to the scenario. Using your knowledge of the
    employer and the role for which you are being assessed, you select the
    response which answers the question while also conveying the competencies that the employer seeks.
                    </p>

                    <p class="lead text-muted mb-0">
                        For the most part, and in more junior or graduate positions, the skills being assessed
    will largely be obvious: communication skills, team working,
    building relationships, commercial awareness. For more senior
    management roles, these could include motivation, strategy, delivering results and long-term planning.
                    </p>

                    <p class="lead text-muted mb-0">
                        In addition to gaining an understanding of how you might respond
    to the challenges of the job and the effectiveness of your
    judgement, SJTs also allow you an insight into the role and decisions/situations
    that you may encounter should you be successful in gaining a role in the organisation.
                    </p>
                </div>
                <div class="col-lg-6 d-none d-lg-block">
                    <img src="../images/proposal.png" alt="" class="img-fluid">
                </div>
            </div>
        </div>
    </div>
</asp:Content>