(function () {
    angular.module('teker.shoppingCart', [])
        .controller('shoppingCartListCtrl',
            [
                '$scope',
                '$http',
                'shoppingCartService',
                function ($scope, $http, shoppingCartService) {
                    var vm = this;
                    vm.cart = {};
                    vm.shippingCity = {};
                    vm.allCities = [];
                    vm.orderTotal = 0;

                    function cartDataCallback(result) {
                        vm.cart = result.data;
                        $('.cart-badge .badge').text(vm.cart.items.length);
                        vm.orderTotal = vm.cart.orderTotal + vm.shippingCity.cost;
                        console.log(vm.cart);
                        console.log(vm.cart.orderTotal);
                        console.log(vm.shippingCity.cost);
                        console.log(vm.shippingCity);
                        console.log(vm.orderTotal);
                    }

                    function getShoppingCartItems() {
                        shoppingCartService.getShoppingCartItems().then(cartDataCallback);
                    }

                    function getAllCities() {
                        $http.get('api/shipping').then((result) => {
                            vm.allCities = result.data;
                            vm.shippingCity = vm.allCities[0];
                        });
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

                    vm.shippingCityChanged = function shippingCityChanged() {
                        vm.orderTotal = vm.cart.orderTotal + vm.shippingCity.cost;
                    }

                    getShoppingCartItems();
                    getAllCities();
                }
            ]);
})();