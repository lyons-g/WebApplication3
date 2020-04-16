// Creating global mocks for testing
const jquery = function () {
    return {
        click: () => { },
    };
};
jquery.ajax = function () {
    return {};
};
global.$ = jquery;

global.Chart = {
    defaults: {
        scale: {
            ticks: {},
        },
    },
};