AOS.init({ duration: 1500 });

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
            console.log(response);
            var data = await response.json();
            console.log(data);

            var registerBtnRow = document.getElementById("register-btn");

            if (response.status == 200) {
                var successMessage = document.createElement("p");
                successMessage.textContent = "Registration successful. Redirecting ...";
                successMessage.style.color = "green";
                registerBtnRow.appendChild(successMessage);

                setTimeout(() => {
                    window.location.href = "./Login.html";
                }, 3000);
            }
            else{
                var errorMessage = document.createElement("p");
                errorMessage.textContent = data.message;
                errorMessage.style.color = "red";
                registerBtnRow.appendChild(errorMessage);
            }
        });
    });
})