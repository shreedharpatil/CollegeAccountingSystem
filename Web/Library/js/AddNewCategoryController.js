angular.module('DAS').controller('AddNewCategoryController', ['$scope', 'AddNewCategoryService', '$modalInstance', function (scope, addNewCategoryService, $modalInstance) {
    scope.Model = addNewCategoryService;
    scope.Model.Close = function () {
        $modalInstance.close('closed');
    }
}]);