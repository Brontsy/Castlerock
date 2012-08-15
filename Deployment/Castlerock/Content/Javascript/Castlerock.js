
window.addEvent('domready', function () {

    $$('#close').addEvent('click', function(event) {

        event.stop();
        $('overlay').addClass('hidden');
        $('modal').addClass('hidden');
        this.addClass('hidden');
    });

    $$('a.edit-control').addEvent('click', function(event) {

        event.stop();
        $('overlay').removeClass('hidden');
        $('close').removeClass('hidden');
        $('modal').set('html', 'Loading...').removeClass('hidden');

        var url = this.get('href');
        var myRequest = new Request.HTML({
            url: url,
            onSuccess: function(esponseTree, responseElements, responseHTML, responseJavaScript) {
                
                $('modal').set('html', responseHTML)
            }
        });
        myRequest.post();
    });

});