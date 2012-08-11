<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.Textbox>" %>


<label for="<%= Model.Key %>"<%= (Model.IsValid ? "" : "class=\"error\"") %>><%= Model.Label %></label>

<input type="text" id="<%= Model.Key %>" name="<%= Model.Key %>" value="<%= Model.Value %>"<%= Model.CssClass %> />

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
