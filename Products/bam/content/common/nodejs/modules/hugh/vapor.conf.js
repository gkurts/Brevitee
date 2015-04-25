var hugh = require('./lib/hugh');

var config = {
    baseUrl: 'http://www.bluenile.com',
    seleniumServerJar: './node_modules/webdrvr/vendor/selenium.jar',
    seleniumArgs: ['-Dwebdriver.ie.driver=./node_modules/webdrvr/vendor/IEDriverServer.exe'],
    seleniumPort: 5555,

    chromeOnly: false,
    chromeDriver: './node_modules/webdrvr/vendor/chromedriver',
    allScriptsTimeout: 36000,

    framework: 'mocha',
    mochaOpts: {
        reporter: "spec",
        timeout: 550000 // ms
    },

    suites: {
        "vapor": ['hugh_modules/example-run.js']
    },
    capabilities: {
        browserName: 'chrome'
    },

    onPrepare: function () {
        browser.ignoreSynchronization = true;
        browser.manage().window().maximize();

        browser.baseLocaleUrl = browser.baseUrl;

        global.expect = require('./lib/config/setupChai')();
        global.Page = require('astrolabe').Page;

        protractor.waitTimeout = 55000;
    },

    framework: 'mocha',
    mochaOpts: {
        reporter: hugh.reporter,
        resultsEndpoint: 'http://localhost:9191/hugh/save',
        timeout: 55000 // ms
    }
};

exports.config = config;
process.on('uncaughtException', function (error) {
    console.log('\033[31m' + error.stack + '\033[91m');
});
