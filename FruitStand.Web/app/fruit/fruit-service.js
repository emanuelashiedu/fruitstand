'use strict';
fruit.factory('fruitSvc', ['$http',
                             'ngSettings',

 function ($http,
           ngSettings) {

     var serviceBase = ngSettings.serviceBaseUri + "fruit/";

     return {

         add: function (data) {
             return $http.post(serviceBase + 'Add', data).then(function (response) {
                 return response;
             });
         },

         get: function (id) {
             return $http.get(serviceBase + 'get?id=' + id).then(function (response) {
                 return response.data;
             });
         },


         getAll: function () {
             return $http.get(serviceBase + 'GetAll').then(function (response) {
                 return response.data;
             });
         },

         getFilter: function (data) {
             return $http.post(serviceBase + 'getFilter', data).then(function (response) {
                 return response.data;
             });
         },
         remove: function (id) {
             return $http.post(serviceBase + 'delete?id=' + id).then(function (response) {
                 return response;
             });
         },

     };
 }]);