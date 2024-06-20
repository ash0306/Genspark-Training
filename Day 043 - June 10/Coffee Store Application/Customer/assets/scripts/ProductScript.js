AOS.init({ duration: 1500 });
var token = sessionStorage.getItem('customerToken');

document.addEventListener('DOMContentLoaded', function () {

    if(token==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }

    getProducts();

});

function getProducts(){
    fetch('http://localhost:5228/api/product/menu', {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {
        console.log(response);
        var data = await response.json();
        var hotDrinks = data[0];
        var coldDrinks = data[1];
        var snacks = data[2];
        console.log(hotDrinks, coldDrinks, snacks);

        var hotDrinksDiv = document.getElementById('hot-drinks');
        hotDrinksDiv.innerHTML = '';
        var coldDrinksDiv = document.getElementById('cold-drinks');
        coldDrinksDiv.innerHTML = '';
        var snacksDiv = document.getElementById('snacks');
        snacksDiv.innerHTML = '';

        hotDrinks.forEach(item => {
            const productCard = createCard(item);
            hotDrinksDiv.appendChild(productCard);
        });

        coldDrinks.forEach(item => {
            const productCard = createCard(item);
            coldDrinksDiv.appendChild(productCard);
        });

        snacks.forEach(item => {
            const productCard = createCard(item);
            snacksDiv.appendChild(productCard);
        });

        // Select all cards after fetching and creating them
        const cards = document.querySelectorAll('.card');

        // Add click event listeners to each card image
        cards.forEach(card => {
            const cardImg = card.querySelector('.card-img-top');
            const cardBody = card.querySelector('.card-body');

            cardImg.addEventListener('click', function () {
                if (cardBody.style.display === 'none' || cardBody.style.display === '') {
                    cardImg.style.display = 'none';
                    cardBody.style.display = 'block';
                } else {
                    cardBody.style.display = 'none';
                    cardImg.style.display = 'block';
                }
            });

            cardBody.addEventListener('click', function () {
                if (cardImg.style.display === 'none' || cardImg.style.display === '') {
                    cardBody.style.display = 'none';
                    cardImg.style.display = 'block';
                } else {
                    cardImg.style.display = 'none';
                    cardBody.style.display = 'block';
                }
            });
        });
    }).catch(error => {
        console.error(error);
    });
}

function createCard(item) {
    const productCard = document.createElement('div');
    productCard.className = 'card col-md-3 shadow-lg';
    productCard.setAttribute('data-aos', 'flip-up');

    const cardContent = `
        <img src="${item.image}" class="card-img-top p-5 m-auto"  alt="${item.name}">
        <div class="card-body h-auto">
            <h5 class="card-title">${item.name}</h5>
            <p class="card-text">${item.description}</p>
            <p id="price"><strong>Rs.${item.price}</strong></p>
            <button class="btn btn-dark" onclick="addToCart('${item.name}','${item.price}')">Add to cart</button>
        </div>`;
    productCard.innerHTML = cardContent;
    return productCard;
}


function addToCart(name, price) {
        let cart = JSON.parse(sessionStorage.getItem('cart')) || [];
        
        let newItem = {
            name: name,
            price: price
        };
        
        // Add the new item to the cart
        cart.push(newItem);
        
        // Save the updated cart to session storage
        sessionStorage.setItem('cart', JSON.stringify(cart));
        
        console.log('Item added to cart:', newItem);
        console.log('Current cart:', cart);
    }