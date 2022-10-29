<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="AptUni.presentationLayer.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../customCss/customCss.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
    <script src="../customScripts/main.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../customScripts/inputValidation.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../customScripts/myAlerts.js"></script>
</head>
<body>
    <section class="vh-200 bg-image" style="background-image: url('../images/register.jpg');">
        <div class="mask d-flex align-items-center h-100 gradient-custom-3">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-8">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-5">
                                <h2 class="text-uppercase text-center mb-5">Sign Up</h2>

                                <form class="needs-validation" novalidate="novalidate" id="form1" runat="server">
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item p-2">
                                            <div class="row">
                                                <div class="col">
                                                    <div class="form-group col-md-6 p-4">
                                                        <h4>Personal Information</h4>
                                                    </div>
                                                    <div class="d-flex inline p-2">
                                                        <div class="form-group col-md-6" style="padding-right: 15px;">
                                                            <asp:Label ID="Label2" CssClass="form-control-label" runat="server" Text="Full Name" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtName" placeholder="Enter Name" runat="server"
                                                                class="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label3" CssClass="form-control-label" runat="server" Text="Surname" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSurname" placeholder="Enter Surname" runat="server"
                                                                class="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex inline p-2">
                                                        <div class="form-group col-md-6" style="padding-right: 15px;">
                                                            <asp:Label ID="Label1" CssClass="form-control-label" runat="server" Text="Email Address" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtEmail" placeholder="Enter Email" runat="server"
                                                                class="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label9" CssClass="form-control-label" runat="server" Text="Password" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtPassword" placeholder="Enter Password" runat="server"
                                                                class="form-control form-control-lg"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-group col-md-6 p-4">
                                                        <h4>June Matric Subjects</h4>
                                                    </div>
                                                    <div class="d-flex inline p-2">
                                                        <div class="form-group col-md-6" style="padding-right: 15px;">
                                                            <asp:Label ID="Label6" CssClass="form-control-label" runat="server" Text="Home Language" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject1" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label7" CssClass="form-control-label" runat="server" Text="First Additional Language" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject2" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex inline p-2">
                                                        <div class="form-group col-md-6" style="padding-right: 15px;">
                                                            <asp:Label ID="Label4" CssClass="form-control-label" runat="server" Text="Mathematics / Mathematics Literacy" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject3" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label5" CssClass="form-control-label" runat="server" Text="Life Orientation" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject4" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex inline p-2">
                                                        <div class="form-group col-md-6" style="padding-right: 15px;">
                                                            <asp:Label ID="Label8" CssClass="form-control-label" runat="server" Text="Elective One" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject5" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group col-md-6">
                                                            <asp:Label ID="Label10" CssClass="form-control-label" runat="server" Text="Elective Two" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject6" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex inline p-2">
                                                        <div class="form-group col-md-6" style="padding-right: 15px;">
                                                            <asp:Label ID="Label11" CssClass="form-control-label" runat="server" Text="Elective Three" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                                            <asp:TextBox ID="txtSubject7" placeholder="Enter Marks" runat="server"
                                                                class="form-control form-control-lg" TextMode="Number"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="p-4">
                                                        <asp:Button ID="btnSignUp" runat="server" Text="Register" class="btn btn-success btn-block btn-lg gradient-custom-4 text-body" OnClick="btnSignUp_Click" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-block btn-lg gradient-custom-4 text-body" Font-Italic="False" OnClick="btnCancel_Click" />
                                                    </div>
                                                    <p class="text-center text-muted mt-5 mb-0">
                                                        Already have an account?
                    <asp:HyperLink ID="HyperlinkRegisterHere" runat="server"
                        NavigateUrl="../presentationLayer/SignIn.aspx" class="fw-bold text-body"><u>Sign In</u></asp:HyperLink>
                                                    </p>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                            </div>
                            <asp:HiddenField ID="hfName" runat="server" />
                            <asp:HiddenField ID="hfSurname" runat="server" />
                            <asp:HiddenField ID="hfEmail" runat="server" />
                            <asp:HiddenField ID="hfPassword" runat="server" />
                            <asp:HiddenField ID="hfSub1" runat="server" />
                            <asp:HiddenField ID="hfSub2" runat="server" />
                            <asp:HiddenField ID="hfSub3" runat="server" />
                            <asp:HiddenField ID="hfSub4" runat="server" />
                            <asp:HiddenField ID="hfSub5" runat="server" />
                            <asp:HiddenField ID="hfSub6" runat="server" />
                            <asp:HiddenField ID="hfSub7" runat="server" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../customScripts/MyAlerts.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../customScripts/myAlerts.js"></script>
</body>
</html>