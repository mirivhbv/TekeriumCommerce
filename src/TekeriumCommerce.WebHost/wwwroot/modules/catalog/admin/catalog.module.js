(function () {
    'use strict';

    angular.module('tekerAdmin.catalog', [])
        .config(['$stateProvider',
            function ($stateProvider) {
                $stateProvider
                    .state('brand',
                        {
                            url: '/brand',
                            templateUrl: 'modules/catalog/admin/brand/brand-list.html',
                            controller: 'BrandListCtrl as vm'
                        })
                    .state('brand-create',
                        {
                            url: '/brand/create',
                            templateUrl: 'modules/catalog/admin/brand/brand-form.html',
                            controller: 'BrandFormCtrl as vm'
                        })
                    .state('brand-edit',
                        {
                            url: '/brand/edit/:id',
                            templateUrl: 'modules/catalog/admin/brand/brand-form.html',
                            controller: 'BrandFormCtrl as vm'
                        })
                    .state('tyre',
                        {
                            url: '/tyre',
                            templateUrl: 'modules/catalog/admin/tyre/tyre-list.html',
                            controller: 'TyreListCtrl as vm'
                        })
                    .state('tyre-add',
                        {
                            url: '/tyre-add',
                            templateUrl: 'modules/catalog/admin/tyre/tyre-form.html',
                            controller: 'TyreFormCtrl as vm'
                        })
                    .state('category',
                        {
                            url: '/category',
                            templateUrl: 'modules/catalog/admin/category/category-list.html',
                            controller: 'CategoryListCtrl as vm'
                        })
                    .state('category-edit',
                        {
                            url: '/category/edit/:id',
                            templateUrl: 'modules/catalog/admin/category/category-form.html',
                            controller: 'CategoryFormCtrl as vm'
                        })
                    .state('category-create',
                        {
                            url: '/category/create',
                            templateUrl: 'modules/catalog/admin/category/category-form.html',
                            controller: 'CategoryFormCtrl as vm'
                        })
                    .state('product',
                        {
                            url: '/product',
                            templateUrl: 'modules/catalog/admin/product/product-list.html',
                            controller: 'ProductListCtrl as vm'
                        })
                    .state('product-edit',
                        {
                            url: '/product/edit/:id',
                            templateUrl: 'modules/catalog/admin/product/product-form.html',
                            controller: 'ProductFormCtrl as vm'
                        })
                    .state('product-create',
                        {
                            url: '/product/edit',
                            templateUrl: 'modules/catalog/admin/product/product-form.html',
                            controller: 'ProductFormCtrl as vm'
                        });
            }]);
})();