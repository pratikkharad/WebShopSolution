$(document).ready(function () {
    $('#addUserForm').submit(function (event) {
        event.preventDefault(); // Prevent default form submission

        var errors = [];

        // Define custom validation rules
        var validationRules = {
            Email: { required: 'Email is required.' },
            FirstName: { required: 'FirstName is required.' },
            LastName: { required: 'LastName is required.' },
            PhoneNumber: { required: 'PhoneNumber is required.' },
            // Add more input fields with custom validation rules
        };

        // Iterate through each input field and validate
        for (var inputId in validationRules) {
            var inputErrors = Validation.validateInput(inputId, validationRules[inputId]);
            errors = errors.concat(inputErrors);
            Validation.displayErrors(inputId, inputErrors);
        }

        if (errors.length === 0) {
            // Form is valid, submit it
            // this.submit();
            $('#addUserForm').submit(function (e) {
                

                var formData = {
                    email: $('#Email').val(), 
                    firstName: $('#FirstName').val(), 
                    lastName: $('#LastName').val(), 
                    phoneNumber: $('#PhoneNumber').val()
                };

                sendPostRequest('', formData, function (response) {
                    displaySuccessMessage(response.message);

                    // Redirect to home/index only when response is successful
                    if (response.success) {

                        window.location.href = '/home/index';
                    }


                }, function (xhr, status, error) {
                    displayErrorMessage(xhr.responseText);
                });
            });
        }
    });

    // Clear validation errors on input change
    $('input').on('input', function () {
        Validation.clearErrors(this.id);
    });
});
