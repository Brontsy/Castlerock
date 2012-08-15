<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Castlerock.Web.Models.PropertyPageViewModel>" %>
<%@ Import Namespace="Castlerock.Web.Extensions" %>

<div id="AustralianMap">
    
    <%
        foreach (System.Collections.Generic.KeyValuePair<string, string> keyValue in Model.States)
        {
        %>
    <div class="<%= keyValue.Key.ToLower() %> state<%= (Model.State.ToLower() == keyValue.Key.ToLower() ? " selected" : "") %>">
        <%= Html.PropertiesInStateLink(keyValue.Key) %>
    </div> 
        <%
        }  
    %>
</div>
    
<script type="text/javascript"> 
 
window.addEvent('domready', function() {
	
	var australianMap = new AustralianMap($$('.state'));
		
});
 
</script>          