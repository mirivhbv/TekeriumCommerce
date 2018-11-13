(function () {
    angular
        .module('tekerAdmin.catalog')
        .factory('tyreService', tyreService);

    function tyreService($http) {
        var service = {
            getWidths: getWidths,
            //getWidth: getWidth,
            getAllProfiles: getAllProfiles,
            getAllRimSizes: getAllRimSizes,
            getAllWidths: getAllWidths,
            deleteWidth: deleteWidth,
            deleteProfile: deleteProfile,
            deleteRimSize: deleteRimSize,
            add: add,
            addWidth: addWidth,
            addProfile: addProfile,
            addRimSize: addRimSize
        };
        return service;

        function getWidths(id) {
            return $http.get('api/tyres/' + id);
        }

        // function getWidth(id) {
        //     return $http.get('api/tyres/' + id);
        // }

        function getAllWidths(id) { // category id
            return $http.get('api/tyres/widths/' + id);
        }

        function getAllProfiles(id) { // category id
            return $http.get('api/tyres/profiles/' + id);
        }

        function getAllRimSizes(id) { // category id
            return $http.get('api/tyres/rimsizes/' + id);
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


        // for adding separately
        function addWidth(param) {
            return $http.post('api/tyres/add-width', param);
        }

        function addProfile(param) {
            return $http.post('api/tyres/add-profile', param);
        }

        function addRimSize(param) {
            return $http.post('api/tyres/add-rimsize', param);
        }
    }
})();