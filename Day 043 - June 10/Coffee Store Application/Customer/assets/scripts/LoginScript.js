AOS.init({ duration: 1500 });

document.addEventListener("DOMContentLoaded", function (){

    // Check if already logged in
    if(sessionStorage.getItem("customerToken")){
        var alreadyLoggedInModal = new bootstrap.Modal(document.getElementById('alreadyLoggedInModal'));
        alreadyLoggedInModal.show();

        // Log out button functionality
        document.getElementById("logoutBtn").addEventListener("click", function() {
            sessionStorage.removeItem("customerToken");
            alreadyLoggedInModal.hide();
        });

        document.getElementById("modal-close").addEventListener("click", function() {
            window.location.href = './index.html';
        })
    }

    login();
})

function login(){
    const form = document.querySelector("form.needs-validation");

    
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;

        fetch("http://localhost:5228/api/customer/login",{
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                email: email,
                password:  password
            })
        }).then(async (response) => {
            console.log(response);
            var data = await response.json();
            // console.log(data);
            sessionStorage.setItem("customerToken", `${data.token}`);

            var loginBtnRow = document.getElementById("login-btn");

            if (response.status == 200) {
                var successMessage = document.createElement("p");
                successMessage.textContent = "Login successful. Redirecting ...";
                successMessage.style.color = "green";
                loginBtnRow.appendChild(successMessage);

                setTimeout(() => {
                    window.location.href = "./index.html";
                }, 3000);
            } else {
                var invalidLoginModal = new bootstrap.Modal(document.getElementById('invalidLoginModal'));
                invalidLoginModal.show();
            }
        });
    });
}