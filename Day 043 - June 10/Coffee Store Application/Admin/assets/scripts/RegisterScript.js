AOS.init({ duration: 1500 });

const email = document.getElementById("email").value;
const password = document.getElementById("password").value;
const name = document.getElementById("name").value;
const dob = document.getElementById("dob").value;
const phone = document.getElementById("phone").value;
var role = '';

function isValidAge() {
    const dobInput = document.getElementById('dob');
    const dobValue = dobInput.value;
    const dobDate = new Date(dobValue);
    const today = new Date();

    // Calculate age
    let age = today.getFullYear() - dobDate.getFullYear();
    const monthDifference = today.getMonth() - dobDate.getMonth();
    const dayDifference = today.getDate() - dobDate.getDate();

    // Adjust age if the birthday hasn't occurred yet this year
    if (monthDifference < 0 || (monthDifference === 0 && dayDifference < 0)) {
        age--;
    }

    // Check if age is at least 18
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

document.addEventListener("DOMContentLoaded", function (){
    const form = document.querySelector("form.needs-validation");

    form.addEventListener("submit", function (event) {
        event.preventDefault();

        var radios = document.getElementsByName('flexRadioButton');
        for (var i = 0, length = radios.length; i < length; i++) {
            if (radios[i].checked) {
                role = radios[i].value;
                break;
            }
        }

        if(role == 'Admin'){
            var fetchUrl = "http://localhost:5228/api/employee/register/admin";
        }
        else if(role == 'Manager') {
            var fetchUrl = "http://localhost:5228/api/employee/register/manager";
        }
        else if(role == 'Barista'){
            var fetchUrl = "http://localhost:5228/api/employee/register/barista";
        }

        register(fetchUrl);
    });
})

function register(fetchUrl){
    fetch(`${fetchUrl}`,{
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
        // console.log(response);
        var data = await response.json();
        // console.log(data);

        if (response.status == 200) {
            newToast("bg-success", "Registration successful. Redirecting ...");

            setTimeout(() => {
                window.location.href = "./Login.html";
            }, 2000);
        }
        else{
            newToast("bg-danger", "Registration failed."+data.message);
        }
    });
}