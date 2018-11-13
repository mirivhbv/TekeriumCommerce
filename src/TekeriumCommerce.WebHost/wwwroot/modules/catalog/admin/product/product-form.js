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
        vm.sel;

        // testing mapping size:
        vm.widths = [];
        vm.profiles = [];
        vm.rims = [];
        vm.selectedWidth = {};
        vm.selectedProfile = {};
        vm.selectedRim = {};

        vm.catUpdate = function(id) {
            tyreService.getWidths(id).then(result => {
                vm.widths = result.data;
                vm.profiles = {};
                vm.rims = {};
            });
        }
        
        vm.selectedWidthChange = function() {
            vm.profiles = vm.selectedWidth.profiles;
            vm.rims = {}; // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        } // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
 // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
  // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
   // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
    // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
     // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
      // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
       // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa // last staaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        vm.selectedProfileChange = function() {
            vm.rims = vm.selectedProfile.rimSizes;
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

        vm.toggleCategories = function toggleCategories(categoryId) {
            if (category)

            var index = vm.product.categoryIds.indexOf(categoryId);
            if (index > -1) {
                vm.product.categoryIds.splice(index, 1);
                var childCategoryIds = getChildCategoryIds(categoryId);
                childCategoryIds.forEach(function spliceChildCategory(childCategoryId) {
                    index = vm.product.categoryIds.indexOf(childCategoryId);
                    if (index > -1) {
                        vm.product.categoryIds.splice(index, 1);
                    }
                });
            } else {
                vm.product.categoryIds.push(categoryId);
                var category = vm.categories.find(function (item) { return item.id === categoryId; });
                if (category) {
                    var parentCategoryIds = getParentCategoryIds(category.parentId);
                    parentCategoryIds.forEach(function pushParentCategory(parentCategoryId) {
                        if (vm.product.categoryIds.indexOf(parentCategoryId) < 0) {
                            vm.product.categoryIds.push(parentCategoryId);
                        }
                    });
                }
            }
        };

        vm.filterAddedOptionValue = function filterAddedOptionValue(item) {
            if (vm.product.options.length > 1) {
                return true;
            }
            var optionValueAdded = false;
            vm.product.variations.forEach(function (variation) {
                var optionValues = variation.optionCombinations.map(function (item) {
                    return item.value;
                });
                if (optionValues.indexOf(item) > -1) {
                    optionValueAdded = true;
                }
            });

            return !optionValueAdded;
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

        function getProduct() {
            productService.getProduct($stateParams.id).then(function (result) {
                vm.product = result.data;

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
            });
        }

        function getBrands() {
            brandService.getBrands().then(function (result) {
                vm.brands = result.data;
            });
        }

        function init() {
            if (vm.isEditMode) {
                getProduct();
            }
            else {

            }
            getCategories();
            getBrands();
        }

        // todo: going to delete
        function getParentCategoryIds(categoryId) {
            if (!categoryId) {
                return [];
            }
            var category = vm.categories.find(function (item) { return item.id === categoryId; });

            return category ? [category.id].concat(getParentCategoryIds(category.parentId)) : []; 
        }

        // going to removing()
        function getChildCategoryIds(categoryId) {
            if (!categoryId) {
                return [];
            }
            var result = [];
            var queue = [];
            queue.push(categoryId);
            while (queue.length > 0) {
                var current = queue.shift();
                result.push(current);
                var childCategories = vm.categories.filter(function (item) { return item.parentId === current; });
                childCategories.forEach(function pushChildCategoryToTheQueue(childCategory) {
                    queue.push(childCategory.id);
                });
            }

            return result;
        }

        init();
    }
})(jQuery);