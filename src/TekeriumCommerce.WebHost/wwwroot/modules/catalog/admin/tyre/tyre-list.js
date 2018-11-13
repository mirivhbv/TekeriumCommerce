(function() {
    angular
        .module('tekerAdmin.catalog')
        .controller('TyreListCtrl', TyreListCtrl);

    function TyreListCtrl($state, tyreService, categoryService) {
        var vm = this;

        vm.categories = [];

        vm.widths = [];
        vm.profiles = [];

        vm.selectedCategory = null;
        vm.selectedWidth = null;
        vm.selectedProfile = null;
        vm.selectedRim = null;

        // all widths:
        vm.allWidths = [];
        vm.selectedAddingWidth = null;
        // all profiles
        vm.allProfiles = [];
        vm.selectedAddingProfile = null;
        // all rimsizes
        vm.allRimSizes = [];
        vm.selectedAddingRimSize = null;

        vm.getCategories = function getCategories() {
            categoryService.getCategories().then(function(result) {
                vm.categories = result.data;
                vm.selectedCategory = vm.categories[0];
                vm.getWidths(vm.selectedCategory.id);
                vm.getAllWidths(vm.selectedCategory.id);
                vm.getAllProfiles(vm.selectedCategory.id);
                vm.getAllRimSizes(vm.selectedCategory.id);
            });
        }

        vm.catUpdated = function() {
            console.log('fake');
            vm.getWidths(vm.selectedCategory.id);
            vm.getAllWidths(vm.selectedCategory.id);
            vm.getAllProfiles(vm.selectedCategory.id);
            vm.getAllRimSizes(vm.selectedCategory.id);
        }

        vm.getWidths = function getWidths(id) {
            tyreService.getWidths(id).then(function (result) {
                vm.widths = result.data;
                vm.selectedWidth = vm.widths[0];
                vm.selectedProfile = vm.widths[0].profiles[0];
                vm.selectedRim = vm.selectedProfile.rimSizes[0];
            });
        };

        vm.getAllWidths = function getAllWidths(id) {
            tyreService.getAllWidths(id).then(function(result) {
                vm.allWidths = result.data;
            });
        };

        vm.getAllProfiles = function getAllProfiles(id) {
            tyreService.getAllProfiles(id).then(function(result) {
                vm.allProfiles = result.data;
            });
        };

        vm.getAllRimSizes = function getAllRimSizes(id) {
            tyreService.getAllRimSizes(id).then(function (result) {
                console.log(result);
                vm.allRimSizes = result.data;
            });
        };

        // remain there
        vm.add = function add() {
            var promise = tyreService.add(vm.selectedAddingWidth.id, vm.selectedAddingProfile.id, vm.selectedAddingRimSize.id);

            promise.then(function (result) {
                let f = vm.selectedAddingWidth.id;
                let c = vm.selectedAddingProfile.id;

                vm.getWidths();
                vm.selectedWidth = vm.widths.find(o => o.id === f);
                vm.selectedProfile = vm.profiles.find(o => o.id === c);
            }).catch(function (response) {
                var error = response.data;
                vm.validationErrors = [];
                if (error && angular.isObject(error)) {
                    for (var key in error) {
                        vm.validationErrors.push(error[key]);
                    }
                } else {
                    vm.validationErrors.push('Could not add selected sizes');
                }
            });
        };

        vm.deleteWidth = function deleteWidth() {
            bootbox.confirm('Are you sure you want to delete this width size: ' + vm.selectedAddingWidth.size,
                function(result) {
                    if (result) {
                        tyreService.deleteWidth(vm.selectedAddingWidth.id)
                            .then(function(result) {
                                toastr.success(vm.selectedAddingWidth.size + ' has been deleted');
                            })
                            .catch(function(response) {
                                console.log(response.data);
                                toastr.error(response.data.error);
                            });
                    }
                });
        };

        vm.deleteProfile = function deleteProfile() {
            bootbox.confirm('Are you sure you want to delete this profile size: ' + vm.selectedAddingProfile.size + ' from this width size ' + vm.selectedAddingWidth.size,
                function (result) {
                    if (result) {
                        let ob = new Object();
                        ob.WidthId = vm.selectedAddingWidth.id;
                        ob.ProfileId = vm.selectedAddingProfile.id;
                        tyreService.deleteProfile(ob)
                            .then(function (result) {
                                let f = vm.selectedAddingWidth.id;
                                let c = vm.selectedAddingProfile.id;

                                vm.getWidths();
                                vm.selectedWidth = vm.widths.find(o => o.id === f);
                                vm.selectedProfile = vm.profiles.find(o => o.id === c);

                                toastr.success(vm.selectedAddingProfile.size + ' has been deleted');
                            })
                            .catch(function (response) {
                                toastr.error(response.data.error);
                            });
                    }
                });
        };

        vm.deleteRimSize = function deleteRimSize() {
            bootbox.confirm('Are you sure you want to delete this rim size: ' + vm.selectedAddingRimSize.size + ' from this width size ' + vm.selectedAddingWidth.size + ' and from this profile size ' + vm.selectedAddingProfile.id,
                function (result) {
                    if (result) {
                        tyreService.deleteRimSize({ WidthId: vm.selectedAddingWidth.id, ProfileId: vm.selectedAddingProfile.id, RimSizeId: vm.selectedAddingRimSize.id})
                            .then(function (result) {
                                let f = vm.selectedAddingWidth.id;
                                let c = vm.selectedAddingProfile.id;

                                vm.getWidths();
                                vm.selectedWidth = vm.widths.find(o => o.id === f);
                                vm.selectedProfile = vm.widths.profiles.find(o => o.id === c);

                                toastr.success(vm.selectedAddingProfile.size + ' has been deleted');
                            })
                            .catch(function (response) {
                                toastr.error(response.data.error);
                            });
                    }
                });
        };

        vm.getCategories();
        //vm.getWidths();
        // vm.getAllWidths();
        //vm.getAllProfiles();
        //vm.getAllRimSizes();
    }
})();