<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="Verbal.aspx.cs" Inherits="AptUni.presentationLayer.Verbal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="topnav" id="myTopnav" style="background-color: white;">
        <header style="height: 10vh; min-height: 400px; background-image: url('../images/ver.jpg'); background-size: cover; background-position: center; background-repeat: no-repeat; opacity: 0.8;">
            <h1 style="color: whitesmoke;">Verbal Reasoning Tests</h1>
            <h4 style="color: whitesmoke;">Verbal reasoning tests assess your understanding and comprehension skills.
                You will be presented with a short passage of text, which you’ll be required to
                interpret and then answer questions on. These are typically in the ‘True, False,
                Cannot Say’ multiple-choice format, although there are a range of alternatives too.</h4>
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
                    <h2 class="display-4">What is a verbal reasoning test?</h2>
                    <p class="lead text-muted mb-0">
                        A verbal reasoning test assesses your ability to make deductions from text. The format is typically a
                     written passage followed by a statement, and
                     you must decide whether the statement is true, false or that you cannot say.
                     They evaluate your understanding of language and level of verbal comprehension and logic.
                    </p>

                    <p class="lead text-muted mb-0">
                        Depending on the role you are applying for, questions may range from basic reading comprehension
    to more advanced reasoning. There are also a number of different test providers
    used by recruiters, offering a range of verbal reasoning assessments for
    different industries and job levels. We will look at these in more detail later in this article.
                    </p>
                </div>
                <div class="col-lg-6 d-none d-lg-block">
                    <img src="../images/voice-recording.png" alt="" class="img-fluid">
                </div>
            </div>
        </div>
    </div>
</asp:Content>