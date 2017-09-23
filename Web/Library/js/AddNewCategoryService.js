angular.module('DAS').service('AddNewCategoryService', ['$http', 'WarningMessageService', function (http, warningMessageService) {

    return new AddNewCategoryServiceViewModel(http, warningMessageService);
}]);

var AddNewCategoryServiceViewModel = (function () {
    var model = function (http, warningMessageService) {
        var self = this;
        self.ShowLoader = false;
        self.BookCategory = { Description: '' };

       
        self.SaveBookCategory = function() {
            self.ShowLoader = true;
            http({
                method: 'POST',
                url: '/api/BookCategory',
                data: self.BookCategory
        })
                .success(function (data) {
                    self.ShowLoader = false;
                    alert(data);
                    self.Clear();
                    self.Close();
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.Clear = function() {
            self.BookCategory = { Description : '' };
        };
    };
    return model;
})();