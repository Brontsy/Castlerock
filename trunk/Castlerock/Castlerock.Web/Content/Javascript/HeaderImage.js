

var HeaderImage = new Class({

    _images: null,
    
	options: {

	},

	initialize: function(images){


        this._images = images[0];



        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/2.jpg', { id: 'image2', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/3.jpg', { id: 'image3', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/4.jpg', { id: 'image4', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/5.jpg', { id: 'image5', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/6.jpg', { id: 'image6', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/7.jpg', { id: 'image7', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/8.jpg', { id: 'image8', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/9.jpg', { id: 'image9', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/10.jpg', { id: 'image10', title: 'myImage', onload: this.imageLoaded.bind(this) }));
        this._images.push(new Asset.image('http://castlerockproperty.blob.core.windows.net/castlerock/images/homepage/11.jpg', { id: 'image11', title: 'myImage', onload: this.imageLoaded.bind(this) }));
    
        this.showHideImages.periodical(6000, this);
	},
	
	imageLoaded: function(image) {

	    image.setStyle('opacity', 0);
	    image.inject(this._images[0].getParent(), 'bottom');
	},
	
	showHideImages: function()
	{
	    var image = this._images.filter(function(image) {

	        return image.hasClass('selected');
	    });
	    
	    var next = image.getNext();
	    
	    if(next == null || next == '')
	    {
	        next = this._images[0];
	    }
        
        image.set('morph', {duration: 1800, transition: Fx.Transitions.Sine.easeOut});
        next.set('morph', {duration: 1800, transition: Fx.Transitions.Sine.easeOut});
        
        image.morph({opacity: 0});
        next.morph({opacity: 1});

	    image.removeClass('selected');
	    next.addClass('selected');
	}
	

});