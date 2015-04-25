module.exports = (function(_){
  "use strict";

  function textOf(el){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return el.getTagName().then(function(tagName){
      if(tagName === "input"){
        return el.getAttribute('value');
      }else{
        return el.getText();
      }
    });
  }

  function dragRightAction(el, pixels){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return browser.actions().dragAndDrop(el, {x: pixels, y: 0});
  }

  /**
   * Drag the specified element to the right
   * by the specified number of pixels
   * @param el
   * @param pixels
   * @returns {*}
   */
  function dragRight(el, pixels){
    return dragRightAction(el, pixels).perform();
  }

  function dragLeftAction(el, pixels){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return browser.actions().dragAndDrop(el, {x: -pixels, y: 0})
  }
  /**
   * Drag the specified element to the left
   * by the specified number of pixels
   * @param el
   * @param pixels
   * @returns {*}
   */
  function dragLeft(el, pixels){
    return dragLeftAction(el, pixels).perform();
  }

  function dragDownAction(el, pixels){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return browser.actions().dragAndDrop(el, {x: 0, y: pixels})
  }

  /**
   * Drag the specified element down
   * by the specified number of pixels
   * @param el
   * @param pixels
   * @returns {*}
   */
  function dragDown(el, pixels){
    return dragDownAction(el, pixels).perform();
  }

  function dragUpAction(el, pixels){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return browser.actions().dragAndDrop(el, {x: 0, y: -pixels});
  }

  /**
   * Drag the specified element up by
   * the specified number of pixels
   * @param el
   * @param pixels
   */
  function dragUp(el, pixels){
    return dragUpAction(el, pixels).perform();
  }

  function clickAction(el){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return browser.actions().click(el);
  }

  function click(el){
    return clickAction(el).perform();
  }

  function sendKeysAction(el, keys){
    if(_.isString(el)){
      el = element(by.css(el));
    }
    return browser.actions().sendKeys(el, keys);
  }

  function sendKeys(el, keys){
    return sendKeys(el, keys).perform();
  }

  function waitFor(fn, comparatorFn) {
    var comparatorFn = comparatorFn || getPageIdentifier;
    return comparatorFn().then(function (beforeActionIdentifier) {
      return fn().then(function () {
        return browser.wait(function () {
          return areIdentifiersDifferent(beforeActionIdentifier, comparatorFn);
        },protractor.waitTimeout).then(function () {
          return waitForBrowserReadyState();
        });
      });
    });
  }
  function areIdentifiersDifferent(startIdentifier, comparatorFn) {
    return comparatorFn().then(function (newIdentifier) {
      return newIdentifier !== startIdentifier;
    });
  }
  // Get an identifier for a page that should be unique pageId + currentUrl
  function getPageIdentifier(page){
    if(_.isUndefined(page)){
      page = Page.create({
        url: { value: browser.baseUrl }
      })
    }
    return page.getPageId().then(function (pageId) {
      return browser.getCurrentUrl().then(function (url) {
        return pageId + url;
      });
    });
  }

  function waitForBrowserReadyState() {
    return browser.executeScript(
            "function addLoadedElement() {                                                                \
              if(document.readyState === 'interactive' || document.readyState === 'complete') {           \
                var div = document.createElement('div');                                                  \
                div.id = 'page-done-loading-for-test-purposes';                                           \
                document.body.appendChild(div);                                                           \
                document.removeEventListener('readystatechange', addLoadedElement);                       \
                return true;                                                                              \
              }                                                                                           \
              return false;                                                                               \
            }                                                                                             \
            if(!document.getElementById('page-done-loading-for-test-purposes') && !addLoadedElement()) {  \
              document.addEventListener('readystatechange', addLoadedElement);                            \
            }").then(function () {
              return browser.wait(function () {
                return element.all(by.css('#page-done-loading-for-test-purposes')).count().then(function (count) {
                  if (count > 0) {
                    return true;
                  } else {
                    return false;
                  }
                });
              },protractor.waitTimeout).then(function () {
                return true;
              });
            });
  }

  var ui = {
    dragRight: dragRight,
    dragLeft: dragLeft,
    dragDown: dragDown,
    dragUp: dragUp,
    click: click,
    sendKeys: sendKeys,
    actions: {
      dragRight: dragRightAction,
      dragLeft: dragLeftAction,
      dragDown: dragDownAction,
      dragUp: dragUpAction,
      sendKeys: sendKeysAction
    },
    waitFor: waitFor,
    textOf: textOf,
    getTextOf: textOf
  };

  _.mixin(ui);

  return ui;
})(require("lodash"));