'use strict';
fruit.controller('fruitCtrl', ['$scope',
                               '$stateParams',
                               '$state',
                               'responseSvc',
                               'fruitSvc',

function ($scope,
          $stateParams,
           $state,
          responseSvc,
          fruitSvc) {

    $scope.item = {
        fruit: "",
        quantity: 0,
        price: 0,
        saleDate: "",
    };

    $scope.filterDate = {
        startDate: "",
        endDate: ""
    };



    $scope.save = function () {

        $scope.isSubmitBtnClicked = true;
        $scope.isSubmitBtnDisable = $scope.itemForm.$valid;

        if ($scope.itemForm.$valid) {

            fruitSvc.add($scope.item).then(function (response) {
                responseSvc.successCompleted($scope, response).then(function (success) {
                    if (success) {
                        $state.go('fruits');
                    }
                });
            }, function (error) {
                responseSvc.failureCompleted($scope, error);
            });
        }


    }


    $scope.getFruits = function () {
        fruitSvc.getAll().then(function (response) {
            $scope.reviews = response.extra.reviews
        }, function (error) {
        });
    }

    $scope.filter = function () {

        $scope.isSubmitBtnClicked = true;

        if ($scope.itemFilter.$valid) {

            fruitSvc.getFilter($scope.filterDate).then(function (response) {
                $scope.reviews = response.extra.reviews
            }, function (error) {
            });
        }
    }


}]);