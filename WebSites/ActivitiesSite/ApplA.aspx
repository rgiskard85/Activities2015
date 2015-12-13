<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplA.aspx.cs" Inherits="ApplA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div id="customer_form">
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>Name</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_custname" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Surname</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_custsurname" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Address</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_custaddress" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Phone</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_custphone" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Number of Chairs</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_chairnum" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Price of Chairs</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_chairprice" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Weight of Chair</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_chairweight" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Number of Tables</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_tablenum" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Price of Tables</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_tableprice" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Weight of Tables</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_tableweight" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Supplier name</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_supplname" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Supplier Address</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_suppladdress" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Transporter Name</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_transpname" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Transporter's price per kilogram</asp:TableCell><asp:TableCell><asp:TextBox ID="txtbox_priceperkilo" runat="server"></asp:TextBox></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Button ID="btnCallWS" runat="server" Text="Submit Order" OnClick="btnCallWS_Click"/></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="lblResponse" runat="server" Visible="false" Text="Order is:"></asp:Label></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    
    </form>
    
</body>
</html>
