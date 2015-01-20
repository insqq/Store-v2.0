<%@ Page Title="" Language="C#" MasterPageFile="~/StartMP.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Store.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPH" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdPanelContent" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdPanelPages" runat="server">
        <ContentTemplate>

        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
