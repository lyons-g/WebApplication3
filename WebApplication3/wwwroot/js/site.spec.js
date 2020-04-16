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



    describe("GetJSON_SimpleD", () => {
        it("should return data when the response is successful", () => {
            const mockResponse = "My mock chart data";

            // Mock the response of the ajax call in the method to be tested
            $.ajax = jest.fn().mockImplementation(() => {
                return Promise.resolve(mockResponse);
            });

            // Call the method to be tested
            const responsePromise = site.GetJSON_SimpleD();

            // Test the response promise. Note: Have to return here or the expect() will not catch error
            return responsePromise.then((responseData) => {
                expect(responseData).toEqual(mockResponse);
            });
        });

        it("should return error when the response fails", () => {
            const mockError = "My mock chart data";

            // Mock the response of the ajax call in the method to be tested
            $.ajax = jest.fn().mockImplementation(() => {
                return Promise.reject(mockError);
            });

            // Call the method to be tested
            const responsePromise = site.GetJSON_SimpleD();

            // Test the response promise. Note: Have to return here or the expect() will not catch error
            return responsePromise.catch((err) => {
                expect(err).toEqual(mockError);
            });
        });
    });
});