(function () {
'use strict';
//  MAIN CONTROLLER
    angular.module('turnerApp')
  .config(function ($stateProvider) {
      $stateProvider
        .state('main', {
            url: '/',
            templateUrl: 'app/main/main.html',
            controller: 'MainCtrl'
        });
  });
})(); 