<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.RssFeedParamater>" %>


<div class="rss-details" id=<%= Model.GetHashCode() %>>

    <% Html.RenderPartial(Model.Paramater.View, Model.Paramater); %>
    
</div>

<%
if (Model.OverrideButton)
{

string pageName = (ViewContext.RouteData.Values["pageName"] != null ? ViewContext.RouteData.Values["pageName"].ToString() : string.Empty);
string pageId = (ViewContext.RouteData.Values["pageId"] != null ? ViewContext.RouteData.Values["pageId"].ToString() : string.Empty);
string location = (ViewContext.RouteData.Values["location"] != null ? ViewContext.RouteData.Values["location"].ToString() : string.Empty);
string controlId = (ViewContext.RouteData.Values["controlId"] != null ? ViewContext.RouteData.Values["controlId"].ToString() : string.Empty);
%>


<script type="text/javascript">

window.addEvent('domready', function() {

    var form = $('<%= Model.GetHashCode() %>').getParent('form');
    <%
    
    if (ViewContext.RouteData.Values["location"] == null)
    {
    %>form.set('action', '/Quickflix/Page/<%= pageName %>/<%= pageId %>/Add/Control/<%= controlId %>/XmlFeed');<%
    }
    else
    {
    %>form.set('action', '/Quickflix/Page/<%= pageName %>/<%= pageId %>/Add/Control/Location/<%= location %>/XmlFeed');<%
    }
     %>
     
     form.getElement('.blue div').set('html', 'Get Rss Feed');
 
}); 
 
</script>
<%
}
%>
