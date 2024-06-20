AOS.init({ duration: 1500 });

var count = 0;
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

    displayOrders();
    
})

function displayOrders() {
    fetch('http://localhost:5228/api/orders/getOrderByCustomerId?customerId='+tokenId, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`
        }
    }).then(async (response) => {
        const data = await response.json();
        console.log(response);
        console.log(data);

        var orderDiv = document.getElementById('accordionOrders');
        orderDiv.innerHTML = '';

        if(response.status != 200) {
            orderDiv.innerHTML = `${data.message}`;
            return;
        }
        

        data.forEach(element => {
            var orderItem = document.createElement('div');
            orderItem.className = 'accordion-item';
            var orderList = document.createElement('ul');

            element.orderItems.forEach(item => {    
                var listItem = document.createElement('li');
                listItem.textContent = item.productName;
                orderList.appendChild(listItem);
            });
            
            var orderBody=``;
            console.log(element.orderStatus);
            if(element.orderStatus == 'Placed'){
                orderBody = `
                    <h2 class="accordion-header">
                                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#order${count}" aria-expanded="true" aria-controls="order${count}">
                                    Order #${element.orderId}
                                </button>
                    </h2>
                    <div id="order${count}" class="accordion-collapse collapse" data-bs-parent="#accordionOrders">
                        <div class="accordion-body">
                            <ul>
                                <li><strong>Order ID:</strong>${element.orderId}</li>
                                <li><strong>Order Items:</strong>
                                    <ul>
                                        ${orderList.innerHTML}
                                    </ul>
                                </li>
                                <li><strong>Order Status:</strong>${element.orderStatus}</li>
                                <li><strong>Total Price:</strong>${element.totalOrderPrice}</li>
                                <button class="btn btn-danger my-3" id="cancel-btn">Cancel</button>
                            </ul>
                        </div>
                    </div>`;
            }
            else{
                orderBody = `
                    <h2 class="accordion-header">
                                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#order${count}" aria-expanded="true" aria-controls="order${count}">
                                    Order #${element.orderId}
                                </button>
                    </h2>
                    <div id="order${count}" class="accordion-collapse collapse" data-bs-parent="#accordionOrders">
                        <div class="accordion-body">
                            <ul>
                                <li><strong>Order ID:</strong>${element.orderId}</li>
                                <li><strong>Order Items:</strong>
                                    <ul>
                                        ${orderList.innerHTML}
                                    </ul>
                                </li>
                                <li><strong>Order Status:</strong>${element.orderStatus}</li>
                                <li><strong>Total Price:</strong>${element.totalOrderPrice}</li>
                            </ul>
                        </div>
                    </div>`;
            }
            
            orderItem.innerHTML = orderBody;
            orderDiv.appendChild(orderItem);
            count++;
        });

    }).catch(error => {
        console.error(error);
    })
}