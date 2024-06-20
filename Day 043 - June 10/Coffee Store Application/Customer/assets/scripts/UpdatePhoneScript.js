var token = sessionStorage.getItem('customerToken');
const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
const tokenEmail = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];

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