(function() {
    angular
        .module('tekerAdmin.catalog')
        .controller('TyreListCtrl', TyreListCtrl);

    function TyreListCtrl($state, tyreService) {
        var vm = this;

        vm.widths = [];
        vm.profiles = [];

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

        vm.getWidths = function getWidths() {
            tyreService.getWidths().then(function (result) {
                vm.widths = result.data;
                vm.selectedWidth = vm.widths[0];
                // console.log(vm.widths[0]);
                vm.selectedProfile = vm.widths[0].profiles[0];
                // console.log(vm.selectedProfile.rimSizes[0]);
                vm.selectedRim = vm.selectedProfile.rimSizes[0];
            });
        };

        vm.getAllWidths = function getAllWidths() {
            tyreService.getAllWidths().then(function(result) {
                vm.allWidths = result.data;
            });
        };

        vm.getProfiles = function getProfiles() {
            tyreService.getProfiles().then(function(result) {
                vm.allProfiles = result.data;
            });
        };

        vm.getRimSizes = function getRimSizes() {
            tyreService.getRimSizes().then(function (result) {
                console.log(result);
                vm.allRimSizes = result.data;
            });
        };

        vm.add = function add() {
            console.log('adding profile called');
            console.log(vm.selectedAddingWidth);
            var promise = tyreService.add(vm.selectedAddingWidth.id, vm.selectedAddingProfile.id, vm.selectedAddingRimSize.id);

            promise.then(function (result) {
                let f = vm.selectedAddingWidth.id;
                let c = vm.selectedAddingProfile.id;

                vm.getWidths();
                vm.selectedWidth = vm.widths.find(o => o.id === f);
                vm.selectedProfile = vm.profiles.find(o => o.id === c);
            }).catch(function (response) {
                console.log(response);
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

        vm.getAllWidths();
        vm.getWidths();
        vm.getProfiles();
        vm.getRimSizes();
    }
})();