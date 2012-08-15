window.addEvent('domready', function () {

    $$('ul.navigation li').each(function (navigationItem) {

        if (navigationItem.getElement('div') != null) {

            navigationItem.addEvents({

                'mouseenter': function () { this.getElement('a').addClass('hover'); this.getElement('div').setStyle('display', 'block'); },
                'mouseleave': function () { this.getElement('a').removeClass('hover'); this.getElement('div').setStyle('display', 'none'); }
            });
        }
    });
});