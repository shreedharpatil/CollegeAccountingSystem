angular.module('DAS').service('IssueBookService', ['$http', '$filter', function (http, filter) {
    return new IssueBookServiceViewModel(http, filter);
}]);

var IssueBookServiceViewModel = (function() {
    var model = function(http, filter) {
        var self = this;

        self.Initialize = function (setEmpty) {
            self.ShowLoader = false;
            self.SearchCriteria = { BranchId: 0, CategoryId: 0, SelectedApplication: 'Diploma' };
            if (setEmpty) {
                self.Branches = [];
                self.BookCategories = [];
            }
            self.Books = [];
            self.Book = {};
            self.CurrentStep = 1;
            self.FirstTabClass = 'active';
            self.SecondTabClass = '';
            self.ThirdTabClass = '';
            self.CurrentTemplate = '/Library/Templates/SelectBookTemplate.html';
            self.StudentBranches = [];
            self.BookBorrow = {};
            self.IssueBook = {};
            self.Student = {};
        };

        self.OnApplicationChanged = function () {
            self.ShowLoader = true;
            self.StudentBranches = filter('filter')(self.Branches, { Application: self.SearchCriteria.SelectedApplication });
            self.SearchCriteria.BranchId = self.StudentBranches[0].Id;
            self.ShowLoader = false;
        };

        self.ChangeStep = function (step) {
            self.CurrentStep = step;
            if (step == 1) {
                self.FirstTabClass = 'active';
                self.SecondTabClass = '';
                self.ThirdTabClass = '';
                self.CurrentTemplate = '/Library/Templates/SelectBookTemplate.html';
            }
            else if (step == 2) {
                self.FirstTabClass = 'completed';
                self.SecondTabClass = 'active';
                self.ThirdTabClass = '';
                self.CurrentTemplate = '/Library/Templates/SelectStudentTemplate.html';
            }
            else if (step == 3) {
                self.FirstTabClass = 'completed';
                self.SecondTabClass = 'completed';
                self.ThirdTabClass = 'active';
                self.CurrentTemplate = '/Library/Templates/ConfirmBookTemplate.html';
            }
        };

        self.LoadBranches = function () {
            self.ShowLoader = true;
            http({
                method: 'GET',
                url: '/api/LibraryBranch?application='
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

        self.SearchBooks = function () {
            self.ShowLoader = true;
            self.Book = {};
            $('#bookdropdown').text('Filter Books');
            http({
                method: 'GET',
                url: '/api/SearchBook?BranchId=' + self.SearchCriteria.BranchId + '&CategoryId=' + self.SearchCriteria.CategoryId
            })
                .success(function (data) {
                    self.ShowLoader = false;
                    self.Books = data;
                })
                .error(function (error) {
                    self.ShowLoader = false;
                    alert(error);
                });
        };

        self.SelectBook = function(book) {
            self.Book = book;
        };

        self.SelectStudent = function(student) {
            self.Student = student;
        };

        self.LoadStudents = function () {
            self.ShowLoader = true;
            self.Student = {};
            $('#studentsdropdown').text('Filter Students');
            http({
                method: 'GET',
                url: '/api/StudentSearch?BranchId=' + self.SearchCriteria.BranchId + '&Application=' + self.SearchCriteria.SelectedApplication
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

        self.PrepareIssueBookObject = function () {
            self.IssueBook.StudentId = self.Student.Id;
            self.IssueBook.BranchId = self.SearchCriteria.BranchId;
            self.IssueBook.BookId = self.Book.BookId;
            self.IssueBook.ISBN = self.Book.ISBN;
            return self.IssueBook;
        };

        self.IssueBooks = function() {
            self.ShowLoader = true;
            http({
                method: 'POST',
                url: '/api/IssueBook',
                data: self.PrepareIssueBookObject()
            })
               .success(function (data) {
                   self.ShowLoader = false;
                   self.Initialize(false);
                   self.ChangeStep(1);
                    alert(data);
                })
               .error(function (error) {
                   self.ShowLoader = false;
                   alert(error);
               });
        };
    };
    return model;
})();
