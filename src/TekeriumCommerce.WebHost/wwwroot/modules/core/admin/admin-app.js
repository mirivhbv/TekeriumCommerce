(function() {
    var adminApp = angular.module('tekerAdmin', [
        'smart-table',
        'ngFileUpload',
        'ngMaterial',
        'ui.router',
        'ui.bootstrap',
        'ui.bootstrap.datetimepicker',
        'ngFileUpload',
        'summernote',
        'tekerAdmin.common',
        'tekerAdmin.dashboard',
        'tekerAdmin.core',
        'tekerAdmin.catalog',
        'tekerAdmin.shipping',
        'tekerAdmin.orders'
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