<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>


<div class="home">
    <div class="headerImage">
        <img class="selected" src="/Content/Images/HomePage/1.jpg" alt="Castle Rock Property" />
    </div>
</div>


<div id="content">
    
        <div class="leftColumn">

            <p class="strong">
               Castlerock specialises in the development and management of purpose built government-leased office buildings.
            </p>
            
                <p>
                    We provide opportunities for property investors to invest in newly developed commercial offices tenanted by 
                    government departments. With more than 15 years experience developing and managing government offices, we 
                    understand how to successfully develop and manage property to meet the specific needs of the government sector.
                </p>             
                <p>                 
                    Focusing on the development of Centrelink Customer Service Centres we have gained a unique understanding of 
                    this asset class, and how to best develop and manage these assets to suit Centrelink and ensure their long-term commitment to the building.
                </p>
            
        </div>
    
        <div class="rightColumn">

        </div>
                
</div>

<script type="text/javascript"> 
 
window.addEvent('domready', function() {
	
	var headerImage = new HeaderImage($$('.headerImage').getElements('img'));
		
});
 
</script>     