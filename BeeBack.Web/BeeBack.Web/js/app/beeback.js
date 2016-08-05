BEEBACK = {
    // Default (no) area
    default: {
        // Logic common to the whole area
        common: {
            init: function () {
                toastr.options.closeButton = true;

                $(".subscribe").click(function () {
                    var button = $(this);
                    var activityId = $(this).attr("data-activityId");
                    if ($(button).hasClass("subscribe-add")) {
                        BEEBACK_API.subscriptions.add(activityId, function () {
                            toastr.success("Vous êtes abonné.");
                            $(button).removeClass("subscribe-add").addClass("subscribe-remove");
                        }, function () {
                            toastr.warning("Nous n'avons pas pu vous abonner. Life is unfair, get used to it.");
                        });
                    } else if ($(button).hasClass("subscribe-remove")) {
                        BEEBACK_API.subscriptions.remove(activityId, function () {
                            toastr.success("Vous êtes abonné.");
                            $(button).removeClass("subscribe-remove").addClass("subscribe-add");
                        }, function () {
                            toastr.warning("Nous n'avons pas pu vous abonner. Life is unfair, get used to it.");
                        });
                    }
                });
            }
        }
    }
};
