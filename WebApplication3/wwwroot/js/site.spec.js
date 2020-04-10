// Load the file to be tested
const site = require("./site.js");
describe("testing site.js", () => {
  it("should set the FG percent in the input when there are values for FG made and FG attempted", () => {
    // Create values for test
    const madeFieldGoals = "5";
    const attemptedFieldGoals = "20";
    const expectedPercentFielGoals = String((5 / 20) * 100);

    // Create mock HTML for test. Could do this globally

    document.body.innerHTML =
      "<div>" +
      '  <input id="FGM" value="' +
      madeFieldGoals +
      '" />' +
      '  <input id="FGA" value="' +
      attemptedFieldGoals +
      '" />' +
      '  <input id="FGperC" value="0" />' +
      "</div>";

    // Call the method we are testing
    site.FGCx();
    // Test the result
    expect(document.getElementById("FGperC").value).toEqual(
      expectedPercentFielGoals
    );
  });
});
