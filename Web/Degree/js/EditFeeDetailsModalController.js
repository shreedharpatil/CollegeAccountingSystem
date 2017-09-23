/**
 * Created by shreedhar on 5/24/2015.
 */
angular.module('DAS').controller('EditFeeDetailsModalController', function ($scope,EditFeeDetailsModalService,$modalInstance) {
    $scope.Model = EditFeeDetailsModalService;
    $scope.Model.Initialize();
    $scope.close = function () {
        $modalInstance.close('closed');
    }
    $scope.Validation = new commonWarningMessage();

    $scope.Model.IsSuccess = false;
    $scope.Model.SuccessMessage = '';
    $scope.Model.CheckFeePaid();
});

angular.module('DAS').service('EditFeeDetailsModalService',function($http,$rootScope){
    return new EditFeeDetailsModalServiceViewModel($http,$rootScope);
});

var EditFeeDetailsModalServiceViewModel = (function(){
    var model = function(http,rootScope){
        var self = this;
        self.Fee = {};
        self.IsSuccess = false;
        self.HasPaidFee = false;
        self.IsPaidFeeLesserThanTotalFee = true;
        self.ShowLoader = false;

        self.Initialize = function(){
            self.Fee = rootScope.feeDetails;
            self.Fee.Due_Fee = angular.copy(self.Fee.DueFee);
            self.Fee.Due_Date = angular.copy(self.Fee.DueDate);
        };

        self.CheckFeePaid = function(){
            var previousDueAmount = parseFloat(self.Fee.DueFee);
            if(previousDueAmount !=0){
                self.HasPaidFee = false;
            }
            else{
                self.HasPaidFee = true;
            }
        };

        self.ValidateDueAmount = function(){
            var currentDueAmount = parseFloat(self.Fee.DueFee);
            var previousDueAmount = parseFloat(self.Fee.Due_Fee);
            return currentDueAmount > previousDueAmount;

        };

        self.UpdateFeeDetails = function () {
            self.ShowLoader = true;
            self.Fee.DueDate = self.Fee.EnteredDueDate;
            http({
                method:'PUT',
                url: '/api/DegreeFee',
                data:self.Fee
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.IsSuccess = true;
                    self.SuccessMessage = data;
                    self.Clear();
                })
                .error(function(error){
                    self.IsSuccess = true;
                    self.ShowLoader = false;
                    self.SuccessMessage = error;
                });
        };

        self.Clear = function(){
            self.Fee.DueFee = '';
            self.Fee.DueDate = '';
        };

        self.CalculateDueFee = function () {
            var currentDueFee = parseFloat(self.Fee.Due_Fee);
            var dueFee = parseFloat(self.Fee.DueFee);
            self.IsPaidFeeLesserThanTotalFee =  dueFee <= currentDueFee;
        };
    };
    return model;
})();