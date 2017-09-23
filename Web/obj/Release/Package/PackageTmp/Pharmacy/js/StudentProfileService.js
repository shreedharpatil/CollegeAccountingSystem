/**
 * Created by shreedhar on 5/27/2015.
 */
angular.module('DAS').service('StudentProfileService',function($http,$rootScope,WarningMessageService){
    return new StudentProfileServiceViewModel($http,$rootScope,WarningMessageService);
});

var StudentProfileServiceViewModel = (function(){
    var model = function(http,rootScope,warningMessageService){
        var self = this;
        self.Student = {};
        self.AdmissionDetails = [];
        self.Years = ['First Year','Second Year','Third Year'];

        self.LoadStudentDetails = function(){
            self.Student = angular.copy(rootScope.studentProfileDetails);
            self.LoadStudentFeeDetails();
        };

        self.LoadStudentFeeDetails = function(){
            http({
                method:'GET',
                url: '/api/Pharmacystudent?id=' + self.Student.Id
            })
                .success(function(data){
                    self.AdmissionDetails = data;
                    rootScope.studentProfileDetails.Year = data.length +1;
                    self.TotalFee = 0;
                    self.TotalDueFee = 0;
                    self.TotalPaidFee = 0;

                    _.each(data,function(fee){
                        self.TotalFee += parseFloat(fee.TotalFee);
                        self.TotalPaidFee += parseFloat(fee.PaidFee);
                        self.TotalDueFee += parseFloat(fee.DueFee);
                    });
                })
                .error(function(error){
                    alert(error);
                });
        };

        self.NewAdmission = function(){
            warningMessageService.OpenPopup({ template: '/Pharmacy/Templates/AddFeeDetailsModalTemplate.html', controller: 'AddFeeDetailsModalController', Callback: self.LoadStudentFeeDetails });
        };

        self.Back = function(){
            rootScope.StudentProfileTemplate = '';
        };

        self.UpdateFeeDetails = function(fee){
            rootScope.feeDetails = fee;
            rootScope.feeDetails.Id = self.Student.Id;
            warningMessageService.OpenPopup({ template: '/Pharmacy/Templates/EditFeeDetailsModalTemplate.html', controller: 'EditFeeDetailsModalController', Callback: self.LoadStudentFeeDetails });
        };
    };

    return model;

})();