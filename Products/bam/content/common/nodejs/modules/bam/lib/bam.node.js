var nodeBam = (function(b){
    if(b.hasOwnProperty("invoke")){
        b.oldInvoke = b.invoke;
    }

    function setViewName(config){
        if(_.isString(config.view)){
            var vn = _.endsWith(config.url, "&") ? config.view: "&" + config.view;
            config.url = config.url + vn;
        }
    }

    function getInvokeConfig(args) {
        var strings = [];

        for (var i = 0; i < args.length; i++) {
            strings.push(JSON.stringify(args[i]));
        }
        var params = JSON.stringify(strings), /* stringifying twice */
            data = JSON.stringify({ jsonParams: params });

        return {
            content: data,
            method: 'POST',
            headers: {
                'Content-Type': "application/json; charset=utf-8"
            }
        };
    }

    b.invoke = function (className, method, args, format, options) {
        if (!$.isArray(args)) {
            var a = [];
            a.push(args);
            args = a;
        }

        var root = b.proxyRoot(b[className].proxyName),
            urlFormat = root + className + "/" + method + ".{0}?nocache=" + b.randomString(4) + "&",
            config = getInvokeConfig(args, urlFormat, format);

        $.extend(config, options);

        if(!crossDomain) {
            setViewName(config);
            return $.ajax(config).promise();
        }else {
            var url = _.format(urlFormat + "callback=?", "jsonp");
            config.url = url;
            setViewName(config);

            return $.getJSON(url, { jsonParams: config.data });
        }
    };
})(bam);

modules.exports = nodeBam;