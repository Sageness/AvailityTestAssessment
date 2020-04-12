// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#txtPhone').mask('(000) 000-0000');
    $('#txtNPI').mask('0000000000');

    //block default form submit
    $("#registrationForm").submit(function (e) {
        e.preventDefault(e);
    });
});


function validateform() {
    //Check email format with some super Regex
    var emailAddress = $("#txtEmail").val();
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;

    if (!pattern.test(emailAddress)) {
        alert("Email address is an invalid format! Please correct this and submit the form again!");
        return;
    }

    //Check NPI length - should be 10 characters long
    if ($("#txtNPI").val().length !== 10) {
        alert("NPI should be at least 10 digits!");
        return;
    }

    //Passed validation, let's submit. 
    submitRegistrationForm();
}

function submitRegistrationForm() {
    $.ajax({
        type: "POST",
        url: "../Home/SubmitProviderInquiry",
        data: {
            providerFirstName: $("#txtFirstName").val(),
            providerLastName: $("#txtLastName").val(),
            providerNpi: $("#txtNPI").val(),
            providerAddress: $("#txtAddress").val(),
            providerCity: $("#txtCity").val(),
            providerState: $("#ddlState").val(),
            providerZip: $("#txtZip").val(),
            providerPhone: $("#txtPhone").val(),
            providerEmail: $("#txtEmail").val()
        },
        success: function () {
            alert("Provider registration has been submitted! Someone from our team will review your submission and will contact you soon!");
        },
        error: function () {
            alert("There was an error with your submission! An error report has been sent to our team. Please try to refresh and try again. If the problems persist, please contact our support team at 867-5309.");
        }
    });
}