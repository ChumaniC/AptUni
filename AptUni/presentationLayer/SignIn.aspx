<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="AptUni.presentationLayer.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
</head>
<body>
    <section class="vh-100 bg-image" style="background-image: url('../images/login.jpg');">
        <div class="mask d-flex align-items-center h-100 gradient-custom-3">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-5">
                                <h2 class="text-uppercase text-center mb-5">Sign In</h2>

                                <form class="needs-validation" novalidate="novalidate" id="form1" runat="server">

                                    <div class="form-group col-sm-12 flex-column d-flex p-3">
                                        <label class="form-label p-2" for="txtEmail">Email Address</label>
                                        <asp:TextBox ID="txtIDLogin" runat="server" class="form-control form-control-lg" required="true"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-sm-12 flex-column d-flex p-3">
                                        <label class="form-label p-2" for="txtPassword">Password</label>
                                        <asp:TextBox ID="txtPasswordLogin" runat="server" class="form-control form-control-lg" TextMode="Password" required="true"></asp:TextBox>
                                    </div>

                                    <div class="d-flex justify-content-center" style="padding-top: 20px;">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login"
                                            class="btn btn-primary btn-block btn-lg gradient-custom-4 text-body" OnClick="btnLogin_Click" />
                                    </div>
                                </form>
                                <p class="text-center text-muted mt-5 mb-0">
                                    Don't have an account?
                    <asp:HyperLink ID="HyperlinkRegisterHere" runat="server"
                        NavigateUrl="../presentationLayer/SignUp.aspx" class="fw-bold text-body"><u>Sign Up</u></asp:HyperLink>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script src="../Scripts/bootstrap.js"></script>
</body>
</html>