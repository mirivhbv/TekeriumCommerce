(function ($) {
    angular
        .module('tekerAdmin.catalog')
        .controller('ProductFormCtrl', ProductFormCtrl);

    function ProductFormCtrl($state, $timeout, $stateParams, $http, categoryService, productService, summerNoteService, brandService, tyreService) {
        var vm = this;

        // declare shoreDescription and description for summernote
        vm.product = { shortDescription: '', description: '', specification: '', isPublished: true, price: 0 };
        vm.product.categoryId = 0;
        vm.categories = [];
        vm.thumbnailImage = null;
        vm.productImages = [];
        vm.productDocuments = [];
        vm.productId = $stateParams.id;
        vm.isEditMode = vm.productId > 0;
        vm.brands = [];
        vm.seasons = [];

        vm.selectedSeason = null;

        vm.sel = null;

        // testing mapping size:
        vm.widths = [];
        vm.profiles = [];
        vm.rims = [];

        vm.selectedWidth = {};
        vm.selectedProfile = {};
        vm.selectedRim = {};

        vm.catUpdate = function (id) {
            tyreService.getWidths(id).then(result => {
                vm.widths = result.data;
                vm.profiles = {};
                vm.rims = {};

                vm.selectedWidth = {};
                vm.selectedProfile = {};
                vm.selectedRim = {};
            });
        }

        vm.selectedWidthChange = function () {
            vm.profiles = vm.selectedWidth.profiles;
            vm.rims = [];

            vm.selectedProfile = {};
            vm.selectedRim = {};
        }

        vm.selectedProfileChange = function () {
            vm.rims = vm.selectedProfile.rimSizes;
            vm.selectedRim = {};
        }

        vm.datePickerSpecialPriceStart = {};
        vm.datePickerSpecialPriceEnd = {};

        vm.updateSlug = function () {
            vm.product.slug = slugify(vm.product.name);
        };

        vm.openCalendar = function (e, picker) {
            vm[picker].open = true;
        };

        vm.shortDescUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.shortDescEditor).summernote('insertImage', response.data);
                });
        };

        vm.descUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.descEditor).summernote('insertImage', response.data);
                });
        };

        vm.specUpload = function (files) {
            summerNoteService.upload(files[0])
                .then(function (response) {
                    $(vm.specEditor).summernote('insertImage', response.data);
                });
        };

        vm.removeImage = function removeImage(media) {
            var index = vm.product.productImages.indexOf(media);
            vm.product.productImages.splice(index, 1);
            vm.product.deletedMediaIds.push(media.id);
        };

        vm.removeDocument = function removeDocument(media) {
            var index = vm.product.productDocuments.indexOf(media);
            vm.product.productDocuments.splice(index, 1);
            vm.product.deletedMediaIds.push(media.id);
        };

        vm.save = function save() {
            var promise;

            // ng-upload will post null as text
            vm.product.brandId = vm.product.brandId === null ? '' : vm.product.brandId;
            vm.product.oldPrice = vm.product.oldPrice === null ? '' : vm.product.oldPrice;
            vm.product.specialPrice = vm.product.specialPrice === null ? '' : vm.product.specialPrice;
            vm.product.specialPriceStart = vm.product.specialPriceStart === null ? '' : vm.product.specialPriceStart;
            vm.product.specialPriceEnd = vm.product.specialPriceEnd === null ? '' : vm.product.specialPriceEnd;
            vm.product.metaTitle = vm.product.metaTitle === null ? '' : vm.product.metaTitle;
            vm.product.metaKeywords = vm.product.metaKeywords === null ? '' : vm.product.metaKeywords;
            vm.product.metaDescription = vm.product.metaDescription === null ? '' : vm.product.metaDescription;
            vm.product.productSeasonId = vm.selectedSeason.id;
            vm.product.tyreWidthId = vm.selectedWidth.id;
            vm.product.tyreProfileId = vm.selectedProfile.id;
            vm.product.tyreRimSizeId = vm.selectedRim.id;

            if (vm.isEditMode) {
                promise = productService.editProduct(vm.product, vm.thumbnailImage, vm.productImages, vm.productDocuments);
            } else {
                promise = productService.createProduct(vm.product, vm.thumbnailImage, vm.productImages, vm.productDocuments);
            }

            promise.then(function (result) {
                $state.go('product');
            })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add product.');
                    }
                });
        };

        function editModeGetSpecSizes() {
            tyreService.getWidths(vm.product.categoryId)
                .then(result => {
                    vm.widths = result.data;
                    vm.profiles = {};
                    vm.rims = {};

                    vm.selectedWidth = vm.widths.find(ob => ob.id == vm.product.tyreWidthId);

                    vm.profiles = vm.selectedWidth.profiles;

                    vm.selectedProfile = vm.profiles.find(ob => ob.id == vm.product.tyreProfileId);
                    vm.rims = vm.selectedProfile.rimSizes;
                    vm.selectedRim = vm.rims.find(ob => ob.id == vm.product.tyreRimSizeId);
                });
        };

        function chooseSelectedSeason() {
            categoryService.getSeasons().then(function (result) {
                vm.seasons = result.data;

                vm.selectedSeason = vm.seasons.find(ob => ob.id == vm.product.productSeasonId);
            });
            console.log('selected season:');
            console.log(vm.selectedSeason);
            console.log('vm.product : ');
            console.log(vm.product);
        }

        function getProduct() {
            productService.getProduct($stateParams.id).then(function (result) {
                vm.product = result.data;

                editModeGetSpecSizes();

                chooseSelectedSeason();

                if (vm.product.specialPriceStart) {
                    vm.product.specialPriceStart = new Date(vm.product.specialPriceStart);
                }
                if (vm.product.specialPriceEnd) {
                    vm.product.specialPriceEnd = new Date(vm.product.specialPriceEnd);
                }
            });
        }

        function getCategories() {
            categoryService.getCategories().then(function (result) {
                vm.categories = result.data;
                //console.log(vm.categories);
            });
        }

        function getBrands() {
            brandService.getBrands().then(function (result) {
                vm.brands = result.data;
            });
        }

        function getSeasons() {
            categoryService.getSeasons().then(function(result) {
                vm.seasons = result.data;
            });
        }

        function init() {
            if (vm.isEditMode) {
                getProduct();
            } else {
                getSeasons();
            }

            getCategories();
            getBrands();
        }

        init();
    }
})(jQuery);