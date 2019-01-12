$(".chosen-select").chosen();

(function ($, currentSearchOption, priceSetting) {
    $(function() {
        function createUrl() {
            var key,
                value,
                newUrl,
                params = [],
                baseUrl = window.location.protocol + '//' + window.location.host + window.location.pathname;

            for (key in currentSearchOption) {
                if (currentSearchOption.hasOwnProperty(key) && currentSearchOption[key]) {
                    value = currentSearchOption[key];
                    params.push(key + '=' + value);
                }
            }

            if (params.length > 0) {
                newUrl = baseUrl + '?' + params.join('&');
            } else {
                newUrl = baseUrl;
            }

            return newUrl;
        }

        b = "";

        $(".chosen-select").chosen().change(() => {
            console.log('isi');
            var brands = $('.chosen-select').val();
            b = brands[0];
            for (var i = 1; i < brands.length; i++)
                b += "--" + brands[i];

            currentSearchOption.brand = b;

            console.log(currentSearchOption.brand);

            window.location = createUrl();
        });

        function initPriceSlider() {
            var slider = $('.slider');
            if (!slider) {
                return;
            }

            var priceValues = [
                document.getElementById('minPrice'),
                document.getElementById('maxPrice')
            ];
            // creating slider:
            
            slider.slider({
                    min: priceSetting.min,
                    max: priceSetting.max,
                    range: true,
                    values: [priceSetting.currentMin, priceSetting.currentMax],
                    step: 1
                })
                .slider("pips",
                    {
                        rest: "label",
                        step: 50
                    })
                .slider("float");

            slider.slider({
                change: function(e, ui) {
                    console.log(ui.values);
                    var min, max, prices;
                    prices = ui.values;
                    console.log(prices);
                    //min = parseInt(prices[0].replace(/\./g, ''), 10);
                    //max = parseInt(prices[1].replace(/\./g, ''), 10);
                    min = prices[0];
                    max = prices[1];
                    if (min !== priceSetting.min) {
                        currentSearchOption.minPrice = min;
                    } else {
                        currentSearchOption.minPrice = null;
                    }

                    if (max !== priceSetting.max) {
                        currentSearchOption.maxPrice = max;
                    } else {
                        currentSearchOption.maxPrice = null;
                    }

                    window.location = createUrl();
                }
            })
        }

        initPriceSlider();
    });
})(jQuery, productFilter.currentSearchOption, productFilter.priceSetting);

// for price:
$(".slider")