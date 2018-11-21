(function() {
    angular
        .module('tekerAdmin.catalog')
        .controller('BrandListCtrl', BrandListCtrl);

    function BrandListCtrl(brandService) {
        var vm = this;
        vm.brands = [];

        vm.getBrands = function getBrands() {
            brandService.getBrands().then(function(result) {
                vm.brands = result.data;
            });
        };

        // done! todo: delete section
        vm.deleteBrand = function deleteBrand(brand) {
            bootbox.confirm('Are you sure you want to delete this brand: ' + brand.name, function (result) {
                if (result) {
                    brandService.deleteBrand(brand)
                        .then(function (result) {
                            vm.getBrands();
                            toastr.success(brand.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            });
        };

        vm.getBrands();
    }
})();