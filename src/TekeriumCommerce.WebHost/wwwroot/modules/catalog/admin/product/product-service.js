(function() {
    angular.module('tekerAdmin.catalog').factory('productService', productService);

    function productService($http, Upload) {
        var service = {
            getProducts: getProducts
        };

        return service;

        function getProducts(params) {
            return $http.post('api/products/grid', params);
        }
    }
})();