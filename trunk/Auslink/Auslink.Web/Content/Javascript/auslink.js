
window.addEvent('domready', function () {

    $$('ul.navigation li').each(function (navigationItem) {

        if (navigationItem.getElement('div') != null) {

            navigationItem.addEvents({

                'mouseenter': function () { this.getElement('a').addClass('hover'); this.getElement('div').setStyle('display', 'block'); },
                'mouseleave': function () { this.getElement('a').removeClass('hover'); this.getElement('div').setStyle('display', 'none'); }
            });
        }
    });

    // Start the rotation of the red logo
    rotate.delay(6000, this, [0, $$('.red-logo')[0]]);
});



var images = [
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/stable-income.png', 'width': '235px', 'height': '113px' },
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/tax-advantage-income.png', 'width': '271px', 'height': '113px' },
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/attractive-yields.png', 'width': '235px', 'height': '113px' },
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/property-location-diversification.png', 'width': '265px', 'height': '150px' },
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/low-management-fees.png', 'width': '235px', 'height': '146px' },
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/sustainable-buildings.png', 'width': '264px', 'height': '143px' },
        { 'imageUrl': 'http://castlerockproperty.blob.core.windows.net/auslinkproperty/images/header/quality-assets.png', 'width': '235px', 'height': '113px' }
];

var rotate = function (index, redLogo) {

    if (index >= images.length) { index = 0; }

        var myFx = new Fx.Tween(redLogo, { property: 'opacity', duration: 'long' });
        myFx.start(1, 0).chain(
        function () {
            redLogo.set('src', images[index].imageUrl);
            this.start(0, 1);
        }
    );

        rotate.delay(6000, this, [index + 1, redLogo]);
}
