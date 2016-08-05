UTIL = {
    exec: function (area, controller, action) {
        var ns = BEEBACK;
        action = (action === undefined) ? "init" : action;

        if (area !== "" && ns[area]
            && controller !== "" && ns[area][controller]
            && typeof ns[area][controller][action] == "function") {
            ns[area][controller][action]();
        }
    },

    init: function () {
        var body = document.body,
            area = body.getAttribute("data-area"),
            controller = body.getAttribute("data-controller"),
            action = body.getAttribute("data-action");

        if (area) {
            UTIL.exec("default", "common");
        } else {
            area = "default";
        }

        UTIL.exec(area, "common");
        UTIL.exec(area, controller);
        UTIL.exec(area, controller, action);
    }
};

$(document).ready(function () {
    UTIL.init();
});