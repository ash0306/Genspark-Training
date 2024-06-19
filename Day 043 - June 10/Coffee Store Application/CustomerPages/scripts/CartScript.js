AOS.init({ duration: 1500 });

var token = sessionStorage.getItem('customerToken');
const tokenArray = token.split('.');
const tokenPayload = JSON.parse(atob(tokenArray[1]));
const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

document.addEventListener('DOMContentLoaded', function(){
    if(sessionStorage.getItem("customerToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }

    displayCartItems();
    placeOrder();
})

function displayCartItems() {
    const cartItemsContainer = document.getElementById('cart-items');
    const cartPriceContainer = document.getElementById('cart-price');

    const cart = JSON.parse(sessionStorage.getItem('cart'));
    if(cart.length <=0){
        cartItemsContainer.innerHTML = '<li class="list-group-item">Cart is empty!! Add products to place your order.</li>';
        return;
    }

    cartItemsContainer.innerHTML = '';
    cartPriceContainer.innerHTML = '';

    let total = 0;

    cart.forEach((item) => {
        const itemElement = document.createElement('li');
        itemElement.className = 'list-group-item';
        itemElement.setAttribute('data-aos', 'flip-left');
        itemElement.textContent = `${item.name}`;

        cartItemsContainer.appendChild(itemElement);

        const priceElement = document.createElement('li');
        priceElement.className = 'list-group-item text-end';
        priceElement.setAttribute('data-aos', 'flip-left');
        priceElement.textContent = `Rs.${item.price}`;
        
        cartPriceContainer.appendChild(priceElement);

        total += parseFloat(item.price);
    });

    const totalItem = document.createElement('li');
    totalItem.className = 'list-group-item fw-bold text-end';
    totalItem.setAttribute('data-aos', 'flip-left');
    totalItem.textContent = `Total`;
    cartItemsContainer.appendChild(totalItem);

    const totalElement = document.createElement('li');
    totalElement.className = 'list-group-item fw-bold text-end';
    totalElement.id = 'total-price';
    totalElement.setAttribute('data-aos', 'flip-left');
    totalElement.textContent = `Rs.${total.toFixed(2)}`;
    cartPriceContainer.appendChild(totalElement);
}

// function placeOrder(){
//     const form = document.getElementById('orderForm');
//     const switchCheck = document.getElementById('switchCheck');
//     const cart = JSON.parse(sessionStorage.getItem('cart'));
    
//     form.addEventListener("submit", function (event) {
//         event.preventDefault();

//         const customerId = tokenId;
//         const useLoyaltyPoints = switchCheck.checked;
//         const itemNames = cart.map(item => item.name);
//         console.log(`id: ${customerId}, name: ${itemNames}, useLoyaltyPoints: ${useLoyaltyPoints}`)
        

//         fetch("http://localhost:5228/api/orders/addOrder",{
//             method: "POST",
//             headers: {
//                 "Content-Type": "application/json",
//                 "Authorization": `Bearer ${token}`
//             },
//             body: JSON.stringify({
//                 customerId: customerId,
//                 useLoyaltyPoints: useLoyaltyPoints,
//                 orderItems: itemNames
//             })
//         }).then(async (response) => {
//             console.log(response);
//             var data = await response.json();
//             console.log(data);

//             var resultDiv = document.getElementById('order-result');
            
//             if (response.status == 200) {
//                 var successMessage = document.createElement("p");
//                 successMessage.textContent = `Order was successfully placed with ID ${data.id}. Redirecting ...`;
//                 successMessage.style.color = "green";
//                 resultDiv.appendChild(successMessage);

//                 setTimeout(() => {
//                     window.location.href = "./Orders.html";
//                 }, 3000);
//             } else {
//                 var errorMessage = document.createElement("p");
//                 errorMessage.textContent = data.message;
//                 errorMessage.style.color = "red";
//                 resultDiv.appendChild(errorMessage);
//             }
//         });
//     });
// }