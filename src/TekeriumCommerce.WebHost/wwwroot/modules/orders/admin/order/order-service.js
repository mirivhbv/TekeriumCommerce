(function() {
    angular
        .module('tekerAdmin.orders')
        .factory('orderService', orderService);

    function orderService($http) {
        var service = {
            getOrders: getOrders,
            getOrdersForGrid: getOrdersForGrid,
            getOrderStatus: getOrderStatus,
            getOrder: getOrder,
            getOrderHistory: getOrderHistory,
            changeOrderStatus: changeOrderStatus
        };

        return service;

        function getOrders(status, numRecords) {
            return $http.get('api/orders?status=' + status + '&numRecords=' + numRecords);
        }

        function getOrdersForGrid(params) {
            return $http.post('api/orders/grid', params);
        }

        function getOrderStatus() {
            return $http.get('api/orders/order-status');
        }

        function getOrder(orderId) {
            return $http.get('api/orders/' + orderId);
        }

        function getOrderHistory(orderId) {
            return $http.get('api/orders/' + orderId + '/history');
        }

        function changeOrderStatus(orderId, statusModel) {
            return $http.post('api/orders/change-order-status/' + orderId, statusModel);

        }
    }
})();