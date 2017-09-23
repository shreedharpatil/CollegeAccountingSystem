angular.module('DAS').controller('CommonModalController', function ($scope, CommonModalService, $rootScope, $modalInstance) {
    $scope.Model = CommonModalService;
    $scope.Model.Title = $rootScope.Title;
    $scope.Model.Content = $rootScope.Content;
    $scope.cancel = function () {
        $modalInstance.dismiss('Canceled');
    }; // end cancel

    $scope.save = function () {
        $modalInstance.close('df');
    };
});

angular.module('DAS').service('CommonModalService', function () {
    return new CommonModalServiceViewModal();
});

var CommonModalServiceViewModal = (function () {
    var model = function () {
        var self = this;
        self.Title = '';
        self.Content = '';
    };

    return model;
})();