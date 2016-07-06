$.extend({
    isuCorpSite: new function() {
        var self = this;

        self.initialize = function() {
            attachBehavior();
        }

        var attachBehavior = function () {
            $('#sortExp').bind('change', function() {
                window.location.href = updateQueryStringParameter(window.location.href, "sortExp", $(this).val());
            });

            $('.ranking').barrating({
                theme: 'bootstrap-stars',
                onSelect: function (value, text, event, objectId) {
                    $.ajax({
                        type: 'POST',
                        url: '/Home/SetRanking',
                        cache: false,
                        dataType: 'json',
                        data: {
                            ReservationId: objectId,
                            Ranking: value
                        },
                        success: function(data) {
                            
                        },
                        error: function() {
                            
                        }
                    });
                }
            });

            $('.favourite').bind('click', function () {
                var element = this;
                var objectId = $(this).attr('objectId');
                var isFavoriteOn = $('.heart',this).hasClass('heart-on');

                $.ajax({
                    type: 'POST',
                    url: '/Home/SetToFavourite',
                    cache: false,
                    dataType: 'json',
                    data: {
                        ReservationId: objectId,
                        Favourite: !isFavoriteOn
                    },
                    success: function (data) {
                        if (data.success) {
                            if (data.favourite) {
                                $('.heart', element).removeClass('heart-off');
                                $('.heart', element).addClass('heart-on');
                            } else {
                                $('.heart',element).removeClass('heart-on');
                                $('.heart', element).addClass('heart-off');
                            }
                            
                        }
                    },
                    error: function () {

                    }
                });
            });

        };

        var updateQueryStringParameter = function(uri, key, value) {
            var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
            var separator = uri.indexOf('?') !== -1 ? "&" : "?";
            if (uri.match(re)) {
                return uri.replace(re, '$1' + key + "=" + value + '$2');
            }
            else {
                return uri + separator + key + "=" + value;
            }
        }
    }
});

$(function () {
    $.isuCorpSite.initialize();
})