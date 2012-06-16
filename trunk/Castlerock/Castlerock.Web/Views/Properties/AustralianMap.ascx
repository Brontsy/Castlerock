<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Castlerock.Web.Models.PropertyPageViewModel>" %>


<div class="australia">
    <div class="headerImage">
    
        <% Html.RenderPartial("Australia", Model); %>
    
        <div class="left">
            <img class="propertiesDeliveredHeading" src="/Content/Images/propertiesDelivered.jpg" />
        </div>
        <div class="center">

            <%
                if (Model.State != string.Empty)
                {
                    Html.RenderPartial("PropertiesInState", Model);
                }
                else
                {
                 %>
            <h1>Australia</h1>
            <p>
                Use our map to discover the properties successfully delivered and managed around Australia by Castlerock since 2000. Simply click on each State to learn more information.
            </p>
            <ul class="hidden">
                <li class="state"><a href="/Properties/State/NSW">New South Whales</a></li>
                <li class="state"><a href="/Properties/State/NT">Northern Territory</a></li>
                <li class="state"><a href="/Properties/State/QLD">Queensland</a></li>
                <li class="state"><a href="/Properties/State/SA">South Australia</a></li>
                <li class="state"><a href="/Properties/State/TAS">Tasmania</a></li>
                <li class="state"><a href="/Properties/State/VIC">Victoria</a></li>
                <li class="state"><a href="/Properties/State/WA">Western Australia</a></li>
            </ul>
                <%
                }
                     %>
        </div>
        <div class="right"></div>

    </div>
</div>

   