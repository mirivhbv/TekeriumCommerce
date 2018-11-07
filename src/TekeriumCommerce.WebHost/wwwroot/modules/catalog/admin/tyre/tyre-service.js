(function () {
    angular
        .module('tekerAdmin.catalog')
        .factory('tyreService', tyreService);

    function tyreService($http) {
        var service = {
            getWidths: getWidths,
            getWidth: getWidth,
            getProfiles: getProfiles,
            getRimSizes: getRimSizes,
            getAllWidths: getAllWidths,
            deleteWidth: deleteWidth,
            deleteProfile: deleteProfile,
            deleteRimSize: deleteRimSize,
            add: add
        };
        return service;

        function getWidths() {
            return $http.get('api/tyres/');
        }

        function getWidth(id) {
            return $http.get('api/tyres/' + id);
        }

        function getAllWidths() {
            return $http.get('api/tyres/widths');
        }

        function getProfiles() {
            return $http.get('api/tyres/profiles/');
        }

        function getRimSizes() {
            return $http.get('api/tyres/rimsizes');
        }

        // remove

        function deleteWidth(id) {
            return $http.delete('api/tyres/width/' + id);
        }

        function deleteProfile(id) {
            return $http({
                method: 'DELETE',
                url: 'api/tyres/profile',
                headers: { 'Content-Type': 'application/json' },
                data: id
            });
        }

        function deleteRimSize(id) {
            return $http({
                method: 'DELETE',
                url: 'api/tyres/rimsize',
                headers: { 'Content-Type': 'application/json' },
                data: id
            });
        }

        // add profile to selected width
        function add(width, profile, rim) {
            return $http.post('api/tyres/add/' + width + '/' + profile + '/' + rim);
        }
    }
})();