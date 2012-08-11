<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.Checkbox>" %>

<%= Html.CheckBox(Model.Key, Model.Selected) %>

<label class="checkbox" for="<%= Model.Key %>"><%= Model.Label %></label>
