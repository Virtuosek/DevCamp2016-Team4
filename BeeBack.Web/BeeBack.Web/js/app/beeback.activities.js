BEEBACK.default.activities = {
    indexViewModel : {
        
    },
    index:  function() {

    },
    details : function() {
        $(".activity-trigger").click(function() {
            var activityId = $(".activity").attr("data-activityId");
            BEEBACK_API.activities.trigger(activityId, function() {
                toastr.success("Notification déclenchée.");
            }, function() {
                toastr.warning("Quelque chose est cassé.");
            });
        });
    }
}