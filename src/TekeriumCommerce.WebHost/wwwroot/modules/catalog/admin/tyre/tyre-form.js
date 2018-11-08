(function() {
    angular
        .module('tekerAdmin.catalog')
        .controller('TyreFormCtrl', TyreFormCtrl);

    function TyreFormCtrl($state, tyreService) {
        var vm = this;
        vm.tyre = {};

        vm.saveWidth = function saveWidth() {
            tyreService.addWidth(vm.tyre.width.size).
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
            tyreService.addProfile(vm.tyre.profile.size).
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
            tyreService.addRimSize(vm.tyre.rim.size).
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