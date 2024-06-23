var token = sessionStorage.getItem("employeeToken");
var submitBtn = document.getElementById("submit-btn");

function updatePoints(){
    const form = document.getElementById("pointsForm");

    form.addEventListener("submit", function (event) {
        event.preventDefault();
        var email = document.getElementById("email").value;
        var points = document.getElementById("points").value;  

        fetch("http://localhost:5228/api/customer/updateLoyaltyPoints",{
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify({
                email: email,
                loyaltyPoints: parseInt(points)
            })
        }).then( async (response) => {
            var data = await response.json();

            if(response.status === 200) {
                var successMessage = document.createElement("p");
                successMessage.textContent = "Customer loyalty points updated successfully";
                successMessage.style.color = "green";
                submitBtn.appendChild(successMessage);

                window.setTimeout(() => {
                    window.location.href = "./Customers.html";
                },2000);
            }
            else{
                var errorMessage = document.createElement("p");
                errorMessage.textContent = "Error updating loyalty points. "+data.message;
                errorMessage.style.color = "red";
                submitBtn.appendChild(errorMessage);
            }
        })
    });
}