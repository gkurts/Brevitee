module.exports = (function () {
  "use strict";
  return {
    //pageUrl: "engagement-rings/top-sidestone-engagement-rings",
    // or
    pageId: "Top Sidestone Engagement Rings",
    countries: [
      "us", "mx"
    ],
    languages: {
      us: ["en", "es"],
      mx: ["es"]
    },
    tests: function (testContext) {
      describe("Test the module test runner", function () {
        before(function(){
          testContext.info();
          testContext.goToPage();
        });

        it("test for " + testContext.countryName + " " + testContext.languageCode, function () {

          console.log("\t\tcountry code = " + testContext.countryCode + "; country name = " + testContext.countryName + "; language code = " + testContext.languageCode + "; example path: " + testContext.pathFor("example/path"));

          // put your test logic here
        });
      });
    }
  }
})();