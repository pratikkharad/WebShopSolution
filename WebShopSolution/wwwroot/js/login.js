// login.js

$(document).ready(function () {
    $('#loginForm').submit(function (e) {
        e.preventDefault();
                
        var formData = {
            userName: $('#email').val(), // Change 'userName' to 'UserName'
            password: $('#password').val() // Change 'password' to 'Password'
        };

        if (!sanitizeData(data)) {
            return; // Stop further processing if data sanitization fails
        }
        sendPostRequest('Login/Index', formData, function (response) {
            displaySuccessMessage(response.message);

            // Redirect to home/index only when response is successful
            if (response.success) {
               
                window.location.href = '/home/index';
            }
           

        }, function (xhr, status, error) {
            displayErrorMessage(xhr.responseText);
        });
    });
});

// Function to sanitize data
function sanitizeData(data) {
    if (!isValidEmail(data.userName)) {
        displayErrorMessage('Invalid email format');
        return false;
    }

    if (data.password.length < 3) {
        displayErrorMessage('Password must be at least 6 characters long');
        return false;
    }

    return true;
}

// Function to validate email format
function isValidEmail(email) {
    // Regular expression for Gmail format
    return email && email.trim() !== "";
}