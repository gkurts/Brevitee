var notify = (function(){
    "use strict";
    var _ = require("lodash"),
        tools = require("../util/tools"),
        mailer = require('nodemailer'),
        defaultConfig = require('../config/defaultEmailConfig');

    return {
        by: {
            email: function(options){
                var transportConfig = _.extend({ host: defaultConfig.defaultHost, tls: defaultConfig.defaultTls }, options),
                    emailConfig = _.extend({
                        from: defaultConfig.defaultFrom,
                        to: defaultConfig.defaultTo,
                        subject: defaultConfig.defaultSubject,
                        out: console.log
                    }, options);

                return _.promise(function(resolve){
                    var transport = mailer.createTransport(transportConfig);
                    transport.sendMail(emailConfig, function(err, info){
                        if(!_.isNull(err) && !_.isUndefined(err)){
                            emailConfig.out(err);
                        }
                        if(!_.isNull(info) && !_.isUndefined(info)){
                            emailConfig.out(info);
                        }
                        resolve({error: err, info: info});
                    })
                });
            },
            httpPost: function(options){

            }
        }
    }
})();

module.exports = notify;