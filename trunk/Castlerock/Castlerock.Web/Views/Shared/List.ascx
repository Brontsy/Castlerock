<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CastleRock.Cms.Controls.List>" %>

<ul>
<%
    foreach (CastleRock.Cms.Controls.ListItem item in Model.ListItems)
    {
    %>
    <li><%= item.Text %></li>
    <%
    }
     %>
</ul>
