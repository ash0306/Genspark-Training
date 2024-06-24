var typed = new Typed("#cart-typed", {
    strings: ["Cart Details"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});

var token = sessionStorage.getItem('customerToken');
const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
var total = 0;

async function getUserLoyaltyPoints() {
    const response = await fetch("http://localhost:5228/api/customer/getById?id="+tokenId,{
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    })

    const data = await response.json();
    return data.loyaltyPoints;
}

const switchCheck = document.getElementById('switchCheck');
switchCheck.addEventListener('click',function(){
    if(switchCheck.checked){
        const cartDiscountContainer = document.getElementById('cart-discount');
        
        getUserLoyaltyPoints()
        .then( userPoints => {
            console.log(userPoints);
            if(userPoints < 100){
                newToast("bg-danger","You have less than 100 points. Need to have atleast a hundred points to use loyalty points");
                switchCheck.checked = false;
                return;
            }

            var newTotal = 0;
            if(userPoints > total){
                newTotal = 0;
            }
            else{
                newTotal = total - userPoints;
            }
            var cartTotal = document.getElementById('cart-total');

            cartDiscountContainer.innerHTML = `
            <span>Discount</span>
            <span>- Rs.${userPoints}</span>
            `;

            cartTotal.innerHTML = `
            <span>Total</span>
            <span>Rs.${newTotal}</span>
            `;
        })
    }
    else{
        const cartDiscountContainer = document.getElementById('cart-discount');
        const cartTotal = document.getElementById('cart-total');
        
        cartDiscountContainer.innerHTML =  ``;
        cartTotal.innerHTML = `
        <span>Total</span>
        <span>Rs.${total}</span>
        `;
    }
})

document.addEventListener('DOMContentLoaded', function() {
    
    AOS.init({ duration: 1500 });
    
    if (sessionStorage.getItem("customerToken") == null) {
        // console.log("customerToken is null");
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        });
        return;
    }

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

    cart.forEach((item) => {
        const itemRow = document.createElement('div');
        itemRow.classList.add('d-flex', 'justify-content-between', 'border-bottom', 'pb-2', 'mb-2');
        itemRow.innerHTML = `
            <span><button class="bg-danger border border-none rounded text-white m-2" onclick="removeItem('${item.name}')"><i class="bi bi-trash-fill"></i></button>${item.name}</span>
            <span>Rs.${item.price}</span>
        `;
        cartItemsContainer.appendChild(itemRow);

        total += parseFloat(item.price);
    });

    cartTotalContainer.innerHTML = `
        <span>Total</span>
        <span>Rs.${total}</span>
    `;
}

function placeOrder(tokenId, token){
    const form = document.getElementById('orderForm');
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