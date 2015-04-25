var addStickerizeeFormViewModel = (function ($, b, s) {
    /**
    */
    function addStickerizeeFormViewModel(el, app) {
        var the = this,
            a = app;
        this.view = {

            //init: function () {

            //}
        };

        this.model = _.observe({
            name: "Add Stickerizee",
            gender: "Male",
            add: function () {
                var name = the.model.name(),
                    gender = the.model.gender();

                s.addStickerizee(name, gender).then(function(){
                    a.refresh($("#stickerizees"));
                });
            }
        });
    }

    return addStickerizeeFormViewModel;
})(jQuery, bam, stickerize);
