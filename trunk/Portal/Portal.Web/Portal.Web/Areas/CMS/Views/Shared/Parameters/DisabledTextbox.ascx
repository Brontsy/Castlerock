<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.DisabledTextbox>" %>


<label for="<%= Model.Key %>"><%= Model.Label %></label>

<input disabled="disabled" type="text" id="<%= Model.Key %>" name="<%= Model.Key %>" value="<%= Model.Value %>" />
