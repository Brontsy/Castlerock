

var AustralianMap = new Class({

    states: null,

    options: {

},

initialize: function (states) {
    this.states = states;
    states.each(this.addEvents.bind(this));
},


addEvents: function (state) {
    state.addEvents({
        'mouseover': function (event) { this.getElement('a').removeClass('hidden'); },
        'mouseleave': function (event) { this.getElement('a').addClass('hidden'); },
        'click': this.stateClicked.bindWithEvent(this, [state])
    });
},

stateClicked: function (event, state) {
    event.stop();

    this.states.each(function (element) { element.removeClass('selected'); });
    state.addClass('selected');

    var stateName = state.get('class').replace(' state', '').replace(' selected', '');

    var url = state.getElement('a').get('href');

    var request = new Request.HTML({ url: url, method: 'post' });

    request.addEvent('success', this.propertiesLoaded.bind(this));

    request.post();
},


propertiesLoaded: function (responseTree, responseElements, responseHTML, responseJavaScript) {

    var updateElement = $$('.headerImage').getElement('.center');
    updateElement.set('html', responseHTML);
}




});