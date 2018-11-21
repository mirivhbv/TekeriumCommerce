(function() {
    'use strict';

    angular
        .module('tekerAdmin.dashboard', [])
        .config([
            '$stateProvider', function($stateProvider) {
                $stateProvider.state('dashboard',
                    {
                        url: '/dashboard',
                        templateUrl: '/admin/dashboard-tpl'
                    });
            }
        ]);
})();