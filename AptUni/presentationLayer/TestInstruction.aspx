<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestInstruction.aspx.cs" Inherits="AptUni.presentationLayer.TestInstruction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Instructions</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-light">
            <div class="container py-5">
                <div class="row h-100 align-items-center py-5">
                    <div class="col-lg-6">
                        <div class="py-2">
                            <asp:Label ID="lblTestTitle" CssClass="display-4" runat="server"></asp:Label>
                        </div>
                        <div class="py-2">
                            <asp:Label ID="lblTestTime" CssClass="display-6" runat="server"
                                Text="4 Questions | 8 minutes"></asp:Label>
                        </div>
                        <div class="py-2">
                            <p class="lead text-muted mb-0">
                                All questions are multiple choice and there is only one correct answer.
                        The test cannot be paused.
                        Try to take the test in an environment where you will not be disturbed.
                            </p>
                        </div>
                        <div class="py-2">
                            <asp:Button ID="btnBegin" CssClass="btn btn-primary" runat="server" Text="Begin" OnClick="btnBegin_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-outline-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>