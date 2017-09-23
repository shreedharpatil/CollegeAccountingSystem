/**
 * Created by shreedhar on 5/27/2015.
 */
angular.module('DAS').controller('StudentProfileController',function($scope,StudentProfileService){
    $scope.Model = StudentProfileService;
    $scope.Model.LoadStudentDetails();
});