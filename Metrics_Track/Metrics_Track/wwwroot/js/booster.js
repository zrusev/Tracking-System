//Keep session alive
$(function () {
    var refreshTime = 55000; //in milliseconds
    window.setInterval(function () {
        var url = '/dashboard/StayAlive';
        $.get(url);
    }, refreshTime);
});