module.exports = (function(out){
  "use strict";
  var _ = require('lodash'),
      request = require('request'),
      tools = require('../util/tools');

    var cache = {
    pages: {
      promise: null,
      apiPath: "/api/page",
      error: null,
      response: null,
      value: []
    }
  };

  var requestJson = tools.requestJson,
      pageData = {
        load: function(){
          var the = this;
          return requestJson(cache, 'pages').then(function(pages){
            the.allPages = pages;
            return the;
          });
        },
        pageByUrl: function(url){
          return _.where(this.allPages, { url: url})[0];
        },
        pageById: function(pageId){
          return _.where(this.allPages, { pageId: pageId })[0];
        }
      };

  _.mixin(pageData);

  return pageData;
})(console.out);