'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', [])

    // Path: /
    .controller('GameListCtrl', ['$scope', '$state', '$window', '$http',
        function ($scope, $state, $window, $http) {
            var errorHandler = function errorHandler(data, status, headers, config) {
                console.error(data.ExceptionMessage);
            };

            $scope.$root.title = 'Spēļu saraksts';
            $http.get('/api/Game/Games').success(function (data) {
                $scope.games = data;
            }).error(errorHandler);

            $scope.joinGame = function joinGame(gameId) {
                $http.post('/api/Game/Join', { gameId: gameId })
                    .success(function () {
                        $state.go('game', { id: gameId });
                    }).error(errorHandler);
            };

            $scope.createGame = function createGame() {
                $http.post('/api/Game/Create')
                    .success(function (gameId) {
                        if (gameId[0] === '"') {
                            gameId = gameId.substring(1, gameId.length - 1);
                        }
                        $state.go('game', { id: gameId });
                    }).error(errorHandler);
            };

            window.$scope = $scope;
        }])

    .controller('GameCtrl', ['$scope', '$location', '$window', '$http', '$stateParams',
        function ($scope, $location, $window, $http, $stateParams) {
            $scope.$root.title = 'Spēle';
            $scope.id = $stateParams.id;
            $scope.player1 = {
                cards: [
                    { code: 'C9' },
                    { code: 'DQ' },
                    { code: 'HQ' },
                    { code: 'SQ' },
                    { code: 'CQ' },
                    { code: 'CK' },
                    { code: 'CJ' },
                    { code: 'CA' }
                ]
            };
            $scope.player2 = {
                cards: [
                    { code: 'D7' },
                    { code: 'H9' },
                    { code: 'S9' },
                    { code: 'C9' },
                    { code: 'DQ' },
                    { code: 'HQ' },
                    { code: 'SQ' },
                    { code: 'CQ' }
                ]
            };
            $scope.me = {
                cards: [
                    { code: 'C9' },
                    { code: 'DQ' },
                    { code: 'HQ' },
                    { code: 'SQ' },
                    { code: 'CQ' },
                    { code: 'CK' },
                    { code: 'CJ' },
                    { code: 'CA' }
                ]
            };
        }])

    // Path: /about
    .controller('AboutCtrl', ['$scope', function ($scope) {
        $scope.$root.title = 'AngularJS SPA | About';
    }])

    // Path: /login
    .controller('LoginCtrl', ['$scope', '$state', 'userService', function ($scope, $state, userService) {
        $scope.$root.title = 'AngularJS SPA | Log In';
        $scope.login = function () {
            userService.logIn($scope.userName);
            $state.go('gameList');
            return false;
        };
    }])

    .controller('UserInfoCtrl', ['$scope', 'userService', function ($scope, userService) {
        $scope.userName = userService.getUserName();
        $scope.isSignedIn = userService.isLoggedIn();
        $scope.logOut = function () {
            userService.logOut();
            $scope.userName = userService.getUserName();
            $scope.isSignedIn = userService.isLoggedIn();
        };
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', function ($scope) {
        $scope.$root.title = 'Error 404: Page Not Found';
    }]);