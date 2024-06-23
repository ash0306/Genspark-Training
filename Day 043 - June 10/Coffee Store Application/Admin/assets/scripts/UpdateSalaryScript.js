var token = sessionStorage.getItem("employeeToken");
var submitBtn = document.getElementById("submit-btn");

function updateSalary(){
    const form = document.getElementById("salaryForm");

    form.addEventListener("submit", function(event){

        event.preventDefault();
        var id = document.getElementById("id").value;
        var salary = document.getElementById("salary").value;

        fetch("http://localhost:5228/api/employee/updateSalary",{
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify({
                employeeId: parseInt(id),
                employeeSalary: salary
            })
        }).then(async(response) => {
            var data = await response.json();
            // console.log(data);

            if(response.status === 200) {
                var successMessage = document.createElement("p");
                successMessage.textContent = "Salary updated successfully. Redirecting...";
                successMessage.style.color = "green";
                submitBtn.appendChild(successMessage);

                window.setTimeout(() => {
                    window.location.href = "./Employees.html";
                },2000);
            }
            else{
                var errorMessage = document.createElement("p");
                errorMessage.textContent = "Error while updating salary. "+data.message;
                errorMessage.style.color = "red";
                submitBtn.appendChild(errorMessage);
            }
        })
    })
}