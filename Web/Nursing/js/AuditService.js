/// <reference path="../Templates/Audit/GovernmentQuotaAuditTemplate.html" />
/**
 * Created by shreedhar on 5/29/2015.
 */
/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').service('AuditService',function($http,WarningMessageService,$rootScope){
    return new AuditServiceViewModel($http,WarningMessageService,$rootScope);
});

var AuditServiceViewModel = (function(){
    var model = function(http,warningMessageService,rootScope){
        var self = this;
        self.Students = [];
        self.Branches = [];
        self.NoStudentsFound = false;
        rootScope.StudentProfileTemplate = '';
        self.ShowMainTemplate = false;
        self.ShowLoader = false;
        self.Student = { BranchId: 0, Year: '----- Please Select ------' };
        self.CurrentTab = 0;
        self.CurrentSubTab = 0;
        self.AuditMainTemplate = '/Nursing/Templates/Audit/AuditQuotaTemplate.html';
        self.AuditSubTemplate = '/Nursing/Templates/Audit/GovernmentQuotaAuditTemplate.html';
        self.MainTemplates = [{ Template: '/Nursing/Templates/Audit/AuditQuotaTemplate.html', DefaultTemplate: 0 },
                { Template: '/Nursing/Templates/Audit/AuditYearTemplate.html', DefaultTemplate: 2 },
                { Template: '/Nursing/Templates/Audit/AuditGenderTemplate.html', DefaultTemplate: 5 }
        ];

        self.SubTemplates = [
            '/Nursing/Templates/Audit/GovernmentQuotaAuditTemplate.html',
            '/Nursing/Templates/Audit/ManagementQuotaAuditTemplate.html',
            '/Nursing/Templates/Audit/YearOneAuditTemplate.html',
            '/Nursing/Templates/Audit/YearTwoAuditTemplate.html',
            '/Nursing/Templates/Audit/YearThreeAuditTemplate.html',
            '/Nursing/Templates/Audit/MaleQuotaAuditTemplate.html',
            '/Nursing/Templates/Audit/FemaleQuotaAuditTemplate.html'
        ];

        self.ChangeSubTab = function (index) {
            self.AuditSubTemplate = self.SubTemplates[index];
            self.CurrentSubTab = index;
        };

        self.ChangeTab = function (tab) {
            self.CurrentTab = tab;
            self.AuditMainTemplate = self.MainTemplates[tab].Template;
            self.AuditSubTemplate = self.SubTemplates[self.MainTemplates[tab].DefaultTemplate];
            self.CurrentSubTab = self.MainTemplates[tab].DefaultTemplate;
        }

        self.SearchStudents = function(){
            self.NoStudentsFound = false;
            self.ShowMainTemplate = false;
            self.ShowLoader = true;
            http({
                method: 'GET',
                url: '/api/Nursingaudit?year=' + self.Student.Year + '&branchId=' + self.Student.BranchId
            })
                .success(function (data) {
                    self.ShowMainTemplate = true;
                    self.ShowLoader = false;
                    if(data.length == 0){self.NoStudentsFound = true;}
                    self.Students = data;
                    self.AuditEnvelope = data;                    
                })
                .error(function(error){
                    self.NoStudentsFound = true;
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.ShowPopup = function(student){
            rootScope.feeDetails = student;
            warningMessageService.OpenPopup({ template: '/Nursing/Templates/EditFeeDetailsModalTemplate', controller: 'EditFeeDetailsModalController', Callback: self.GetAllStudents });
        };

        self.GetBranches = function () {
            self.ShowLoader = true;
            http({
                method:'GET',
                url: '/api/Nursingbranch'
            })
                .success(function(data){
                    self.Branches = data;
                    self.Branches.unshift({ Id: 0, Name: "-----Please select -----" });
                    self.ShowLoader = false;
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.ShowStudentProfile = function(student){
            rootScope.studentProfileDetails = student;
            rootScope.StudentProfileTemplate = '/Nursing/Templates/StudentProfileTemplate.html';
        };

        self.GetYears = function () {
            http({
                method: 'GET',
                url: '/api/Nursingyear'
            })
                .success(function (data) {
                    self.Years = data;
                    self.Years.unshift('----- Please Select ------');
                })
                .error(function (error) {
                    alert(error);
                });
        };

        self.Clear = function(){
            self.Students = [];
            self.Student = { BranchId: 0, Year: '----- Please Select ------' };
            self.ShowMainTemplate = false;
            self.AuditEnvelope = {};
            self.ShowLoader = false;
            self.SetPristine();
        };
    };
    return model;
})();