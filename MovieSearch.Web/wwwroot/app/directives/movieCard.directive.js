'use strict';

//  THE DIRECTIVE FOR ALL OF THE TWEETS BEING DISPLAYED
angular.module('turnerApp')
    .directive('movieCard', ['MovieService', '$window', function (MovieService, $window) {
        return{
            restrict: 'E',
            scope:{
                q: '@', //  QUERY FOR SEARCHING MOVIES
                f: '='  //  QUERY MOVIES BASED ON A Q
            },
            templateUrl: 'app/directives/movieCard.html',
            link: function($scope, element, attrs){
                //  ALLOWS FOR PUTTING ARRAY OF SIZE N INTO COLUMNS OF SIZE X
                function chunk(arr, size) {
                    var newArr = [];
                    for (var i=0; i<arr.length; i+=size) {
                        newArr.push(arr.slice(i, i+size));
                    }
                    return newArr;
                }

                MovieService.getTopTenMostRecent().then(function (data) {
                    console.log(data);
                    $scope.movies = chunk(data, 4);
                    console.log($scope.movies);
                });
            }
        }
    }]);