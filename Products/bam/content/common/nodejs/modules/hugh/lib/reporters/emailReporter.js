var emailReporter = (function(){
    "use strict";

    var _ = require('lodash'),
        fs = require('fs'),
        events = require("events"),
        util = require('util'),
        notify = require('../messaging/notify'),
        q = require('q'),
        format = util.format,
        tools = require('../util/tools'),
        escape = tools.escape,
        clean = tools.clean,
        defaultEmailConfig = require('../config/defaultEmailConfig'),
        defaultConfig = {
            filePath: "./reports/testReport.html",
            reportEndpoint: null,
            outputStream: null,
            sendEmail: true
        };

    function getConfiguration(options){
        var config = _.extend({}, defaultConfig);
        if(!_.isUndefined(options)){
            _.extend(config, options);
        }
        config.outputStream = fs.createWriteStream(config.filePath);

        return config;
    }

    function getEmailConfiguration(options){
        var config = _.extend({}, defaultEmailConfig);
        _.extend(config, options);
        return config;
    }

    function sendEmail(stats, emailConfig, reporterConfig){
        var emailConf = _.extend({}, emailConfig);
        console.log('suites: ' + stats.suites + ", tests: " + stats.tests + ", passes: " + stats.passes + ", failures: " + stats.failures);
        console.log();
        console.log('Sending report: ' + reporterConfig.filePath);
        notify.by.email(emailConf);
    }

    function ctor(runner, options) {
        var the = this,
            stats = this.stats = { suites: 0, tests: 0, passes: 0, pending: 0, failures: 0},
            failures = this.failures = [],
            results = { tests: { passed: [], failed: [] }, stats: stats, uuid: _.uuid() },
            indents = 2,
            msgBody = '',
            summary = '',
            reporterConfig = getConfiguration(options),
            emailConfig = getEmailConfiguration(options.emailConfig);

        if (!runner) return;
        this.runner = runner;

        function indent() {
            return Array(indents).join('  ');
        }

        function writeBody(msg){
            msgBody += msg;
        }

        function writeSummary(msg){
            summary += msg;
        }

        runner.on('suite', function(suite){
            if (suite.root) return;
            stats.suites++;
            ++indents;
            console.log('%s%s', indent(), suite.title);
            writeBody(format('%s<section class="suite">', indent()));
            ++indents;
            writeBody(format('%s<h1>%s</h1>', indent(), escape(suite.title)));
            writeBody(format('%s<dl>', indent()));
        });

        runner.on('suite end', function(suite){
            if (suite.root) return;
            writeBody(format('%s</dl>', indent()));
            --indents;
            writeBody(format('%s</section>', indent()));
            --indents;
            if(1 == indents){}
            console.log();
        });

        runner.on('pending', function(test){
            console.log(format(indent() + ' - %s', test.title));
        });

        runner.on('pass', function(test){
            stats.passes++;
            stats.tests++;
            results.tests.passed.push(test.title);
            writeBody(format('PASSED - %s  <dt>%s</dt>', indent(), escape(test.title)));
            console.log(indent() + 'PASSED: ' + test.title);
        });

        runner.on('fail', function(test, err){
            stats.failures++;
            stats.tests++;
            test.err = err;
            var failure = {suite: test.parent.title, test: test.title, error: err};
            failures.push(failure);
            results.tests.failed.push(failure);
            writeBody(format('FAILED - %s  <dt class="error">%s</dt>', indent(), escape(test.title)));
            var code = escape(clean(test.fn.toString()));
            writeBody(format('%s  <dd class="error"><pre><code>%s</code></pre></dd>', indent(), code));
            writeBody(format('%s  <dd class="error">%s</dd>', indent(), escape(err)));
            console.log(indent() + 'FAILED: ' + test.title);
        });

        runner.on('end', function(){
            writeSummary('<br/><div>suites: ' + stats.suites + ", tests: " + stats.tests + ", passes: " + stats.passes + ", failures: " + stats.failures + "</div>");
            if(failures.length > 0){
                writeSummary('<h2>Failures</h2><ol>');
                failures.forEach(function(failureInfo){
                    var info = '<div><h3>' + failureInfo.suite + '</h3><p>' + failureInfo.test + ': -<br/>' + failureInfo.error + '</p></div>';
                    writeSummary('<li>' + info + '</li>');
                });
                writeSummary('</ol><br />');
            }
            emailConfig.html = summary + msgBody;
            sendEmail(stats, emailConfig, reporterConfig);
            //if(!_.isNull(reporterConfig.reportEndpoint)){
            //    tools.postJson(results, reporterConfig.reportEndpoint).then(function(){
            //        sendEmail(stats, emailConfig, reporterConfig);
            //    });
            //}else{
            //    sendEmail(stats, emailConfig, reporterConfig);
            //}
        })
    }

    return {
        ctor: ctor
    }
})();
exports = module.exports = emailReporter;
