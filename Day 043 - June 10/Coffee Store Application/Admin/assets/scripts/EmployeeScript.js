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

function getAllAdminDetails(){
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
                <td>${new Date(element.dateOfBirth).toLocaleDateString()}</td>
                <td>${element.salary}</td>
                <td>${element.role}</td>
                <td class="${statusClass}">${element.status}<br>
                <button class="${buttonClass}">${buttonText}</button>
                </td>`;
            tableBody.appendChild(row);
        });

    }).catch(error => {
        console.error(error);
    });
}

function getEmployeeDetails(){
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