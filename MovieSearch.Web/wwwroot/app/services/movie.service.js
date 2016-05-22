
'use strict';

angular.module('turnerApp').factory('MovieService', [
    '$http', function ($http) {
        var factory = [];

        //  GETS ALL THE FEEDS FROM:CNN
        //  DEPRECATED USED TO BEGIN THE PROJECT
        var _getTopTenMostRecent = function () {
            return $http.get('/api/movies/toptenlatest').then(function (response) {
                return response.data;
            });
        };

        factory.getTopTenMostRecent = _getTopTenMostRecent;

        return factory;
    }
]);