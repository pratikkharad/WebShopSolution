// Page realted constant value and send the asc and desc for the metod 
const pageSize = 10;
let currentPage = 1;
let sortColumn = 'Id';
let sortOrder = 'asc';

function getUser() {
    $.ajax({
        url: `/home/index?page=${currentPage}&pageSize=${pageSize}&sortColumn=${sortColumn}&sortOrder=${sortOrder}`,
        method: 'GET',
        dataType: 'json', // Specify the expected data type
        success: function (data) {
            displayUsers(data);
            console.log(data);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText); // Log the detailed error message
            // Handle the error appropriately (e.g., display an error message to the user)
        }

    });
}
function displayUsers(users, maxRows) {
    const tbody = $('#userTable tbody');
    tbody.empty();

    if (!users || users.length === 0) {
        return; // No need to display a message
    }

    let displayedRows = 0;

    for (const item of users) {
        if (item) {
            const id = item.Id !== undefined ? item.Id : '';
            const firstName = item.FirstName !== undefined ? item.FirstName : '';
            const dateOfBirth = item.DateOfBirth !== undefined ? item.DateOfBirth : '';
            const phoneNumber = item.PhoneNumber !== undefined ? item.PhoneNumber : '';

            const row = `<tr>
                <td>${id}</td>
                <td>${firstName}</td>
                <td>${dateOfBirth}</td>
                <td>${phoneNumber}</td>
            </tr>`;

            tbody.append(row);
            // Add other cells as needed

            displayedRows++;

            if (displayedRows === maxRows) {
                break; // Exit the loop once the desired number of rows is reached
            }
        }
    }
}

function sortTable(column) {
    if (column === sortColumn) {
        sortOrder = sortOrder === 'asc' ? 'desc' : 'asc';
    } else {
        sortColumn = column;
        sortOrder = 'asc';
    }

    getUser();
}

$(document).ready(function () {

    // Call someFunction1 when the document is ready
    getUser();

    // Event delegation for click events
    $(document).on('click', '.sortData', function () {
        // Call someFunction2 when #elementId1 is clicked
        sortTable();
    });

});



$(document).ready(function () {
    // Call getUser when the document is ready
    getUser();

// Event delegation for click events
    $(document).on('click', '.sortData', function () {
    // Call sortTable when an element with class .sortData is clicked
    sortTable();
    });
});
