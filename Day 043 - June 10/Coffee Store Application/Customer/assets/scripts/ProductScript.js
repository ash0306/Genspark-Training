AOS.init({ duration: 1500 });
var token = sessionStorage.getItem('customerToken');

var hotDrinkTyped = new Typed("#hotDrinks-typed", {
    strings: ["Hot Drinks"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});
var coldDrinkTyped = new Typed("#coldDrinks-typed", {
    strings: ["Cold Drinks"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});
var snackTyped = new Typed("#snacks-typed", {
    strings: ["Snacks"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});

document.addEventListener('DOMContentLoaded', function () {
    getProducts();

});

function getProducts(){
    fetch('http://localhost:5228/api/product/menu', {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {
        var data = await response.json();
        var hotDrinks = data[0];
        var coldDrinks = data[1];
        var snacks = data[2];

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

            card.addEventListener('mouseover', function () {
                if (cardBody.style.display === 'none' || cardBody.style.display === '') {
                    cardImg.style.display = 'none';
                    cardBody.style.display = 'block';
                } else {
                    cardBody.style.display = 'none';
                    cardImg.style.display = 'block';
                }
            });

            card.addEventListener('mouseout', function () {
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
    productCard.className = 'card col-md-3 col-sm-5 shadow-lg p-0';
    productCard.setAttribute('data-aos', 'flip-up');

    const cardContent = `
        <img src="${item.image}" class="card-img-top rounded"  alt="${item.name}">
        <div class="card-body h-auto p-4">
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
        
        cart.push(newItem);
        sessionStorage.setItem('cart', JSON.stringify(cart));
        newToast("bg-success", "Item added successfully!");
}

function newToast(classBackground, message) {
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