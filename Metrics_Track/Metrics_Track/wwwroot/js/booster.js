//Keep session alive
$(function () {
    var refreshTime = 60000*29;
    window.setInterval(function () {
        var url = '/dashboard/StayAlive';
        $.get(url);
    }, refreshTime);
});