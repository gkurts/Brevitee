var init = (function($, b){
    $(document).ready(function () {
        bam.app("stickerize").setPageTransitionFilter("current", "next", function (tx, d) {
            // tx is the transitionHandler which looks like this
            // {
            //      name: <string>,
            //      from: <string>, // the name of the page the transition is from
            //      to: <string>, // the name of the page the transition is to
            //      play: function(data), // plays the transition passing in optional data
            //      also triggers start and end events before and after play
            // }
            // analyze the data d to determine if the transition will be allowed or
            // directly analyze the state of the dom.
            // return false to stop the transition from current to next page
        })
        .pageActivated("home", function (page, data) {
            user.get().done(function(u){
                bam.exports.user = u;
                //if(u.isAuthenticated && u.loginCount == 1){
                //    page.app.transitionToPage("firstLogin");
                //}
            });
        });

        if(!bam.app("stickerize").betaWarning){
            alert("Please pardon the mess while we get things together for our beta");
            bam.app("stickerize").betaWarning = true;
        }
    });

    return {

    }
})(jQuery, bam);


