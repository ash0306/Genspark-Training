var token = sessionStorage.getItem('employeeToken');

var typed = new Typed("#typed-element", {
    strings: ["Product Details"],
    typeSpeed: 50,
    cursorChar: "",
    loop: false
});

document.addEventListener('DOMContentLoaded', function () {

    getAllProducts();

    const searchInput = document.getElementById('search-input');
    searchInput.addEventListener('input', async function() {
        const productName = this.value.trim();
        if (productName.length === 0) {
            getAllProducts();
            return;
        }
        searchResults(productName);
    });
});

function getAllProducts(){
    fetch('http://localhost:5228/api/product/getAllProducts', {
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async (response) => {
        
        var data = await response.json();

        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 
        data.forEach(element => {
            const row = addRow(element);
            tableBody.appendChild(row);
        });

    }).catch(error => {
        console.error(error);
    });
}

function addRow(element){
    const row = document.createElement('tr');
    let statusColor = '';
    if (element.status === 'Available') {
        statusColor = 'text-success';
    } else if (element.status === 'Unavailable') {
        statusColor = 'text-danger';
    } else {
        statusColor = 'text-warning';
    }
    
    row.innerHTML = `
        <td>${element.name}</td>
        <td><img src="${element.image}"></td>
        <td>${element.description}</td>
        <td>${element.category}</td>
        <td>${element.price}</td>
        <td class="${statusColor}">${element.status}</td>
        <td>${element.stock}</td>`;

    return row;
}
function searchResults(productName){
    fetch('http://localhost:5228/api/product/getAllProducts',{
        method: 'GET',
        headers: {
            Authorization: `Bearer ${token}`
        }
    }).then(async(response)=>{
        const data = await response.json();
        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 

        var filteredResults = data.filter(element => element.name.toLowerCase().includes(productName.toLowerCase()));

        filteredResults.forEach(element => {
            const row = document.createElement('tr');

            let statusColor = '';
            if (element.status === 'Available') {
                statusColor = 'text-success';
            } else if (element.status === 'Unavailable') {
                statusColor = 'text-danger';
            } else {
                statusColor = 'text-warning';
            }
            
            row.innerHTML = `
                <td>${element.name}</td>
                <td><img src="${element.image}"></td>
                <td>${element.description}</td>
                <td>${element.category}</td>
                <td>${element.price}</td>
                <td class="${statusColor}">${element.status}</td>
                <td>${element.stock}</td>`;
            tableBody.appendChild(row);
        });
    }).catch(error => console.log(error));
}