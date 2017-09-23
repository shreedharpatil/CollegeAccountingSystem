/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').controller('AdmissionController',function($scope,AdmissionService){
    $scope.Model = AdmissionService;
    $scope.Model.GetBranches();
    $scope.Validation = new commonWarningMessage();
    $scope.Model.SetPristine = function () {
        $scope['admissionform'].$setPristine();
    };
});