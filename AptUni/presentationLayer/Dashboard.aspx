<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AptUni.presentationLayer.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bg-light">
        <div class="container py-2">
            <div class="row">
                <div class="col">
                    <img src="../images/robot.png" height="64" width="64" alt=""><h2 class="display-6"><%= this.welcome %></h2>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid py-5">
        <div class="row">
            <h2 class="display-10">Overview</h2>
            <div class="col-lg-4">
                <div class="box-part text-center border rounded-5 bg-light">

                    <div class="title">
                        <h4>Your Best Score</h4>
                    </div>
                    <div class="text">
                        <h3><%= this.bestTestScoreName %></h3>
                    </div>
                    <div class="flex items-center text-red-200">
                        <p class="btn btn-success"><%= this.bestTestScore %></p>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="box-part text-center border rounded-5 bg-light">

                    <div class="title">
                        <h4>Your Average Score</h4>
                    </div>
                    <div class="text">
                        <h3><%= this.numberOfTest    %></h3>
                    </div>
                    <div class="flex items-center text-red-200">
                        <p class="btn btn-warning"><%= this.averageTestScore %></p>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="box-part text-center border rounded-5 bg-light">

                    <div class="title">
                        <h4>Your Latest Score</h4>
                    </div>
                    <div class="text">
                        <h3>Numerical Reasoning 2</h3>
                    </div>
                    <div class="flex items-center text-red-200">
                        <p class="btn btn-danger">46%</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <h2 class="display-10">Recommended Prospects</h2>
            <div class="col-lg-4">
                <div class="box-part text-center border rounded-5 bg-light">

                    <div class="title">
                        <h4>Most Likely Higher Education Institution Choice</h4>
                    </div>
                    <div class="text">
                        <h3><%= this.universityChoice %></h3>
                    </div>
                    <div class="flex items-center text-red-200">
                        <a class="btn btn-success" href="<%= this.universityURL %>">Visit Institution</a>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="box-part text-center border rounded-5 bg-light">

                    <div class="title">
                        <h4>Likely Undergraduate Choice</h4>
                    </div>
                    <div class="text">
                        <h3><%= this.undergraduateChoice %></h3>
                    </div>
                    <div class="flex items-center text-red-200">
                        <a class="btn btn-warning" href="<%= this.undergraduateURL %>">Read More</a>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="box-part text-center border rounded-5 bg-light">

                    <div class="title">
                        <h4>Likely Career Choice</h4>
                    </div>
                    <div class="text">
                        <h3><%= this.careerChoice %></h3>
                    </div>
                    <div class="flex items-center text-red-200">
                        <a class="btn btn-danger" href="<%= this.careerURL %>">Read More</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="border rounded-5 bg-light">
        <div class="container-fluid py-5">
            <div class="row">
                <div class="col">
                    <h2 class="display-6">Recent Activity</h2>

                    <div class="card-body px-0 pb-2">
                        <div class="table table-hover w-100">
                            <asp:GridView ID="gvTests"
                                CssClass="table align-items-center mb-0" runat="server"
                                AutoGenerateColumns="false" BorderStyle="None">
                                <Columns>
                                    <asp:BoundField DataField="Test_ID"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Test Name" />
                                    <asp:BoundField DataField="Test_Type"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Category" />
                                    <asp:BoundField DataField="Test_Average"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="User Average" />
                                    <asp:BoundField DataField="Test_Score"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Test Score" />
                                    <asp:BoundField DataField="Test_Accuracy"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Accuracy" />
                                    <asp:BoundField DataField="Time_Taken"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Time Taken" />
                                    <asp:BoundField DataField="Test_Date"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Test Date" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfCurrent" runat="server" />
</asp:Content>