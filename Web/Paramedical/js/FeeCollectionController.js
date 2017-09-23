angular.module('DAS').controller('FeeCollectionController', function ($scope,FeeCollectionService) {
    $scope.Model = FeeCollectionService;
    $scope.Validation = new commonWarningMessage();
    $scope.Model.SetPristine = function (form) {
        $scope[form].$setPristine();
    };
});