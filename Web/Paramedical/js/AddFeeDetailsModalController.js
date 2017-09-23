/**
 * Created by shreedhar on 5/28/2015.
 */
angular.module('DAS').controller('AddFeeDetailsModalController',function($scope,AddFeeDetailsModalService,$modalInstance){
    $scope.Model = AddFeeDetailsModalService;
    $scope.Model.Initialize();
    $scope.Validation = new commonWarningMessage();
    $scope.close = function () {
        $modalInstance.close('closed');
    }
});

angular.module('DAS').service('AddFeeDetailsModalService',function($http,$rootScope){
    return new AddFeeDetailsModalServiceViewModel($http,$rootScope);
});

var AddFeeDetailsModalServiceViewModel = (function(){
    var model = function(http,rootScope){
        var self = this;
        self.Student = {};
        self.IsPaidFeeLesserThanTotalFee = true;
        self.ShowLoader = false;
        self.Keys = ['CourseFee', 'AdmissionFormFee', 'AdmissionFee', 'IdentityCardFee', 'StudentAssociationFee',
            'ReadingRoomFee', 'MagazineFee', 'LibraryFee', 'LabFee', 'StudentWelfareFundFee',
            'TeacherBenefitFundFee', 'AdmissionFineFee', 'SportsFee', 'FineFee', 'OtherFee'
        ];

        self.Initialize = function () {
            self.Student = angular.copy(rootScope.studentProfileDetails);
        };

        self.CalculateTotalFee= function(){
            var totalFee = 0;
            _.each(self.Keys, function (key) {
                totalFee += parseFloat(self.Student[key] ? self.Student[key] : 0);
            });
            self.Student.TotalFee = totalFee;
        };

        self.CalculateDueFee = function(){
            var totalFee = parseFloat(self.Student.TotalFee ? self.Student.TotalFee : 0);
            var paidFee = parseFloat(self.Student.PaidFee ? self.Student.PaidFee : 0);

            self.Student.DueFee = totalFee - paidFee;
        };

        self.ValidatePaidFee = function () {
            var paidfee = parseFloat(self.Student.PaidFee ? self.Student.PaidFee : 0);
            var totalfee = parseFloat(self.Student.TotalFee ? self.Student.TotalFee : 0);
            self.IsPaidFeeLesserThanTotalFee = paidfee <= totalfee;
        };

        self.AddFee = function () {
            self.ShowLoader = true;
            http({
                method:'POST',
                url :'/api/ParamedicalFee',
                data:self.Student
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    alert(data);
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };
    };

    return model;
})();