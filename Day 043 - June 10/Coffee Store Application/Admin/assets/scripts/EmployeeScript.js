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

    const searchInput = document.getElementById('search-input');
    searchInput.addEventListener('input', async function() {
        const employeeEmail = this.value.trim();
        if (employeeEmail.length === 0) {
            getAllAdminDetails();
            return;
        }
        searchResults(employeeEmail);
    });
    
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

            salaryEditIcon.addEventListener('click', () => {
                salaryView.classList.add('d-none');
                salaryEdit.classList.remove('d-none');
                salaryEditIcon.classList.add('d-none');
                salarySave.classList.remove('d-none');
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

                    newToast("bg-success", "Salary updated successfully");
                }
            });
        });

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
            <button class="btn btn-primary btn-sm salary-save d-none m-1">Save</button>
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

function searchResults(employeeEmail){
    fetch('http://localhost:5228/api/employee/getAll',{
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async(response)=>{
        const data = await response.json();
        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 

        var filteredResults = data.filter(element => element.email.toLowerCase().includes(employeeEmail.toLowerCase()));

        filteredResults.forEach(element => {
            const row = document.createElement('tr');

            var statusClass = '';
            var buttonText = '';
            var buttonClass = '';
            if (element.status === 'Active') {
                statusClass = 'text-success fw-bold';
                buttonText = 'Deactivate Employee';
                buttonClass = 'btn btn-danger';
            } else if (element.status === 'Inactive') {
                statusClass = 'text-danger fw-bold';
                buttonText = 'Activate Employee';
                buttonClass = 'btn btn-success';
            }
                
            row.innerHTML = `
                <td>${element.id}</td>
                <td>${element.name}</td>
                <td>${element.email}</td>
                <td>${element.phone}</td>
                <td>${element.dateOfBirth}</td>
                <td>${element.salary}</td>
                <td>${element.role}</td>
                <td class="${statusClass}">${element.status}<br>
                <button class="${buttonClass}">${buttonText}</button>
                </td>`;
            tableBody.appendChild(row);
        });
    }).catch(error => console.log(error));
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