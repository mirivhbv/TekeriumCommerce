(function () {
    'use strict';

    angular.module('tekerAdmin.core', [])
        .config([
            '$stateProvider', function ($stateProvider) {
                $stateProvider
                    .state('users',
                        {
                            url: '/users',
                            templateUrl: 'modules/core/admin/user/user-list.html',
                            controller: 'UserListCtrl as vm'
                        })
                    .state('user-create',
                        {
                            url: '/user/create',
                            templateUrl: '/modules/core/admin/user/user-form.html',
                            controller: 'UserFormCtrl as vm'
                        })
                    .state('user-edit',
                        {
                            url: '/user/edit/:id',
                            templateUrl: '/modules/core/admin/user/user-form.html',
                            controller: 'UserFormCtrl as vm'
                        });
            }
        ]);
})();