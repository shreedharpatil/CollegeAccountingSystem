var commonmodule = angular.module('DAS');

commonmodule.service('WarningMessageService',  function ($dialogs, $rootScope) {
    return new warningmessageviewModel($dialogs, $rootScope);
});

var warningmessageviewModel = (function () {
    var model = function (dialog, rootScope) {
        this.OpenPopup = function (data) {
            rootScope.Title = data.Heading;
            rootScope.Content = data.Body;
            rootScope.HtmlBody = data.HtmlBody;
            dlg = dialog.create(data.template, data.controller, {}, { key: true, back: 'static' });
            dlg.result.then(function () {
                if (data.Callback) {
                    data.Callback();
                }
            }, function () {
            });
        };
    }
    return model;
})();/**
 * Created by shreedhar on 5/24/2015.
 */
