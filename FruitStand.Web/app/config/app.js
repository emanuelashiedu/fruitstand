var app = angular.module('FruitStandApp', ['ui.router',
                                           'LocalStorageModule',
                                           'ngSanitize',
                                           'ngMask',
                                           'fruit']);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorSvc');
});