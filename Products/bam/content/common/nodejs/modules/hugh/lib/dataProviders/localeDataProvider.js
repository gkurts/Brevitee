module.exports = (function(out){
  "use strict";
  var _ = require('lodash'),
          request = require('request'),
          tools = require('../util/tools');

  var cache = {
    countries: {
      promise: null,
      apiPath: "/api/country",
      error: null,
      response: null,
      value: []
    },
    languages: {
      promise: null,
      apiPath: "/api/language",
      error: null,
      response: null,
      value: []
    },
    currencies:{
      promise: null,
      apiPath: "/api/currency",
      error: null,
      response: null,
      value: []
    }
  };

  var requestJson = tools.requestJson;

  var localeData = {
    out: out,
    dump: tools.dump,
    load: function(){
      var the = this;
      return requestJson(cache, 'countries').then(function(countries){
        the.countries = _.map(countries, function(country){
          return country.displayCode;
        });
        return requestJson(cache, 'languages').then(function(languages){
          the.languages = _.map(languages, function(language){
            return language.displayCode;
          });
          return requestJson(cache, 'currencies').then(function(currencies){
            the.currencies = _.map(currencies, function(currency){
              return currency.currencyCode;
            });
            return the;
          });          
        });         
      })
    },
    countryNameFor: function(countryCode){
        var the = this,
            countries = the.cache.countries.value,
            result = "not found";
        countries.forEach(function(country){
          if(country.displayCode === countryCode){
            result = country.countryName;
          }
        });
        return result;
    },
    languageCodesFor: function(countryCode){
      var the = this,
          languages = [];

      if(the.languages && the.languages[countryCode]) {
        if(!_.isArray(the.languages[countryCode])){
          throw {message: "languages." + countryCode + " was not an array as expected", toString: function(){return this.message;}}
        }

        languages = the.languages[countryCode];
      } else {
        the.languagesFor(countryCode).forEach(function(language){
          languages.push(language.displayCode);
        });
      }
      return languages;
    },
    languagesFor: function(countryCode){
      var the = this,
          countries = the.cache.countries.value,
          languages = [];

      countries.forEach(function(country){
         if(country.displayCode === countryCode){
           country.languages.forEach(function(language){
             languages.push(language);
           })
         }
      });
      return languages;
    },
    pathFor: function(path, countryCode, language){
      if(path === "/"){
        path = "";
      }
      if(language === ""){
        language = undefined;
      }
      if(_.isString(path) && _.isString(countryCode) && _.isUndefined(language)){
        return countryCode + "/" + path;
      }else if(_.isString(path) && _.isString(countryCode) && _.isString(language)){
        return countryCode + "/" + language + "/" + path;
      }
      return path;
    },
    cache: cache
  };
  
  _.mixin(localeData);
  
  return localeData;
})(console.log);