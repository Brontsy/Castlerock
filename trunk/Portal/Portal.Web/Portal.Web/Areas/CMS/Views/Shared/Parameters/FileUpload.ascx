<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.FileUpload>" %>


<div class="xml-feed-details" id=<%= Model.GetHashCode() %>>

    <label for="<%= Model.Key %>"<%= (Model.IsValid ? "" : "class=\"error\"") %>><%= Model.Label %></label>

    <input type="file" id="<%= Model.Key %>" name="<%= Model.Key %>"<%= Model.CssClass %> />

    <%
    if (!Model.IsValid)
    {
    %>

    <p class="error-message">

        <%= Model.Message %>

    </p>

</div>

<%
}
  %>