<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CastleRock.Cms.Controls.Person>" %>

    <% 
        foreach (CastleRock.Cms.Interfaces.IControl control in Model.Controls)
        {
            Html.RenderPartial(control.View, control);
        }
    %>
