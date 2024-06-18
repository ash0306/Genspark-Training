document.addEventListener('DOMContentLoaded', function () {

    if(sessionStorage.getItem("employeeToken")==null){
        var notLoggedInModal = new bootstrap.Modal(document.getElementById('notLoggedInModal'));
        notLoggedInModal.show();

        document.getElementById('login-btn').addEventListener('click', function(){
            window.location.href = './Login.html';
        })
        return;
    }

    var token = sessionStorage.getItem('employeeToken');

    fetch('http://localhost:5228/api/product/getAllProducts', {
        method: 'GET',
        headers: {
            Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIxMiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJEb21pbmljIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZG9taW5pY0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJCYXJpc3RhIiwiZXhwIjoxNzE4ODgwNDUxfQ.L8GXfnw_e2tXyFz7MNSjSCh5jNb-1h6D3aq0DdXSqoY`
        }
    }).then(async (response) => {
        console.log(response);
        var data = await response.json();
        console.log(data);

        const tableBody = document.getElementsByTagName('tbody')[0];
        tableBody.innerHTML = ''; 
        data.forEach(element => {
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

    }).catch(error => {
        console.error(error);
    });
});