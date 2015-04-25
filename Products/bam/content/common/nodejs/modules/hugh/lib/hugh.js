var hugh = (function(cout){
  "use strict";

  var _ = require('lodash'),
          localeData = require("./dataProviders/localeDataProvider"),
          pageData = require("./dataProviders/pageDataProvider"),
          out = cout;

  function goToPage(page){
    var the = this;
    if(!_.isUndefined(page) && _.isFunction(page.go) && page.url){
      return page.go(_.pathFor(page.url, the.countryCode, the.languageCode));
    }else{
      if(!_.isObject(the.page)){
        the.page = Page.create({
          url: { value: browser.baseUrl }
        })
      }
      if(_.isObject(the.pageData)){
        the.pageId = the.pageData.pageId;
        the.pageUrl = the.pageById(the.pageId).url;
      }
      if(_.isString(the.pageId)){
        the.pageUrl = the.pageById(the.pageId).url;
      }
      if(!_.isString(the.pageUrl)){
        the.pageUrl = "/"
      }
      return the.page.go(_.pathFor(the.pageUrl, the.countryCode, the.languageCode));
    }
  }

  function deleteCookies(){
    browser.driver.manage().deleteAllCookies();
  }

  function localeTests(){
    var the = this,
        countryCodeTests = [],
        countrySpecificTests = [],
        initResult = null,
        runLocaleTests = function() {
          the.countries.forEach(function (countryCode) {
            the.languageCodesFor(countryCode).forEach(function (languageCode) {
              countryCodeTests.push(function () {
                var test = _.extend({}, the);
                test.countryCode = countryCode;
                test.countryName = the.countryNameFor(countryCode);
                test.languageCode = languageCode;
                test.tests(test);
              });
            });
          });

          the.cache.countries.value.forEach(function (country){
            var countryName = the.countryNameFor(country.displayCode),
                    countrySpecificTestName = _.camelCase(countryName, ' ') + "Test";
            if (_.isFunction(the[countrySpecificTestName])) {
              the.languageCodesFor(country.displayCode).forEach(function (languageCode) {
                countrySpecificTests.push(function (){
                  var countrySpecificTest = _.extend({}, the);
                  countrySpecificTest.countryCode = country.displayCode;
                  countrySpecificTest.countryName = countryName;
                  countrySpecificTest.languageCode = languageCode;
                  countrySpecificTest[countrySpecificTestName](countrySpecificTest);
                });
              });
            }
          });

          countryCodeTests.concat(countrySpecificTests).forEach(function(test){
            test();
          });
        };

    if(_.isFunction(the.initCountries)){
      initResult = the.initCountries();
    }
    if(initResult !== null && _.isFunction(initResult.then)){
      initResult.then(function(){
        runLocaleTests();
      })
    }else{
      runLocaleTests();
    }
  }

  function pageTests(){
    var the = this,
        pageTests = [],
            initResult = null,
        runPageTests = function(){
          the.pages.forEach(function(page){
            pageTests.push(function(){
              var test = _.extend({}, the);
              test.pageData = page;
              test.tests(test);
            })
          });
          pageTests.forEach(function(test){
            test();
          });
        };

    if(_.isUndefined(the.pages) || _.isNull(the.pages)){
      the.pages = pageData.allPages;
    }
    if(_.isFunction(the.initPages)){
      initResult = the.initPages();
    }
    if(initResult !== null && _.isFunction(initResult.then)){
      initResult.then(function(){
        runPageTests();
      })
    }else{
      runPageTests();
    }
  }

  function loadData(){
    return localeData.load().then(function () {
      return pageData.load();
    });
  }

  function createTestModule(module){
    var testModule = require(module),
        countries = testModule.countries || localeData.countries,
        languages = testModule.languages || localeData.languages;

    _.extend(testModule, localeData);
    _.extend(testModule, pageData);

    testModule.countries = countries;
    testModule.languages = languages;

    return testModule;
  }

  function pathFor(path){
    return localeData.pathFor(path, this.countryCode, this.languageCode);
  }

  var base = { // the base object for test modules
    goToPage: goToPage,
    localeTests: localeTests,
    pageTests: pageTests,
    deleteCookies: deleteCookies,
    loadData: loadData,
    info: function(){
      cout("\t\t" + this.countryName + " (" + this.countryCode + "-" + this.languageCode + ")");
    }
  };

  function run(options) {
    var moduleNames = [],
        countries = null,
        languages = null,
        testType = options.testType || "locale";
    if(_.isObject(options)){
      // get country config
      if(_.isString(options.countryConfig)){ // path to country config module
        var countryConfig = require(options.countryConfig);
        countries = countryConfig.countries;
        languages = countryConfig.languages;
      }
      // get module definition file
      if(_.isString(options.moduleConfig)){
        moduleNames = require(options.moduleConfig);
        if(!_.isArray(moduleNames)){
          throw new Error("module " + options.moduleConfig + " did not contain an array of module names");
        }
      }

      if(_.isArray(options.modules)){
        moduleNames = moduleNames.concat(options.modules);
      }
    }

    if(moduleNames.length === 0){
      out("no modules specified");
      return;
    }

    describe("running tests for modules: " + moduleNames.join(", "), function(){
      var testContexts = [];
      before(function(){
        return loadData().then(function(){
          moduleNames.forEach(function(moduleName){
            var module = createTestModule(moduleName);
            if(!_.isNull(countries)){
              module.countries = countries;
            }
            if(!_.isNull(languages)){
              module.languages = languages;
            }
            module.pathFor = pathFor;
            testContexts.push(module);
          })
        })
      });

      it("running locale tests", function(){
        testContexts.forEach(function(testContext){
          var test = _.extend(base, testContext);
          test[testType + "Tests"]();
        })
      })
    });
  }

  var reporter = require('./reporters/emailReporter').ctor;
  return {
    run: run,
    verify: function(){
        cout("all good");
    },
    reporter: reporter
  }
})(console.log);

module.exports = hugh;