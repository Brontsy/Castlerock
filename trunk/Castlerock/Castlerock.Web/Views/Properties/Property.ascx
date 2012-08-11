<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Castlerock.Web.Models.PropertyPageViewModel>" %>


        <% Html.RenderPartial("AustralianMap", Model); %>
<div id="content">


    <div class="greenColumn" style=""></div>
    
    
    
    <div id="contentArea" style="float:left;">

        <img src="http://castlerockproperty.blob.core.windows.net/castlerock/images/properties/<%= Model.Property.ImageFolder %>/755x311.jpg" />
        
        
            <div class="propertyHeadingContainer">
                <h2 class="propertyName">
                    <%= Model.Property.Name%>
                </h2>
                
                <h3 class="propertyAddress">- &nbsp;  &nbsp; <%= Model.Property.Address%></h3>
            </div>
            
            <h4 class="hidden">Information</h4>
            <div class="divider"></div>
        
            <ul class="propertyDetails">
                <li>
                    <div class="field">Tenant</div>
                    <div class="value"><%= Model.Property.Tenant%></div>
                </li>
                <li>
                    <div class="field">Department</div>
                    <div class="value"><%= Model.Property.Department%></div>
                </li>
                <li>
                    <div class="field">Floor Area</div>
                    <div class="value"><%= Model.Property.FloorArea%></div>
                </li>
                <%
                    if (Model.Property.IsComplete && Model.Property.LeaseCommenced.HasValue)
                    {
                 %>
                <li>
                    <div class="field">Lease Commenced</div>
                    <div class="value"><%= Model.Property.LeaseCommenced.Value.ToString("d MMMM yyyy")%></div>
                </li>
                <%
                    }
                 %>
                <%
                    if (!Model.Property.IsComplete && Model.Property.ExpectedCompletionDate.HasValue)
                    {
                 %>
                <li>
                    <div class="field">Expected Completion</div>
                    <div class="value"><%= Model.Property.ExpectedCompletionDate.Value.ToString("d MMMM yyyy") %></div>
                </li>
                <%
                    }
                 %>
                <li>
                    <div class="field">Energy Rating</div>
                    <div class="value"><%= Model.Property.EnergyRating%></div>
                </li>                                                                
            </ul>
        
            <div class="divider"></div>
        
        </div>
    
</div>
