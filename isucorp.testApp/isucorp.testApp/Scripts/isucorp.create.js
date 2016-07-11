$.extend({
    isuCorpSite: new function() {
        var self = this;

        self.initialize = function() {
            attachBehavior();

            initEditor();
        }

        var attachBehavior = function () {

            $('#BirthDay').datepicker();

            $('div#Text').Editor();

            $('#reservation-form').submit(function(event) {
                $('#Text').val($('div#Text').Editor('getText'));
            });

            $('#BirthDay').bind('keypress', allowDates);

            $('#Phone').bind('keypress', allowOnlyNumbers);

        };

        var allowOnlyNumbers = function (event) {
            if (event.keyCode == 8 || event.keyCode == 40 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||  // Allow: backspace, delete, tab, escape, and enter
                        (event.keyCode == 65 && event.ctrlKey === true) || // Allow: Ctrl+A
                        (event.keyCode == 67 && event.ctrlKey === true) || // Allow: Ctrl+C
                        (event.keyCode == 86 && event.ctrlKey === true) /*|| // Allow: Ctrl+C
                        (event.keyCode >= 35 && event.keyCode < 39)*/) // Allow: home, end, left, right
            {
                return; // let it happen, don't do anything
            }
            else {
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode >= 97)) {  // Ensure that it is a number and stop the keypress
                    event.preventDefault();
                }
            }
        };

        var allowDates = function (event) {
            if (event.keyCode == 47  || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||  // Allow: backspace, delete, tab, escape, and enter
                        (event.keyCode == 65 && event.ctrlKey === true) || // Allow: Ctrl+A
                        (event.keyCode == 67 && event.ctrlKey === true) || // Allow: Ctrl+C
                        (event.keyCode == 86 && event.ctrlKey === true) /*|| // Allow: Ctrl+C
                        (event.keyCode >= 35 && event.keyCode <= 39)*/) // Allow: home, end, left, right
            {
                return; // let it happen, don't do anything
            }
            else {
                if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode >= 97)) {  // Ensure that it is a number and stop the keypress
                    event.preventDefault();
                }
            }
        };

        var initEditor = function() {
            $('div#Text').Editor('setText', $('#Text').val());
        }
        
    }
});

$(function () {
    $.isuCorpSite.initialize();
})