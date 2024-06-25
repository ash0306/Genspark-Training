var token = sessionStorage.getItem("employeeToken");

var nameInput = document.getElementById("name");
var statusInput = document.getElementById("status");
var stockInput = document.getElementById("stock");
var priceInput = document.getElementById("price");

var submitBtn = document.getElementById("submit-btn");


document.addEventListener("DOMContentLoaded", function () {
    statusInput.addEventListener("change", function () {
        if(statusInput.value === "Available"){
            stockInput.disabled = false;
        }
        else{
            stockInput.disabled = true;
        }
    });
});

function updateProduct(){
    const form = document.getElementById("productForm");

    form.addEventListener("submit", function (event) {
        event.preventDefault();

        if(statusInput.value === "" && stockInput.value === "" && priceInput.value === ""){
            form.classList.add('is-invalid');
            form.classList.remove('is-valid');
        }
        else{
            if(stockInput.value && statusInput.value === ""){
                updateStock(nameInput.value, stockInput.value);
            }
            if(statusInput.value){
                updateStatus(nameInput.value, statusInput.value, stockInput.value);
            }
            if(priceInput.value){
                updatePrice(nameInput.value, priceInput.value);
            }

            newToast("bg-success", "Update successful. Redirecting...");
            
            window.setTimeout(() => {
                window.location.href = "./Products.html";
            },2000);
        }
    });
}

function updateStock(name, stock) {
    return fetch('http://localhost:5228/api/product/updateStock', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({
            name: name,
            stock: parseInt(stock)
        })
    }).then(response => {
        var data = response.json();
        if(response.status === 200) {
            var successMessage = document.createElement("p");
            successMessage.textContent = "Product stock updated successfully";
            successMessage.style.color = "green";
            submitBtn.appendChild(successMessage);
        }
        else{
            var errorMessage = document.createElement("p");
            errorMessage.textContent = "Error updating product stock. "+data.message;
            errorMessage.style.color = "red";
            submitBtn.appendChild(errorMessage);
        }
    });
}

function updateStatus(name, status, stock) {
    return fetch('http://localhost:5228/api/product/updateStatus', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({
            name: name,
            status: status,
            stock: stock ? parseInt(stock) : undefined
        })
    }).then(response => {
        var data = response.json();
        if(response.status === 200) {
            var successMessage = document.createElement("p");
            successMessage.textContent = "Product status updated successfully";
            successMessage.style.color = "green";
            submitBtn.appendChild(successMessage);
        }
        else{
            var errorMessage = document.createElement("p");
            errorMessage.textContent = "Error updating product status. "+data.message;
            errorMessage.style.color = "red";
            submitBtn.appendChild(errorMessage);
        }
    });
}

function updatePrice(name, price) {
    return fetch('http://localhost:5228/api/product/updatePrice', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({
            name: name,
            price: parseFloat(price)
        })
    }).then(response => {
        var data = response.json();
        if(response.status === 200) {
            var successMessage = document.createElement("p");
            successMessage.textContent = "Product price updated successfully";
            successMessage.style.color = "green";
            submitBtn.appendChild(successMessage);
        }
        else{
            var errorMessage = document.createElement("p");
            errorMessage.textContent = "Error updating product price. "+data.message;
            errorMessage.style.color = "red";
            submitBtn.appendChild(errorMessage);
        }
    });
}