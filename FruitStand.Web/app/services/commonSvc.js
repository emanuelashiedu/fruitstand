'use strict';

// This service contain the shared methods
app.service('commonSvc', function () {

    this.getError = function (error) {

        var message;
        if (error.status == 400) {

            if (angular.isObject(error.data)) {

                if (angular.isObject(error.data.extra)) {
                    var errors = [];
                    for (var i = 0; i < error.data.extra.errors.length; i++) {
                        if (error.data.extra.errors[i] != null && error.data.extra.errors[i].length > 0)
                            errors.push(error.data.extra.errors[i]);
                    }
                    message = "<li>" + errors.join('</li><li>') + "</li>";
                }
                else {
                    message = error.data.message;
                }
            }
            else {
                message = error.data;
            }
        }
        else if (error.status == 500 || error.status == 501) {
            message = error.data.message;
        }

        return message;
    };

    this.resetAlertProperties = function ($scope) {
        $scope.errorSummary = false;
        $scope.success = false;
        $scope.error = false;
        $scope.info = false;
        $scope.isError = false;
    }
});

