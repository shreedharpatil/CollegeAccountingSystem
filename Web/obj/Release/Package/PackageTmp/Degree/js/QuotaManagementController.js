/**
 * Created by shreedhar on 5/24/2015.
 */
angular.module('DAS').controller('QuotaManagementController',function($scope,QuotaManagementService){
    $scope.Model = QuotaManagementService;
    $scope.Validation = new commonWarningMessage();
    $scope.Model.GetBranches();
    $scope.Model.SetPristine = function (form) {
        $scope[form].$setPristine();
    };
});