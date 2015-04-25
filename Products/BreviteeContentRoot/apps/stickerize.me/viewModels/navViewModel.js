function navViewModel(el, app) {
    var model = new templates.navLinksModel();

    user.get().done(function (u) {
        model.addItem("home", function () {
            app.navigateTo("home");
        });
        
        if (u.isAuthenticated) {
            model.addItem("stickerize", function () {
                app.navigateTo("stickerizees");
            })
        }

        model.renderIn(el);
    });
}