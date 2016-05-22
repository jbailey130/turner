
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

        ////  PROPER WAY TO USE THE SERVICE
        ////  Q = IS SOME QUERY VALUE FOR THE TWITTER API
        //var _queryFeedSearch = function (q) {
        //    return $http.get('/api/twitter/search/' + q).then(function (response) {
        //        return response.data;
        //    });
        //};

        //var _queryFeedFrom = function (f) {
        //    return $http.get('/api/twitter/from/' + f).then(function (response) {
        //        return response.data;
        //    });
        //};


        factory.getTopTenMostRecent = _getTopTenMostRecent;

        return factory;
    }
]);