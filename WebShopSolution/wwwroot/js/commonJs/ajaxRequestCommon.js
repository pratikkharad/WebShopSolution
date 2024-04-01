// ajaxCommon.js (without using sendAjaxRequest)



// Function to get CSRF token from cookie
function getCSRFToken() {
    return $('input[name="__RequestVerificationToken"]').val();
}
/**
 * Sends a POST AJAX request.
 * @param {string} url - The URL of the request.
 * @param {Object} data - The data to be sent in the request.
 * @param {function} successCallback - The callback function to handle success response.
 * @param {function} errorCallback - The callback function to handle error response.
 */
function sendPostRequest(url, data,  successCallback, errorCallback) {
   

    

    $.ajax({
        url: window.location.href + url,
        type: 'POST',
        contentType: 'application/json',
        headers: {
            'X-CSRF-TOKEN': getCSRFToken() // Include CSRF token in request header
        },
        data: JSON.stringify(data),
        success: function (response) {
            if (typeof successCallback === 'function') {
                successCallback(response);
            }

        },
        error: function (xhr, status, error) {
            if (typeof errorCallback === 'function') {
                errorCallback(xhr, status, error);
                alert("An error occurred: " + error);
            }
        }
    });
}

/**
 * Sends a GET AJAX request.
 * @param {string} url - The URL of the request.
 * @param {function} successCallback - The callback function to handle success response.
 * @param {function} errorCallback - The callback function to handle error response.
 */
function sendGetRequest(url, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (response) {
            if (typeof successCallback === 'function') {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (typeof errorCallback === 'function') {
                errorCallback(xhr, status, error);
            }
        }
    });
}

/**
 * Sends a PUT AJAX request.
 * @param {string} url - The URL of the request.
 * @param {Object} data - The data to be sent in the request.
 * @param {function} successCallback - The callback function to handle success response.
 * @param {function} errorCallback - The callback function to handle error response.
 */
function sendPutRequest(url, data, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: 'PUT',
        contentType: 'application/json',
        headers: {
            RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() // Anti-forgery token
        },
        data: JSON.stringify(data),
        success: function (response) {
            if (typeof successCallback === 'function') {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (typeof errorCallback === 'function') {
                errorCallback(xhr, status, error);
            }
        }
    });
}

/**
 * Sends a DELETE AJAX request.
 * @param {string} url - The URL of the request.
 * @param {function} successCallback - The callback function to handle success response.
 * @param {function} errorCallback - The callback function to handle error response.
 */
function sendDeleteRequest(url, successCallback, errorCallback) {
    $.ajax({
        url: url,
        type: 'DELETE',
        success: function (response) {
            if (typeof successCallback === 'function') {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (typeof errorCallback === 'function') {
                errorCallback(xhr, status, error);
            }
        }
    });
}
