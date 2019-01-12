(function () {
    angular.module('tekerAdmin.catalog')
        .factory('brandService', brandService);

    /* @ngInject */
    function brandService($http, Upload) {
        var service = {
            getBrand: getBrand,
            getBrands: getBrands,
            createBrand: createBrand,
            editBrand: editBrand,
            deleteBrand: deleteBrand
        };

        return service;

        function getBrand(id) {
            return $http.get('api/brands/' + id);
        }

        function getBrands() {
            return $http.get('api/brands');
        }

        function createBrand(brand, brandImage) {
            return Upload.upload({
                url: 'api/brands',
                data: {
                    brand: brand,
                    brandImage: brandImage
                }
            });
            // return $http.post('api/brands', brand);
        }

        function editBrand(brand, brandImage) {
            return Upload.upload({
                url: 'api/brands/' + brand.id,
                method: 'PUT',
                data: {
                    brand: brand,
                    brandImage: brandImage
                }
            });
            //return $http.put('api/brands/' + brand.id, brand);
        }

        function deleteBrand(brand) {
            return $http.delete('api/brands/' + brand.id, null);
        }
    }
})();