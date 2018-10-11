<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bank.aspx.cs" Inherits="mentor1.Bank" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 148px;
        }
        .auto-style2 {
            width: 49%;
        }
        .auto-style3 {
            margin-left: 103px;
            margin-top: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style2">
            <tr>
                <td class="auto-style1">Poid</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Height="24px" Width="175px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Processing Date</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Height="24px" Width="173px" TextMode="DateTime"></asp:TextBox>
                </td>
            </tr>
        </table>
    
    </div>
        <br />
        <asp:Button ID="Button1" runat="server" CssClass="auto-style3" Height="35px" OnClick="Button1_Click" Text="Button" Width="135px" />
        <%--<asp:GridView ID="GridView1" runat="server">
        </asp:GridView>--%>
    </form>
</body>
</html>
