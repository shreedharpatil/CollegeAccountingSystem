var commonWarningMessage = function () {
    var self = this;
    self.FirstNameMandatory = "Please enter the first name.";
    self.LastNameMandatory = "Please enter the last name.";
    self.NameMandatory = "Please enter the \ name.";
    self.GenderMandatory = "Please select gender.";
    self.BranchMandatory = "Please select branch.";
    self.QuotaMandatory = "Please select quota.";
    self.AddressMandatory = "Please enter an address.";
    self.ContactNumberMandatory = "Please enter contact number.";
    self.ContactNumberRegEx = /^[0-9]{10,12}$/;
    self.ContactNumberRegExMessage = "Contact number should contains only numbers.";
    self.PhotoSizeWarningMessage = "Maximum photo size is 2MB";
    self.YearMandatory = 'Please select year.';
    self.NumberRegExMessage = 'Please enter only numbers.';
    self.NumberRequiredMessage  = 'Please enter number of seats.';
    self.NumberRegEx = /^[0-9]+$/;
    self.BranchNameMandatory = "Please enter branch name.";
    self.StudentIdMandatory = 'Please enter student id.';

    self.FeeRegEx = /^\d+(\.\d{1,2})?$/;
    self.FeeRegExMessage = 'Fee should contain only numbers.';
    self.FeeMandatoryMessage = 'This field is mandatory';
    self.PaidFeeShoouldBeLessThanOrEqaulToTotalFeeMessage = 'Paid fee should be less than or equal to total fee';
    self.DueFeeShouldBeLessThanOrEqualToCurrentDueFee = 'Entered due fee should be less than or equal to current due fee';
};