'use strict';

// Demonstrate how to register services
// In this case it is a simple value service.
angular.module('app.services', [])

    .value('version', '0.1');

    //.factory('userService', function () {
    //    return {
    //        addUserInfo: function addUserInfo(url) {
    //            var userName = $('#userSelect').val();
    //            return url + '?user=' + userName;
    //        }
    //    };
    //})