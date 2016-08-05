BEEBACK = {
    // Default (no) area
    default: {
        // Logic common to the whole area
        common: {
            init: function () {
                toastr.options.closeButton = true;

                $(".subscribe").click(function () {
                    if ($(this).hasClass("subscribe-add")) {
                        var activityId = $(this).attr("data-activityId");
                        BEEBACK_API.subscriptions.add(activityId, function () {
                            toastr.success("Vous êtes abonné.");
                        }, function () {
                            toastr.warning("Nous n'avons pas pu vous abonner. Life is unfair, get used to it.")
                        });
                    } else if ($(this).hasClass("subscribe-remove")) {
                        var activityId = $(this).attr("data-activityId");
                        BEEBACK_API.subscriptions.remove(activityId, function () {
                            toastr.success("Vous êtes abonné.");
                        }, function () {
                            toastr.warning("Nous n'avons pas pu vous abonner. Life is unfair, get used to it.")
                        });
                    }
                });
            }
        }
    }
};
