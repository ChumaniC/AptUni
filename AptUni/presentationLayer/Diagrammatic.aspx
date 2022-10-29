<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="Diagrammatic.aspx.cs" Inherits="AptUni.presentationLayer.Logical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="topnav" id="myTopnav" style="background-color: white;">
        <header style="height: 10vh; min-height: 400px; background-image: url('../images/dia.jpg'); background-size: cover; background-position: center; background-repeat: no-repeat; opacity: 0.8;">
            <h1 style="color: whitesmoke;">Diagrammatic Reasoning Tests</h1>
            <h4 style="color: whitesmoke;">Diagrammatic reasoning tests assess your logical reasoning ability.
                The questions measure your ability to infer a set of rules from a flowchart
                or sequence of diagrams and then to apply those rules to a new situation</h4>
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
                        Diagrammatic reasoning tests are psychometric tests that assess a
    candidate’s ability to interpret sequences of shapes, patterns and figures.

The questions centre on deducing the rule, or rules, governing a sequence and extending or reapplying these conventions to
    determine the correct input or output. They test a potential
    employee’s ability to think logically and rapidly apply concepts to new situations
                    </p>

                    <p class="lead text-muted mb-0">
                        Although often conflated with abstract reasoning tests, the diagrammatic variety differs slightly. Whilst abstract reasoning tends to
    focus upon symbols and shapes, diagrammatic reasoning questions may also include letters and numbers,
    as well as operators or processors – adding to their complexity.
                    </p>

                    <p class="lead text-muted mb-0">
                        Diagrammatic reasoning tests are a useful tool for determining whether applicants
    have the skills of spatial deduction and agile problem solving
    required for a role. They were once predominantly administered
    for jobs in sectors such as engineering, but are now increasingly present across various industries.
                    </p>
                </div>
                <div class="col-lg-6 d-none d-lg-block">
                    <img src="../images/shapes.png" alt="" class="img-fluid">
                </div>
            </div>
        </div>
    </div>
</asp:Content>