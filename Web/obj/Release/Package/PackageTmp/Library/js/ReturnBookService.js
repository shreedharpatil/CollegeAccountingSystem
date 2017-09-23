angular.module('DAS').service('ReturnBookService', ['$http', function(http) {
    return new ReturnBookServiceViewModel(http);
}]);

var ReturnBookServiceViewModel = (function() {

    var model = function(http) {
        var self = this;
        self.Initialize = function () {
            self.SearchCriteria = {Application  : '', BranchId : 0};
            self.Branches = [];
            self.Student = {};
            self.BookCategories = [];
            self.Students = [];
        };

        self.LoadBranches = function () {
            self.ShowLoader = true;
            self.SearchCriteria.BranchId = 0;
            http({
                method: 'GET',
                url: '/api/LibraryBranch?application=' + self.SearchCriteria.Application
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.Branches = data;
                    self.Branches.unshift({ Id: 0, Name: "----- Please select -----" });
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.LoadStudents = function () {
            self.ShowLoader = true;
            self.Student = {};
            self.BooksBorrowed = [];
            $('#studentsdropdown').text('Filter Students');
            http({
                method: 'GET',
                url: '/api/StudentSearch?BranchId=' + self.SearchCriteria.BranchId + '&Application=' + self.SearchCriteria.Application
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.Students = data;
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.SelectStudent = function(student) {
            self.Student = student;
            self.LoadStudentBooksBorrowed();
        };

        self.LoadStudentBooksBorrowed = function () {
            self.ShowLoader = true;
            http({
                method: 'GET',
                url: '/api/BookReturn?StudentId=' + self.Student.Id 
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.BooksBorrowed = data;
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.ReturnBooks = function (book) {
            book.ShowLoader = true;
            http({
                method: 'PUT',
                url: '/api/BookReturn',
                data: book
            })
                .success(function (data) {
                    book.ShowLoader = false;
                    book.ShowEditSection = false;
                    self.LoadStudentBooksBorrowed();
                    alert(data);
                })
                .error(function (error) {
                    book.ShowLoader = false;
                    alert(error);
                });
        };
    };
    return model;
})();