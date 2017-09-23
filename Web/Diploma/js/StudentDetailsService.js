/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').service('StudentDetailsService',function($http,WarningMessageService,$rootScope){
    return new StudentDetailsServiceViewModel($http,WarningMessageService,$rootScope);
});

var StudentDetailsServiceViewModel = (function(){
    var model = function(http,warningMessageService,rootScope){
        var self = this;
        self.Students = [];
        self.Branches = [];
        self.NoStudentsFound = false;
        rootScope.StudentProfileTemplate = '';
        self.Student = { BranchId: 0, Year: '', Gender: '', AdmissionYear: "----- Please Select ------" };
        self.CurrentTab = 0;
        self.ShowLoader = false;
        self.ShowMainTemplate = false;
        self.CriteriaTemplate = '/Diploma/Templates/StudentDetails/StudentDetailsCriteriaOneTemplate.html';
        self.CriteriaTemplates = [
            '/Diploma/Templates/StudentDetails/StudentDetailsCriteriaOneTemplate.html',
            '/Diploma/Templates/StudentDetails/StudentDetailsCriteriaTwoTemplate.html',
            '/Diploma/Templates/StudentDetails/StudentDetailsCriteriaThreeTemplate.html'
        ];

        self.GetQueryStrings = function (criteria) {
            if (criteria == 1) {
                return 'BranchId=' + self.Student.BranchId + '&Quota=' + self.Student.Quota + '&AdmissionYear=' + self.Student.AdmissionYear
            }
            else if (criteria == 2) {
                return 'BranchId=' + self.Student.BranchId + '&AdmissionYear=' + self.Student.AdmissionYear + '&Year=' + self.Student.Year
            }
            else {
                return 'Name=' + self.Student.Name + '&Gender=' + self.Student.Gender + '&Quota=' + self.Student.Quota
            }
        };

        self.SearchStudents = function (criteria) {
            self.ShowLoader = true;
            self.ShowMainTemplate = false;
            var queryStrings = self.GetQueryStrings(criteria);
            self.NoStudentsFound = false;
            http({
                method: 'GET',
                url: '/api/student?' + queryStrings + '&Criteria=' + criteria
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.ShowMainTemplate = true;
                    if(data.length == 0){self.NoStudentsFound = true;}
                    self.Students = data;
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    self.ShowMainTemplate = true;
                    self.NoStudentsFound = true;
                    alert(error);
                });
        };

        self.ShowPopup = function(student){
            rootScope.feeDetails = student;
            warningMessageService.OpenPopup({ template: '/Diploma/Templates/EditFeeDetailsModalTemplate', controller: 'EditFeeDetailsModalController', Callback: self.GetAllStudents });
        };

        self.GetBranches = function(){
            http({
                method:'GET',
                url:'/api/branch'
            })
                .success(function(data){
                    self.Branches = data;
                    self.Branches.unshift({Id:0,Name:"-----Please select -----"});
                })
                .error(function(error){
                    alert(error);
                });
        };

        self.GetYears = function () {
            http({
                method: 'GET',
                url: '/api/year'
            })
                .success(function (data) {
                    self.Years = data;
                    self.Years.unshift('----- Please Select ------');
                })
                .error(function (error) {
                    alert(error);
                });
        };

        self.ShowStudentProfile = function(student){
            rootScope.studentProfileDetails = student;
            rootScope.StudentProfileTemplate = '/Diploma/Templates/StudentProfileTemplate.html';
        };

        self.ChangeTab = function (tab) {
            self.CurrentTab = tab;
            self.CriteriaTemplate = self.CriteriaTemplates[tab];
            //self.Student = { BranchId: 0, Year: '', Gender: '', Name: '', AdmissionYear: "----- Please Select ------" };
        }

        self.Clear = function (form) {
            self.Student = { BranchId: 0, Year: '', Gender: '', Name: '', Quota: '', AdmissionYear: "----- Please Select ------" };
            self.Students = [];
            self.SetPristine(form);
            self.ShowLoader = false;
            self.ShowMainTemplate = false;
            self.NoStudentsFound = false;
        }
    };
    return model;
})();