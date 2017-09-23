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
            url: '/api/Logout?application=pharmacy'
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
            url: '/api/Logout?application=pharmacy'
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
            templateUrl: '/Pharmacy/Templates/AdmissionTemplate.html',
            controller: 'AdmissionController'
        })
        .when('/studentdetails', {
            templateUrl: '/Pharmacy/Templates/StudentDetailsTemplate.html',
            controller: 'StudentDetailsController'
        })
        .when('/quotamanagement', {
            templateUrl: '/Pharmacy/Templates/QuotaManagementTemplate.html',
            controller: 'QuotaManagementController'
        })
        .when('/audit', {
            templateUrl: '/Pharmacy/Templates/AuditTemplate.html',
            controller: 'AuditController'
        })
         .when('/feescollection', {
             templateUrl: '/Pharmacy/Templates/FeeCollectionTemplate.html',
             controller: 'FeeCollectionController'
         })
    .when('/receipt', {
        templateUrl: '/Pharmacy/Templates/DownloadReceiptTemplate.html',
        controller: 'DownloadReceiptController'
    })    
        .otherwise({
            redirectTo: '/admission'
        });
});