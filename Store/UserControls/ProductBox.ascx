<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductBox.ascx.cs" Inherits="Store.ProductBox" %>
<header>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</header>
<style type="text/css">
    .auto-style1 {
        margin-top: 10px;
        width: 100%;
        height: 120px;
    }

    .auto-style2 {
        width: 120px;
    }

    .auto-style3 {
        width: 70%;
    }

    .auto-style4 {
        width: 100%;
        height: 112px;
    }
</style>
<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:ImageButton ID="imgBtn" runat="server" Width="120" Height="120" />
        </td>
        <td class="auto-style3" style="vertical-align: top">
            <table class="auto-style4">
                <tr>
                    <td>
                        <asp:HyperLink ID="nameLink" runat="server" Font-Size="X-Large" ForeColor="#66FF33">HyperLink</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="prodInfoUPD" runat="server">
                            <ContentTemplate>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
            <asp:Button CssClass="btn btn-success" ID="priceBtn" runat="server" Text="Button" />
        </td>
    </tr>
</table>

