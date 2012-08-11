<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.CSSPicker>" %>

<label for="<%= Model.Key %>"><%= Model.Label %></label>


<select id="<%= Model.Key %>" name="<%= Model.Key %>"<%= Model.CssClass %>>
    <option value="">No CSS</option>
	<optgroup label="Help">
		<option<%= (Model.Value == "HelpContainer" ? " selected" : "") %> value="HelpContainer">Help Items Container</option>
		<optgroup label="Help Topics">
			<option<%= (Model.Value == "BecomeMember" ? " selected" : "") %> value="BecomeMember">Becoming a member</option>
			<option<%= (Model.Value == "MbrSubscript" ? " selected" : "") %> value="MbrSubscript">Membership subscription</option>
			<option<%= (Model.Value == "PyamentsRefunds" ? " selected" : "") %> value="PyamentsRefunds">Payments and refunds</option>
			<option<%= (Model.Value == "MgMyAcc" ? " selected" : "") %> value="MgMyAcc">Manage My Account</option>
			<option<%= (Model.Value == "QuickflixComm" ? " selected" : "") %> value="QuickflixComm">Quickflix community</option>
			<option<%= (Model.Value == "TechProbs" ? " selected" : "") %> value="TechProbs">Technical problems</option>
			<option<%= (Model.Value == "GiftSubscript" ? " selected" : "") %> value="GiftSubscript">Gift Subscriptions</option>
		</optgroup>
	</optgroup>
	<option<%= (Model.Value == "NewsArticles" ? " selected" : "") %> value="NewsArticles">News Articles Container</option>
	<option<%= (Model.Value == "TitlesofWeekContainer" ? " selected" : "") %> value="TitlesofWeekContainer">Titles of the Week</option>
	<option<%= (Model.Value == "WhiteContainer" ? " selected" : "") %> value="WhiteContainer">White Container</option>
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
