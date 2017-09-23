angular.module('DAS').controller('DownloadReceiptController', function ($scope) {
    $scope.Model = { Id: '', Year: '', ShowLoader:false };
    $scope.Validation = new commonWarningMessage();
    $scope.Model.Clear = function () {
        $scope.Model.Id = '';
        $scope.Model.Year = '';
        $scope.receiptform.$setPristine();
    };
});