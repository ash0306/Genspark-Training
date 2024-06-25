var typed = new Typed("#typed-element", {
    strings: ["Customer Details"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});

var adminRole = '';

var token = sessionStorage.getItem('employeeToken');
const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
adminRole = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

document.addEventListener('DOMContentLoaded', function(){
    getAllDetails();
});

function newToast(classBackground, message){
    const toastNotification = new bootstrap.Toast(document.getElementById('toastNotification'));
    var toast = document.getElementById('toastNotification');
    toast.className = 'toast align-items-center text-white border-0';
    toast.classList.add(`${classBackground}`);
    var toastBody = document.querySelector(".toast-body");
    if (toastBody) {
        toastBody.innerHTML = `${message}`;
    }
    toastNotification.show();
}

function getAllDetails() {
    fetch('http://localhost:5228/api/customer/getAll',{
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async(response)=>{
        const data = await response.json();
        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 

        data.forEach(element => {
            const row = document.createElement('tr');

            row.innerHTML = `
                <td>${element.name}</td>
                <td>${element.email}</td>
                <td>${element.phone}</td>
                <td>${new Date(element.dateOfBirth).toLocaleDateString()}</td>
                <td>
                    <span class="points-view">${element.loyaltyPoints}</span>
                    <input type="text" class="points-edit form-control d-none" value="${element.loyaltyPoints}">
                    <i class="bi bi-pencil-square points-edit-icon" style="cursor: pointer; float:right;" id="edit-icon"></i>
                    <button class="btn btn-success btn-sm points-save d-none m-1">Save</button>
                    <button class="btn btn-danger m-1 btn-sm d-none" id="cancel-changes">Cancel</button>
                </td>
            `;
            tableBody.appendChild(row);

            const pointsView = row.querySelector('.points-view');
            const pointsEdit = row.querySelector('.points-edit');
            const pointsEditIcon = row.querySelector('.points-edit-icon');
            const pointsSave = row.querySelector('.points-save');
            const cancelChanges = row.querySelector('#cancel-changes');

            if (adminRole === 'Admin') {
                pointsEditIcon.style.display = 'none';
            }

            pointsEditIcon.addEventListener('click', () => {
                pointsView.classList.add('d-none');
                pointsEdit.classList.remove('d-none');
                pointsEditIcon.classList.add('d-none');
                pointsSave.classList.remove('d-none');
                cancelChanges.classList.remove('d-none');
            });

            pointsSave.addEventListener('click', () => {
                const newPoints = pointsEdit.value;
                var status = updatePoints(element.email, newPoints);
                
                if(status === 200){
                    pointsView.textContent = newPoints;
                    pointsView.classList.remove('d-none');
                    pointsEditIcon.classList.remove('d-none');
                    pointsEdit.classList.add('d-none');
                    pointsSave.classList.add('d-none');
                    cancelChanges.classList.add('d-none');

                    newToast("bg-success", "Points updated successfully");
                }
            });

            cancelChanges.addEventListener('click', () => {
                pointsView.classList.remove('d-none');
                pointsEdit.classList.add('d-none');
                pointsEditIcon.classList.remove('d-none');
                pointsSave.classList.add('d-none');
                cancelChanges.classList.add('d-none');
            });
        });
        addDataTable();
    }).catch(error => console.log(error));
}

function searchResults(customerEmail){
    fetch('http://localhost:5228/api/customer/getAll',{
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async(response)=>{
        const data = await response.json();
        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 

        var filteredResults = data.filter(element => element.email.toLowerCase().includes(customerEmail.toLowerCase()));

        filteredResults.forEach(element => {
            const row = document.createElement('tr');

            row.innerHTML = `
                <td>${element.name}</td>
                <td>${element.email}</td>
                <td>${element.phone}</td>
                <td>${element.dateOfBirth}</td>
                <td>${element.loyaltyPoints}</td>
            `;
            tableBody.appendChild(row);
        });
    }).catch(error => console.log(error));
}

function updatePoints(customerEmail, newPoints){
    fetch("http://localhost:5228/api/customer/updateLoyaltyPoints",{
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify({
            email: customerEmail,
            loyaltyPoints: newPoints
        })
    }).then(async(response) => {
        var data = await response.json();

        if(response.status !== 200) {
            newToast("bg-danger", `${data.message}`);
            return 0;
        }
    })
    return 200;
}

function addDataTable(){
    const table = $("#table-custom").DataTable({
        columns: [null, null, null, null, null],
        pagingType: "full_numbers",
        pageLength: 10,
        language: {
            paginate: {
            previous: '<span><i class="bi bi-chevron-left"></i></span>',
            next: '<span><i class="bi bi-chevron-right"></i></span>',
            first: '<span><i class="bi bi-chevron-bar-left"></i></span>',
            last: '<span><i class="bi bi-chevron-bar-right"></i></span>',
            },
            lengthMenu:
            'Display <select class="form-control input-sm">' +
            '<option value="5">5</option>' +
            '<option value="10">10</option>' +
            '<option value="15">15</option>' +
            '<option value="20">20</option>' +
            '<option value="25">25</option>' +
            '<option value="-1">All</option>' +
            "</select> results",
        },
    });

    table.draw();
}