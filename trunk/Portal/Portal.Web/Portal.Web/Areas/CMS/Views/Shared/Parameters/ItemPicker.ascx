<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Qfx.Cms3.Parameters.ItemPicker>" %>





<ul id="<%= Model.GetHashCode() %>">

    <p style="margin: 10px 0px 10px 0px; font-weight: bold;">
        Please search for a <%= Model.Label %> by clicking on the search box
    </p>

  
        
    <li class="float-container">
        <label for="item_picker_search">Search</label>
        <input type="text" autocomplete="off" name="item_picker_search" id="item_picker_search_<%= Model.GetHashCode() %>" value="Click here to start searching" />
    </li>
    
    <li class="search-results hidden">
        <div class="searching">Searching</div>
    </li>
                
    

    <li>
        <label for="itemId"><%= Model.Name %> Id</label>
        <input type="text" name="itemId" id="itemId_<%= Model.GetHashCode() %>" value="<%= Model.ItemId %>"<%= Model.CssClass %> />
    </li>

    <li>
        <label for="itemName"><%= Model.Name %>s Name</label>
        <input type="text" name="itemName" id="itemName_<%= Model.GetHashCode() %>" value="<%= Model.ItemName %>"<%= Model.CssClass %> />
    </li>
    
    <li>
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
    </li>
    
</ul>


<script type="text/javascript">

window.addEvent('domready', function() {

    new ItemPicker('<%= Model.GetHashCode() %>', '<%= Model.Url %>'); 
 
}); 
 
</script>
