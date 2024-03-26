// login.js

$(document).ready(function () {
    $('#loginForm').submit(function (e) {
        e.preventDefault();
        var formData = {
            UserName: $('#email').val(), // Change 'userName' to 'UserName'
            Password: $('#password').val() // Change 'password' to 'Password'
        };

        sendPostRequest('Login/Index', formData, function (response) {
            displaySuccessMessage(response.message);
            // Redirect to dashboard or perform other actions
        }, function (xhr, status, error) {
            displayErrorMessage(xhr.responseText);
        });
    });
});

// Function to sanitize data
function sanitizeData(data) {
    if (!isValidEmail(data.UserName)) {
        displayErrorMessage('Invalid email format');
        return false;
    }

    if (data.Password.length < 3) {
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