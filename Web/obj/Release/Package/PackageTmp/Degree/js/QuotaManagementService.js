/**
 * Created by shreedhar on 5/24/2015.
 */
angular.module('DAS').service('QuotaManagementService',function($http){
    return new QuotaManagementServiceViewModel($http);
});

var QuotaManagementServiceViewModel = (function(){
    var model = function(http){
        var self = this;
        self.Quota = {BranchId:0};
        self.Branches = [];
        self.Branch = {};
        self.ShowLoader = false;

        self.GetBranches = function () {
            self.ShowLoader = true;
            http({
                method:'GET',
                url: '/api/Degreebranch'
            })
                .success(function(data){
                    self.Branches = data;
                    self.Branches.unshift({ Id: 0, Name: "-----Please select -----" });
                    self.ShowLoader = false;
                })
                .error(function(error){
                    alert(error);
                });

        };

        self.SaveQuotaDetails = function () {
            self.ShowLoader = true;
            http({
                method:'POST',
                url:'/api/quota',
                data:self.Quota
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    alert(data);
                    self.ClearQuota();
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.SaveBranchDetails = function () {
            self.ShowLoader = true;
            self.Branch.Application = "degree";
            http({
                method:'POST',
                url: '/api/Degreebranch',
                data:self.Branch
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    alert(data);
                    self.ClearBranch();
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.ClearBranch = function(){
            self.Branch = { Name: '' };
            self.SetPristine('addbranch');
        };

        self.ClearQuota = function(){
            self.Quota = { Quota: '' , BranchId : 0};
            self.SetPristine('quotaform');
        };
    };
    return model;
})();