<%@ Page Title="" Language="C#" MasterPageFile="/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Castlerock.Web.Models.PageViewModel>" %>




<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPage" runat="server">
    <% 
        Html.RenderPartial(Model.View, Model.Model); %> 

</asp:Content>

