document.addEventListener('DOMContentLoaded', function(){
    
    if(sessionStorage.getItem("employeeToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
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

var token = sessionStorage.getItem('employeeToken');

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
                <td>${element.dateOfBirth}</td>
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