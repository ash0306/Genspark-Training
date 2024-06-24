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
        // var editBtn = document.getElementById('edit-icon');
        // editBtn.style.display = 'none';
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
                    <i class="bi bi-pencil-square points-edit-icon" style="cursor: pointer;" id="edit-icon"></i>
                    <button class="btn btn-primary btn-sm points-save d-none m-1">Save</button>
                </td>
            `;
            tableBody.appendChild(row);

            const pointsView = row.querySelector('.points-view');
            const pointsEdit = row.querySelector('.points-edit');
            const pointsEditIcon = row.querySelector('.points-edit-icon');
            const pointsSave = row.querySelector('.points-save');

            if (adminRole === 'Admin') {
                pointsEditIcon.style.display = 'none';
            }

            pointsEditIcon.addEventListener('click', () => {
                pointsView.classList.add('d-none');
                pointsEdit.classList.remove('d-none');
                pointsEditIcon.classList.add('d-none');
                pointsSave.classList.remove('d-none');
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

                    newToast("bg-success", "Points updated successfully");
                }
            });
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