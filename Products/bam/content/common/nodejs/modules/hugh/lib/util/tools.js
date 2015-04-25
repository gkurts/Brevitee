var tools = (function(){
    var q = require("q"),
        _ = require('lodash'),
        request = require('request'),
        urllib = require('urllib-sync');

    function postJsonSync(url, data){
        return urllib.request(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            data: data
        });
    }

    function postJson(data, url){
        return promise(function(resolve, reject){
           request({
               url: url,
               method: "POST",
               json: true,
               headers: {
                   "content-type": "application/json"
               },
               body: JSON.stringify(data)
           }, function(err, resp, body){
               if(!err && resp.statusCode == 200){
                   resolve(JSON.parse(body));
               }else{
                   reject({error: err, response: resp});
               }
           })
        });
    }

    function requestJson(cache, cacheKey){ // countries, languages, currencies
        cache = _.extend({
            promise: null,
            apiPath: "/api/page",
            error: null,
            response: null,
            value: []
        }, cache);

        if(cache[cacheKey].promise !== null){
            return cache[cacheKey].promise;
        }
        var prom = new protractor.promise.Deferred();
        cache[cacheKey].promise = prom;
        if(cache.hasOwnProperty(cacheKey) && cache[cacheKey].value.length > 0){
            prom.fulfill(cache[cacheKey].value);
        }
        else {
            request(browser.baseUrl + cache[cacheKey].apiPath, function (error, response, body) {
                if (!error && response.statusCode == 200) {
                    cache[cacheKey].value = JSON.parse(body);
                    prom.fulfill(cache[cacheKey].value);
                }
                else {
                    var em = error ? error.toString() : "",
                        ex = {
                            message: "Api call failed for " + cacheKey + ": " + em,
                            toString: function () { return this.message; }
                        };
                    cache[cacheKey].error = error;
                    cache[cacheKey].response = response;
                    prom.reject(ex);
                    throw ex;
                }
            });
        }
        return prom;
    }

    function argsArray() {
        var args = [];
        for (var i = 0; i < arguments.length; i++) {
            args.push(arguments[i]);
        }
        return args;
    }

    function promise(fn) {
        var def = q.defer(),
            args = argsArray(arguments);
        fn(def.fulfill, def.reject, argsArray(_.rest(args)));
        return def.promise;
    }

    function readFile(path, options){
        return promise(function(resolve, reject){
            var fs = require('fs');
            fs.readFile(path, options, function(err, data){
                if(err){
                    reject(err);
                }else{
                    resolve(data);
                }
            })
        });
    }

    function propertiesToString(obj) {
        var txt = '';

        if (_.isArray(obj)) {
            _.each(obj, function (o) {
                txt += propsToString(o);
            })
        } else {
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) { // skip the prototype?
                    if (_.isArray(obj[prop])) {
                        _.each(obj[prop], function (o) {
                            txt += propsToString(o);
                        })
                    } else {
                        txt += prop + ": " + obj[prop] + '\r\n';
                    }
                }
            }
        }
        return txt;
    }

    function escape(html){
        return String(html)
            .replace(/&/g, '&amp;')
            .replace(/"/g, '&quot;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;');
    }

    function trim(str){
        return str.replace(/^\s+|\s+$/g, '');
    }

    function clean(str) {
        str = str
            .replace(/\r\n?|[\n\u2028\u2029]/g, "\n").replace(/^\uFEFF/, '')
            .replace(/^function *\(.*\)\s*{|\(.*\) *=> *{?/, '')
            .replace(/\s+\}$/, '');

        var spaces = str.match(/^\n?( *)/)[1].length
            , tabs = str.match(/^\n?(\t*)/)[1].length
            , re = new RegExp('^\n?' + (tabs ? '\t' : ' ') + '{' + (tabs ? tabs : spaces) + '}', 'gm');

        str = str.replace(re, '');

        return trim(str);
    }

    function uuid(){
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
            var r = Math.random()*16|0, v = c == 'x' ? r : (r&0x3|0x8);
            return v.toString(16);
        });
    }

    var t = {
        dump: function (obj) {
            console.log(propertiesToString(obj));
        },
        argsArray: argsArray,
        promise: promise,
        propertiesToString: propertiesToString,
        propsToString: propertiesToString,
        props: propertiesToString,
        escape: escape,
        trim: trim,
        clean: clean,
        uuid: uuid,
        postJson: postJson,
        postJsonSync: postJsonSync,
        readFile: readFile,
        requestJson: requestJson
    };

    _.mixin(t);
    return t;
})();

module.exports = tools;