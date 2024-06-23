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
    if(adminRole === 'Admin'){
        var updateBtn = document.getElementById('updateBtn');
        updateBtn.style.display = 'none';
    }
    getAllDetails();

    const searchInput = document.getElementById('search-input');
    searchInput.addEventListener('input', async function() {
        const customerEmail = this.value.trim();
        if (customerEmail.length === 0) {
            getAllDetails();
            return;
        }
        searchResults(customerEmail);
    });
});

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
                <td>${element.loyaltyPoints}</td>
            `;
            tableBody.appendChild(row);
        });
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