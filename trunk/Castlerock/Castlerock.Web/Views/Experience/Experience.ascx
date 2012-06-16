<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<string, IList<Castlerock.Properties.Interfaces.IProperty>>>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="managementExpertise">
    <div class="headerImage">
    
    </div>
</div>    


<div id="content">

        <div class="leftColumn">
            <h1>
                Management Expertise
            </h1>
            
            <p>
                We specialise in managing government-tenanted buildings around Australia.            </p>            <p>                <div>                    Our skills and experience span all areas of property management, including:                 </div>                <ul>                    <li>lease negotiation</li>                    <li>rental reviews</li>                    <li>tenant management</li>                    <li>building management</li>                    <li>maintenance</li>                    <li>reporting to property trusts.</li>                </ul>            </p>            <p>                We have developed excellent working relationships with government departments and thoroughly understand their specific needs. Because we custom design and construct government-leased buildings, we have a distinct advantage in the ongoing management of their properties. This enables us to provide investors with the highest possible return.
            </p>
            
            <h1> 
                Development Expertise
            </h1> 
            <p> 
                The Castlerock team brings many years of experience to the development of government office buildings across Australia.
            </p> 
             
                <p> 
                    We are proud of our track record of delivering of profitable projects. We have the necessary expertise to provide our clients with a comprehensive service, which includes:
                </p> 

                <ul> 
                    <li>identifying and securing suitable sites</li> 
                    <li>developing submissions to prospective tenants and negotiating    lease agreements</li> 
                    <li>arranging funding and long-term finance</li> 
                    <li>obtaining planning permits and other statutory approvals</li> 
                    <li>designing high quality, energy efficient, cost effective buildings</li> 
                    <li>managing the construction to ensure projects are delivered within budget    and time</li> 
                    <li>managing the project from conception through to delivery.  </li> 
                </ul> 
             
                        
        </div>

        <div class="rightColumn">
            <h3>Properties managed by Castlerock</h3>
            
            <%
            foreach (string state in Model.Keys)
            {
                IList<Castlerock.Properties.Interfaces.IProperty> properties = Model[state];
            %>
                <h4><%= state %></h4>
                <ul>

                <%
                foreach (Castlerock.Properties.Interfaces.IProperty property in properties)
                {
                %>
                    <li>
                        <a href="<%= property.NavigationUrl %>">
                            <%= property.Name %>
                        </a>
                    </li>
                <%
                }    
                %>
                </ul>
            <%
            }    
            %>
            
        </div>

                
    
</div>