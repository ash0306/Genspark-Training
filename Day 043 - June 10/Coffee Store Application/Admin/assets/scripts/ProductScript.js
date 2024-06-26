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
        addDataTable();
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

function addDataTable() {
    const table = $("#table-custom").DataTable({
        columns: [null, null, null, null, null, null, null],
        pagingType: "full_numbers",
        pageLength: 5,
        language: {
            paginate: {
            previous: '<span><i class="bi bi-chevron-left"></i></span>',
            next: '<span><i class="bi bi-chevron-right"></i></span>',
            first: '<span><i class="bi bi-chevron-bar-left"></i></span>',
            last: '<span><i class="bi bi-chevron-bar-right"></i></span>',
            },
            lengthMenu:
            'Display <select class="form-control input-sm">' +
            '<option value="5">5</option>' +
            '<option value="10">10</option>' +
            '<option value="15">15</option>' +
            '<option value="20">20</option>' +
            '<option value="25">25</option>' +
            '<option value="-1">All</option>' +
            "</select> results",
        },
    });

    table.draw();
}