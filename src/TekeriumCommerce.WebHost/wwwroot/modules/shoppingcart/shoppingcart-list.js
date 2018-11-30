(function () {
    angular.module('teker.shoppingCart', [])
        .controller('shoppingCartListCtrl',
            [
                '$scope',
                'shoppingCartService',
                function ($scope, shoppingCartService) {
                    var vm = this;
                    vm.cart = {};

                    function cartDataCallback(result) {
                        vm.cart = result.data;
                        $('.cart-badge .badge').text(vm.cart.items.length);
                    }

                    function getShoppingCartItems() {
                        shoppingCartService.getShoppingCartItems().then(cartDataCallback);
                    }

                    vm.removeShoppingCartItem = function removeShoppingCartItem(item) {
                        shoppingCartService.removeShoppingCartItem(item.id).then(cartDataCallback);
                    };

                    vm.increaseQuantity = function increaseQuantity(item) {
                        item.quantity += 1;
                        shoppingCartService.updateQuantity(item.id, item.quantity).then(cartDataCallback);
                    };

                    vm.decreaseQuantity = function decreaseQuantity(item) {
                        if (item.quantity <= 1) {
                            return;
                        }
                        item.quantity -= 1;
                        shoppingCartService.updateQuantity(item.id, item.quantity).then(cartDataCallback);
                    };

                    getShoppingCartItems();
                }
            ]);
})();