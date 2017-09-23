/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').controller('LibraryController', function ($scope, LibraryService) {
    $scope.Model = LibraryService;
});

angular.module('DAS').service('LibraryService', function ($location,$http) {
    var self = this;
    self.ShowLoader = false;
    self.Year = new Date().getFullYear();
    self.Logout = function () {
        self.ShowLoader = true;
        $http({
            method: 'GET',
            url: '/api/Logout?application=library'
        })
        .success(function (data) {
            self.ShowLoader = false;
            window.location.href = $location.$$protocol + "://" + $location.$$host + ":" + $location.$$port + "/login.html";
        }).error(function (error) {
            self.ShowLoader = false;
            window.location.href = $location.$$protocol + "://" + $location.$$host + ":" + $location.$$port + "/login.html";
        });        
    };

    self.TakeBackup = function () {
        self.ShowLoader = true;
        $http({
            method: 'GET',
            url: '/api/Logout?application=library'
        })
        .success(function (data) {
            if (!data) {
                alert('There was a problem encountered while taking backup. Please try again.');
            }
            self.ShowLoader = false;
        })
        .error(function (error) {
            alert('There was a problem encountered while taking backup. Please try again.');
            self.ShowLoader = false;
        });
    };
});
angular.module('DAS').config(function($routeProvider) {
    $routeProvider.
        when('/addnewbook', {
            templateUrl: '/Library/Templates/AddNewBookTemplate.html',
            controller: 'AddNewBookController'
        })
        .when('/searchbooks', {
            templateUrl: '/Degree/Templates/StudentDetailsTemplate.html',
            controller: 'StudentDetailsController'
        })
        .when('/issuebook', {
            templateUrl: '/Library/Templates/IssueBookTemplate.html',
            controller: 'IssueBookController'
        })
        .when('/returnbook', {
            templateUrl: '/Library/Templates/ReturnBookTemplate.html',
            controller: 'ReturnBookController'
        })   
        .otherwise({
            redirectTo: '/addnewbook'
        });
});