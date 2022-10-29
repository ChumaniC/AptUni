<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="AptUni.presentationLayer.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aptitute Test</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../customCss/material-dashboard.css" rel="stylesheet" />
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900|Roboto+Slab:400,700" />
    <!-- Font Awesome Icons -->
    <link href="../customCss/sweetalert2.min.css" rel="stylesheet" />
    <link href="../customCss/sweetalert2.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/42d5adcbca.js" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../customScripts/MyAlerts.js"></script>
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <script src="//code.jquery.com/jquery-migrate-1.2.1.min.js"></script>

    <style>
        .question-body {
            height: 35rem;
            width: 40rem;
        }
    </style>
</head>
<body onload="<%= this.chartTypeFunction %> setHiddenField();">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="bg-light">
            <!-- Question Page Numbers -->
            <div class="card px-1 py-2">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <div class="d-flex justify-content-center information mt-4">
                                <asp:Label ID="lblTestName" Font-Bold="true" Font-Size="30px" runat="server"></asp:Label>
                            </div>
                            <div class="d-flex justify-content-center information mt-4">
                                <asp:Label ID="lblPagination" runat="server"></asp:Label>
                            </div>
                        </div>

                        <div class="col">
                            <div class="d-flex justify-content-end information mt-4">
                                <img alt="an image of a stopwatch" src="../images/time.png" height="32" width="32" />
                                <asp:Label ID="lblTimer" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row row-cols-2">
                <!-- Question Content -->
                <div class="col p-5">
                    <div class="question-body">
                        <div class="card px-1 py-4">
                            <div class="card-body">
                                <div id="myImage" hidden="hidden">
                                    <asp:Image ID="myDiagram" Height="500" Width="700" Visible="false" runat="server" />
                                </div>
                                <div id="myCase" hidden="hidden">
                                    <p id="case"><%= this.myCaseContent %></p>
                                </div>
                                <div>
                                    <div class="p-0 bg-transparent">
                                        <div id="myCharts"
                                            class="bg-gradient-white shadow-primary border-radius-lg py-3 pe-1">
                                            <div class="chart">
                                                <canvas id="<%= this.chartType %>" class="chart-canvas" style="height: 23rem;"></canvas>
                                                <br />
                                                <canvas id="myChart" hidden="hidden" class="chart-canvas" style="height: 23rem;"></canvas>
                                            </div>
                                            <div id="myTable" class="py-4" hidden="hidden" style="padding: 10px">
                                                <p>The average selling prices of the different grades of wireless headphones are as follows:</p>
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <th class="p-2" style="border: solid; border-color: gray; background-color: rgba(255, 26, 104, 1); color: white">Grade A</th>
                                                            <td class="p-2" style="border: solid; border-color: gray; background-color: lightgray; color: white">R500 per 50</td>
                                                            <th class="p-2" style="border: solid; border-color: gray; background-color: rgba(54, 162, 235, 1); color: white">Grade B</th>
                                                            <td class="p-2" style="border: solid; border-color: gray; background-color: lightgray; color: white">R300 per 50</td>
                                                            <th class="p-2" style="border: solid; border-color: gray; background-color: rgba(255, 206, 86, 1); color: white">Grade C</th>
                                                            <td class="p-2" style="border: solid; border-color: gray; background-color: lightgray; color: white">R150 per 50</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Possible Answers -->
                <div class="col p-2">
                    <div class="d-flex justify-content-end">
                        <div style="height: 50rem; width: 25rem" class="card px-1 py-4">
                            <div class="card-body">
                                <div class="d-flex align-items-start mb-4">
                                    <asp:Label CssClass="text-uppercase fw-weight-bold mb-1" ID="lblQuestionHeading" runat="server"></asp:Label>
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:Label CssClass="information mt-4" ID="lblQuestionContent" runat="server"></asp:Label>
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:RadioButton ID="rdAns1" GroupName="answers" runat="server" />
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:RadioButton ID="rdAns2" GroupName="answers" runat="server" />
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:RadioButton ID="rdAns3" GroupName="answers" runat="server" />
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:RadioButton ID="rdAns4" GroupName="answers" runat="server" />
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:RadioButton ID="rdAns5" Visible="false" GroupName="answers" runat="server" />
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <div>
                                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-info" Text="Back" OnClick="btnBack_Click" />
                                        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-success" Text="Next" OnClick="btnNext_Click" />
                                    </div>
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:Button ID="btnEnd" runat="server" CssClass="btn btn-danger" Text="End Test" OnClick="btnEnd_Click" />
                                </div>
                                <div class="d-flex align-items-start mb-4">
                                    <asp:Button ID="btnSubmit" runat="server" Visible="false" CssClass="btn btn-success" Text="Submit Answers" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hfCounter" Value="1" runat="server" />
                <input type="hidden" id="myTimer" name="MyTimer" value='<%=this.MyTimer %>' runat="server" />
                <asp:HiddenField ID="hfTotalQuestions" Value="4" runat="server" />
                <asp:HiddenField ID="hfCurrentQuestion" runat="server" />
                <asp:HiddenField ID="hfSelectedRadioButton" runat="server" />
                <asp:HiddenField ID="hfPagerCounter" Value="0" runat="server" />
                <asp:HiddenField ID="hfPaginationTotalPages" Value="0" runat="server" />
                <asp:HiddenField ID="hfFinalMark" runat="server" />
                <asp:HiddenField ID="hfAccuracy" runat="server" />
                <asp:HiddenField ID="hfTestScore" runat="server" />
                <asp:HiddenField ID="hfHasEntry" runat="server" />
                <asp:HiddenField ID="hfResultHasEntry" runat="server" />
                <asp:HiddenField ID="hfCase" runat="server" />
                <asp:HiddenField ID="hfAverageScores" runat="server" />
                <asp:HiddenField ID="hfListCounter" runat="server" />
                <asp:HiddenField ID="hfNumberOfTests" runat="server" />
                <asp:HiddenField ID="hfLastTest" runat="server" />
                <asp:HiddenField ID="hfHasScore" runat="server" />
            </div>
        </div>
    </form>

    <script src="../customScripts/Case.js"></script>
    <script src="../customScripts/ImageDisplay.js"></script>
    <script src="../customScripts/MyCountDownTimer.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../customScripts/chartjs.min.js"></script>
    <script src="../customScripts/popper.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <script type="text/javascript">
        var _lineA_2018 = '<%= this._lineA_2018 %>';
        var _lineA_2019 = '<%= this._lineA_2019 %>';
        var _lineA_2020 = '<%= this._lineA_2020 %>';
        var _lineA_2021 = '<%= this._lineA_2021 %>';
        var _lineA_2022 = '<%= this._lineA_2022 %>';

        var _lineB_2018 = '<%= this._lineB_2018 %>';
        var _lineB_2019 = '<%= this._lineB_2019 %>';
        var _lineB_2020 = '<%= this._lineB_2020 %>';
        var _lineB_2021 = '<%= this._lineB_2021 %>';
        var _lineB_2022 = '<%= this._lineB_2022 %>';

        var _lineC_2018 = '<%= this._lineC_2018 %>';
        var _lineC_2019 = '<%= this._lineC_2019 %>';
        var _lineC_2020 = '<%= this._lineC_2020 %>';
        var _lineC_2021 = '<%= this._lineC_2021 %>';
        var _lineC_2022 = '<%= this._lineC_2022 %>';
    </script>
    <script src="../customScripts/TestOneNumericalLineChart.js"></script>
    <script type="text/javascript">
        var _Tirana_Jan = '<%= this._Tirana_Jan %>';
        var _Tirana_Feb = '<%= this._Tirana_Feb %>';
        var _Tirana_Mar = '<%= this._Tirana_Mar %>';
        var _Tirana_Apr = '<%= this._Tirana_Apr %>';
        var _Tirana_May = '<%= this._Tirana_May %>';

        var _Algiers_Jan = '<%= this._Algiers_Jan %>';
        var _Algiers_Feb = '<%= this._Algiers_Feb %>';
        var _Algiers_Mar = '<%= this._Algiers_Mar %>';
        var _Algiers_Apr = '<%= this._Algiers_Apr %>';
        var _Algiers_May = '<%= this._Algiers_May %>';

        var _Stockholm_Jan = '<%= this._Stockholm_Jan %>';
        var _Stockholm_Feb = '<%= this._Stockholm_Feb %>';
        var _Stockholm_Mar = '<%= this._Stockholm_Mar %>';
        var _Stockholm_Apr = '<%= this._Stockholm_Apr %>';
        var _Stockholm_May = '<%= this._Stockholm_May %>';
    </script>
    <script src="../customScripts/TestTwoNumericalBarChart.js"></script>
    <script type="text/javascript">
        var _Balcom_plc_2021 = '<%= this._Balcom_plc_2021 %>';
        var _Antlyn_plc_2021 = '<%= this._Antlyn_plc_2021 %>';
        var _Graaf_inc_2021 = '<%= this._Graaf_inc_2021 %>';
        var _Trade_ltd_2021 = '<%= this._Trade_ltd_2021 %>';
        var _Royer_inc_2021 = '<%= this._Royer_inc_2021 %>';

        var _Balcom_plc_2022 = '<%= this._Balcom_plc_2022 %>';
        var _Antlyn_plc_2022 = '<%= this._Antlyn_plc_2022 %>';
        var _Graaf_inc_2022 = '<%= this._Graaf_inc_2022 %>';
        var _Trade_ltd_2022 = '<%= this._Trade_ltd_2022 %>';
        var _Royer_inc_2022 = '<%= this._Royer_inc_2022 %>';
    </script>
    <script src="../customScripts/TestThreeNumericalPieChart.js"></script>
    <script type="text/javascript">
        var _Les_Arcs_Jan = '<%= this._Les_Arcs_Jan %>';
        var _Les_Arcs_Feb = '<%= this._Les_Arcs_Feb %>';
        var _Les_Arcs_Nov = '<%= this._Les_Arcs_Nov %>';
        var _Les_Arcs_Dec = '<%= this._Les_Arcs_Dec %>';

        var _Tignes_Jan = '<%= this._Tignes_Jan %>';
        var _Tignes_Feb = '<%= this._Tignes_Feb %>';
        var _Tignes_Nov = '<%= this._Tignes_Nov %>';
        var _Tignes_Dec = '<%= this._Tignes_Dec %>';

        var _Whistler_Jan = '<%= this._Whistler_Jan %>';
        var _Whistler_Feb = '<%= this._Whistler_Feb %>';
        var _Whistler_Nov = '<%= this._Whistler_Nov %>';
        var _Whistler_Dec = '<%= this._Whistler_Dec %>';

        var _Val_Thorens_Jan = '<%= this._Val_Thorens_Jan %>';
        var _Val_Thorens_Feb = '<%= this._Val_Thorens_Feb %>';
        var _Val_Thorens_Nov = '<%= this._Val_Thorens_Nov %>';
        var _Val_Thorens_Dec = '<%= this._Val_Thorens_Dec %>';
    </script>
    <script src="../customScripts/TestFourNumericalBarChart.js"></script>
</body>
</html>