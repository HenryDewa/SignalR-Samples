/// <reference path="Scripts/jquery-1.6.4.js" />
/// <reference path="Scripts/jquery.signalR.js" />
/// <reference path="Scripts/jquery-ui-1.8.18.js" />

$(function () {

    var hub = $.connection.moveShape;

    $.extend(hub, {
        shapeMoved: function (cid, l, r) {
            if ($.connection.hub.id !== cid)
            {
                $("#right").css({ left: r.x, top: r.y });
                $("#left").css({ left: l.x, top: l.y });
            }
        }
    });

    $.connection.hub.start();
});
