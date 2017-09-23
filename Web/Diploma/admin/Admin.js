/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').controller('AdminController', function ($scope, AdminService) {
    $scope.Model = AdminService;
});

angular.module('DAS').service('AdminService', function ($location,$http) {
    var self = this;
    self.ShowLoader = false;
    self.Logout = function () {
        self.ShowLoader = true;
        $http({
            method: 'GET',
            url: '/api/Logout?application=diploma'
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
            url: '/api/Logout?application=diploma'
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
        when('/admission', {
            templateUrl: '/Diploma/Templates/AdmissionTemplate.html',
            controller: 'AdmissionController'
        })
        .when('/studentdetails', {
            templateUrl: '/Diploma/Templates/StudentDetailsTemplate.html',
            controller: 'StudentDetailsController'
        })
        .when('/quotamanagement', {
            templateUrl: '/Diploma/Templates/QuotaManagementTemplate.html',
            controller: 'QuotaManagementController'
        })
        .when('/audit', {
            templateUrl: '/Diploma/Templates/AuditTemplate.html',
            controller: 'AuditController'
        })
         .when('/feescollection', {
             templateUrl: '/Diploma/Templates/FeeCollectionTemplate.html',
             controller: 'FeeCollectionController'
         })
    .when('/receipt', {
        templateUrl: '/Diploma/Templates/DownloadReceiptTemplate.html',
        controller: 'DownloadReceiptController'
    })
    .when('/managefaculty', {
        templateUrl: '/Diploma/Templates/FacultyTemplate.html',
        controller: 'FacultyController'
    })    
        .otherwise({
            redirectTo: '/admission'
        });
});