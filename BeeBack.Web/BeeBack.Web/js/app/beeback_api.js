BEEBACK_API = {
    subscriptions: {
        add: function (activityId, success, error) {
            $.ajax({
                type: "POST",
                url: "/api/subscription/add/" + activityId,
                dataType: "json",
                crossDomain: false,
                xhrFields: {
                    withCredentials: true
                },
                contentType: "application/json; charset=utf-8",
                success: success,
                error: error
            });
        },
        remove: function (activityId, success, error) {
            $.ajax({
                type: "POST",
                url: "/api/subscription/remove/" + activityId,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: success,
                error: error
            });
        }
    },
    activities: {
        trigger : function(activityId, success, error) {
            $.ajax({
                type: "POST",
                url: "/api/activities/trigger/" + activityId,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: success,
                error: error
            });
        }
    }
}