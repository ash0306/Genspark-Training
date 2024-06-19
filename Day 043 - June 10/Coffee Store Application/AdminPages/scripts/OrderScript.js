document.addEventListener('DOMContentLoaded', function(){

    if(sessionStorage.getItem("employeeToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }

    var token = sessionStorage.getItem('employeeToken');

    fetch("http://localhost:5228/api/orders/pendingOrders", {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {

        const data = await response.json();
        console.log(data);

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

            if(element.status === 'Placed'){
                const card = document.createElement('div');
                card.classList.add('card', 'col-md-3');
                card.id = 'placed-order'
                card.innerHTML = `
                    <div class="card-body h-auto">
                        <h5 class="card-title">Order #${element.id}</h5>
                        <p class="card-text">
                            <ul>
                                ${orderList.innerHTML}
                            </ul>
                        </p>
                        <a href="#" class="btn btn-dark">Move to preparing</a>
                    </div>
                `;
                placedDiv.appendChild(card);
            }
            else if(element.status === 'Preparing'){
                const card = document.createElement('div');
                card.classList.add('card', 'col-md-3');
                card.id = 'preparing-order'
                card.innerHTML = `
                    <div class="card-body h-auto">
                        <h5 class="card-title">Order #${element.id}</h5>
                        <p class="card-text">
                            <ul>
                                ${orderList.innerHTML}
                            </ul>
                        </p>
                        <a href="#" class="btn btn-dark">Move to ready</a>
                    </div>
                `;
                preparingDiv.appendChild(card);
            }
            else if(element.status === 'Ready'){
                const card = document.createElement('div');
                card.classList.add('card', 'col-md-3');
                card.id ='ready-order'
                card.innerHTML = `
                    <div class="card-body h-auto">
                        <h5 class="card-title">Order #${element.id}</h5>
                        <p class="card-text">
                            <ul>
                                ${orderList.innerHTML}
                            </ul>
                        </p>
                        <a href="#" class="btn btn-dark">Move to completed</a>
                    </div>
                `;
                readyDiv.appendChild(card);
            }
        });
    }).catch(error =>{
        console.error(error);
    })
});