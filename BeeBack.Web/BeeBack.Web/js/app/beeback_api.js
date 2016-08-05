BEEBACK_API = {
    subscriptions: {
        add: function (activityId, success, error) {
            $.ajax({
                type: "POST",
                url: "api/subscription/" + activityId,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: success,
                error: error
            });
        },
        remove: function (activityId, succes, error) {
            $.ajax({
                type: "DELETE",
                url: "api/subscription/" + activityId,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: success,
                error: error
            });
        }
    }
}