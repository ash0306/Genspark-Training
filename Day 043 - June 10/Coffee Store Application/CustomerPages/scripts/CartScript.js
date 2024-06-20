document.addEventListener('DOMContentLoaded', function() {
    
    AOS.init({ duration: 1500 });
    
    if (sessionStorage.getItem("customerToken") == null) {
        console.log("customerToken is null");
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        });
        return;
    }

    var token = sessionStorage.getItem('customerToken');
    const tokenArray = token.split('.');
    const tokenPayload = JSON.parse(atob(tokenArray[1]));
    const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

    displayCartItems();
    placeOrder(tokenId, token);
});

function displayCartItems() {
    const cartItemsContainer = document.getElementById('cart-items');
    const cartTotalContainer = document.getElementById('cart-total');

    const cart = JSON.parse(sessionStorage.getItem('cart'));
    if (!cart || cart.length <= 0) {
        cartItemsContainer.innerHTML = '<div class="fw-bold h4">Cart is empty!! Add products to place your order.</div><br>';
        return;
    }

    cartItemsContainer.innerHTML = '';
    cartTotalContainer.innerHTML = '';

    let total = 0;

    cart.forEach((item) => {
        const itemRow = document.createElement('div');
        itemRow.classList.add('d-flex', 'justify-content-between', 'border-bottom', 'pb-2', 'mb-2');
        itemRow.innerHTML = `
            <span>${item.name}</span>
            <span>$${item.price}</span>
        `;
        cartItemsContainer.appendChild(itemRow);

        total += parseFloat(item.price);
    });

    cartTotalContainer.innerHTML = `
        <span>Total</span>
        <span>$${total}</span>
    `;
}

function placeOrder(tokenId, token){
    console.log("placeOrder");
    const form = document.getElementById('orderForm');
    const switchCheck = document.getElementById('switchCheck');
    const cart = JSON.parse(sessionStorage.getItem('cart'));
    
    form.addEventListener("submit", function (event) {
        event.preventDefault();

        const customerId = tokenId;
        const useLoyaltyPoints = switchCheck.checked;
        const orderItems = cart.map(item => ({ productName: item.name }));
        
        fetch("http://localhost:5228/api/orders/addOrder", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify({
                customerId: customerId,
                useLoyaltyPoints: useLoyaltyPoints,
                orderItems: orderItems
            })
        }).then(async (response) => {
            console.log(response);
            var data = await response.json();
            console.log(data);

            var resultDiv = document.getElementById('order-result');
            resultDiv.innerHTML = '';

            if (response.status == 200) {
                sessionStorage.removeItem('cart');
                var successMessage = document.createElement("p");
                successMessage.textContent = `Order was successfully placed with ID ${data.id}. Redirecting ...`;
                successMessage.style.color = "green";
                resultDiv.appendChild(successMessage);

                setTimeout(() => {
                    window.location.href = "./Orders.html";
                }, 3000);
            } else {
                var errorMessage = document.createElement("p");
                errorMessage.textContent = data.message;
                errorMessage.style.color = "red";
                resultDiv.appendChild(errorMessage);
            }
        }).catch(error => {
            console.error('Error:', error);
            var resultDiv = document.getElementById('order-result');
            resultDiv.innerHTML = '';

            var errorMessage = document.createElement("p");
            errorMessage.textContent = 'An error occurred while placing the order. Please try again.';
            errorMessage.style.color = "red";
            resultDiv.appendChild(errorMessage);
        });
    });
}

function removeItem(itemName) {
    console.log("Removing item: ", itemName);
    let cart = JSON.parse(sessionStorage.getItem('cart'));
    cart = cart.filter(cartItem => cartItem.name !== itemName);
    sessionStorage.setItem('cart', JSON.stringify(cart));
    displayCartItems();
}
