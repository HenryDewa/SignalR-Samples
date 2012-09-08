/// <reference path="Scripts/jquery-1.8.0.js" />
/// <reference path="Scripts/jquery.signalR-0.5.3.js" />
/// <reference path="Scripts/jquery-ui-1.8.23.js" />

$(function () {

    var cn = $.hubConnection();
    var hub = cn.createProxy('moveShape');

    hub.on('shapeMoved', function (cid, l, r) {
        if ($.connection.hub.id !== cid) {
            $("#right").css({ left: r.x, top: r.y });
            $("#left").css({ left: l.x, top: l.y });
        }
    });

    cn.start().done(function () {
    });
});
