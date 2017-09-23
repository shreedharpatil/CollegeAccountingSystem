angular.module('Login').service('LoginService', function ($http, $location) {
    return new viewModel($http, $location);
});

var viewModel = (function () {
    var model = function (http, location) {
        this.Login = { UserName: '', Password: '', Type: '' };
        this.Status = true;
        this.ShowLoader = false;
        this.DoLogin = function () {
            var self = this;
            self.ShowLoader = true;
            http({ method: 'POST', url: 'api/Login', data: self.Login }).success(function (data) {
                self.ShowLoader = false;
                self.Status = data.Status;
                if (data.Status) {
                    var path = location.$$protocol + '://' + location.$$host + ':' + location.$$port + '/' +self.Login.Application +data.Path;;// + "/" + self.Login.UserName;
                    window.location = path;
                }
            }).error(function (err) {
                self.ShowLoader = false;
                console.log(err);
            });
        };
    };
    return model;
})();
