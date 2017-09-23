angular.module('DAS').controller('IssueBookController', ['$scope', 'IssueBookService',
    function (scope, issueBookService) {
        scope.Model = issueBookService;
        scope.Model.Initialize(true);
        scope.Model.LoadBranches();
        scope.Model.LoadBookCategories();
        scope.Validation = new commonWarningMessage();
    }]);