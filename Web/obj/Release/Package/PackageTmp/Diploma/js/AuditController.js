/**
 * Created by shreedhar on 5/29/2015.
 */
angular.module('DAS').controller('AuditController',function($scope,AuditService){
    $scope.Model = AuditService;
    $scope.Model.GetBranches();
    $scope.Model.GetYears();
    $scope.Model.SetPristine = function () {
        $scope['auditform'].$setPristine();
    };
    $scope.Validation = new commonWarningMessage();
});