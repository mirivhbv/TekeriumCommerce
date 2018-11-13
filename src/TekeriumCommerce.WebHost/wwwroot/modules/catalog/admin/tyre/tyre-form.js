(function() {
    angular
        .module('tekerAdmin.catalog')
        .controller('TyreFormCtrl', TyreFormCtrl);

    function TyreFormCtrl($state, tyreService, categoryService) {
        var vm = this;
        vm.tyre = {};
        vm.categories = [];
        vm.selectedCatForWidth = {};
        vm.selectedCatForProfile = {};
        vm.selectedCatForRim = {};

        vm.getCat = function() {
            categoryService.getCategories()
                .then(result => { vm.categories = result.data });
        }();

        vm.saveWidth = function saveWidth() {
            p = { 'categoryId': vm.selectedCatForWidth.id, 'size': vm.tyre.width.size };
            tyreService.addWidth(p).
                then(result => { $state.go('tyre'); })
                .catch(response => {
                    var error = response.data;
                    vm.validationWidthErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationWidthErrors.push(error[key]);
                        }
                    } else {
                        vm.validationWidthErrors.push('Could not add this width');
                    }
                });
        };

        vm.noneTypedWidth = function () {
            if (vm.tyre.width !== undefined && vm.tyre.width.size.length > 0)
                return false;
            return true;
        }

        vm.saveProfile = function saveProfile() {
            p = { 'categoryId': vm.selectedCatForProfile.id, 'size': vm.tyre.profile.size };
            tyreService.addProfile(p).
                then(result => { $state.go('tyre'); })
                .catch(response => {
                    var error = response.data;
                    vm.validationProfileErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationProfileErrors.push(error[key]);
                        }
                    } else {
                        vm.validationProfileErrors.push('Could not add this profile');
                    }
                });
        };

        vm.noneTypedProfile = function () {
            if (vm.tyre.profile !== undefined && vm.tyre.profile.size.length > 0)
                return false;
            return true;
        }

        vm.saveRim = function saveRim() {
            p = { 'categoryId': vm.selectedCatForRim.id, 'size': vm.tyre.rim.size };

            tyreService.addRimSize(p).
                then(result => { $state.go('tyre'); })
                .catch(response => {
                    var error = response.data;
                    vm.validationRimErrors = [];
                    if (error && angular.isObject(error)) {
                        for (var key in error) {
                            vm.validationRimErrors.push(error[key]);
                        }
                    } else {
                        vm.validationRimErrors.push('Could not add this rim size');
                    }
                });
        };

        vm.noneTypedRim = function () {
            if (vm.tyre.rim !== undefined && vm.tyre.rim.size.length > 0)
                return false;
            return true;
        }
    }
})();