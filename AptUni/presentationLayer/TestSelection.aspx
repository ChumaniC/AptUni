<%@ Page Title="" Language="C#" MasterPageFile="~/presentationLayer/Main.Master" AutoEventWireup="true" CodeBehind="TestSelection.aspx.cs" Inherits="AptUni.presentationLayer.TestSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="topnav" id="myTopnav" style="background-color: white;">
        <header style="height: 10vh; min-height: 400px; background-image: url('../images/test.jpg'); background-size: cover; background-position: center; background-repeat: no-repeat; opacity: 0.8;">
            <h1 style="color: white;"><%= this.HeaderTitle %></h1>
            <h4 style="color: white;"><%= this.HeaderContent %>.</h4>
        </header>
    </div>

    <div class="bg-light">
        <div class="container py-5">
            <div class="row">
                <div class="col">
                    <h2 class="display-6">Available Tests</h2>

                    <div class="card-body px-0 pb-2">
                        <div class="table table-hover w-100">
                            <asp:GridView ID="gvTests"
                                CssClass="table align-items-center mb-0" runat="server"
                                AutoGenerateColumns="false" BorderStyle="None">
                                <Columns>
                                    <asp:BoundField DataField="Test_ID"
                                        ControlStyle-CssClass="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"
                                        HeaderText="Test Name" />
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
                                    <asp:TemplateField ControlStyle-CssClass="text-uppercase text text-lg font-weight-bolder btn btn-success"
                                        HeaderText="Option">
                                        <ItemTemplate>
                                            <asp:Button ID="btnBegin" CssClass="btn btn-primary" runat="server" Text="Begin" OnClick="btnBegin_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfTotalQuestions" Value="4" runat="server" />
    <asp:HiddenField ID="hfNumberOfTests" runat="server" />
    <asp:HiddenField ID="hfLastTest" runat="server" />
    <asp:HiddenField ID="hfTestStatus" runat="server" />
    <asp:HiddenField ID="hfHasScore" runat="server" />
    <asp:HiddenField ID="hfListCounter" runat="server" />
    <asp:HiddenField ID="hfAverageScore" runat="server" />
</asp:Content>