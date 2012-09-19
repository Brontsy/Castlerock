


$(document).ready(function () {
    $('form').each(function (index, form) {
        parseForm($(form), false);
    });
});

// Set up some extra validation properties so we can give positive feedback to the user
// Note: if the element has the positive-feedback data value then we will not automatically add
// positive feedback, it will be done when all fields are valid
function parseForm(form, reparseValidation) {

    if (reparseValidation) {
        form.removeData('validator');
        form.removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse(form);
    }

    var settngs = $.data(form.get(0), 'validator').settings;

    var oldErrorFunction = settngs.errorPlacement;
    var oldSucessFunction = settngs.success;

    // custom function when a error occurs. in here we can hide the positive feedback
    // because there was an error
    settngs.errorPlacement = function (error, inputElement) {

        $(inputElement).data('validated', true);

        inputElement.parents('li').addClass('error');
        inputElement.parents('li').removeClass('success');

        oldErrorFunction(error, inputElement);
    }

    // custom function to do positive feedback when the element is successfully validated
    // elements that have the positive-feedback attribute will be ignored (see below)
    settngs.success = function (error) {

        var container = error.data("unobtrusiveContainer");

        var id = container.data('valmsg-for');

        if (id) {
            id = id.replace('.', '_');

            var element = $('#' + id);

            $(element).data('validated', true);

            if (element.val() != '') {

                $(element).parents('li').removeClass('error');
                $(element).parents('li').addClass('success');
            }
        }
        oldSucessFunction(error);
    }

    // go through each element that relies on 1 or more other elements to give positive feedback to the user
    $('[data-val-positivefeedbackrequires]').each(function (index, element) {

        var elements = $(element).data('valPositivefeedbackrequiresProperties').split(',');

        validateField($(element).attr('id'), elements);
    })
}



// Allows us to say that field X is a required if field Y is null
// Example: Vin becomes a required field if the Rego value is null. Also Rego becomes a required field if vin is null
$.validator.addMethod("requiredifpropertiesisnull", function (value, element, params) {

    var returnValue = false;

    $.each(params, function (index, parameter) {
        if ($('#' + parameter).val() != '' || value != '') {
            returnValue = true;
        }
    });

    return returnValue;
});

$.validator.unobtrusive.adapters.add("requiredifpropertiesisnull", ['properties'], function (options) {
    options.rules["requiredifpropertiesisnull"] = options.params.properties.split(',');
    options.messages["requiredifpropertiesisnull"] = options.message;
});





// Allows us to say that field X is a required if field Y is not null.
// Example: The RegoExpiryMonth And RegoExpiryYear is required only when the Rego field is not null
$.validator.addMethod("requiredifpropertiesisnotnull", function (value, element, params) {

    var returnValue = true;

    $.each(params, function (index, parameter) {
        if ($('#' + parameter).val() != '' && value == '') {
            returnValue = false;
        }
    });

    return returnValue;
});

$.validator.unobtrusive.adapters.add("requiredifpropertiesisnotnull", ['properties'], function (options) {
    options.rules["requiredifpropertiesisnotnull"] = options.params.properties.split(',');
    options.messages["requiredifpropertiesisnotnull"] = options.message;
});








// Expiry date validation.
// monthproperty: this is the dropdown box that contains the value for the month
// yearproperty: this is the dropdown that contains the year the user is selecting
// isrequired: is a validexpiry date required for the form to be submitted.
$.validator.addMethod("validexpiry", function (value, element, params) {

    var id = $(element).attr('id');

    var month = $('#' + params.monthproperty).val()
    var year = $('#' + params.yearproperty).val()

    //    // if the expiry is required.
    //    if (params.isrequired == 'True') {

    //        // validating month and its empty but year is not
    //        if (month == '' && year != '' && id == params.monthproperty) {
    //            return false;
    //        }

    //        // validating month and its not empty but year is
    //        if (month != '' && year == '' && id == params.monthproperty) {
    //            return true;
    //        }

    //        // validating year and its empty but year is not
    //        if (month != '' && year == '' && id == params.yearproperty) {
    //            return false;
    //        }

    //        // validating year and its not empty but year is
    //        if (month == '' && year != '' && id == params.yearproperty) {
    //            return true;
    //        }

    //        if (month == '' && year == '') {
    //            return false;
    //        }
    //    }

    // otherwise if its not required then we only need to make sure the date is greater then today
    if (month != '' && year != '') {
        if (new Date(year, month, 1) <= new Date()) {
            return false;
        }
    }

    return true;
});

$.validator.unobtrusive.adapters.add("validexpiry", ['monthproperty', 'yearproperty', 'isrequired'], function (options) {
    options.rules["validexpiry"] = options.params;
    options.messages["validexpiry"] = options.message;
});







// CCV validation for client side. if its amex then it must have a length of 4
$.validator.addMethod("ccv", function (value, element, params) {

    if ($(element).parents('form').find('#CardType').val() == 'AmericanExpress') {
        if (value.length != 4) {
            return false;
        }
    }
    else {
        if (value.length != 3) {
            return false;
        }
    }

    return true;
});

$.validator.unobtrusive.adapters.add("ccv", {}, function (options) {
    options.rules["ccv"] = options.params;
    options.messages["ccv"] = options.message;
});






// makes sure that a checkbox is checked
$.validator.addMethod("istrue", function (value, element, params) {

    return ($(element).is(':checked'));
});

$.validator.unobtrusive.adapters.add("istrue", {}, function (options) {
    options.rules["istrue"] = options.params;
    options.messages["istrue"] = options.message;
});







// What is this used for?
// This function will validate other fields when another field is changed. This is usefull to give the user positive feedback
// when the validation requires more then 1 field
// For example when ExpiryMonth is changed then we automatically kick off the validation for ExpiryYear.
// Note: The validation for the extra elements will only be kicked off if they have been validated once before. This
// is to stop the behaviour where the user selects a expirymonth and then a error appears about the expiry date before they
// have even selected a expiry year
function validateField(id, fields) {

    // for main element when it is changed
    $('#' + id).on('keyup change blur', function () {

        // if it has been previously validated
        if ($('#' + id).data('validated')) {

            // remove any previous success class (because we are revalidating)
            $(this).parents('li').find('.success').addClass('hidden');

            // re-validate out main element to make sure its ok
            var success = $(this).val() != '' && jQuery($('#' + id)).valid();

            // then loop through each of the additional elements and check if they are valid
            // if one is not valid then the element group is not valid
            $.each(fields, function (index, field) {

                if ($('#' + field).data('validated')) {
      
                    if (!jQuery($('#' + field)).valid()) {
                        success = false;
                    }
                }
                else {
                    success = false;
                }
            });

            if (success) {
                $(this).parents('li').find('.success').removeClass('hidden');
            }
        }
    });
}


