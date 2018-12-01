(function() {
    'use strict';

    angular.module('tekerAdmin.shipping', [])
        .config([
            '$stateProvider', function($stateProvider) {
                $stateProvider
                    .state('city',
                        {
                            url: '/city',
                            templateUrl: 'modules/shipping/admin/city/city-list.html',
                            controller: 'CityListCtrl as vm'
                        })
                    .state('city-create',
                        {
                            url: '/city/create',
                            templateUrl: 'modules/shipping/admin/city/city-form.html',
                            controller: 'CityFormCtrl as vm'
                        })
                    .state('city-edit',
                        {
                            url: '/city/edit/:id',
                            templateUrl: 'modules/shipping/admin/city/city-form.html',
                            controller: 'CityFormCtrl as vm'
                        })
            }
        ])
})();