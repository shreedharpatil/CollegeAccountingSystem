/**
 * Created by shreedhar on 5/23/2015.
 */
angular.module('DAS').controller('FacultyController', function ($scope) {
    $scope.Faculties = [
        {
            Id: 1, Name: 'Shreedhar, patil', ContactNumber: 9868574857, Qualification: 'Phd', Subjects: 'Kannada, English', EmailId: 'shreedhar@gmail.com', HandlesClassess: '8, 9, 10', ImageUrl: '/photos/default/photo3.jpg'
        },
        {
            Id: 2, Name: 'Pramod, patil', ContactNumber: 9868574857, Qualification: 'Phd', Subjects: 'Kannada, English', EmailId: 'shreedhar@gmail.com', HandlesClassess: '8, 9, 10', ImageUrl: '/photos/default/photo4.png'
        },
        {
            Id: 3, Name: 'Santosh, patil', ContactNumber: 9868574857, Qualification: 'Phd', Subjects: 'Kannada, English', EmailId: 'shreedhar@gmail.com', HandlesClassess: '8, 9, 10', ImageUrl: '/photos/default/photo5.jpg'
        },
        {
            Id: 4, Name: 'Aryan, Swamy', ContactNumber: 9868574857, Qualification: 'Phd', Subjects: 'Kannada, English', EmailId: 'shreedhar@gmail.com', HandlesClassess: '8, 9, 10', ImageUrl: '/photos/default/photo1.jpg'
        },
        {
            Id: 5, Name: 'Arun, S', ContactNumber: 9868574857, Qualification: 'Phd', Subjects: 'Kannada, English', EmailId: 'shreedhar@gmail.com', HandlesClassess: '8, 9, 10', ImageUrl: '/photos/default/photo2.png'
        },
        {
            Id: 6, Name: 'Ram, K', ContactNumber: 9868574857, Qualification: 'Phd', Subjects: 'Kannada, English', EmailId: 'shreedhar@gmail.com', HandlesClassess: '8, 9, 10', ImageUrl: '/photos/default/photo10.jpg'
        }
    ];
});