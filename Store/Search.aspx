<%@ Page Title="" Language="C#" MasterPageFile="~/StartMP.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Store.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPH" runat="server">
    <asp:PlaceHolder ID="pageButtonsPH" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="contentPH" runat="server"></asp:PlaceHolder>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SearchInfoPH" runat="server">
    <asp:PlaceHolder ID="searchPanelPH" runat="server">
        
    </asp:PlaceHolder>
</asp:Content>
