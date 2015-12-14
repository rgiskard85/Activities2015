<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppB.aspx.cs" Inherits="AppB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update orders from file" OnClick="btnUpdate_Click" />
        <asp:DropDownList ID="ddlOrders" runat="server"></asp:DropDownList>
        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" />
    </div>
    <div>
        <table>
            <tr>
                <td>Order Serial:</td><td><asp:TextBox ID="order_id" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>Customer Name:</td><td><asp:TextBox ID="customer_name" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>Customer Surname:</td><td><asp:TextBox ID="customer_surname" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Supplier:</td><td><asp:TextBox ID="supplier_name" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>Transporter:</td><td><asp:TextBox ID="transporter_name" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>Order was made on:</td><td><asp:TextBox ID="tborder_date" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Transfer From:</td><td><asp:TextBox ID="supplier_address" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>Transfer To:</td><td><asp:TextBox ID="customer_address" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">Chairs for transfer:</td>
            </tr>
            <tr>
                <td>Number</td><td>Price</td><td>Weight</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="tbchair_num" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td><asp:TextBox ID="tbchair_price" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td><asp:TextBox ID="tbchair_weight" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3">Tables for transfer</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="tbtable_num" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td><asp:TextBox ID="tbtable_price" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td><asp:TextBox ID="tbtable_weight" runat="server" ReadOnly="true"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    </form>
    </body>
</html>
