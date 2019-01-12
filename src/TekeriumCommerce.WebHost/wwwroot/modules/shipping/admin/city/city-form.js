(function() {
    angular
        .module('tekerAdmin.shipping')
        .controller('CityFormCtrl', CityFormCtrl);

    function CityFormCtrl($state, $stateParams, cityService) {
        var vm = this;
        vm.city = {};
        vm.cityId = $stateParams.id;
        vm.isEditMode = vm.cityId > 0;

        vm.save = function () {
            var promise;
            if (vm.isEditMode) {
                promise = cityService.editCity(vm.city);
            } else {
                promise = cityService.createCity(vm.city);
            }

            promise
                .then(function (result) {
                    $state.go('city');
                })
                .catch(function (response) {
                    var error = response.data;
                    vm.validationErrors = [];
                    if (error && angular.isObject(error)){
                        for (var key in error) {
                            vm.validationErrors.push(error[key][0]);
                        }
                    } else {
                        vm.validationErrors.push('Could not add a city.');
                    }
                });
        }

        function init() {
            if (vm.isEditMode) {
                console.log(vm.cityId);
                cityService.getCity(vm.cityId).then(function(result) {
                    vm.city = result.data;
                });
            }
        }

        init();
    }
})();