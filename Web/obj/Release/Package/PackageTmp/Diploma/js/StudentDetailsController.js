/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').controller('StudentDetailsController',function($scope,StudentDetailsService){
    $scope.Model = StudentDetailsService;
    //$scope.Model.GetAllStudents();
    $scope.Model.GetBranches();
    $scope.Model.GetYears();
    $scope.Validation = new commonWarningMessage();
    $scope.Model.SetPristine = function (form) {
        $scope[form].$setPristine();
    };
});