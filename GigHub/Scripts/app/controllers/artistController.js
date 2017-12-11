var ArtistController = function (followService) {

    var button;

    var init = function (container) {
        $(container).on("click", ".js-toggle-follow", toggleFollow);
    };   

    var toggleFollow = function (e) {
        button = $(e.target);
        var followeeId = button.attr("data-user-id")

        if (button.text().trim() == "Follow?")
            followService.follow(followeeId, done, fail);
        else
            followService.unfollow(followeeId, done, fail);
    };

    var fail = function () {
        alert("Something failed");
    };    

    var done = function () {
        var text = (button.text() == "Following") ? "Follow?" : "Following";
        toggleClass(text);
    };

    var toggleClass = function (text) {
        button.toggleClass("btn-info").toggleClass("btn-default").text(text);
    };

    return {
        init: init
    }
}(FollowService);