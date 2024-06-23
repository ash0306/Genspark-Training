var token = sessionStorage.getItem('employeeToken');

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
                    <div class="card-body h-auto">
                        <h5 class="card-title">Order #${element.id}</h5>
                        <p class="card-text">
                            <ul>
                                ${orderList.innerHTML}
                            </ul>
                        </p>
                        <a href="#" class="btn btn-dark" onclick="updateOrderStatus(${element.id}, 'Preparing')">Move to preparing</a>
                    </div>
                `;
                placedDiv.appendChild(card);
            } else if (element.status === 'Preparing') {
                card.id = 'preparing-order';
                card.innerHTML = `
                    <div class="card-body h-auto">
                        <h5 class="card-title">Order #${element.id}</h5>
                        <p class="card-text">
                            <ul>
                                ${orderList.innerHTML}
                            </ul>
                        </p>
                        <a href="#" class="btn btn-dark" onclick="updateOrderStatus(${element.id}, 'Ready')">Move to ready</a>
                    </div>
                `;
                preparingDiv.appendChild(card);
            } else if (element.status === 'Ready') {
                card.id = 'ready-order';
                card.innerHTML = `
                    <div class="card-body h-auto">
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
        console.log(data);

        if (response.status === 200) {
            displayOrders();
        }
    }).catch(error => {
        console.error(error);
    });
}
