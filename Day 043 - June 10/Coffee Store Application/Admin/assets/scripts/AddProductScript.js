var nameInput = document.getElementById('name');
var descriptionInput = document.getElementById('description');
var categoryInput = document.getElementById('category');
var statusInput = document.getElementById('status');
var priceInput = document.getElementById('price');
var stockInput = document.getElementById('stock');
var imageInput = document.getElementById('image');

var token = sessionStorage.getItem('employeeToken');

document.addEventListener("DOMContentLoaded", function(){
    statusInput.addEventListener("change", function(){
        if(statusInput.value === "Available"){
            stockInput.disabled = false;
        }
        else{
            stockInput.disabled = true;
            stockInput.value = 0;
        }
    })
});


function newProduct(){
    const form = document.getElementById('newProductForm');

    form.addEventListener('submit', async function(event) {
        event.preventDefault();

        if(categoryInput.value == ""){
            categorySelect.classList.add('is-invalid');
            categorySelect.classList.remove('is-valid');
            event.stopPropagation();
        }
        if(statusInput.value == ""){
            statusSelect.classList.add('is-invalid');
            statusSelect.classList.remove('is-valid');
            event.stopPropagation();
        }

        fetch("http://localhost:5228/api/product/addProduct", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Authorization: `Bearer ${token}`
            },
            body: JSON.stringify({
                name: nameInput.value,
                description: descriptionInput.value,
                category: categoryInput.value,
                status: statusInput.value,
                price: parseInt(priceInput.value),
                stock: parseInt(stockInput.value),
                image: imageInput.value
            })
        }).then( async (response) => {
            var data = await response.json();
            console.log(data);

            var submitBtn = document.getElementById("submit-btn");
            if(response.status === 200) {
                var successMessage = document.createElement("p");
                successMessage.textContent = "Product added successfully";
                successMessage.style.color = "green";
                submitBtn.appendChild(successMessage);
                setTimeout(() => {
                    window.location.href = "./Products.html";
                }, 2000);
            }
            else{
                var errorMessage = document.createElement("p");
                errorMessage.textContent = data.message;
                errorMessage.style.color = "red";
                submitBtn.appendChild(errorMessage);
            }
        })
    });
}