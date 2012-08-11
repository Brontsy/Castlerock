﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.Textarea>" %>

<label for="<%= Model.Key %>"><%= Model.Label %></label>
<textarea id="<%=Guid.NewGuid().ToString().Substring(0,5) %>-<%= Model.Key %>" name="<%= Model.Key %>" <%= Model.CssClass %>><%= Model.Value %></textarea>

<%
if (!Model.IsValid)
{
%>
    <p class="error-message">
        <%= Model.Message %>
    </p>
<%
}
%>
