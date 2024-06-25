AOS.init({ duration: 1500 });

document.addEventListener("DOMContentLoaded", function (){
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
            var data = await response.json();

            sessionStorage.setItem("customerToken", `${data.token}`);

            if (response.status == 200) {
                newToast("bg-success", "Login successful!! Redirecting...");

                setTimeout(() => {
                    window.location.href = "./index.html";
                }, 3000);
            } else {
                newToast("bg-danger", "Login Failed!! Invalid Email or Password.")
            }
        });
    });
}

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