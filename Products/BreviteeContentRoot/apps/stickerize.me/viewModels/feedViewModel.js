var feedViewModel = (function($, b, s){
    function feedViewModel(el) {
        this.view = {
            items: [],
            init: function () {
                var the = this;
                return $.Deferred(function(){
                    var prom = this;
                    s.getTestItems(8).then(function (r) {
                        the.items = r;
                        prom.resolve();
                    });
                }).promise();
            }
        }
    }

    return feedViewModel;
})(jQuery, bam, stickerize);