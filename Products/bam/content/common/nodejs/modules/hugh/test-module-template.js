module.exports = (function () {
  "use strict";
  return {
    //pageUrl: "/",
    // or
    pageId: "Homepage",
    countries: [
      "us",
      "mx"
    ],
    languages: {
      us: ["en"],
      mx: ["es"]
    },
    tests: function (testContext) {
      describe("the test", function () {
        before(function(){
          testContext.deleteCookies();
          testContext.goToPage();
        });

        it("should do normal test", function () {
          // test here
          console.log("country = " + testContext.countryCode + "; language = " + testContext.languageCode + ":: put your test logic here");
        });
      });
    }
  }
})();