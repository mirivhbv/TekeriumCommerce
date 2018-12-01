(function() {
    angular
        .module('tekerAdmin.shipping')
        .factory('cityService', cityService);

    function cityService($http) {
        var service = {
            getCity: getCity,
            getCities: getCities,
            createCity: createCity,
            editCity: editCity,
            deleteCity: deleteCity
        };
        return service;

        function getCity(id) {
            return $http.get('api/shipping/' + id);
        }

        function getCities() {
            return $http.get('api/shipping');
        }

        function createCity(city) {
            console.log(city);
            return $http.post('api/shipping/add', city);
        }

        function editCity(city) {
            return $http.put('api/shipping/' + city.id, city);
        }

        function deleteCity(city) {
            return $http.delete('api/shipping/' + city.id, null);
        }
    }
})();