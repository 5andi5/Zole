'use strict';

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('app.services', [])


    .factory('userService', function () {
        var getUserName= function getUserName() {
            return document.cookie.split('=')[1];
        };
        return {
            logIn: function logIn(username) {
                document.cookie = 'u=' + username;
            },
            logOut: function logOut() {
                document.cookie = 'u=';
            },
            getUserName: getUserName,
            isLoggedIn: function isLoggedIn() {
                return !!getUserName();
            }
        };
    })

    .value('version', '0.1');
