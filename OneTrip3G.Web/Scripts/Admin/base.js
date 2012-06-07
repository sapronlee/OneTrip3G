$(document).ready(function () {
    global.setMainAndSidebarHeight();
});
$(window).resize(function () {
    global.setMainAndSidebarHeight();
});

var global = {
    setMainAndSidebarHeight: function () {
        var minHeight = $(window).height() - $("header").height() - 3;
        var mainHeight = $("#main").height();
        var sidebarHeight = $("#sidebar").height();
        var toolbarHeight = $("#toolbar").height();

        mainHeight = mainHeight > sidebarHeight ? mainHeight : sidebarHeight;

        if (mainHeight > minHeight) {
            $("#main").height(mainHeight);
            $("#sidebar").height(mainHeight);
        } else {
            $("#main").height(minHeight);
            $("#sidebar").height(minHeight);
            $(".main-container").height(minHeight - toolbarHeight);
        }
    }
}