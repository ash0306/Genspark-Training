var token = sessionStorage.getItem('employeeToken');

var placedTyped = new Typed("#typed-placed", {
    strings: ["Placed Orders"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
}); 
var prepareTyped = new Typed("#typed-prepare", {
    strings: ["Prepared Orders"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
}); 
var placedTyped = new Typed("#typed-ready", {
    strings: ["Ready Orders"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
}); 

document.addEventListener('DOMContentLoaded', function() {
    displayOrders();
});

function displayOrders() {
    fetch("http://localhost:5228/api/orders/pendingOrders", {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {
        const data = await response.json();

        var placedDiv = document.getElementById('placedOrder');
        placedDiv.innerHTML = '';
        var preparingDiv = document.getElementById('preparingOrder');
        preparingDiv.innerHTML = '';
        var readyDiv = document.getElementById('readyOrder');
        readyDiv.innerHTML = '';

        data.forEach(element => {
            var orderList = document.createElement('ul');

            element.orderItems.forEach(item => {    
                var listItem = document.createElement('li');
                listItem.textContent = item.productName;
                orderList.appendChild(listItem);
            });

            const card = document.createElement('div');
            card.classList.add('card', 'col-md-3');

            if (element.status === 'Placed') {
                card.id = 'placed-order';
                card.innerHTML = `
                    <div class="card-body h-auto d-flex flex-column justify-content-between">
                        <div>
                            <h5 class="card-title">Order #${element.id}</h5>
                            <p class="card-text">
                                <ul>
                                    ${orderList.innerHTML}
                                </ul>
                            </p>
                        </div>
                        <a href="#" class="btn btn-dark" onclick="updateOrderStatus(${element.id}, 'Preparing')">Move to preparing</a>
                    </div>
                `;
                placedDiv.appendChild(card);
            } 
            else if (element.status === 'Preparing') {
                card.id = 'preparing-order';
                card.innerHTML = `
                    <div class="card-body h-auto d-flex flex-column justify-content-between">
                        <div>
                            <h5 class="card-title">Order #${element.id}</h5>
                            <p class="card-text">
                                <ul>
                                    ${orderList.innerHTML}
                                </ul>
                            </p>
                        </div>
                        <a href="#" class="btn btn-dark" onclick="updateOrderStatus(${element.id}, 'Ready')">Move to ready</a>
                    </div>
                `;
                preparingDiv.appendChild(card);
            } 
            else if (element.status === 'Ready') {
                card.id = 'ready-order';
                card.innerHTML = `
                    <div class="card-body h-auto d-flex flex-column justify-column-between">
                        <h5 class="card-title">Order #${element.id}</h5>
                        <p class="card-text">
                            <ul>
                                ${orderList.innerHTML}
                            </ul>
                        </p>
                        <a href="#" class="btn btn-dark" onclick="updateOrderStatus(${element.id}, 'Completed')">Move to completed</a>
                    </div>
                `;
                readyDiv.appendChild(card);
            }
        });
    }).catch(error => {
        console.error(error);
    });
}

function updateOrderStatus(orderId, orderStatus) {
    fetch("http://localhost:5228/api/orders/updateOrderStatus", {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`
        },
        body: JSON.stringify({
            orderId: parseInt(orderId),
            status: orderStatus
        })
    }).then(async (response) => {
        var data = await response.json();

        if (response.status === 200) {
            newToast("bg-success", "Updated order status successfully.");
            displayOrders();
        }
    }).catch(error => {
        console.error(error);
    });
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