var stickerizables=(function(app, sys){
    "use strict";

    function setMessage(msg, type){
        if(_.isUndefined(type)){
            type = "success";
        }
        var $msg = $("#message"),
            classes = ["success", "info", "warning", "danger"];
        _.each(classes, function(v){
            $msg.removeClass("panel-" + v);
        });
        $msg.addClass("panel-" + type);
        $("h3", $msg).text(msg);
    }

    function getFormattedDate(date){
        return (date.getMonth() + 1).toString() + "/" + date.getDate() + "/" + date.getFullYear();
    }
    function setDateVisibility(page){
        if(page.name != "stickerizables"){
            $("#stickerizeDate").hide();
        }else{
            $("#stickerizeDate").show();
        }
    }

    function showStickerize(id){
        $("button[data-id=" + id +"][data-action=stickerize]").show();
        $("button[data-id=" + id +"][data-action=unstickerize]").hide();
    }

    function showUnstickerize(id){
        $("button[data-id=" + id +"][data-action=stickerize]").hide();
        $("button[data-id=" + id +"][data-action=unstickerize]").removeClass("hidden").show();
    }

    function setStickerizations(page){
        return $.Deferred(function(){
            var prom = this; // we're in the deferred
            if(!_.isUndefined(page.stickerizee) && !_.isNull(page.stickerizee)){
                var date = page.getSelectedDate(),
                    stickerizeeId = page.stickerizee.Id;

                sys.getStickerizations(date, stickerizeeId).done(function(r){
                    var $msg = $("#message");
                    if(!r.Success){
                        setMessage(r.Message, "danger");
                    }
                    page.stickerizations = {};
                    _.each(r.Result, function(v){
                        page.stickerizations[v.StickerizableId] = v;
                        if(v.IsUndone){
                            showStickerize(v.Id);
                        }else{
                            showUnstickerize(v.Id);
                        }
                    });
                    prom.resolve(page.stickerizations);
                });
            }else{
                prom.resolve({});
            }
        }).promise();
    }

    function setSelectedDate(date){ // gets attached to the stickerizables page
        this.selectedDate = date;
        this.selectedDateString = getFormattedDate(this.selectedDate);
    }

    function getSelectedDate(){
        if(_.isUndefined(this.selectedDate)){
            this.setSelectedDate(new Date());
        }

        return this.selectedDate;
    }

    function getSelectedDateString(){
        if(_.isUndefined(this.selectedDateString)){
            this.setSelectedDate(new Date());
        }

        return this.selectedDateString;
    }

    $(document).ready(function(){
        app.pageActivated("stickerizables", function(page, stickerizee){
                page.stickerizee = stickerizee;
                if(_.isUndefined(page.setSelectedDate)){
                    page.setSelectedDate = setSelectedDate;
                }

                if(_.isUndefined(page.getSelectedDate)){
                    page.getSelectedDate = getSelectedDate;
                }

                if(_.isUndefined(page.selectedDate)){
                    page.setSelectedDate(new Date());
                }

                if(_.isUndefined(page.getSelectedDateString)){
                    page.getSelectedDateString = getSelectedDateString;
                }

                app.appView("namedImage", {Size: 150, Name: stickerizee.Name, ImageSource: stickerizee.StickerizeeImageSource}, "#stickerizee");

                $("#stickerizeDate")
                    .text(page.selectedDateString)
                    .css("font-weight", "bold")
                    .css("cursor", "pointer")
                    .datepicker({orientation: "top"})
                    .on("changeDate", function(e){
                        page.setSelectedDate(e.date);
                        $(this).text(page.selectedDateString);
                        $("#stickerizeDate").datepicker("hide");
                    });

                $(window).off("scroll").on("scroll", function(e){
                    $("#stickerizeDate").datepicker("hide");
                });

            })
            .anyPageActivated(function(page, data){
                setDateVisibility(page);
            });

        app.onModelsAttached = function(){
            setStickerizations(this.pages[this.currentPage]);
        }
    });

    return {
        setMessage: setMessage,
        setStickerizations: setStickerizations
    }
})(bam.app("stickerize"), stickerize || {});
