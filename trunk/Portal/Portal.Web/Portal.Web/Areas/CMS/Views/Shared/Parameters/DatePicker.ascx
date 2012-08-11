<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.DatePicker>" %>

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


<!-- for some reason the browser outputs the javascript for no reason, so jsut wrap it in a hidden div -->
<div class="hidden">
    <script type="text/javascript">

    window.addEvent('domready', function() {

        var dp = new DatePicker($('<%= Model.Key %>'), { pickerClass: 'datepicker_vista' }); 
     
    }); 
     
    </script>
</div>