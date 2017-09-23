/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').service('AdmissionService', function ($http, WarningMessageService, $rootScope, CommonModalService) {
    return new AdmissionServiceViewModel($http, WarningMessageService, $rootScope, CommonModalService);
});

var AdmissionServiceViewModel = (function(){
    var model = function (http, warningMessageService, rootScope, commonModalService) {
        var self = this;
        self.Admission = {Gender:'',Quota:'',BranchId : 0};
        self.Branches = [];
        self.Files = [];
        self.ShowLoader = false;
        self.GetBranches = function () {
            self.ShowLoader = true;
            http({
                method:'GET',
                url:'/api/branch'
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

        self.AdmitStudent = function () {
            self.ShowLoader = true;
            if(!self.Files[0]){
                self.Admission.IsPhotoUploaded = false;
            }
            else{
                self.Admission.IsPhotoUploaded = true;
            }

            http({
                method:"POST",
                url:"/api/student",
                data : self.Admission
            })
                .success(function(data){
                    if(self.Files[0]){
                        self.UploadPhoto(data);
                    }
                    else {
                        self.ShowLoader = false;
                        self.ShowMessage('Student Registration', data.Message);
                        //alert(data.Message);
                        self.Clear();
                    }
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    //alert(error);
                    self.ShowMessage('Error', error);
                });
        };

        this.filesChanged = function(elt){
            var self = this;
            self.Files = elt.files;
            self.Admission.image_url = '/student/' + self.Files[0].name;
            console.log(self.Admission.image_url);
        };

        self.UploadPhoto = function(data){
            var self = this;
            var formData = new FormData();
            //data = {FirstName:'shreedahr', Id:1};
            formData.append('studentPhoto', self.Files[0]);
            //console.log(formData);
            http.post('/api/UploadPhoto', formData, {
                headers: { 'Content-Type': undefined,
                studentId : data.Id,
                studentName : data.Name},
                transformRequest: angular.identity
            }).success(function (result) {
                self.ShowLoader = false;
                self.ShowMessage('Student Registration', result.Message);                
                self.Clear();
            }).error(function (error) {
                self.ShowLoader = false;
                self.ShowMessage('Error', error);                
            });
        };

        self.Clear = function () {
            self.Admission = { Gender: '', Quota: '', BranchId: 0 };
            self.SetPristine();
        };

        self.CheckSeatsAvailbility = function () {
            http({
                method: 'GET',
                url: '/api/CheckSeats?Quota=' + self.Admission.Quota + '&BranchId=' + self.Admission.BranchId
            })
            .success(function (data) {
                if (data) {                    
                    self.AdmitStudent();
                }
                else {
                    self.ShowMessage('No Seats available', 'The available seat quota under ' + self.Admission.Quota + ' for the branch ' + self.GetBranchName(self.Admission.BranchId) + ' is over.');
                }
            })
            .error(function (error) {
                self.ShowMessage('Error', error);
            });
        };

        self.GetBranchName = function (branchId) {
            var branch = _.where(self.Branches, { Id: branchId });
            return branch[0].Name;
        };

        self.ShowMessage = function (title,content) {
            commonModalService.Title = title;
            commonModalService.Content = content;
            warningMessageService.OpenPopup({ template: '/Diploma/Templates/CommonModalTemplate.html', controller: 'CommonModalController', Heading: title, Body: content });
        };
    };

    return model;
})();