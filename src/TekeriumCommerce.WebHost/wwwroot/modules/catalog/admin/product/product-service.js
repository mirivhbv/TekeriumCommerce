(function() {
    angular.module('tekerAdmin.catalog').factory('productService', productService);

    function productService($http, Upload) {
        var service = {
            getProduct: getProduct,
            getProducts: getProducts,
            createProduct: createProduct
        };

        return service;

        function getProduct(id) {
            return $http.get('api/products/' + id);
        }

        function getProducts(params) {
            return $http.post('api/products/grid', params);
        }

        function createProduct(product, thumbnailImage, productImages, productDocuments) {
            return Upload.upload({
                url: 'api/products',
                data: {
                    product: product,
                    thumbnailImage: thumbnailImage,
                    productImages: productImages,
                    productDocuments: productDocuments
                }
            });
        }
    }
})();