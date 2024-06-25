AOS.init({duration:1500});

var token = sessionStorage.getItem('employeeToken');
var adminRole = '';
const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
adminRole = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

const adminDetailsDiv = document.getElementById('div-container');
const employeeDetailsDiv = document.getElementById('div-content');

document.addEventListener('DOMContentLoaded', function () {    
    if (adminRole == 'Admin') {
        getAllAdminDetails();
    } 
    else {
        getEmployeeDetails();
    }
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

function getAllAdminDetails(){
    var typed = new Typed("#typed-element1", {
        strings: ["Employee Details"],
        typeSpeed: 50,
        cursorChar: "",
        loop: false
    });
    adminDetailsDiv.style.display = 'block';
    employeeDetailsDiv.style.display = 'none';

    fetch('http://localhost:5228/api/employee/getAll', {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {
        // console.log(response);
        var data = await response.json();
        // console.log(data);
        AOS.init({duration:1500});

        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 
        data.forEach(element => {
            var row = addRow(element);
            tableBody.appendChild(row);

            const salaryView = row.querySelector('.salary-view');
            const salaryEdit = row.querySelector('.salary-edit');
            const salaryEditIcon = row.querySelector('.salary-edit-icon');
            const salarySave = row.querySelector('.salary-save');
            const cancelChanges = row.querySelector('#cancel-changes');

            salaryEditIcon.addEventListener('click', () => {
                salaryView.classList.add('d-none');
                salaryEdit.classList.remove('d-none');
                salaryEditIcon.classList.add('d-none');
                salarySave.classList.remove('d-none');
                cancelChanges.classList.remove('d-none');
            });

            salarySave.addEventListener('click', () => {
                const newSalary = salaryEdit.value;
                var status = updateSalary(element.id, newSalary);
                console.log(status);
                if(status === 200){
                    salaryView.textContent = newSalary;
                    salaryView.classList.remove('d-none');
                    salaryEditIcon.classList.remove('d-none');
                    salaryEdit.classList.add('d-none');
                    salarySave.classList.add('d-none');
                    cancelChanges.classList.add('d-none');

                    newToast("bg-success", "Salary updated successfully");
                }
            });

            cancelChanges.addEventListener('click', () => {
                salaryView.classList.remove('d-none');
                salaryEdit.classList.add('d-none');
                salaryEditIcon.classList.remove('d-none');
                salarySave.classList.add('d-none');
                cancelChanges.classList.add('d-none');
            });
        });
        addDataTable();
    }).catch(error => {
        console.error(error);
    });
}

function addRow(element){
    const row = document.createElement('tr');

    var statusClass = '';
    var buttonText = '';
    var buttonClass = '';
    if (element.status === 'Active') {
        statusClass = 'text-success fw-bold';
        buttonText = 'Deactivate Employee';
        buttonClass = 'btn btn-danger';
        functionName = 'deactivateEmployee';
    } else if (element.status === 'Inactive') {
        statusClass = 'text-danger fw-bold';
        buttonText = 'Activate Employee';
        buttonClass = 'btn btn-success';
        functionName = 'activateEmployee';
    }
    
    if(element.salary === null){
        element.salary = 0;
    }
    row.innerHTML = `
        <td>${element.id}</td>
        <td>${element.name}</td>
        <td>${element.email}</td>
        <td>${element.phone}</td>
        <td>${new Date(element.dateOfBirth).toLocaleDateString()}</td>
        
        <td>
            <span class="salary-view">${element.salary}</span>
            <input type="number" class="salary-edit form-control d-none" value="${element.salary}">
            <i class="bi bi-pencil-square salary-edit-icon" style="cursor: pointer;"></i>
            <button class="btn btn-success btn-sm salary-save d-none m-1">Save</button>
            <button class="btn btn-danger m-1 btn-sm d-none" id="cancel-changes">Cancel</button>
        </td>
        <td>${element.role}</td>
        <td class="${statusClass}">${element.status}<br>
        <button class="${buttonClass}" onclick="${functionName}('${element.id}')">${buttonText}</button>
        </td>`;

    return row;
}

function getEmployeeDetails(){
    var typed = new Typed("#typed-element2", {
        strings: ["Employee Details"],
        typeSpeed: 50,
        cursorChar: "",
        loop: false
    });
    adminDetailsDiv.style.display = 'none';
    employeeDetailsDiv.style.display = 'block';

    fetch('http://localhost:5228/api/employee/getById?id='+tokenId, {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {
        const data = await response.json();
        console.log(data);

        AOS.init({duration:1500});  
        var userDiv = document.getElementById('user-details');
        userDiv.innerHTML = '';

        if(response.ok) {
            userDiv.innerHTML = `
            <li class="list-group-item"><strong>Name : </strong>${data.name}</li>
            <li class="list-group-item"><strong>Date Of Birth : </strong>${new Date(data.dateOfBirth).toLocaleDateString()}</li>
            <li class="list-group-item"><strong>Email ID : </strong>${data.email}</li>
            <li class="list-group-item"><strong>Phone : </strong>${data.phone}</li>
            <li class="list-group-item"><strong>Salary : </strong>${data.salary}</li>
            <li class="list-group-item"><strong>Role : </strong>${data.role}</li>
        `;
        return;
        }
        
        userDiv.innerHTML = `${data.message}`;

    }).catch(error => {
        console.error(error);
    });
}

function deactivateEmployee(employeeId){
    if(employeeId === tokenId){
        newToast("bg-danger", "Cannot update your own status");
        return;
    }

    fetch('http://localhost:5228/api/employee/deactivateEmployee?id='+employeeId,{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    }).then(async(response) => {
        // console.log(response);
        var data = response.json();
        // console.log(data);

        if (response.ok) {
            newToast("bg-success", "Status updated successfully. Reloading...");
            setTimeout(() =>{
                location.reload();
            }, 2000);
        }
        else{
            newToast("bg-danger", "Unable to update status. Try again later");
        }
    })
}

function activateEmployee(employeeId){
    if(employeeId === tokenId){
        newToast("bg-danger", "Cannot update your own status");
        return;
    }

    
    fetch('http://localhost:5228/api/employee/activateEmployee?id='+employeeId,{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        }
    }).then(async(response) => {
        // console.log(response);
        var data = response.json();
        // console.log(data);

        if (response.ok) {
            newToast("bg-success", "Status updated successfully. Reloading...");
            setTimeout(() =>{
                location.reload();
            }, 2000);
        }
        else{
            newToast("bg-danger", "Unable to update status. Try again later");
        }
    })
}

function updateSalary(employeeId, newSalary){
    fetch("http://localhost:5228/api/employee/updateSalary",{
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify({
            employeeId: employeeId,
            employeeSalary: newSalary
        })
    }).then(async(response) => {
        var data = await response.json();
        // console.log(data);

        if(response.status !== 200) {
            newToast("bg-danger", `${data.message}`);
            return 0;
        }
    })
    return 200;
}

function addDataTable() {
    const table = $("#table-custom").DataTable({
        columns: [null, null, null, null, null, null, null, null],
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