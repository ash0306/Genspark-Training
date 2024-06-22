AOS.init({ duration: 1500 });

var token = sessionStorage.getItem('customerToken');

const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

document.addEventListener('DOMContentLoaded', function(){

    if(sessionStorage.getItem("customerToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }
    
    displayUserDetails();
})

function displayUserDetails(){
    fetch('http://localhost:5228/api/customer/getById?id='+tokenId, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`
        }
    }).then(async (response) => {
        const data = await response.json();
        // console.log(data);

        var userDiv = document.getElementById('user-details');
        userDiv.innerHTML = '';

        if(response.ok) {
            userDiv.innerHTML = `
            <li class="list-group-item"><strong>Name : </strong>${data.name}</li>
            <li class="list-group-item"><strong>Date Of Birth : </strong>${new Date(data.dateOfBirth).toLocaleDateString()}</li>
            <li class="list-group-item"><strong>Email ID : </strong>${data.email}</li>
            <li class="list-group-item"><strong>Phone : </strong>${data.phone}</li>
            <li class="list-group-item"><strong>Loyalty Points : </strong>${data.loyaltyPoints}</li>
        `;
        return;
        }
        
        userDiv.innerHTML = `${data.message}`;
        
    }).catch(error => {
        console.error(error);
    })
}

function redirect(){
    window.location.href = './UpdatePhone.html';
}

function updatePhone(){
    const form = document.querySelector("form.needs-validation");
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        const email = document.getElementById("email").value;
        const phone = document.getElementById("phone").value;

        if(email !== tokenEmail){
            var invalidEmailModal = new bootstrap.Modal(document.getElementById('invalidEmailModal'));
            invalidEmailModal.show();
        }

        fetch("http://localhost:5228/api/customer/updatePhone",{
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify({
                email: email,
                phone: phone  
            })
        }).then(async (response) => {
            console.log(response);
            var data = await response.json();

            var updateBtnRow = document.getElementById("update-btn");

            if (response.status == 200) {
                var successMessage = document.createElement("p");
                successMessage.textContent = "Update successful. Redirecting ...";
                successMessage.style.color = "green";
                updateBtnRow.appendChild(successMessage);

                setTimeout(() => {
                    window.location.href = "./User.html";
                }, 2000);
            } else {
                var invalidEmailModal = new bootstrap.Modal(document.getElementById('invalidEmailModal'));
                invalidEmailModal.show();
            }
        });
    });
}