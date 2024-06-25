AOS.init({ duration: 1500 });

function isValidAge() {
    const dobInput = document.getElementById('dob');
    const dobValue = dobInput.value;
    const dobDate = new Date(dobValue);
    const today = new Date();

    let age = today.getFullYear() - dobDate.getFullYear();
    const monthDifference = today.getMonth() - dobDate.getMonth();
    const dayDifference = today.getDate() - dobDate.getDate();

    if (monthDifference < 0 || (monthDifference === 0 && dayDifference < 0)) {
        age--;
    }

    if (age < 18) {
        dobInput.setCustomValidity("You must be at least 18 years old.");
        dobInput.classList.add('is-invalid');
        return false;
    } else {
        dobInput.setCustomValidity("");
        dobInput.classList.remove('is-invalid');
        dobInput.classList.add('is-valid');
        return true;
    }
}

// Real-time validation for Date of Birth
document.getElementById('dob').addEventListener('input', function () {
    isValidAge();
});

document.addEventListener("DOMContentLoaded", function (){
    const form = document.querySelector("form.needs-validation");

    form.addEventListener("submit", function (event) {
        event.preventDefault();

        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;
        const name = document.getElementById("name").value;
        const dob = document.getElementById("dob").value;
        const phone = document.getElementById("phone").value;

        fetch("http://localhost:5228/api/customer/register",{
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                email: email,
                password:  password,
                name: name,
                dob: dob,
                phone: phone
            })
        }).then(async (response) => {
            var data = await response.json();

            if (response.status == 200) {
                newToast("bg-success","Registered successfully! Redirecting...")

                setTimeout(() => {
                    window.location.href = "./Login.html";
                }, 3000);
            }
            else{
                newToast("bg-danger", "Registration failed. "+data.message);
            }
        });
    });
})

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