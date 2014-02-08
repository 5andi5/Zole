'use strict';

angular.module('app.filters', [])

    .filter('interpolate', ['version', function (version) {
        return function (text) {
            return String(text).replace(/\%VERSION\%/mg, version);
        }
    }])

    .filter('formatPlayers', [function () {
        return function (game) {
            var names = game.players
                .filter(function (player) {
                    return player && player.userName;
                })
                .map(function (player) {
                    return player.userName;
                })
                .join(', ');
            return names;
        }
    }])