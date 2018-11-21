(function() {
    angular.module('tekerAdmin.catalog').factory('productService', productService);

    function productService($http, Upload) {
        var service = {
            getProduct: getProduct,
            getProducts: getProducts,
            createProduct: createProduct,
            editProduct: editProduct,
            changeStatus: changeStatus,
            deleteProduct: deleteProduct
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

        function editProduct(product, thumbnailImage, productImages, productDocuments) {
            return Upload.upload({
                url: 'api/products/' + product.id,
                method: 'PUT',
                data: {
                    product: product,
                    thumbnailImage: thumbnailImage,
                    productImages: productImages,
                    productDocuments: productDocuments
                }
            });
        }

        function deleteProduct(product) {
            return $http.delete('api/products/' + product.id, null);
        }

        function changeStatus(product) {
            return $http.post('api/products/change-status/' + product.id, null);
        }
    }
})();