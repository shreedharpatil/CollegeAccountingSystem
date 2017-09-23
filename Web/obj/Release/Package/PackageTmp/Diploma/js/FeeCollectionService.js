angular.module('DAS').service('FeeCollectionService', function ($http) {
    return new FeeCollectionServiceViewModel($http);
});

var FeeCollectionServiceViewModel = (function () {
    var model = function (http) {
        var self = this;
        self.Student = {};
        self.DoesStudentFound = false;
        self.StudentFound = false;
        self.IsPaidFeeLesserThanTotalFee = true;
        self.ShowLoader = false;
        self.Keys = ['CourseFee', 'AdmissionFormFee', 'AdmissionFee', 'IdentityCardFee', 'StudentAssociationFee',
            'ReadingRoomFee', 'MagazineFee', 'LibraryFee', 'LabFee', 'StudentWelfareFundFee',
            'TeacherBenefitFundFee','AdmissionFineFee','SportsFee','FineFee','OtherFee'
        ];
        self.Fee = {};

        self.FindStudent = function () {
            self.DoesStudentFound = false;
            self.StudentFound = false;
            self.ShowLoader = true;
            self.Student = {ImageUrl:''};

            http({
                method: 'GET',
                url : '/api/student?studentId=' + self.Id
            })
            .success(function (data) {
                self.Student = data;
                self.FindStudentFeesDetails();
                self.DoesStudentFound = true;
                self.StudentFound = false;                
            })
            .error(function (error) {
                self.DoesStudentFound = false;
                self.StudentFound = true;
                self.ShowLoader = false;
            });
        };

        self.FindStudentFeesDetails = function () {
            http({
                method: 'GET',
                url: '/api/student?Id=' + self.Id
            })
            .success(function (data) {
                self.ShowLoader = false;
                self.Student.Year = data.length + 1;
                self.Fee.Year = data.length + 1;
            })
            .error(function (error) {
                self.ShowLoader = false;
                alert(error);
            });
        };

        self.AddFee = function () {
            self.ShowLoader = true;
            self.Fee.Id = self.Id;
            self.Fee.Year = self.Student.Year;
            http({
                method: 'POST',
                url: '/api/Fee',
                data: self.Fee
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    alert(data);
                    self.ClearSearchForm();
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.ClearSearchForm = function () {
            self.IsPaidFeeLesserThanTotalFee = true;
            self.DoesStudentFound = false;
            self.StudentFound = false;
            self.ShowLoader = false;
            self.Student = {};
            self.Id = '';
            self.SetPristine('feescollectionform');
            self.Clear();
        };
        self.CalculateTotalFee = function () {
            var totalFee = 0;
            _.each(self.Keys,function(key){
                totalFee += parseFloat(self.Fee[key] ? self.Fee[key] : 0);
            });
            self.Fee.TotalFee = totalFee;
        };

        self.CalculateDueFee = function () {
            var totalFee = parseFloat(self.Fee.TotalFee ? self.Fee.TotalFee : 0);
            var paidFee = parseFloat(self.Fee.PaidFee ? self.Fee.PaidFee : 0);

            self.Fee.DueFee = totalFee - paidFee;
        };

        self.ValidatePaidFee = function () {
            var paidfee = parseFloat(self.Fee.PaidFee ? self.Fee.PaidFee : 0);
            var totalfee = parseFloat(self.Fee.TotalFee ? self.Fee.TotalFee : 0);
            self.IsPaidFeeLesserThanTotalFee = paidfee <= totalfee;
        };

        self.Clear = function () {
            self.Fee = {};
            self.Fee.Year = self.Student.Year;
            self.SetPristine('addfeeform');
        };
    }

    return model;
})();