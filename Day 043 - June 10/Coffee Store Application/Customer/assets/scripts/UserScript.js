AOS.init({ duration: 1500 });

document.addEventListener('DOMContentLoaded', function () {
    if (sessionStorage.getItem("customerToken") == null) {
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function () {
            window.location.href = './Login.html';
        });
        return;
    }

    displayUserDetails();
});

var userTyped = new Typed("#user-typed", {
    strings: ["User Details"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});

var token = sessionStorage.getItem('customerToken');

const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

function newToast(classBackground, message) {
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

function displayUserDetails() {
    fetch('http://localhost:5228/api/customer/getById?id=' + tokenId, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`
        }
    }).then(async (response) => {
        const data = await response.json();

        var userDiv = document.getElementById('user-details');
        userDiv.innerHTML = '';

        if (response.ok) {
            userDiv.innerHTML = `
                <li class="list-group-item"><strong>Name : </strong>${data.name}</li>
                <li class="list-group-item"><strong>Date Of Birth : </strong>${new Date(data.dateOfBirth).toLocaleDateString()}</li>
                <li class="list-group-item"><strong>Email ID : </strong>${data.email}</li>
                <li class="list-group-item"><strong>Phone : </strong><span id="phone-span">${data.phone}</span>
                    <i class="bi bi-pencil-square" id="edit-phone" style="cursor:pointer; margin-left: 10px; float:right;"></i>
                    <input type="number" maxlength="10" minlength="10" id="phone-input" value="${data.phone}" class="form-control d-none my-2">
                    <button class="btn btn-success m-1 btn-sm d-none" id="save-changes">Save</button>
                    <button class="btn btn-danger m-1 btn-sm d-none" id="cancel-changes">Cancel</button>
                </li>
                <li class="list-group-item"><strong>Loyalty Points : </strong>${data.loyaltyPoints}</li>
            `;

            var editIcon = document.getElementById('edit-phone');
            editIcon.addEventListener('click', function () {
                editPhone(data.email, data.phone);
            });
        } else {
            userDiv.innerHTML = `${data.message}`;
        }
    }).catch(error => {
        console.error(error);
    });
}

function editPhone(email, currentPhone) {
    var editIcon = document.getElementById('edit-phone');
    var saveBtn = document.getElementById('save-changes');
    var phoneInput = document.getElementById('phone-input');
    var phoneSpan = document.getElementById('phone-span');
    var cancelBtn = document.getElementById('cancel-changes');

    editIcon.classList.add('d-none');
    phoneSpan.innerHTML = '';
    saveBtn.classList.remove('d-none');
    phoneInput.classList.remove('d-none');
    cancelBtn.classList.remove('d-none');

    saveBtn.addEventListener('click', function () {
        
        updatePhone(email);
    });

    cancelBtn.addEventListener('click', function () {
        editIcon.classList.remove('d-none');
        saveBtn.classList.add('d-none');
        phoneInput.classList.add('d-none');
        cancelBtn.classList.add('d-none');
        phoneSpan.innerHTML = `${currentPhone}`;
    });
}

function updatePhone(email) {
    var phoneInput = document.getElementById('phone-input');
    var newPhone = phoneInput.value;
    if (!validatePhoneNumber(newPhone)) {
        newToast("bg-danger", "Invalid phone number. Please enter a valid 10-digit phone number.");
        return;
    }

    fetch("http://localhost:5228/api/customer/updatePhone", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify({
            email: email,
            phone: newPhone
        })
    }).then(async (response) => {
        var data = await response.json();

        if (response.ok) {
            var phoneSpan = document.getElementById('phone-span');
            var editIcon = document.getElementById('edit-phone');
            var phoneInput = document.getElementById('phone-input');
            var saveBtn = document.getElementById('save-changes');

            phoneSpan.innerHTML = `${data.phone}`;
            editIcon.classList.remove('d-none');
            phoneInput.classList.add('d-none');
            saveBtn.classList.add('d-none');

            newToast("bg-success", "Phone updated successfully.");
        } else {
            newToast("bg-danger", `${data.message}`);
        }
    }).catch(error => {
        console.error(error);
    });
}

function validatePhoneNumber(phone) {
    const phoneRegex = /^[0-9]{10}$/;
    return phoneRegex.test(phone);
}