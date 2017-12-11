var GigsController = function (attendaceService, followService) {

    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };

    var toggleAttendance = function (e) {
        button = $(e.target);

        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-default"))
            attendaceService.createAttendance(gigId, done, fail);
        else
            attendaceService.deleteAttendance(gigId, done, fail);
    };   

    var fail = function () {
        alert("Something failed");
    };

    var done = function () {
        var text = (button.text().trim() == "Going") ? "Going?" : "Going";
        toggleClass(text);
    };

    var toggleClass = function (text) {
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    return {
        init: init
    }
}(AttendaceService);