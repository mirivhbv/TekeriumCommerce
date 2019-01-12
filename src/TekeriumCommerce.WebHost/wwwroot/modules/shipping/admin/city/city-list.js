(function() {
    angular
        .module('tekerAdmin.shipping')
        .controller('CityListCtrl', CityListCtrl);

    function CityListCtrl(cityService) {
        var vm = this;
        vm.cities = [];

        vm.getCities = function() {
            cityService.getCities().then(function(result) {
                vm.cities = result.data;
            });
        };

        vm.deleteCity = function (city) {
            bootbox.confirm('Are you sure you want to delete this city: ' + city.name, function(result) {
                if (result) {
                    cityService.deleteCity(city)
                        .then(function (result) {
                            vm.getCities();
                            toastr.success(city.name + ' has been deleted');
                        })
                        .catch(function (response) {
                            toastr.error(response.data.error);
                        });
                }
            })
        }

        vm.getCities();
    }

})();