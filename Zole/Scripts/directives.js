'use strict';

angular.module('app.directives', [])

    .directive('appVersion', ['version', function (version) {
        return function (scope, elm) {
            elm.text(version);
        };
    }])

    .directive('appCardIcon', [function () {
        var getDeckOffset = function getDeckOffset(code) {
            var offset = -90;
            switch (code) {
                case 'D':
                    return 0;
                case 'C':
                    return offset * 1;
                case 'H':
                    return offset * 2;
                case 'S':
                    return offset * 3;
                default:
                    return -offset;
            }
        },
        getCardIndex = function getCardIndex(code) {
            switch (code) {
                case 'J':
                    return 9;
                case 'Q':
                    return 10;
                case 'K':
                    return 11;
                case 'A':
                    return 12;
                default:
                    return parseInt(code, 10) - 2;
            }
        },
        getCardOffset = function getDeckOffset(code) {
            var index = getCardIndex(code),
                offset = -64;
            return index * offset;
        };
        return {
            restrict: 'A',
            link: function (scope, element, attribute) {
                var code = attribute.appCardIcon.toUpperCase(),
                    deckCode = code[0],
                    cardCode = code.substring(1);

                element.addClass('card');

                element.css('background-position-x', getCardOffset(cardCode));
                element.css('background-position-y', getDeckOffset(deckCode));
            }
        };
    }]);