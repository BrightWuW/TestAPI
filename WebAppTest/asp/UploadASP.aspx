<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadASP.aspx.cs" Inherits="WebAppTest.asp.UploadASP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload Multiple Files in ASP.NET Using jQuery</title>
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery.MultiFile.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--<asp:TextBox ID="TextBox1" runat="server" Height="79px" TextMode="MultiLine"></asp:TextBox>--%>
            <asp:TextBox ID="TextBox1" runat="server" Height="79px" TextMode="MultiLine"></asp:TextBox>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="multi" /><asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>

    </form>
</body>
</html>
