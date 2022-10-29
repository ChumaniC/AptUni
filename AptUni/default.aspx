<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AptUni._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <!-- Custom styling -->
    <style>
        .carousel-item {
            height: 25rem;
            background: #000;
            color: white;
            position: relative;
            background-position: center;
            background-size: cover;
            margin-top: 50px;
        }

        .container {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            padding-bottom: 50px;
        }

        .overlay-image {
            position: absolute;
            bottom: 0;
            left: 0;
            right: 0;
            top: 0;
            background-position: center;
            background-size: cover;
            opacity: 0.5;
        }

        .card-title {
            float: right;
        }

        .card-text {
            float: right;
        }
    </style>


     <!-- carousel-->
    <div id="myCarousel" class="carousel slide carousel-fade"
        data-bs-ride="carousel">
        <ol class="carousel-indicators">
            <li data-bs-target="#myCarousel" data-bs-slide-to="0" class="active"></li>
            <li data-bs-target="#myCarousel" data-bs-slide-to="1"></li>
            <li data-bs-target="#myCarousel" data-bs-slide-to="2"></li>
        </ol>
        <div class="carousel-inner" role="listbox">
            <div class="carousel-item active">
                <div class="overlay-image" style="background-image: url('../images/1.jpg')">
                </div>
                <div class="container">
                    <div class="carousel-caption">
                        <h3>What is an aptitude test?</h3>
                        <p>An aptitude test is a way to measure a job candidate’s cognitive abilities,
                            work behaviours, or personality traits. Aptitude tests
                            will examine your numeracy, logic and problem-solving skills, as well 
                            as how you deal with work situations. They are a proven method to assess employability skills.</p>
                        <p>Aptitude tests measure a range of skills such as numerical ability, language comprehension and logical reasoning.</p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <div class="overlay-image" style="background-image: url('../images/2.jpg')">
                </div>
                <div class="container">
                    <div class="carousel-caption">
                        <h3>What are the different types of aptitude tests?</h3>
                        <p>There are a number of different types of aptitude test due to the range of cognitive capabilities 
                            and employer priorities. At AptUni, we provide industry standard aptitude or
                            psychometric tests for banking, accountancy, finance, law, engineering, business, marketing and vocational fields.</p>
                        <p>The most commonly used are numerical reasoning tests, verbal reasoning tests, diagrammatic reasoning tests and situational judgement tests</p>
                    </div>
                </div>
            </div>
            <div class="carousel-item">
                <div class="overlay-image" style="background-image: url('../images/3.jpg')">
                </div>
                <div class="container">
                    <div class="carousel-caption">
                        <h3>Take an aptitude test</h3>
                        <p>Try an aptitude test from the various test types below to prepare for your psychometric tests. 
                            All our assessments are written by accredited industry experts and are designed to replicate real exams
                            used by leading employers.Each has a strict time limit and at the end of the test you can view your score, 
                            benchmark and the full solutions to all the questions.</p>
                    </div>
                </div>
            </div>
        </div>
        <a class="carousel-control-prev" href="#myCarousel" role="button" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </a>
        <a class="carousel-control-next" href="#myCarousel" role="button" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </a>
    </div>

     <div class="box">
              <h1 style="text-align: center; color: black">Aptitute Tests</h1>
            <div class="row">
                <div class="col-lg-3">
                    <div class="box-part text-center">
                        <asp:Button ID="btnNumerical" runat="server" Style="background-image: url('../images/numbers.png')" BorderStyle="None" Height="128px" Width="128px" OnClick="btnNumerical_Click"/>
                        <div class="title">
                            <h4>Numerical Reasoning</h4>
                        </div>  
                        <div class="text">
                            <span>4 Tests | 4 Questions Per Test</span>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="box-part text-center">
                        <asp:Button ID="btnDiagrammatic" runat="server" Style="background-image: url('../images/logic.png')" BorderStyle="None" Height="128px" Width="128px" OnClick="btnDiagrammatic_Click"/>
                        <div class="title">
                            <h4>Diagrammatic Reasoning</h4>
                        </div>
                        <div class="text">
                            <span>2 Tests | 4 Questions Per Test</span>
                        </div>
                    </div>
                </div>

                 <div class="col-lg-3">
                    <div class="box-part text-center">
                        <asp:Button ID="btnVerbal" runat="server" Style="background-image: url('../images/speaking.png')" BorderStyle="None" Height="128px" Width="128px" OnClick="btnVerbal_Click" />
                        <div class="title">
                            <h4>Verbal Reasoning</h4>
                        </div>
                        <div class="text">
                            <span>3 Tests | 4 Questions Per Test</span>
                        </div>
                    </div>
                </div>

                <div class="col-lg-3">
                    <div class="box-part text-center">
                        <asp:Button ID="btnSituational" runat="server" Style="background-image: url('../images/location.png')" BorderStyle="None" Height="128px" Width="128px" OnClick="btnSituational_Click" />
                        <div class="title">
                            <h4>Situational Judgement</h4>
                        </div>
                        <div class="text">
                            <span>1 Test | 4 Questions</span>
                        </div>
                    </div>
                </div>
            </div>
    </div>

</asp:Content>
