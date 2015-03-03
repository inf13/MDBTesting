<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFilm.aspx.cs" Inherits="MDB.WebForms.AddFilm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Film</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Film Title:"/>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFilmTitle" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Film Genre:"/>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFilmGenre" runat="server"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Film Year:"/>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFilmYear" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddFilm" runat="server" Text="Add Film" OnClick="ButtonAddFilmClick" />
    </div>
    </form>
</body>
</html>
