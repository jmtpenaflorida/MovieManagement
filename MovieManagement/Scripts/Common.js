var movieApp = angular.module('movieApp', ['angular-loading-bar', 'ui.grid']);

movieApp.config(['cfpLoadingBarProvider', function(cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = false;
}]);

function getApiServer() {
    return 'http://127.0.0.1:8080/api';
}


