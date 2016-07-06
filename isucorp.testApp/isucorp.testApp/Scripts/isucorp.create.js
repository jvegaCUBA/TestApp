$.extend({
    isuCorpSite: new function() {
        var self = this;

        self.initialize = function() {
            attachBehavior();
        }

        var attachBehavior = function () {

            $('#BirthDay').datepicker();

            $('#Text').Editor();
        };
        
    }
});

$(function () {
    $.isuCorpSite.initialize();
})