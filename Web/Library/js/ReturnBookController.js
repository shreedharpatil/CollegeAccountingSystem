angular.module('DAS').controller('ReturnBookController', ['$scope', 'ReturnBookService', function (scope, returnBookService) {
    scope.Model = returnBookService;
    scope.Validation = new commonWarningMessage();
    scope.Model.Initialize();
}]);