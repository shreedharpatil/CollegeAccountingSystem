angular.module('DAS').controller('AddNewBookController', ['$scope', 'AddNewBookService', function (scope, addNewBookService) {
    scope.Model = addNewBookService;
    scope.Validation = new commonWarningMessage();
    scope.Model.LoadBranches();
    scope.Model.LoadBookCategories();
    scope.Model.Initialize();
    scope.Model.SetPristine = function() {
        scope['addnewbookform'].$setPristine();
    };
}]);