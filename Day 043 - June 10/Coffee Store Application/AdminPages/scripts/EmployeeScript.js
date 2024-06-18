document.addEventListener('DOMContentLoaded', function () {

    var adminRole = '';

    var token = sessionStorage.getItem('employeeToken');
    const tokenArray = token.split('.');
    const tokenPayload = JSON.parse(atob(tokenArray[1]));
    console.log(tokenPayload);
    const tokenId = tokenPayload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    adminRole = tokenPayload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

    const adminDetailsDiv = document.getElementById('div-container');
    const employeeDetailsDiv = document.getElementById('div-content');
    
    if (adminRole == 'Admin') {
        adminDetailsDiv.style.display = 'block';
        employeeDetailsDiv.style.display = 'none';
        console.log("inside admin");
        fetch('http://localhost:5228/api/employee/getAll', {
            method: 'GET',
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(async (response) => {
            console.log(response);
            var data = await response.json();
            console.log(data);

            const tableBody = document.getElementsByTagName('tbody')[0];
            tableBody.innerHTML = ''; 
            data.forEach(element => {
                const row = document.createElement('tr');

                var statusColor = '';
                var buttonText = '';
                var buttonClass = '';
                if (element.status === 'Active') {
                    statusColor = 'text-success';
                    buttonText = 'Deactivate Employee';
                    buttonClass = 'btn btn-success';
                } else if (element.status === 'Inactive') {
                    statusColor = 'text-danger';
                    buttonText = 'Activate Employee';
                    buttonClass = 'btn btn-danger';
                }
                
                row.innerHTML = `
                    <td>${element.id}</td>
                    <td>${element.name}</td>
                    <td>${element.email}</td>
                    <td>${element.phone}</td>
                    <td>${element.dateOfBirth}</td>
                    <td>${element.salary}</td>
                    <td>${element.role}</td>
                    <td class="${statusColor}">${element.status}<br>
                    <button class="${buttonClass}">${buttonText}</button>
                    </td>`;
                tableBody.appendChild(row);
            });

        }).catch(error => {
            console.error(error);
        });
    } 
    else {
        adminDetailsDiv.style.display = 'none';
        employeeDetailsDiv.style.display = 'block';
        employeeDetailsDiv.style.zIndex = '100';
        console.log("inside employee");

        fetch('http://localhost:5228/api/employee/getById?id='+tokenId, {
            method: 'GET',
            headers: {
                Authorization: `Bearer ${token}`
            }
        }).then(async (response) => {
            const data = await response.json();
            console.log(data);

            var userDiv = document.getElementById('user-details');
            userDiv.innerHTML = '';

            if(response.ok) {
                userDiv.innerHTML = `
                <li class="list-group-item"><strong>Name : </strong>${data.name}</li>
                <li class="list-group-item"><strong>Date Of Birth : </strong>${new Date(data.dateOfBirth).toLocaleDateString()}</li>
                <li class="list-group-item"><strong>Email ID : </strong>${data.email}</li>
                <li class="list-group-item"><strong>Phone : </strong>${data.phone}</li>
                <li class="list-group-item"><strong>Salary : </strong>${data.salary}</li>
                <li class="list-group-item"><strong>Role : </strong>${data.role}</li>
            `;
            return;
            }
            
            userDiv.innerHTML = `${data.message}`;

        }).catch(error => {
            console.error(error);
        });
    }
});