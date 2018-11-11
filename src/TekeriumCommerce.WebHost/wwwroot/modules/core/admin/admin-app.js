(function() {
    var adminApp = angular.module('tekerAdmin', [
        'smart-table',
        'ngFileUpload',
        'ui.router',
        'ngFileUpload',
        'tekerAdmin.dashboard',
        'tekerAdmin.core',
        'tekerAdmin.catalog',
        ]);

    adminApp.config([
        '$urlRouterProvider', '$httpProvider',
        function ($urlRouterProvider, $httpProvider) {
            $urlRouterProvider.otherwise("/dashboard");

            $httpProvider.interceptors.push(function () {
                return {
                    request: function (config) {
                        if (/modules.*admin.*\.html/i.test(config.url)) {
                            var separator = config.url.indexOf('?') === -1 ? '?' : '&';
                            config.url = config.url + separator + 'v=' + window.Global_AssetVersion;
                        }

                        return config;
                    }
                };
            });
        }
    ]);
}());