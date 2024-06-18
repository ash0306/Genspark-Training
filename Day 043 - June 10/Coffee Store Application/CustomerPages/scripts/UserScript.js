AOS.init({ duration: 1500 });

document.addEventListener('DOMContentLoaded', function(){

    if(sessionStorage.getItem("customerToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }

    var token = sessionStorage.getItem('customerToken');

    const tokenArray = token.split('.');
    const tokenPayload = JSON.parse(atob(tokenArray[1]));
    const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    // console.log(tokenId);
    
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
})