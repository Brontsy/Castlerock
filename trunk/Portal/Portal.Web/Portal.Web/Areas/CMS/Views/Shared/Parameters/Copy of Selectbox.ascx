<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.Selectbox>" %>

<label for="<%= Model.Key %>"><%= Model.Label %></label>


<select id="<%= Model.Key %>" name="<%= Model.Key %>"<%= Model.CssClass %>>
<%
    foreach (var keyValue in Model.Values)
    {
      %>
      <option value="<%= keyValue.Value %>"<%= (Model.Value == keyValue.Key ? " selected" : "") %>><%= keyValue.Key %></option>
      <%
    }   
%>
</select>

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
