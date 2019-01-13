(function() {
    angular
        .module('tekerAdmin.orders')
        .controller('OrderListCtrl', OrderListCtrl);

    function OrderListCtrl(orderService) {
        var vm = this;
        vm.tableStateRef = {};
        vm.orders = [];

        orderService.getOrderStatus().then(function(result) {
            vm.orderStatus = result.data;
        });

        vm.getOrders = function getOrders(tableState) {
            vm.isLoading = true;
            vm.tableStateRef = tableState;
            orderService.getOrdersForGrid(tableState).then(function(result) {
                vm.orders = result.data.items;
                tableState.pagination.numberOfPages = result.data.numberOfPages;
                tableState.pagination.totalItemCount = result.data.totalRecord;
                vm.isLoading = false;
            })
        }
    }
})();