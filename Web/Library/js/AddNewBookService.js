angular.module('DAS').service('AddNewBookService', ['$http', 'WarningMessageService', function (http, warningMessageService) {

    return new AddNewBookServiceViewModel(http, warningMessageService);
}]);

var AddNewBookServiceViewModel = (function() {
    var model = function (http, warningMessageService) {
        var self = this;
        self.ShowLoader = false;
        self.Book = { BranchId : 0 , CategoryId : 0};
        self.Branches = [];
        self.BookCategories = [];

        self.Initialize = function() {
            self.Clear();
        };

        self.LoadBranches = function() {
            self.ShowLoader = true;
            http({
                method: 'GET',
                url : '/api/LibraryBranch?application='
                })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.Branches = data;
                    self.Branches.unshift({ Id : 0 , Name : "----- Please select -----" });
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.LoadBookCategories = function () {
            self.ShowLoader = true;
            http({
                method: 'GET',
                url: '/api/BookCategory'
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.BookCategories = data;
                    self.BookCategories.unshift({ CategoryId: 0, Description: "----- Please select -----" });
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.SaveBook = function() {
            self.ShowLoader = true;
            http({
                method: 'POST',
                url: '/api/Book',
                data : self.Book
        })
                .success(function (data) {
                    self.ShowLoader = false;
                    alert(data);
                    self.Clear();
                    self.SetPristine();
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.Clear = function() {
            self.Book = { BranchId: 0, CategoryId: 0 };
        };

        self.NewBookCategory = function() {
            warningMessageService.OpenPopup({ template: '/Library/Templates/AddNewBookCategoryModalTemplate.html', controller: 'AddNewCategoryController', Callback: self.LoadBookCategories });
        };
    };
    return model;
})();