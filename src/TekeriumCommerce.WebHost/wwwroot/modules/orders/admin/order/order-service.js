(function() {
    angular
        .module('tekerAdmin.orders')
        .factory('orderService', orderService);

    function orderService($http) {
        var service = {
            getOrdersForGrid: getOrdersForGrid,
            getOrderStatus: getOrderStatus
        };

        return service;

        function getOrdersForGrid(params) {
            return $http.post('api/orders/grid', params);
        }

        function getOrderStatus() {
            return $http.get('api/orders/order-status'); // remain
        }

        function getOrder(orderId) {
            return $http.get('api/orders/' + orderId); // remain
        }
    }
})();